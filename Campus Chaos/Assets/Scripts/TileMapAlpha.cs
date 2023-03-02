using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapAlpha : MonoBehaviour
{
    public Renderer tilemap;
    // Start is called before the first frame update
    void Start()
    {
        //  Color tmp = GetComponent<Tilemap>().color;
        // tmp.a = 0f;
        // GetComponent<Tilemap>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")){
            Color tmp = GetComponent<Renderer>().material.color;
            tmp.a = 0.5f;
            GetComponent<Renderer>().material.color = tmp;
            tilemap.material.color = tmp;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")){
            Color tmp = GetComponent<Renderer>().material.color;
            tmp.a = 1f;
            GetComponent<Renderer>().material.color = tmp;
            tilemap.material.color = tmp;
        }
    }
}
