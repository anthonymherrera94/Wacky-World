using UnityEngine;
using UnityEngine.Events;

namespace MonoStates
{
    public abstract class MonoState : MonoBehaviour
    {
        private MonoState nextState;
        private FsmStage currentStage = FsmStage.Enter;
        public UnityEvent onEnter, onExit;
        public bool isStateActive => currentStage == FsmStage.Update;

        /// <summary>
        /// This method is called in the update loop and handles:
        /// entering, exiting, and updating (normal logic) of the state.
        /// </summary>
        /// <returns></returns>
        public MonoState Process()
        {
            if (currentStage == FsmStage.Enter) Enter();
            if (currentStage == FsmStage.Update) StateUpdate();
            if (currentStage != FsmStage.Exit) return (MonoState) this;
            Exit();
            return nextState;
        }

        /// <summary>
        /// This method is called in the update look while this monostate is in the update state.
        /// You should place your logic here and proceed to the next stage when the appropriate conditions are met.
        /// </summary>
        protected abstract void StateUpdate();

        protected void ProceedToNextStage(MonoState next)
        {
            nextState = next;
            currentStage = FsmStage.Exit;
            nextState.currentStage = FsmStage.Enter;
        }

        protected virtual void Enter()
        {
            currentStage = FsmStage.Update;
            onEnter?.Invoke();
        }

        protected virtual void Exit()
        {
            onExit?.Invoke();
        }

        private enum FsmStage
        {
            Enter,
            Update,
            Exit
        }
    }
}