using UnityEngine;

namespace Movement
{
    public class Rotator : MonoBehaviour
    {
        float rotationAngle;
        [Range(5,100)]
        [SerializeField] private float speed =10f;
    
        void FixedUpdate()
        {
            transform.Rotate(transform.up,rotationAngle*Time.fixedDeltaTime*speed);
        }

        public void SetRotation(float angle)
        {
            rotationAngle = angle;
        }
    }
}
