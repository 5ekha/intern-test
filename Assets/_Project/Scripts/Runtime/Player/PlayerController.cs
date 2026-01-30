using UnityEngine;

namespace ProjectName.Runtime.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        #region Fields
        [Header("Physics")]
        [SerializeField] private float m_Gravity = -9.81f;
        private Vector3 m_Velocity; // To store falling speed
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

            Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }

            HandleRotation();
            HandleMovement();
        }
        #endregion

        #region Private Methods
        private void HandleMovement()
        {
            // 1. Check grounding
            bool isGrounded = m_CharacterController.isGrounded;
            if (isGrounded && m_Velocity.y < 0)
            {
                // Use a small negative value to keep the player "stuck" to the ground
                m_Velocity.y = -2f;
            }

            // 2. Calculate horizontal movement
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            // Important: Use transform.TransformDirection to ensure we move relative to where we look
            Vector3 moveDirection = transform.right * x + transform.forward * z;

            // 3. Apply horizontal movement
            m_CharacterController.Move(moveDirection * m_MoveSpeed * Time.deltaTime);

            // 4. Calculate and apply gravity separately
            m_Velocity.y += m_Gravity * Time.deltaTime;

            // Final vertical move
            m_CharacterController.Move(m_Velocity * Time.deltaTime);
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