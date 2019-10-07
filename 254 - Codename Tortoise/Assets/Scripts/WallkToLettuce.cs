using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallkToLettuce : StateMachineBehaviour
{

    // VARIABLES
    #region
    public Transform goalTransform;
    public Transform tortoiseTransform;
    public float speed = 0.1f;
    public float safeDistance = 2f;

    #endregion

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tortoiseTransform = animator.GetComponent<Transform>();
        goalTransform = GameObject.FindGameObjectWithTag("Goal").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(tortoiseTransform.position, goalTransform.position) >= safeDistance)
        {
            tortoiseTransform.position = Vector3.MoveTowards(tortoiseTransform.position, goalTransform.position, speed * Time.deltaTime);
        }
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
