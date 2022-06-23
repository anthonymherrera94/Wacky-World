using UnityEngine;

namespace MonoStates
{
    public class Patrolling : AgentMState
    {
        public Transform[] waypoints;
        [SerializeField] private float minimumDistance = 1;
        private int currentPoint;
        public AgentMState onPlayerSpotted;

        protected override void Enter()
        {
            base.Enter();
            SetNearestWaypoint();
        }
        private void SetNearestWaypoint()
        {
            Vector3 myPosition = transform.position;
            float previousMin = float.PositiveInfinity;

            Transform previousPoint = null;
            for (int index = 0; index < waypoints.Length; index++)
            {
                Transform point = waypoints[index];
                float distanceToPoint = Vector3.SqrMagnitude(point.position - myPosition);
                if (distanceToPoint < previousMin)
                {
                    previousMin = distanceToPoint;
                    previousPoint = point;
                    currentPoint = index;
                }
            }

            agent.destination = previousPoint.position;
        }

        protected override void StateUpdate()
        {
            PatrolWaypoints();
            if (PlayerSpotted())
            {
                ProceedToNextStage(onPlayerSpotted);
            }
        }

        private void PatrolWaypoints()
        {
            if (agent.remainingDistance < minimumDistance)
            {
                currentPoint++;
                if (currentPoint >= waypoints.Length)
                {
                    currentPoint = 0;
                }

                agent.destination = waypoints[currentPoint].position;
            }
        }
        private void OnDrawGizmosSelected()
        {
            if (!isStateActive)
            {
                return;
            }
            // DrawWaypoints();
        }

        private void DrawWaypoints()
        {
            for (int i = 0; i < waypoints.Length - 1; i++)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }

            foreach (Transform waypoint in waypoints)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(waypoint.position, minimumDistance);
            }

            DrawHeroSpotSphere();
        }

       
    }
}