using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouch : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    public static Vector3 TouchPoint {get; private set;}
    
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = _mainCamera.ScreenPointToRay(touch.position);

            if(Physics.Raycast(ray, out RaycastHit raycastHit, 100, layerMask))
            {
                TouchPoint = raycastHit.point;
            }
        }
    }
}
