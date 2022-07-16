using UnityEngine;

namespace Movement
{
    public class InputController : MonoBehaviour
    {
        public Translator Translator;
        public Rotator Rotator;
        public Jumper jumper; // Update is called once per frame

        void Update()
        {
            float forwardDirection = Input.GetAxis("Vertical");
            float rotation = Input.GetAxis("Horizontal");
            Translator.SetDirection(new Vector3(0, 0, forwardDirection));
            Rotator.SetRotation(rotation);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumper.Jump();
            }
        }
    }
}