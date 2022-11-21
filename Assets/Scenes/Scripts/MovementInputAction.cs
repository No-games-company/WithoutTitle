using UnityEngine;
using UnityEngine.InputSystem;

namespace BombermanScripts
{
    public class MovementInputAction : MonoBehaviour
    {

        private const string MOVE = "Move";
        private const string PLAYER = "Player";
        private const string RUN = "Run";
        private const string LOOK = "Look";
        private const string MOUSE_POSITION = "MousePosition";
        private const string ATTACK = "Attack";

        private PlayerInput playerInput;

        public InputAction actionMove { get; private set; }
        public InputAction actionRun { get; private set; }
        public InputAction actionAlt { get; private set; }
        public InputAction mousePosition { get; private set; }
        public InputAction attackAction { get; private set; }

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            actionMove = playerInput.actions.FindActionMap(PLAYER).FindAction(MOVE);
            actionMove.Enable();

            actionRun = playerInput.actions.FindActionMap(PLAYER).FindAction(RUN);
            actionRun.Enable();

            actionAlt = playerInput.actions.FindActionMap(PLAYER).FindAction(LOOK);
            actionAlt.Enable();

            mousePosition = playerInput.actions.FindActionMap(PLAYER).FindAction(MOUSE_POSITION);
            mousePosition.Enable();

            attackAction = playerInput.actions.FindActionMap(PLAYER).FindAction(ATTACK);
            attackAction.Enable();
        }
    }
}