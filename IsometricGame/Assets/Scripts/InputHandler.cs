using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static Action<Vector3> ClickedOnTheMap;
    [SerializeField] private LayerMask groundMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundMask))
            {
                ClickedOnTheMap?.Invoke(hitInfo.point);
            }
        }
    }
}
