using UnityEngine;

namespace ProjectName.Runtime.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        #region Fields
        [Header("Movement")]
        [SerializeField] private float m_MoveSpeed = 5.0f;
        [SerializeField] private float m_LookSensitivity = 2.0f;

        private CharacterController m_CharacterController;
        private Camera m_Camera;
        private float m_XRotation = 0f;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            m_CharacterController = GetComponent<CharacterController>();
            m_Camera = GetComponentInChildren<Camera>();

            // Fareyi ekranýn ortasýna kitle
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            HandleRotation();
            HandleMovement();
        }
        #endregion

        #region Private Methods
        private void HandleMovement()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            m_CharacterController.Move(move * m_MoveSpeed * Time.deltaTime);
        }

        private void HandleRotation()
        {
            float mouseX = Input.GetAxis("Mouse X") * m_LookSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * m_LookSensitivity;

            m_XRotation -= mouseY;
            m_XRotation = Mathf.Clamp(m_XRotation, -90f, 90f);

            m_Camera.transform.localRotation = Quaternion.Euler(m_XRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
        #endregion
    }
}