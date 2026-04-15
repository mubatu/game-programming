using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventoryModule
{
    public static class InventoryHelper
    {
        private const string INVENTORY_PREFIX = "inventory_";

        private static string GetKeyForType(InventoryType type) => INVENTORY_PREFIX + type;

        private static Dictionary<InventoryType, Action<float>> _events = new();

        private static List<InventoryDataItem> _items;

        private static List<InventoryDataItem> Items
        {
            get
            {
                if (_items != null) return _items;

                _items = Resources.Load<InventoryData>("InventoryData").items;
                return _items;
            }
        }

        static InventoryHelper()
        {
            foreach (var item in Items)
            {
                _events[item.type] = null;
            }
        }

        public static void RegisterTracker(InventoryType type, Action<float> callback)
        {
            _events[type] += callback;
            callback?.Invoke(GetInventoryItem(type));
        }

        public static void RemoveTracker(InventoryType type, Action<float> callback)
        {
            _events[type] -= callback;
        }

        private static void TriggerTracker(InventoryType type)
        {
            _events[type]?.Invoke(GetInventoryItem(type));
        }

        public static void AddInventoryItem(InventoryType type, float amount)
        {
            var newValue = Mathf.Max(0, GetInventoryItem(type)) + amount;
            SetInventory(type, newValue);
            TriggerTracker(type);
        }

        public static bool TrySpendItem(InventoryType type, float amount)
        {
            if (!HasEnoughAmount(type, amount)) return false;

            var newValue = Mathf.Max(GetInventoryItem(type) - amount, 0);
            SetInventory(type, newValue);
            TriggerTracker(type);
            return true;
        }

        public static float GetInventoryItem(InventoryType type)
        {
            var defaultValue = GetDefaultValue(type);
            return PlayerPrefs.HasKey(GetKeyForType(type)) ? PlayerPrefs.GetFloat(GetKeyForType(type), defaultValue) : defaultValue;
        }

        public static void SetInventoryItem(InventoryType type, float amount)
        {
            SetInventory(type, amount);
            TriggerTracker(type);
        }

        private static float GetDefaultValue(InventoryType type)
        {
            return Items.First(x => x.type == type).defaultValue;
        }

        private static bool HasEnoughAmount(InventoryType type, float amount) => GetInventoryItem(type) >= amount;

        private static void SetInventory(InventoryType type, float value)
        {
            PlayerPrefs.SetFloat(GetKeyForType(type), value);
        }
    }
}
