using TMPro;
using UnityEngine;

namespace InventoryModule
{
    public class InventoryTracker : MonoBehaviour
    {
        [SerializeField] private InventoryType _type;
        public string endText = "";
        private TextMeshProUGUI _trackingText;

        private void Awake()
        {
            _trackingText = GetComponent<TextMeshProUGUI>();
            if (_trackingText == null)
            {
                Debug.LogError("TextMeshProUGUI component not found on " + gameObject.name);
            }
        }
        
        protected virtual void OnEnable()
        {
            // todo:Register the tracker for the inventory
        }

        protected virtual void OnDisable()
        {
            // todo: Remove the tracker for the inventory
        }

        
        // This method is called when the inventory is updated
        protected virtual void OnTrigger(float amount)
        {
            _trackingText.text = amount % 1 == 0 ? ((int)amount).ToString() : amount.ToString("F1") + endText;
        }
    }
}
