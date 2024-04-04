using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRunner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Grid<int> grid = new Grid<int>(60, 60, 1f, new Vector3(-30, -30));
    }
}
