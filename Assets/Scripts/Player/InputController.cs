using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject buildingHint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            Debug.Log("Key was pressed");
            buildingHint.GetComponent<BuildingHint>().BuildOnHint();
        }
    }
}
