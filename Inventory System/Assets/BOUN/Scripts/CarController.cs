using System.Collections.Generic;
using DG.Tweening;
using EventModule;
using InventoryModule;
using UnityEngine;

namespace BOUN.Scripts
{
    public class CarController : MonoBehaviour
    {
        public GameObject car;
        public LineRenderer lineRenderer;
        private List<Vector3> controlPoints = new List<Vector3>();
        private bool isMoving = false;

        void Start()
        {
            controlPoints.Add(new Vector3(car.transform.position.x, .1f, car.transform.position.z));
            EventController.AddEventListener<OnPointSelected>(data => AddPoint(data.point));
            EventController.AddEventListener<OnPathConfirmed>(data => MoveCar());
        }

        void OnDestroy()
        {
            EventController.RemoveEventListener<OnPointSelected>(data => AddPoint(data.point));
            EventController.RemoveEventListener<OnPathConfirmed>(data => MoveCar());
        }
    
        void AddPoint(Vector3 point)
        {
            if (isMoving)
            {
                return;
            }
            point.y = .1f;
            var lastDistance = Vector3.Distance(controlPoints[^1], point);
            // todo: Check if the distance between the last point and the new point is less than the remaining fuel
            var remainingFuel = InventoryHelper.GetInventoryItem(InventoryType.Fuel);
            if (lastDistance > .5f && lastDistance < remainingFuel)
            {
                // todo: If the distance is valid, spend the fuel and add the point to the path
                controlPoints.Add(point);
                UpdateLineRenderer();
                InventoryHelper.TrySpendItem(InventoryType.Fuel, lastDistance);
            }
        }
    
        void MoveCar()
        {
            if (isMoving || controlPoints.Count < 2)
            {
                return;
            }
            isMoving = true;
            var duration = GetPathLength() / 10f;
            car.transform.DOPath(controlPoints.ToArray(), duration, PathType.CatmullRom)
                .SetEase(Ease.Linear)
                .SetLookAt(0.01f)
                .OnComplete(() =>
                {
                    isMoving = false;
                    ClearPath();
                    EventController.TriggerEvent(new OnPathFinished());
                    Debug.Log("Car reached the end of the path");
                });
        }
    
        void UpdateLineRenderer()
        {
            lineRenderer.positionCount = controlPoints.Count;
            lineRenderer.SetPositions(controlPoints.ToArray());
        }

        void ClearPath()
        {
            var lastPoint = controlPoints[^1];
            controlPoints.Clear();
            controlPoints.Add(lastPoint);
        }
    
        float GetPathLength()
        {
            float length = 0f;
            for (int i = 1; i < controlPoints.Count; i++)
            {
                length += Vector3.Distance(controlPoints[i - 1], controlPoints[i]);
            }
            return length;
        }
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coin"))
            {
                var collectable = other.GetComponent<Collectable>();
                if (collectable == null)
                {
                    return;
                }
                collectable.Collect();

                if (collectable.type == InventoryType.Coin)
                {
                    // todo: Add the coin to the inventory
                    InventoryHelper.AddInventoryItem(InventoryType.Coin, 1);

                    Debug.Log("Car collected a coin!");
                }
                // todo: Add the fuel to the inventory if the collectable is a fuel
                if (collectable.type == InventoryType.Fuel)
                {
                    InventoryHelper.AddInventoryItem(InventoryType.Fuel, 10);
                    Debug.Log("Car collected fuel!");
                }
            }
        }
    }
}