using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    public static Action<Vector3> ClickedOnTheMap;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform targetPoint; 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundMask))
            {
                if(EventSystem.current.IsPointerOverGameObject()) return;
                targetPoint.position = hitInfo.point;
                ClickedOnTheMap?.Invoke(hitInfo.point);
            }
        }
    }
}
