using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private bool isActive = false;

    private int ACTIVE_DISTANCE = 5;

    [SerializeField]
    private GameObject throwable;

    [SerializeField]
    private float launchForce;

    [SerializeField]
    private Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.GameIsPaused){
            UpdateDirection();
            transform.GetChild(0).gameObject.SetActive(isActive);
            if (Input.GetMouseButtonDown(0) && GameObject.Find("Throwable(Clone)") == null)
            {
                Shoot();
            }
        }
    }

    private void UpdateDirection()
    {
        Vector2 playerPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;
        transform.right = direction;
        isActive = direction.magnitude <= ACTIVE_DISTANCE;
    }

    private void Shoot()
    {
        GameObject newThrowable = Instantiate(throwable, shotPoint.position, shotPoint.rotation);
        newThrowable.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}
