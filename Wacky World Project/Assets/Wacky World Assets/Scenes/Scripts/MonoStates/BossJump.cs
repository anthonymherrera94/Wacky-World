using System;
using System.Collections;
using System.Threading.Tasks;
using Movement;
using UnityEngine;
using UnityEngine.Events;
using PlayerManagement;

namespace MonoStates
{
    [RequireComponent(typeof(Jumper)), RequireComponent(typeof(Groundable))]
    public class BossJump : AgentMState
    {
        bool landed;
        private bool GroundShake = false;
        [SerializeField] private MonoState afterJump;
        public Jumper jumper;
        private Groundable groundable;
        private UnityAction setLand;

        protected override void Start()
        {
            base.Start();
            jumper = GetComponent<Jumper>();
            groundable = GetComponent<Groundable>();
        }

        protected override void Enter()
        {
            setLand = () => landed = true;

            base.Enter();
            StartCoroutine(DisableAgentWaitJump());
        }

         IEnumerator DisableAgentWaitJump()
        {
            agent.enabled = false;
            landed = false;
            yield return new WaitForSeconds(1);
            // TransformJump();
            jumper.Jump();
            groundable.onGround.AddListener(setLand);
        }

        protected override void Exit()
        {
            base.Exit();
            groundable.onGround.RemoveListener(setLand);
            agent.enabled = true;
            landed = false;
        }

        protected override void StateUpdate()
        {
            if (landed)
            {
                ProceedToNextStage(afterJump);
                Debug.Log("landed");
            }
        }

        void TransformJump()
        {
            Transform enemyTransform = transform;
            Vector3 position = enemyTransform.position;
            position = new Vector3(position.x, 4, position.z);
            enemyTransform.position = position;
            Debug.Log("jumped");
        }
    }
}