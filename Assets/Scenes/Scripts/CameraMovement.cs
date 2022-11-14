using BombermanScripts;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public MovementInputAction action;

    public Rigidbody2D body;

    private void LateUpdate()
    {

        body.MovePosition(
            player.GetComponent<Rigidbody2D>().position + 
            action.actionMove.ReadValue<Vector2>() * 5f * Time.fixedDeltaTime);
    }
}
