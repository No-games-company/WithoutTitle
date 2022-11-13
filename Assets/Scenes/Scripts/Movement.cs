using UnityEngine;

namespace BombermanScripts
{
    public class Movement : MonoBehaviour
    {

        private float speed = 5f;

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

                var newPosition = inputAction.actionMove.ReadValue<Vector2>();

                body.MovePosition(body.position + newPosition * speed * newPosition.magnitude * Time.fixedDeltaTime);
            }
           
        }
    }
}
