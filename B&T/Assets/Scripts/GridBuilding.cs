using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class GridBuilding : MonoBehaviour
{
    private GridXZ<GridObject> grid;

    private void Awake()
    {
        int gridWidth = 12;
        int gridHeight = 9;
        float cellsize = 10f;

        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellsize, new Vector3(0, -10), (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z));
    }
    
    public class GridObject
    {
        private GridXZ<GridObject> _grid;
        private int _x;
        private int _z;

        public GridObject(GridXZ<GridObject> grid, int x, int z)
        {
            this._grid = grid;
            this._x = x;
            this._z = z;
        }
    }
}


