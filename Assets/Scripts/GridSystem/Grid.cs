using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<T>
{
    private int height;
    private int width;
    private T[,] gridArray;

    public Grid(int height, int width)
    {
        this.height = height;
        this.width = width;
        gridArray = new T[width, height];
    
        for(int i = 0; i < gridArray.GetLength(0); ++i) {
            for(int j = 0; j < gridArray.GetLength(1); ++j) {
                Debug.Log($"{i}, {j}");
            }
        }
    }
}
