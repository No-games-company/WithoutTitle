using BombermanScripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementAnimation : MonoBehaviour
{

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
    private const string RUN = "Run";
    private const string ATTACK = "Attack";

    private string moveState = DOWN;

    private bool isAttack = false;

    private MovementInputAction inputAction;
    private Animator animator;

    private const int rayVisionSize = 100;

    private int halfWidth = Screen.width / 2;
    private int halfHeight = Screen.height / 2;

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

        if (isAttack && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            isAttack = false;

        if (!isAttack)
        {

            if ((inputAction.actionAlt.IsPressed() || inputAction.attackAction.IsPressed()))
            {

                switch (Mouse.current.position.ReadValue())
                {

                    case Vector2 vector when vector.x < halfWidth + rayVisionSize && vector.x > halfWidth - rayVisionSize && vector.y > halfHeight + rayVisionSize:
                        {
                            ChangeState(UP);
                            return;
                        }

                    case Vector2 vector when vector.x < halfWidth + rayVisionSize && vector.x > halfWidth - rayVisionSize && vector.y < halfHeight - rayVisionSize:
                        {
                            ChangeState(DOWN);
                            return;
                        }

                    case Vector2 vector when vector.x < halfWidth - rayVisionSize && vector.y < halfHeight + rayVisionSize && vector.y > halfHeight - rayVisionSize:
                        {
                            ChangeState(LEFT);
                            return;
                        }

                    case Vector2 vector when vector.x > halfWidth + rayVisionSize && vector.y < halfHeight + rayVisionSize && vector.y > halfHeight - rayVisionSize:
                        {
                            ChangeState(RIGHT);
                            return;
                        }

                    case Vector2 vector when vector.x < halfWidth - rayVisionSize && vector.y > halfHeight + rayVisionSize:
                        {
                            ChangeState(LEFT_UP);
                            return;
                        }

                    case Vector2 vector when vector.x < halfWidth - rayVisionSize && vector.y < halfHeight - rayVisionSize:
                        {
                            ChangeState(LEFT_DOWN);
                            return;
                        }

                    case Vector2 vector when vector.x > halfWidth + rayVisionSize && vector.y < halfHeight - rayVisionSize:
                        {
                            ChangeState(RIGHT_DOWN);
                            return;
                        }

                    case Vector2 vector when vector.x > halfWidth + rayVisionSize && vector.y > halfHeight + rayVisionSize:
                        {
                            ChangeState(RIGHT_UP);
                            return;
                        }
                }

            }
            else CheckPosition();
        }
    }

    private void CheckPosition()
    {

        var newPosition = inputAction.actionMove.ReadValue<Vector2>();

        switch (newPosition)
        {

            case Vector2 vector when vector.Equals(Vector2.up):
                {
                    ChangeState(UP);
                    return;
                }

            case Vector2 vector when vector.Equals(Vector2.down):
                {
                    ChangeState(DOWN);
                    return;
                }

            case Vector2 vector when vector.Equals(Vector2.right):
                {
                    ChangeState(RIGHT);
                    return;
                }

            case Vector2 vector when vector.Equals(Vector2.left):
                {
                    ChangeState(LEFT);
                    return;
                }

            case Vector2 vector when vector.x > 0 && vector.x < 1 && vector.y > 0 && vector.y < 1:
                {
                    ChangeState(RIGHT_UP);
                    return;
                }

            case Vector2 vector when vector.x > 0 && vector.x < 1 && vector.y < 0 && vector.y > -1:
                {
                    ChangeState(RIGHT_DOWN);
                    return;
                }

            case Vector2 vector when vector.x < 0 && vector.x > -1 && vector.y > 0 && vector.y < 1:
                {
                    ChangeState(LEFT_UP);
                    return;
                }

            case Vector2 vector when vector.x < 0 && vector.x > -1 && vector.y < 0 && vector.y > -1:
                {
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

        if (inputAction.actionAlt.IsPressed())
            animator.Play(IDLE + state);
        else if (inputAction.attackAction.IsPressed())
        {
            isAttack = true;
            animator.Play(ATTACK + state);
        }
        else if (inputAction.actionRun.IsPressed())
            animator.Play(RUN + state);
        else if (inputAction.actionMove.IsPressed())
            animator.Play(WALK + state);

    }
}