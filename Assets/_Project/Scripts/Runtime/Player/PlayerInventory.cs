using UnityEngine;
using System.Collections.Generic;

namespace ProjectName.Runtime.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        #region Fields
        
        private List<string> m_CollectedKeys = new List<string>();
        #endregion

        #region Public Methods
        public void AddKey(string keyName)
        {
            if (!m_CollectedKeys.Contains(keyName))
            {
                m_CollectedKeys.Add(keyName);
                Debug.Log($"<color=yellow>Inventory:</color> {keyName} taken!");
            }
        }

        public bool HasKey(string keyName)
        {
            return m_CollectedKeys.Contains(keyName);
        }
        #endregion
    }
}