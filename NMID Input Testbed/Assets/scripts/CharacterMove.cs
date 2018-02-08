using UnityEngine;
using System.Collections;

namespace Character.BasicControls
{
    [RequireComponent(typeof (Rigidbody))]
    public class CharacterMove : MonoBehaviour
    {
        public class MoveSettings
        {
            public float forwardSpeed = 4.0f;
            public float strafeSpeed = 2.5f;
            public float backSpeed = 1.0f;
            public float targetSpeed = 4.0f;

            public KeyCode Left = KeyCode.LeftArrow;
            public KeyCode Right = KeyCode.RightArrow;
            public KeyCode Forward = KeyCode.UpArrow;

            public void UpdateMovement()
            {
                //if (input == Vector2.zero) return;
                //if (input.x > 0 || input.x < 0)
                //{
                //    targetSpeed = strafeSpeed;
                //}
                //if (input.y < 0)
                //{
                //
                //}
                if (Input.GetKey(Right))
                {
                    
                }
                if (Input.GetKey(Left))
                {
                    
                }
            }
        }
    }
}

