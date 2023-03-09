using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    private int RETURN_SPEED = 20;

    private GameObject player;
    private bool left = false;

    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Return();
    }

    private void Return()
    {
        Debug.Log("Player: ", player);
        rigidbody2D.AddForce((player.transform.position - transform.position).normalized * RETURN_SPEED);
        // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, RETURN_SPEED * Time.deltaTime);
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         if (left) Destroy(gameObject);
    //     }
    //     else if (collision.gameObject.GetComponent<Health>() != null)
    //     {
    //         Health health = collision.gameObject.GetComponent<Health>();
    //         health.Damage(damage);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (left) Destroy(gameObject);
        }
        else if (collider.GetComponent<Health>() != null)
        {
            collider.GetComponent<Health>().Damage(damage);
        }
        Debug.Log(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            left = true;
        }
    }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         left = true;
    //     }
    // }
}