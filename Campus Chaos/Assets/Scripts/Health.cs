using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] public GameOver gameOver;

    [SerializeField] private HealthBar healthBar;

    private int MAX_HEALTH = 100;

    private Color originalColor;
    

    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        // //Debugging
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     Damage(10);
        // }

        // if (Input.GetKeyDown(KeyCode.H))
        // {
        //     Heal(10);
        // }
    }

    public void SetHealth(int maxHealth, int health) {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    public IEnumerator VisualIndicator(Color color) {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = originalColor;
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Damage amount must be a non negative integer");
        }

        health = Mathf.Max(0, health - amount);
        if(healthBar)
            healthBar.SetSize((float)this.health/this.MAX_HEALTH);

        if (health == 0)
        {
            Die();
        }

        StartCoroutine(VisualIndicator(Color.red));
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Heal amount must be a non negative integer");
        }

        health = Mathf.Min(health + amount, MAX_HEALTH);
        if(healthBar)
            healthBar.SetSize((float)this.health/this.MAX_HEALTH);
        StartCoroutine(VisualIndicator(Color.green));
    }

    private void Die()
    {
        if(gameObject.tag=="Enemy"){
            ScoreHandler.IncreaseScore(this.MAX_HEALTH);
        }else if(gameObject.tag=="Player"){
            gameOver.Pause();
        }
        Destroy(gameObject);
    }
}
