using Assets;
using UnityEngine;

public class BlockingCheck : StateMachineBehaviour
{
    IBlocking blockingScript = null;
    bool blocking = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(blockingScript == null)
        {
            blockingScript = animator.gameObject.GetComponent<IBlocking>();
        }

        if (blockingScript != null)
        {
            if (blocking
            && stateInfo.tagHash != blockingScript.TargetTagHash)
            {
                Debug.Log("We are transitioning away from a blocking state.");
                if (blockingScript.UnblockOnTransition)
                {
                    blockingScript.UnblockStuff(stateInfo.shortNameHash);
                    blocking = false;
                }
            }

            if (stateInfo.tagHash == blockingScript.TargetTagHash)
            {
                blockingScript.BlockStuff(stateInfo.shortNameHash);
                blocking = true;
            }
        }        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (blockingScript != null
            && stateInfo.tagHash == blockingScript.TargetTagHash)
        {
            blockingScript.UnblockStuff(stateInfo.shortNameHash);
            blocking = false;
        }
    }
}
