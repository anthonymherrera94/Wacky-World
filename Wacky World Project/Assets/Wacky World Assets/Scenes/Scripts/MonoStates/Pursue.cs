using UnityEngine;

namespace MonoStates
{
    public class Pursue : AgentMState
    {
        private float forgetCounter;
        [SerializeField] private float forgetTimeout = 4;
        [SerializeField] private MonoState onTargetForget;
        [SerializeField] private MonoState onTargetInRange;
        [SerializeField] private float attackRange  = 4f;


        protected override void StateUpdate()
        {
            agent.destination = Player.transform.position;

            if (agent.remainingDistance < attackRange)
                ProceedToNextStage(onTargetInRange);

            if (PlayerSpotted())
            {
                forgetCounter = 0;
                return;
            }

            forgetCounter += Time.deltaTime;
            if (forgetCounter > forgetTimeout)
            {
                Debug.Log("Target forgot");
                ProceedToNextStage(onTargetForget);
            }


        }
        private void OnDrawGizmosSelected()
        {
            if (!isStateActive)
            {
                return;
            }
            DrawToDestinationWhenAgentSet();
        }
    }
}