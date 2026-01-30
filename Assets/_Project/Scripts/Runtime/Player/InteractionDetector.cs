using ProjectName.Runtime.Interactables;
using ProjectName.Runtime.UI;
using UnityEngine;

namespace ProjectName.Runtime.Player
{
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields
        [SerializeField] private float m_InteractionDistance = 3.0f;
        [SerializeField] private LayerMask m_InteractableLayer;
        private float m_HoldTimer = 0f;

        private IInteractable m_CurrentInteractable;
        private InteractionUI m_InteractionUI; 
        #endregion

        #region Unity Methods
        private void Awake()
        {
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
                   
                    m_InteractionUI?.UpdatePrompt(m_CurrentInteractable.InteractionPrompt);
                    return;
                }
            }

            m_CurrentInteractable = null;
            
            m_InteractionUI?.UpdatePrompt(string.Empty);
        }

        private void HandleInteractionInput()
        {
            if (m_CurrentInteractable == null)
            {
                ResetHold();
                return;
            }

            
            if (m_CurrentInteractable is LootChest chest)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    m_HoldTimer += Time.deltaTime;
                    float progress = m_HoldTimer / chest.HoldDuration;

                    
                    m_InteractionUI?.UpdateProgress(progress);

                    if (m_HoldTimer >= chest.HoldDuration)
                    {
                        m_CurrentInteractable.Interact();
                        ResetHold();
                    }
                }
                else if (Input.GetKeyUp(KeyCode.E))
                {
                    ResetHold();
                }
            }
            else 
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    m_CurrentInteractable.Interact();
                }
            }
        }

        private void ResetHold()
        {
            m_HoldTimer = 0f;
            m_InteractionUI?.UpdateProgress(0f);
        }
        #endregion

    }
}