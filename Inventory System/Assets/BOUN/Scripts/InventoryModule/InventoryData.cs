using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryModule
{
    [CreateAssetMenu(fileName = "InventoryData", menuName = "Scriptable Objects/InventoryData", order = 5)]
    public class InventoryData : ScriptableObject
    {
        public List<InventoryDataItem> items;
    }

    [Serializable]
    public class InventoryDataItem
    {
        public InventoryType type;
        public float defaultValue;
    }
    
    public enum InventoryType
    {
        None,
        Coin,
        // todo: add more types here
        Fuel,
    }
}

