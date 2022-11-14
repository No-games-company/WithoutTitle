using BombermanScripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementAnimation : MonoBehaviour
{

    private const float DIAGONAL_MOVE = 0.71f;

    private const string UP = "Up";
    private const string DOWN = "Down";
    private const string LEFT = "Left";
    private const string RIGHT = "Right";

    private const string RIGHT_UP = "RightUp";
    private const string RIGHT_DOWN = "RightDown";
    private const string LEFT_UP = "LeftUp";
    private const string LEFT_DOWN = "LeftDown";

    private const string IDLE = "Idle";
    private const string WALK = "Walk";

    private string moveState = DOWN;

    private MovementInputAction inputAction;
    private Animator animator;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        inputAction = GetComponent<MovementInputAction>();
    }

    private void SetIDle()
    {

        animator.Play(IDLE + moveState);
    }

    private void FixedUpdate()
    {
        CheckPosition();
    }

    private void CheckPosition()
    {

        var newPosition = inputAction.actionMove.ReadValue<Vector2>();

        switch (newPosition)
        {

            case Vector2 vector when vector.Equals(Vector2.up):
                {
                    Debug.Log(newPosition);
                    ChangeState(UP);
                    return;
                }

            case Vector2 vector when vector.Equals(Vector2.down):
                {
                    Debug.Log(newPosition);
                    ChangeState(DOWN);
                    return;
                }

            case Vector2 vector when vector.Equals(Vector2.right):
                {
                    Debug.Log(newPosition);
                    ChangeState(RIGHT);
                    return;
                }

            case Vector2 vector when vector.Equals(Vector2.left):
                {
                    Debug.Log(newPosition);
                    ChangeState(LEFT);
                    return;
                }

            case Vector2 vector when vector.x > 0 && vector.x < 1 && vector.y > 0 && vector.y < 1:
                {
                    Debug.Log(newPosition);
                    ChangeState(RIGHT_UP);
                    return;
                }

            case Vector2 vector when vector.x > 0 && vector.x < 1 && vector.y < 0 && vector.y > -1:
                {
                    Debug.Log(newPosition);
                    ChangeState(RIGHT_DOWN);
                    return;
                }

            case Vector2 vector when vector.x < 0 && vector.x > -1 && vector.y > 0 && vector.y < 1:
                {
                    Debug.Log(newPosition);
                    ChangeState(LEFT_UP);
                    return;
                }

            case Vector2 vector when vector.x < 0 && vector.x > -1 && vector.y < 0 && vector.y > -1:
                {
                    Debug.Log(newPosition);
                    ChangeState(LEFT_DOWN);
                    return;
                }

            case Vector2 vector when vector.Equals(Vector2.zero):
                {
                    SetIDle();
                    return;
                }

        }
    }
    private void ChangeState(string state)
    {
        moveState = state;

        animator.Play(WALK + state);
    }
}
