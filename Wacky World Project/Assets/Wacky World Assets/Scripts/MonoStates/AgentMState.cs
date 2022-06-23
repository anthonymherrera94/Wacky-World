using UnityEngine;
using UnityEngine.AI;

namespace MonoStates
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class AgentMState : MonoState
    {
        protected NavMeshAgent agent;
        [Range(1, 30)] [SerializeField] private float movementSpeed = 3.5f;
        [SerializeField] protected float visionDistance = 10;
        [SerializeField] private LayerMask playerMask;
        public GameObject Player { get; set; }


        protected override void Enter()
        {
            base.Enter();
            agent.speed = movementSpeed;
        }

        protected virtual void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        protected bool PlayerSpotted()
        {
            var position = transform.position;
            Vector3 toPlayer = Player.transform.position - position;
//todo return if distance is smaller than vision
            RaycastHit hitInfo;
            Debug.DrawRay(position,toPlayer,Color.red);
            bool hit = Physics.Raycast(position, toPlayer, out hitInfo, visionDistance,playerMask);
            if (!hit)
            {
                return false;
            }

            return hitInfo.transform.CompareTag("Player");
            // return (null != hit);
        }

        protected void DrawToDestinationWhenAgentSet()
        {
            if (agent == null)
            {
                return;
            }

            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, agent.destination);
        }

        protected void DrawHeroSpotSphere()
        {
            Gizmos.DrawWireSphere(transform.position, visionDistance);
        }
    }
}