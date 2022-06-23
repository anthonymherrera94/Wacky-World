using UnityEngine;

namespace MonoStates
{
    public class Flee : AgentMState
    {
        private float forgetCounter;
        [SerializeField] private MonoState onTargetForget;
        [SerializeField] private float forgetTimeout = 2;

        void FleeFrom(Vector3 scary)
        {
            Vector3 location = transform.position;
            Vector3 awayFrom = location - scary;
            Vector3 targetLocation = location + awayFrom;

            agent.SetDestination(targetLocation);
        }

        protected override void StateUpdate()
        {
            FleeFrom(Player.transform.position);
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