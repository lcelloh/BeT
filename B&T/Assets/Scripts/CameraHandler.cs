using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    Camera _isometricCamera;
    [SerializeField] Camera _frontalCamera;

    void Awake()
    {
        _isometricCamera = Camera.main;
       _isometricCamera.enabled = true;
        _frontalCamera.enabled = false;
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
        if (_isometricCamera.enabled)
        {
            _isometricCamera.enabled = false;
            _frontalCamera.enabled = true;
        }
        else if (!_isometricCamera.enabled)
        {
            _frontalCamera.enabled = false;
            _isometricCamera.enabled = true;
        }
    }
}
