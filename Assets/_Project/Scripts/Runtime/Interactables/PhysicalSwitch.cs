using UnityEngine;

namespace ProjectName.Runtime.Interactables
{
    public class PhysicalSwitch : MonoBehaviour, IInteractable
    {
        [Header("Settings")]
        [SerializeField] private GameObject m_TargetObject;

        [Header("Audio")]
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip m_SwitchOnSound;
        [SerializeField] private AudioClip m_SwitchOffSound;

        private bool m_IsToggled = false;

        public string InteractionPrompt => m_IsToggled ? "Turn OFF [E]" : "Turn ON [E]";

        public bool Interact()
        {
            m_IsToggled = !m_IsToggled;

          
            AudioClip clipToPlay = m_IsToggled ? m_SwitchOnSound : m_SwitchOffSound;
            if (m_AudioSource != null && clipToPlay != null)
            {
                m_AudioSource.pitch = Random.Range(0.95f, 1.05f);
                m_AudioSource.PlayOneShot(clipToPlay);
            }
            if (m_TargetObject != null)
            {
                ITriggerable triggerable = m_TargetObject.GetComponent<ITriggerable>();
                if (triggerable != null)
                {
                    triggerable.Trigger();
                }
            }

            return true;
        }

        public void OnSelect() { /* Glow Effect */ }
        public void OnDeselect() { /* Remove Glow */ }
    }
}