using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallkToLettuce : StateMachineBehaviour
{

    // VARIABLES
    #region
    public Transform goalTransform;
    public Transform tortoiseTransform;
    public float speed;
    public float safeDistance = 2f;

    #endregion

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tortoiseTransform = animator.GetComponent<Transform>();
        goalTransform = changeMoveToTarget().transform;
        speed = Random.Range(.1f, 1f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (changeMoveToTarget() == null)
        {
            animator.SetInteger("TortoiseStateNumber", 1);
        }
        else
        {
            if (goalTransform == null)
            {

                goalTransform = changeMoveToTarget().transform;
            }
            if (goalTransform != null && Vector3.Distance(tortoiseTransform.position, goalTransform.position) >= safeDistance)
            {
                tortoiseTransform.position = Vector3.MoveTowards(tortoiseTransform.position, goalTransform.position, speed * Time.deltaTime);
                tortoiseTransform.LookAt(goalTransform);
            }
            goalTransform = changeMoveToTarget().transform;
        }

    }

    GameObject changeMoveToTarget()
    {
        // changes which object with target tag is chosen to move towards

        GameObject[] TargetArray = GameObject.FindGameObjectsWithTag("Goal");

        

        float currentClosestDistance = 100;
        GameObject closestTarget = null;

        foreach (GameObject g in TargetArray)
        {
            float distance = Vector3.Distance(tortoiseTransform.position, g.transform.position);

            if (currentClosestDistance == 100)
            {
                currentClosestDistance = distance;
                closestTarget = g;
            }
            else if (distance < currentClosestDistance)
            {
                currentClosestDistance = distance;
                closestTarget = g;
            }
        }

        //get any flipped tortoise in need of help
        GameObject[] tortoiseArray = GameObject.FindGameObjectsWithTag("tortoise");
        foreach(GameObject g in tortoiseArray)
        {
            
            if (g.GetComponent<Animator>().GetInteger("TortoiseStateNumber") == 3)
            {
                
                float distance = Vector3.Distance(tortoiseTransform.position, g.transform.position);
                
                if (distance < currentClosestDistance)
                {
                    currentClosestDistance = distance;
                    closestTarget = g;
                }
            }
        }

        return closestTarget;
    }

    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
