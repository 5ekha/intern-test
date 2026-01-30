using UnityEngine;

namespace ProjectName.Runtime.Interactables
{
    public class PhysicalSwitch : MonoBehaviour, IInteractable
    {
        #region Fields

        [SerializeField] private MonoBehaviour m_TargetToTrigger;

        private bool m_IsToggled = false;
        #endregion

        #region Interface Implementations
        string IInteractable.InteractionPrompt => m_IsToggled ? "Turn OFF [E]" : "Turn ON [E]";

        bool IInteractable.Interact()
        {
            if (m_TargetToTrigger is ITriggerable triggerable)
            {
                m_IsToggled = !m_IsToggled;
                triggerable.Trigger();

                AnimateSwitch();
                return true;
            }

            Debug.LogWarning("[Switch]: Target is not ITriggerable!");
            return false;
        }

        void IInteractable.OnSelect() { /* Highlight Logic */ }
        void IInteractable.OnDeselect() { /* Highlight Logic */ }
        #endregion

        private void AnimateSwitch()
        {
            GetComponent<Renderer>().material.color = m_IsToggled ? Color.green : Color.red;
        }
    }
}