using UnityEngine;

namespace ProjectName.Runtime.Interactables
{
    public class SimpleObject : MonoBehaviour, IInteractable
    {
        #region Interface Implementations
        // Explicit implementation (Dokümandaki kural)
        string IInteractable.InteractionPrompt => "Press 'E' to interact";

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
            Debug.Log("<color=green>Success!</color> Interacted with the object.");

            GetComponent<Renderer>().material.color = Random.ColorHSV();

            return true;
        }
        #endregion
    }
}