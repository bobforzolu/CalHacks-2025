using UnityEngine;

namespace System.Components
{
    public class MovementComponent: MonoBehaviour
    {
        public Rigidbody rigidbody; 
        private Vector3 workplace;
        public int facingDirections;
        public Vector3 CurrentVelocity { get; private set; }

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            facingDirections = 1;
        }
        public void LogicUpdate()
        {
       
            CurrentVelocity = rigidbody.linearVelocity;

        }

        public void SetVelocity(float velocity, Vector3 Direction)
        {
            workplace = new Vector2(Direction.x * velocity,rigidbody.linearVelocity.y);
            rigidbody.linearVelocity = workplace;
            CurrentVelocity = workplace;
        }
        public void SetJumpVelocity(float velocity)
        {
            rigidbody.AddForce(Vector2.up * velocity, ForceMode.Impulse);
        
        }
        public void CheckIfShouldFlip(float XInput, bool canflip)
        {
            XInput = XInput < 0 ? -1 : (XInput > 1 ? 1 : XInput);

            if (canflip)
            {
                if (XInput != 0 && XInput != facingDirections)
                {
                    Flip();
                }

            }
        }
        public void CheckIfShouldFlip(float XInput)
        {
            XInput = XInput < 0 ? -1 : (XInput > 1 ? 1 : XInput);

         
                if (XInput != 0 && XInput != facingDirections)
                {
                    Flip();
                }

            
        }
        public void Flip()
        {
            // Determine the current rotation
            float currentYRotation = transform.rotation.eulerAngles.y;

            // Toggle the rotation between 0 and 180
            float newYRotation = (currentYRotation == 0) ? 180 : 0;

            // Apply the new rotation
            transform.rotation = Quaternion.Euler(0, newYRotation, 0);

            // Optionally update the facing direction (if it's used elsewhere)
            facingDirections *= -1;
        }
    }
}