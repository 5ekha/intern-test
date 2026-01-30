using UnityEngine;
using UnityEngine.UI; 
using TMPro;

namespace ProjectName.Runtime.UI
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_PromptText;
        [SerializeField] private Slider m_ProgressBar; 

        public void UpdatePrompt(string message)
        {
            m_PromptText.text = message;
        }

        
        public void UpdateProgress(float value)
        {
            if (m_ProgressBar == null) return;

            
            if (value > 0f && value < 1f)
            {
                m_ProgressBar.gameObject.SetActive(true);
                m_ProgressBar.value = value;
            }
            else
            {
                m_ProgressBar.gameObject.SetActive(false);
                m_ProgressBar.value = 0f;
            }
        }
    }
}