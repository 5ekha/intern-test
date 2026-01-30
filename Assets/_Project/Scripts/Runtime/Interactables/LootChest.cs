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

        public bool Interact()
        {
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