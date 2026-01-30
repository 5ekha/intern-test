using UnityEngine;

public interface IInteractable
{
    string InteractionPrompt { get; }
    bool Interact();
    void OnSelect();
    void OnDeselect();
}
