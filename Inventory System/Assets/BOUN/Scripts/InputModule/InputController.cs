using EventModule;
using UnityEngine;

namespace InputModule
{
    public class InputController : MonoBehaviour
    {

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("InputMask")))
                {
                    EventController.TriggerEvent(new OnPointSelected {point = hit.point});
                }
            }
        
            if (Input.GetMouseButtonUp(0))
            {
                EventController.TriggerEvent(new OnPathConfirmed());
            }
        }
    }
}