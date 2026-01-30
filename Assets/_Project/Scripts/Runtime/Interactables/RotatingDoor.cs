using UnityEngine;
using System.Collections;

namespace ProjectName.Runtime.Interactables
{
    public class RotatingDoor : MonoBehaviour, IInteractable
    {
        [Header("Rotation Settings")]
        [SerializeField] private float m_OpenAngle = 90f;
        [SerializeField] private float m_Speed = 2f;

        private bool m_IsOpen = false;
        private bool m_IsMoving = false;

        private Quaternion m_ClosedRotation;
        private Quaternion m_OpenRotation;

        private void Awake()
        {
            
            m_ClosedRotation = transform.localRotation;
            
            m_OpenRotation = m_ClosedRotation * Quaternion.Euler(0, m_OpenAngle, 0);
        }

        public string InteractionPrompt => m_IsOpen ? "Close Door [E]" : "Open Door [E]";

        public bool Interact()
        {
            if (m_IsMoving) return false;

            m_IsOpen = !m_IsOpen;
            StopAllCoroutines();
            StartCoroutine(AnimateRotation(m_IsOpen ? m_OpenRotation : m_ClosedRotation));
            return true;
        }

        private IEnumerator AnimateRotation(Quaternion targetRotation)
        {
            m_IsMoving = true;

            while (Quaternion.Angle(transform.localRotation, targetRotation) > 0.1f)
            {
                transform.localRotation = Quaternion.Slerp(
                    transform.localRotation,
                    targetRotation,
                    Time.deltaTime * m_Speed
                );
                yield return null;
            }

            transform.localRotation = targetRotation;
            m_IsMoving = false;
        }

        public void OnSelect() {}
        public void OnDeselect() {}
    }
}