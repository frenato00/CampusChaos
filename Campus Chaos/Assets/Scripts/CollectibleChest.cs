using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleChest : MonoBehaviour
{
    [SerializeField]
    private int money = 500;

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
                ScoreHandler.IncreaseScore(money);
            this.gameObject.SetActive(false);
        }
    }

}
