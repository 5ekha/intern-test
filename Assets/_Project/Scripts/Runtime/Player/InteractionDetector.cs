using UnityEngine;

namespace ProjectName.Runtime.Player
{
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields
        [SerializeField] private float m_InteractionDistance = 3.0f;
        [SerializeField] private LayerMask m_InteractableLayer;

        private IInteractable m_CurrentInteractable;
        private InteractionUI m_InteractionUI; // New reference
        #endregion

        #region Unity Methods
        private void Awake()
        {
            // Cache the UI component
            m_InteractionUI = Object.FindFirstObjectByType<InteractionUI>();
        }

        private void Update()
        {
            CheckForInteractable();
            HandleInteractionInput();
        }
        #endregion

        #region Private Methods
        private void CheckForInteractable()
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out RaycastHit hit, m_InteractionDistance, m_InteractableLayer))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    m_CurrentInteractable = interactable;
                    // Update UI with the prompt from the interface
                    m_InteractionUI?.UpdatePrompt(m_CurrentInteractable.InteractionPrompt);
                    return;
                }
            }

            m_CurrentInteractable = null;
            // Clear UI if nothing is hit
            m_InteractionUI?.UpdatePrompt(string.Empty);
        }

        private void HandleInteractionInput()
        {
            if (m_CurrentInteractable != null && Input.GetKeyDown(KeyCode.E))
            {
                m_CurrentInteractable.Interact();
            }
        }
        #endregion
    }
}