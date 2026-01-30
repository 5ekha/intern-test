using UnityEngine;
using ProjectName.Runtime.Player;

namespace ProjectName.Runtime.Interactables
{
    public class LockedDoor : MonoBehaviour, IInteractable
    {
        #region Fields
        [SerializeField] private string m_RequiredKeyID = "MainDoorKey";
        private bool m_IsOpen = false;
        #endregion

        #region Interface Implementations
        string IInteractable.InteractionPrompt => m_IsOpen ? "" : "Open the Door [E]";

        public void OnDeselect()
        {
            throw new System.NotImplementedException();
        }

        public void OnSelect()
        {
            throw new System.NotImplementedException();
        }

        bool IInteractable.Interact()
        {
            if (m_IsOpen) return false;

            PlayerInventory inventory = FindFirstObjectByType<PlayerInventory>();

            if (inventory != null && inventory.HasKey(m_RequiredKeyID))
            {
                OpenDoor();
                return true;
            }

            Debug.Log("<color=red>Door is locked!</color> You need a key.");
            return false;
        }
        #endregion

        #region Private Methods
        private void OpenDoor()
        {
            m_IsOpen = true;
            Debug.Log("<color=cyan>Door is open!</color>");

            // Destroy or animate the door opening
            transform.Translate(Vector3.up * 3f);
        }
        #endregion
    }
}