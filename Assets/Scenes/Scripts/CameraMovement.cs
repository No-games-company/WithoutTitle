using BombermanScripts;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public MovementInputAction action;

    public Rigidbody2D body;

    private void LateUpdate()
    {
        if (action.actionMove.IsPressed() && !action.actionAlt.IsPressed())
            body.MovePosition(player.GetComponent<Rigidbody2D>().position);
    }
}
