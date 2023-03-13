using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    private int RETURN_SPEED = 25;

    private GameObject player;
    private bool left = false;

    [SerializeField]
    private int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Return();
    }

    private void Return()
    {
        GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * RETURN_SPEED);
        // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, RETURN_SPEED * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerBody"))
        {
            if (left) Destroy(gameObject);
        }
        else if (!collider.CompareTag("Player") && collider.GetComponent<Health>() != null)
        {
            collider.GetComponent<Health>().Damage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerBody"))
        {
            left = true;
        }
    }
}