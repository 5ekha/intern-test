using UnityEngine;
using ProjectName.Runtime.Player;

namespace ProjectName.Runtime.Interactables
{
    public class KeyItem : MonoBehaviour, IInteractable
    {
        #region Fields
        [SerializeField] private string m_KeyID = "MainDoorKey";
        #endregion

        #region Interface Implementations
        string IInteractable.InteractionPrompt => "Take the key [E]";

        bool IInteractable.Interact()
        {
            PlayerInventory inventory = FindFirstObjectByType<PlayerInventory>();

            if (inventory != null)
            {
                inventory.AddKey(m_KeyID);
                Destroy(gameObject); // Destroys upon being taken
                return true;
            }
            return false;
        }
        #endregion
    }
}