using System.Collections;
using UnityEngine;

namespace Assets.SRC.PlayerControl.Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementController : MonoBehaviour
    {

        public float speed = 11f;
        public float gravity = -30f; // -9.81
        public LayerMask groundMask;
        public float jumpHeight = 3.5f;


        private bool isGrounded;
        private bool jump;
        private Vector2 horizontalInput;
        private CharacterController controller;
        private Vector3 verticalVelocity = Vector3.zero;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
            if (!GroundCheck(transform, groundMask))
            {
                verticalVelocity.y += gravity * Time.deltaTime;
                controller.Move(verticalVelocity * Time.deltaTime);
                return;
            }
            if (GroundCheck(transform, groundMask)) verticalVelocity.y = 0;
            if (jump)
            {
                if (isGrounded)
                {
                    verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
                }
                jump = false;
            }


            Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
            controller.Move(horizontalVelocity * Time.deltaTime);

            verticalVelocity.y += gravity * Time.deltaTime;
            controller.Move(verticalVelocity * Time.deltaTime);
        }

        public void ReceiveInput(Vector2 _horizontalInput)
        {
            horizontalInput = _horizontalInput;
        }

        public void OnJumpPressed()
        {
            jump = true;
        }
        private bool GroundCheck(Transform transform, LayerMask mask) => Physics.CheckSphere(transform.position, 0.1f, mask);

    }
}