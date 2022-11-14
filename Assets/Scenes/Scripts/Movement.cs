using UnityEngine;

namespace BombermanScripts
{
    public class Movement : MonoBehaviour
    {

        private float speed = 2f;
        private float speedRunning = 5f;

        private Rigidbody2D body;

        private MovementInputAction inputAction;

        private void Awake()
        {

            body = GetComponent<Rigidbody2D>();
            inputAction = GetComponent<MovementInputAction>();
        }

        private void FixedUpdate()
        {
            if (inputAction.actionMove.IsPressed())
            {

                if (inputAction.actionRun.IsPressed())
                {

                    var newPosition = inputAction.actionMove.ReadValue<Vector2>().normalized;

                    body.MovePosition(body.position + newPosition * speedRunning * newPosition.magnitude * Time.fixedDeltaTime);
                } else
                {

                    var newPosition = inputAction.actionMove.ReadValue<Vector2>().normalized;

                    body.MovePosition(body.position + newPosition * speed * newPosition.magnitude * Time.fixedDeltaTime);
                }
            } 
           
        }
    }
}
