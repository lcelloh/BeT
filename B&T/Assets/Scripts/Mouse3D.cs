using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse3D : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    
    public static Mouse3D Instance { get; private set; }
    public  static Camera _camera = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _layerMask)) 
        { 
            transform.position = raycastHit.point;
        }
    }

    public static Vector3 GetMousePosition3D() => Instance.GetMousePosition3DInstace();
    
    private Vector3 GetMousePosition3DInstace()
    {
        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _layerMask))
        {
            return raycastHit.point;
        }else
        {
            return Vector3.zero;
        }
    }
}

