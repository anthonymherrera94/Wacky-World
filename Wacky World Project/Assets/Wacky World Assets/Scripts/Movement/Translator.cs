using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class Translator : MonoBehaviour, PowerupVisitable
    {
        [Range(1, 50)] [SerializeField] private float baseSpeed = 1f;
        public float currentSpeed;
        private Vector3 translateDirection;
        private Rigidbody rb;

        void Start()
        {
            currentSpeed = baseSpeed;
            rb = GetComponent<Rigidbody>();
            translateDirection = transform.forward;
        }

        void FixedUpdate()
        {
            Vector3 velocity =transform.TransformDirection(translateDirection * (Time.fixedDeltaTime * currentSpeed*10));
            velocity.y = rb.velocity.y;
            rb.velocity = velocity;
            // transform.Translate(translateDirection*Time.fixedDeltaTime*speed);
            // rb.AddRelativeForce(translateDirection * Time.fixedDeltaTime * currentSpeed, ForceMode.Impulse);
        }


        public void SetDirection(Vector3 moveDirection)
        {
            translateDirection = moveDirection;
        }

        public void Accept(PowerupVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void ResetValues()
        {
            currentSpeed = baseSpeed;
        }
    }
}