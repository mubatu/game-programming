using EventModule;
using InventoryModule;
using UnityEngine;

namespace BOUN.Scripts
{
    public class GameController : MonoBehaviour
    {
        private void Awake()
        {
            EventController.RemoveAllEvents();
            // todo: Set the fuel inventory to 30
            InventoryHelper.SetInventoryItem(InventoryType.Fuel, 30);
        }
    }
}