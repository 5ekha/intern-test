using UnityEngine;

namespace ProjectName.Runtime.Player
{
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields
        [SerializeField] private float m_InteractionDistance = 3.0f;
        [SerializeField] private LayerMask m_InteractableLayer;

        private IInteractable m_CurrentInteractable;
        #endregion

        #region Unity Methods
        private void Update()
        {
            CheckForInteractable();

            if (m_CurrentInteractable != null && Input.GetKeyDown(KeyCode.E))
            {
                m_CurrentInteractable.Interact();
            }
        }
        #endregion

        #region Private Methods
        private void CheckForInteractable()
        {
            // Kameranýn merkezinden ileriye ýþýn atar
            Ray r_ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(r_ray, out RaycastHit hit, m_InteractionDistance, m_InteractableLayer))
            {
                // TryGetComponent performansý yüksektir ve null check yapar
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    m_CurrentInteractable = interactable;
                    Debug.Log($"Object you are facing: {m_CurrentInteractable.InteractionPrompt}");
                    return;
                }
            }

            m_CurrentInteractable = null;
        }
        #endregion
    }
}