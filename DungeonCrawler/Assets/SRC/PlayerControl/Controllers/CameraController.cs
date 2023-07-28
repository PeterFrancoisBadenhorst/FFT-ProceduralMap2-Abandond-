using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.SRC.PlayerControl.Controllers
{
    public class CameraController : MonoBehaviour
    {
        public float sensitivityX = 8f;
        public float sensitivityY = 0.5f;
        public float mouseX, mouseY;
        public Transform playerCamera;

        private float xClamp = 85f;
        private float xRotation = 0f;


        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
        private void Update()
        {
            transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
            Vector3 targetRotation = transform.eulerAngles;
            targetRotation.x = xRotation;
            playerCamera.eulerAngles = targetRotation;
        }

        public void ReceiveInput(Vector2 mouseInput)
        {
            mouseX = mouseInput.x * sensitivityX;
            mouseY = mouseInput.y * sensitivityY;
        }

    }
}