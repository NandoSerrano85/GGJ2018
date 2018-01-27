using UnityEngine;

public class RandomIdleAnimationBehaviour : StateMachineBehaviour
{
    [SerializeField] private string defaultIdleStateName;
    [SerializeField] private string parameterName;
    [SerializeField] private int [] animationStateIDs;
    [SerializeField] private float timeToWait;
    private float timeElapsed;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

	//}

	// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(stateInfo.IsName(defaultIdleStateName))
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed > timeToWait)
            {
                PlayNewRandomIdleAnimation(animator);
                timeElapsed = 0.0f;
            }
        }
	}

    private void PlayNewRandomIdleAnimation(Animator animator)
    {
        if (animationStateIDs.Length <= 0)
        {
            animator.SetInteger(parameterName, 0);
        }
        else
        {
            int index = Random.Range(0, animationStateIDs.Length);
            animator.SetInteger(parameterName, animationStateIDs[index]);
        }
    }

	// OnStateExit is called before OnStateExit is called on any state inside this state machine
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
	    if(!stateInfo.IsName(defaultIdleStateName))
        {
            animator.SetInteger(parameterName, 0);
        }
	}

	// OnStateMove is called before OnStateMove is called on any state inside this state machine
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

	// OnStateIK is called before OnStateIK is called on any state inside this state machine
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMachineEnter is called when entering a statemachine via its Entry Node
	//override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
        
	//}

	// OnStateMachineExit is called when exiting a statemachine via its Exit Node
	override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        timeElapsed = 0.0f;
    }
}
