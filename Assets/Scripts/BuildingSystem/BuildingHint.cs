using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingHint : MonoBehaviour
{
    public Tilemap buildingHintTilemap;
    public GameObject player;

    public GameObject buildingSystem;

    private Vector3Int newSquarePos;
    public Vector3Int prevSquarePos = Vector3Int.zero;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, -Vector2.up, 1, layer);
        
        Vector2 lastMovementDirection = player.GetComponent<PlayerController>().LastMovementDirection;
        Vector3Int direction = new Vector3Int(Mathf.CeilToInt(lastMovementDirection.x), Mathf.CeilToInt(lastMovementDirection.y));
        newSquarePos = new Vector3Int(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y)) + direction;
        // Vector2Int lastMovementDirection = player.lastMovementDirection;

        
        buildingHintTilemap.SetTileFlags(prevSquarePos, TileFlags.LockColor);
        buildingHintTilemap.SetColor(prevSquarePos, Color.white);
        buildingHintTilemap.SetTileFlags(newSquarePos, TileFlags.None);
        buildingHintTilemap.SetColor(newSquarePos, Color.yellow);
        prevSquarePos = newSquarePos;
    }

    public void BuildOnHint() {
        Debug.Log($"Trying to build at {newSquarePos}");
        buildingSystem.GetComponent<BuildingSystem>().BuildGroundAt(newSquarePos);
        
    }
}
