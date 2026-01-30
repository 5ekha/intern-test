using UnityEngine;
using TMPro;

namespace ProjectName.Runtime.Player
{
    public class InteractionUI : MonoBehaviour
    {
        #region Fields
        [SerializeField] private TextMeshProUGUI m_PromptText;
        #endregion

        #region Public Methods
       
        /// Updates the HUD text. If the prompt is empty, the text is hidden.
       
        public void UpdatePrompt(string prompt)
        {
            if (string.IsNullOrEmpty(prompt))
            {
                m_PromptText.gameObject.SetActive(false);
            }
            else
            {
                m_PromptText.gameObject.SetActive(true);
                m_PromptText.text = prompt;
            }
        }
        #endregion
    }
}