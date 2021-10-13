using UnityEngine;

namespace Energy
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Attributes.")]
        [SerializeField]
        private float mouseSensitivity = 300f;
        [SerializeField]
        private float maxXAngle = 45f;
        [SerializeField]
        private float maxYAngle = 60f;

        private float yRotation = 0f;
        private float xRotation = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            mouseSensitivity = PlayerPrefs.GetFloat(GameData.MOUSE_SENSITIVITY, 300);
        }

        private void Update() => RotateCamera();

        private void RotateCamera()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, -maxXAngle, maxXAngle);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -maxYAngle, maxYAngle);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}