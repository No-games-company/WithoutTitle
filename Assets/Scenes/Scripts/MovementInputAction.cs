using UnityEngine;
using UnityEngine.InputSystem;

namespace BombermanScripts
{
    public class MovementInputAction : MonoBehaviour
    {

        private const string MOVE = "Move";
        private const string PLAYER = "Player";

        private PlayerInput playerInput;

        public InputAction actionMove { get; private set; }

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            actionMove = playerInput.actions.FindActionMap(PLAYER).FindAction(MOVE);
            actionMove.Enable();
        }
    }
}