using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class SetAnimationSpeed : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        private Rigidbody rb;
        private Groundable groundable;
        private static readonly int Grounded = Animator.StringToHash("grounded");
        private static readonly int WalkSpeed = Animator.StringToHash("walkSpeed");

        // Start is called before the first frame update
        void Start()
        {
            groundable = GetComponent<Groundable>();
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            var velocity = rb.velocity;
            Vector2 horizontalVelocity = new Vector2(velocity.x, velocity.z);
            anim.SetFloat(WalkSpeed,horizontalVelocity.magnitude);
            anim.SetBool(Grounded,groundable.grounded);
        }
    }
}
