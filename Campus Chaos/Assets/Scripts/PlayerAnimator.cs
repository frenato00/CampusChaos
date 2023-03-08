using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;

    Transform healthBar;
    float barX;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = transform.Find("HealthBarPlayer");
        barX = healthBar.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.moveDir.x!=0 || playerMovement.moveDir.y!=0)
        {
            animator.SetBool("Move", true);
            SpriteDirectionChecker();
        }
        else{
            animator.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecker()
    {
        if(playerMovement.lastHorizontalVector <0){
            transform.localScale = new Vector3(-1f, transform.localScale.y);
            healthBar.transform.localScale = new Vector3(-1f*barX, healthBar.transform.localScale.y);
        }
        else{
            transform.localScale = new Vector3(1f, transform.localScale.y);
            healthBar.transform.localScale = new Vector3(barX, healthBar.transform.localScale.y);
        }
    }
}
