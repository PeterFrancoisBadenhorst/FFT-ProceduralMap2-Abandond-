using Assets.SRC.PlayerControl.Controllers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.PlayerControl.Mono;
using System.Collections;
using UnityEngine;

namespace Assets.SRC.PlayerControl.Mono.Managers
{
    public class InputManager : MonoBehaviour
    {
        [Header("Camera Settings")]
        public float sensitivityX = 8f;
        public float sensitivityY = 0.5f;
        public float mouseX, mouseY;
        public Transform playerCamera;
        [Header("Movement Settings")]
        public float speed = 11f;
        public float gravity = -30f; // -9.81
        public LayerMask groundMask;
        public float jumpHeight = 3.5f;




        private bool isGrounded;
        private bool jump;
        private Vector2 horizontalMovementInput;
        private CharacterController controller;
        private Vector3 verticalVelocity = Vector3.zero;

        private MovementController movement;
        private CameraController mouseLook;
        private PlayerControlActions controls;
        private PlayerControlActions.PlayerInputActions groundMovement;

        private Vector2 horizontalMouseInput;
        private Vector2 mouseInput;
        private float xClamp = 85f;
        private float xRotation = 0f;

        private void Awake()
        {
            movement = new MovementController();
            mouseLook = new CameraController();

            controls = new PlayerControlActions();
            groundMovement = controls.PlayerInput;

            groundMovement.Movement.performed += ctx => horizontalMovementInput = ctx.ReadValue<Vector2>();

            groundMovement.Jump.performed += _ => movement.OnJumpPressed();

            groundMovement.MouseControl_X.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
            groundMovement.MouseControl_Y.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        }

        private void Update()
        {
            movement.ReceiveInput(horizontalMovementInput);
            mouseLook.ReceiveInput(mouseInput);
        }


        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDestroy()
        {
            controls.Disable();
        }
    }
}

// https://www.youtube.com/watch?v=tXDgSGOEatk