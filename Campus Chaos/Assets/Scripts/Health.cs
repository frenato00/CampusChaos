using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;

    // Start is called before the first frame update
    void Start()
    {

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

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Damage amount must be a non negative integer");
        }

        health = Mathf.Max(0, health - amount);
        if (health == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Heal amount must be a non negative integer");
        }

        health = Mathf.Min(health + amount, MAX_HEALTH);
    }

    private void Die()
    {
        Debug.Log("DDDDEEEEAAADDDD");
        Destroy(gameObject);
    }
}
