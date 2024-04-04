using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public Tilemap water;
    public Tilemap grass;
    public RuleTile buildingTile;


    // Start is called before the first frame update
    void Start()
    {
        BuildGroundAt(new Vector3Int(0, 0));
        BuildGroundAt(new Vector3Int(0, 1));
        BuildGroundAt(new Vector3Int(0, 2));
        // water.SetTile(position, null);
    }

    public void BuildGroundAt(Vector3Int position) {
        Debug.Log("Inside a BuildGroundAt");
        if (!grass.HasTile(position)) {
            Debug.Log("Grass doesn't have tile at that position, building");
            water.SetTile(position, null);
            grass.SetTile(position, buildingTile);
        }
    }
}
