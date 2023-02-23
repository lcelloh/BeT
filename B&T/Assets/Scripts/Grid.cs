using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GridXZ<TGridObject>
{


    public static GridXZ<TGridObject> Instance { get; private set; }

    private int _width;
    private int _height;
    private float _cellSize;
    private Vector3 _originPosition;
    private TGridObject[,] _gridArray;

    public GridXZ(int width, int height, float cellSize, Vector3 originPosition, Func<GridXZ<TGridObject>, int, int, TGridObject> createGridObject)
     {
        // REMEMBER : add event for object changed

        this._width = width;
        this._height = height;
        this._cellSize = cellSize;
        this._originPosition = originPosition;

        _gridArray = new TGridObject[width,height];
        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < _gridArray.GetLength(1); z++)
            {
                _gridArray[x,z] = createGridObject(this, x, z); 
            }
        }

        bool showDebug = true;
        if (showDebug)
        {
            TextMesh[,] debugTextArray = new TextMesh[width,height];
            for (int x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (int z = 0; z < _gridArray.GetLength(1); z++)
                {
                    Utils.CreateText(Utils.PositionText(x, z), null,GetWorldPositionGrid(x, z) + new Vector3(_cellSize, 0, cellSize) * .5f , 20, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPositionGrid(x, z), GetWorldPositionGrid(x, z + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPositionGrid(x, z), GetWorldPositionGrid(x + 1, z), Color.white, 100f);
                }
            }

            // Draw Grid Boxes
            Debug.DrawLine(GetWorldPositionGrid(0, _height), GetWorldPositionGrid(_width, _height), Color.white, 100f);
            Debug.DrawLine(GetWorldPositionGrid(_width, 0), GetWorldPositionGrid(_width, _height), Color.white, 100f);
        }
     }

    // Get Position
    public Vector3 GetWorldPositionGrid(int x, int z)
    {
        return new Vector3(x, 0, z) * _cellSize + _originPosition;
    }

    public void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosition - _originPosition).x / _cellSize);
        z = Mathf.FloorToInt((worldPosition - _originPosition).z / _cellSize);
    }

    // Get Object
    public TGridObject GetObject(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < _width && z < _height)
        {
            return _gridArray[x, z];
        }
        else
        {
            return default(TGridObject);
        }
    }
    public TGridObject GetObject(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        return GetObject(x, z);
    }

    // Set Object
    public void SetObject(int x, int z, TGridObject value)
    {
        if (x >= 0 && z >= 0 && x < _width && z < _height)
        {
            _gridArray[x, z] = value ;
        }
    }
    public void SetObject(Vector3 worldPosition, TGridObject value)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetObject(x, z, value);
    }    
}
