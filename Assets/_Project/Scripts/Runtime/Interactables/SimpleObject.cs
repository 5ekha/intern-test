using UnityEngine;

namespace ProjectName.Runtime.Interactables
{
    public class SimpleObject : MonoBehaviour, IInteractable
    {
        #region Interface Implementations
        // Explicit implementation (Dokümandaki kural)
        string IInteractable.InteractionPrompt => "Press 'E' to interact";

        bool IInteractable.Interact()
        {
            Debug.Log("<color=green>Success!</color> Interacted with the object.");

            // Görsel bir geri bildirim için rengini deðiþtirelim
            GetComponent<Renderer>().material.color = Random.ColorHSV();

            return true;
        }
        #endregion
    }
}