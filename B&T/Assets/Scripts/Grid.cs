using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Grid
{
    private int _width;
    private int _height;
    private float _cellSize;
    private int[,] _gridArray;

     public Grid(int width, int height, float cellSize)
     {
        this._width = width;
        this._height = height;
        this._cellSize = cellSize;

        _gridArray = new int[width,height];
        for (int x=0; x< _gridArray.GetLength(0); x++) 
        {
            for (int y = 0; y< _gridArray.GetLength(1); y++) 
            {
                // Utils.Createtext(_gridArray[x, y].ToString(), null,  );
            }
        } 

        }   
}
