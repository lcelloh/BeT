using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;

public class GridBuilding : MonoBehaviour
{
    [SerializeField] Transform testBuilding;
    private GridXZ<GridObject> grid;

    [SerializeField] int gridWidth = 12;
    [SerializeField] int gridHeight = 9;
    [SerializeField] float cellsize = 10f;

    private void Awake()
    {
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellsize, Vector3.zero, (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z));
    }
    
    public class GridObject
    {
        private GridXZ<GridObject> _grid;
        private int _x;
        private int _z;
        private Transform _transform;

        public GridObject(GridXZ<GridObject> grid, int x, int z)
        {
            this._grid = grid;
            this._x = x;
            this._z = z;
        }
        public void SetTransform(Transform transform) 
        {
            this._transform = transform;
        }
        public void ClearTransform()
        {
            _transform = null;
        }

        public bool CanBuild()
        {
            return _transform == null;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            grid.GetXZ(Mouse3D.GetMousePosition3D(), out int x, out int z);
            
            GridObject gridObject = grid.GetObject(x, z);
            if (gridObject.CanBuild()) 
            { 
                Instantiate(testBuilding, grid.GetWorldPositionGrid(x, z), Quaternion.identity);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            grid.GetXZ(Mouse3D.GetMousePosition3D(), out int x, out int z);
            
            GridObject gridObject = grid.GetObject(x, z);
            
            if (gridObject.CanBuild())
            {
                Debug.Log("ok");
                gridObject.ClearTransform();
            }
        }
    }
}


