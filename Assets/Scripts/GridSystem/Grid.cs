using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid<T>
{
    private int height;
    private int width;
    private T[,] gridArray;
    private float cellSize;
    private Vector3 originPosition;
    private TextMesh[,] debugTextArray;

    public Grid(int height, int width, float cellSize, Vector3 originPosition)
    {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        gridArray = new T[width, height];

        debugTextArray = new TextMesh[width, height];
    
        for(int i = 0; i < gridArray.GetLength(0); ++i) {
            for(int j = 0; j < gridArray.GetLength(1); ++j) {
                Debug.Log($"{i}, {j}");
                UtilsClass.CreateWorldText(gridArray[i, j].ToString(), null, GetWorldPosition(i, j) + new Vector3(1, 1, 0) / 2, 4, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.white, 100f);
                
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, T value) {
        if (x >= 0 && y >= 0 && x < width && y > height) {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = value.ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, T value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
    }

    public T GetValue(int x, int y) {
        if(x >= 0 && y >= 0 && x < width && y > height) {
            return gridArray[x, y];
        } else {
            return default;
        }
    }

    public T GetValue(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
