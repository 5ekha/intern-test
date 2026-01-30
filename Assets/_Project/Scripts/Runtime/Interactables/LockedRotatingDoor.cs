using System.Collections;
using ProjectName.Runtime.Player;
using UnityEngine;

namespace ProjectName.Runtime.Interactables
{
    public class LockedRotatingDoor : MonoBehaviour, IInteractable
    {
        [Header("Audio")]
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip m_OpenSound;
        [SerializeField] private AudioClip m_CloseSound;
        [SerializeField] private AudioClip m_LockedLockedSound;

        [Header("Key Settings")]
        [SerializeField] private string m_RequiredKeyId = "Level1_Key";

        [Header("Rotation Settings")]
        [SerializeField] private float m_OpenAngle = 90f;
        [SerializeField] private float m_Speed = 3f;

        private bool m_IsLocked = true;
        private bool m_IsOpen = false;
        private bool m_IsMoving = false;

        private Quaternion m_ClosedRotation;
        private Quaternion m_OpenRotation;

        private void Awake()
        {
            m_ClosedRotation = transform.localRotation;
            m_OpenRotation = m_ClosedRotation * Quaternion.Euler(0, m_OpenAngle, 0);
        }

        public string InteractionPrompt
        {
            get
            {
                if (m_IsLocked) return "Locked - Needs Key";
                return m_IsOpen ? "Close [E]" : "Open [E]";
            }
        }

        public bool Interact()
        {
            if (m_IsMoving) return false;

            if (m_IsLocked)
            {
                var inventory = Object.FindFirstObjectByType<PlayerInventory>();
                if (inventory != null && inventory.HasKey(m_RequiredKeyId))
                {
                    m_IsLocked = false;
                    
                }
                else
                {
                    PlaySound(m_LockedLockedSound); 
                    return false;
                }
            }

            m_IsOpen = !m_IsOpen;

            
            PlaySound(m_IsOpen ? m_OpenSound : m_CloseSound);

            StopAllCoroutines();
            StartCoroutine(AnimateRotation(m_IsOpen ? m_OpenRotation : m_ClosedRotation));
            return true;
        }

        private void PlaySound(AudioClip clip)
        {
            if (m_AudioSource != null && clip != null)
            {
                m_AudioSource.PlayOneShot(clip);
            }
        }

        private IEnumerator AnimateRotation(Quaternion target)
        {
            m_IsMoving = true;
            while (Quaternion.Angle(transform.localRotation, target) > 0.1f)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * m_Speed);
                yield return null;
            }
            transform.localRotation = target;
            m_IsMoving = false;
        }

        public void OnSelect() { }
        public void OnDeselect() { }
    }
}