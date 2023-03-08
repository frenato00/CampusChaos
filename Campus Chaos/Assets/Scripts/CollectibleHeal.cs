using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHeal : MonoBehaviour
{
    [SerializeField]
    private int health = 15;

    private bool hidden = false;
    private float respawnTime = 60f;
    private float timer = 0f;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hidden){
            timer+=Time.deltaTime;
            if(timer >= respawnTime) {
                timer = 0;
                hidden = false;
                // this.gameObject.SetActive(true);
                this.gameObject.GetComponent<Collider2D>().enabled=true;
                this.gameObject.GetComponent<Renderer>().enabled=true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")){
            collider.GetComponent<Health>().Heal(health);
            this.gameObject.GetComponent<Collider2D>().enabled=false;
            this.gameObject.GetComponent<Renderer>().enabled=false;
            hidden=true;
        }
    }

}
