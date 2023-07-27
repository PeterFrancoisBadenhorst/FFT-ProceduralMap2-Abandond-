using Assets.SRC.PlayerControl.Controllers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.PlayerControl.Mono;
using System.Collections;
using UnityEngine;

namespace Assets.SRC.PlayerControl.Mono.Managers
{
    public class InputManager : MonoBehaviour
    {

        [SerializeField] MovementController movement;
        [SerializeField] CameraController mouseLook;
        [SerializeField] WeaponController gun;

        PlayerControlActions controls;
        PlayerControlActions.PlayerInputActions groundMovement;

        Vector2 horizontalInput;
        Vector2 mouseInput;

        Coroutine fireCoroutine;

        private void Awake()
        {
            controls = new PlayerControlActions();
            groundMovement = controls.PlayerInput;

            // groundMovement.[action].performed += context => do something
            groundMovement.Movement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

            groundMovement.Jump.performed += _ => movement.OnJumpPressed();

            groundMovement.MouseControl_X.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
            groundMovement.MouseControl_Y.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

            groundMovement.Shoot.started += _ => StartFiring();
            groundMovement.Shoot.canceled += _ => StopFiring();
        }

        private void Update()
        {
            movement.ReceiveInput(horizontalInput);
            mouseLook.ReceiveInput(mouseInput);
        }

        void StartFiring()
        {
            fireCoroutine = StartCoroutine(gun.RapidFire());
        }

        void StopFiring()
        {
            if (fireCoroutine != null)
            {
                StopCoroutine(fireCoroutine);
            }
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