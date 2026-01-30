using UnityEngine;

namespace ProjectName.Runtime.Interactables
{
    public class LootChest : MonoBehaviour, IInteractable
    {
        [SerializeField] private float m_HoldDuration = 2.0f;
        [SerializeField] private Transform m_LidTransform;

        [SerializeField] private GameObject m_ItemInside;

        private bool m_IsOpened = false;
        public float HoldDuration => m_HoldDuration;

        public string InteractionPrompt => m_IsOpened ? "" : "Hold [E] to Search Chest";
        
        [Header("Audio")]
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip m_SearchLoop;
        [SerializeField] private AudioClip m_OpenSound;

        public void StartSearching()
        {
            if (m_IsOpened || m_AudioSource == null || m_SearchLoop == null) return;

            m_AudioSource.clip = m_SearchLoop;
            m_AudioSource.loop = true;
            m_AudioSource.Play();
        }

        public void StopSearching()
        {
            if (m_AudioSource != null && m_AudioSource.clip == m_SearchLoop)
            {
                m_AudioSource.Stop();
                m_AudioSource.loop = false;
            }
        }

        public bool Interact()
        {
            if (m_IsOpened) return false;
            StopSearching(); // Stop the loop when finished

            if (m_AudioSource != null && m_OpenSound != null)
                m_AudioSource.PlayOneShot(m_OpenSound);

            if (m_IsOpened) return false;

            m_IsOpened = true;
           
            if (m_LidTransform != null)
                m_LidTransform.localRotation = Quaternion.Euler(-270, 0, 0);

            if (m_ItemInside != null)
            {
                m_ItemInside.SetActive(true);
                Debug.Log("<color=cyan>[Chest]:</color> Found an item inside!");
            }

            return true;
        }

        public void OnSelect() { }
        public void OnDeselect() { }
    }
}