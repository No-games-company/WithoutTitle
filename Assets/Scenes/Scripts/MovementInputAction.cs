using UnityEngine;
using UnityEngine.InputSystem;

namespace BombermanScripts
{
    public class MovementInputAction : MonoBehaviour
    {

        private const string MOVE = "Move";
        private const string PLAYER = "Player";
        private const string RUN = "Run";

        private PlayerInput playerInput;

        public InputAction actionMove { get; private set; }
        public InputAction actionRun { get; private set; }

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            actionMove = playerInput.actions.FindActionMap(PLAYER).FindAction(MOVE);
            actionMove.Enable();

            actionRun = playerInput.actions.FindActionMap(PLAYER).FindAction(RUN);
            actionRun.Enable();
        }
    }
}