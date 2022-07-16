using UnityEngine;

namespace MonoStates
{
    public class Wandering : AgentMState
    {
        [SerializeField] private float wanderJitter = 0.1f;
        [SerializeField] private float wanderRadius = 0.5f;
        [SerializeField] private float wanderDistance = 10;
        [SerializeField] private MonoState onPlayerSpotted;

        void Wander()
        {
            Vector3 pointOnCircle = new Vector3(Random.Range(-1f, 1f) * wanderJitter, 0, Random.Range(-1f, 1f) * wanderJitter);
            pointOnCircle = pointOnCircle.normalized * wanderRadius;
            Vector3 wanderDestination = transform.position+ pointOnCircle + transform.forward * wanderDistance;
            // Vector3 globalDestination = transform.TransformVector(wanderDestination);
            agent.destination =wanderDestination;
        }

        protected override void StateUpdate()
        {
            //todo Not working.
            Wander();
            if (PlayerSpotted())
            {
                ProceedToNextStage(onPlayerSpotted);
            }
        
        }
        private void OnDrawGizmosSelected()
        {
            if (!isStateActive)
            {
                return;
            }
            Gizmos.DrawLine(transform.position,transform.position+transform.forward*wanderDistance);
            DrawToDestinationWhenAgentSet();
        }
    }
}