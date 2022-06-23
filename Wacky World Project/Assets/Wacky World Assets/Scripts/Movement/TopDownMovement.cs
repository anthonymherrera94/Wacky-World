using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class TopDownMovement : MonoBehaviour, PowerupVisitable
    {
        private Rigidbody _rb;

        public float BaseSpeed;
        [HideInInspector] public float Speed;

        public Vector2 TargetMovement
        {
            get => _targetMovement;
            set
            {
                _targetMovement = value.magnitude > 1 ? value.normalized : value;
                _targetMovement *= Speed;
                _targetHeading = _targetMovement.magnitude < 0.08f ? _actualHeading : GetHeading(_targetMovement);
                // _targetHeading = (_targetMovement.x > 0 ? 0 : 180) + 180 - (Mathf.Atan2(_targetMovement.y, _targetMovement.x) + 90);
            }
        }

        private bool _attemptJump;

        public bool AttemptJump
        {
            get => _attemptJump;
            set { _attemptJump = value; }
        }

        public Animator Anim;
        public GroundedTrigger Footpad;
        public float TranslationAcceleration;
        public float AirTranslationAcceleration;
        public float RotationAcceleration;
        public float JumpForce;
        public float JumpTolerance;

        private float _targetHeading;
        private float _actualHeading;
        private Vector2 _targetMovement;
        private Vector2 _actualMovement;
        private float _lastJump;

        private int _walkSpeedHash;
        private int _groundedHash;

        public void Start()
        {
            _groundedHash = Animator.StringToHash("grounded");
            _walkSpeedHash = Animator.StringToHash("walkSpeed");
            _rb = GetComponent<Rigidbody>();
            ResetValues();
        }

        public void Update()
        {
            Anim.SetFloat(_walkSpeedHash, _rb.velocity.magnitude);
            Anim.SetBool(_groundedHash, Footpad.IsGrounded);

            float accel = Footpad.IsGrounded ? TranslationAcceleration : AirTranslationAcceleration;

            var delta = _targetMovement - _actualMovement;
            if (delta.magnitude > (delta.normalized * accel * Time.deltaTime).magnitude)
                delta = delta.normalized * accel * Time.deltaTime;
            _actualMovement = _actualMovement + delta;
            _rb.velocity = new Vector3(_actualMovement.x, _rb.velocity.y, _actualMovement.y);

            var deltaHeading = DiffHeading(_targetHeading, _actualHeading);
            // Not sure I need the squaring
            deltaHeading = Mathf.Clamp(deltaHeading, -RotationAcceleration * Time.deltaTime,
                RotationAcceleration * Time.deltaTime);
            _actualHeading = (_actualHeading + deltaHeading) % 360;
            transform.rotation = Quaternion.Euler(0, _actualHeading, 0);

            if (_attemptJump && Footpad.IsGrounded && Time.realtimeSinceStartup - _lastJump > JumpTolerance)
            {
                _lastJump = Time.realtimeSinceStartup;
                _rb.velocity = new Vector3(_rb.velocity.x, JumpForce, _rb.velocity.z);
            }
        }

        public float DiffHeading(float target, float actual)
        {
            float delta = target - actual;
            if (delta > 180)
                delta -= 360;
            else if (delta < -180)
                delta += 360;
            return delta;
        }

        private float GetHeading(Vector2 a)
        {
            var b = Mathf.Atan2(a.y, a.x).ToDegrees();
            if (a.x > 0)
            {
                return 90 - b;
            }
            else
            {
                return (450 - b) % 360;
            }
        }

        public void Accept(PowerupVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void ResetValues()
        {
            Speed = BaseSpeed;
        }
    }
}