using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHeal : MonoBehaviour
{
    [SerializeField]
    private int health = 15;

    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")){
                collider.GetComponent<Health>().Heal(health);
            this.gameObject.SetActive(false);
        }
    }

}
