using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    Camera _frontalCamera;
    [SerializeField] Camera _topDownCamera;

    void Awake()
    {
        _frontalCamera = Camera.main;
       _frontalCamera.enabled = true;
        _topDownCamera.enabled = false;
        Mouse3D._camera = _frontalCamera;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchCameras();
        }
    }

    void SwitchCameras() 
    {
        if (_frontalCamera.enabled)
        { 
            _frontalCamera.enabled = false;
            _topDownCamera.enabled = true;
            Mouse3D._camera = _topDownCamera;
        }
        else if (!_frontalCamera.enabled)
        {
            _topDownCamera.enabled = false;
            _frontalCamera.enabled = true;
            Mouse3D._camera = _frontalCamera;
        }
    }
}
