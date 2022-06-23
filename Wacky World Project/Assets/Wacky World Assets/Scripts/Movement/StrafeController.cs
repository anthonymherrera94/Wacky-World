using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class StrafeController : MonoBehaviour
    {
        public Translator Translator;
        public Jumper jumper; // Update is called once per frame
        public Striker striker;

        [FormerlySerializedAs("topDown")] public TopDownMovement topDownMovement;


        void Update() {

            float forwardDirection = Input.GetAxis("Vertical");
            float sideWays = Input.GetAxis("Horizontal");
            topDownMovement.TargetMovement = new Vector2(sideWays, forwardDirection);

            //Alex thinks:these should be ORs, also a jump action/button should be abstracted from these two inputs.
            //Consider moving to new input system.
            if (Input.GetKey(KeyCode.Space))
                topDownMovement.AttemptJump = true;
            else if (Input.GetKeyUp(KeyCode.Space) )
                topDownMovement.AttemptJump = false;

            if (Input.GetKeyDown(KeyCode.Q)) {
                striker?.Strike();
            }
        }
    }
}