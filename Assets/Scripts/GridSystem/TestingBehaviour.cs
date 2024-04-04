using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestingBehaviour : MonoBehaviour
{
    public RuleTile tile;
    private Tilemap tilemap;

    private void Awake() {
        tilemap = GetComponent<Tilemap>();
        tilemap.SetTile(new Vector3Int(0, 0), tile);
        tilemap.SetTile(new Vector3Int(1, 0), tile);
        tilemap.SetTile(new Vector3Int(2, 0), tile);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
