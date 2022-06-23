using UnityEngine;

namespace MonoStates
{
    public class StartState : MonoBehaviour
    {
        public MonoState startState;

        public MonoState currentState;

        // Start is called before the first frame update
        void Start()
        {
            currentState = startState;
        }

        private void Update()
        {
            currentState = currentState.Process();
        }
    }
}