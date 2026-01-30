using UnityEngine;

namespace ProjectName.Runtime.Interactables
{
    public class TriggerableLight : MonoBehaviour, ITriggerable
    {
        private Light m_Light;

        private void Awake()
        {
            m_Light = GetComponent<Light>();

            Debug.Log($"[Light]: Initial state is {m_Light.enabled}");
        }

        public void Trigger()
        {
            m_Light.enabled = !m_Light.enabled;
            Debug.Log("[Light]: Toggled via Switch!");
        }
    }
}