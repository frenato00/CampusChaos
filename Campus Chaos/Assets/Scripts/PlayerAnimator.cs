using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;

    Transform healthBar;
    Transform staminaBar;
    float healthX;
    float staminaX;
    float staminaXPos;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = transform.Find("HealthBarPlayer");
        staminaBar = transform.Find("StaminaBar");
        healthX = healthBar.transform.localScale.x;
        staminaX = staminaBar.transform.localScale.x;
        staminaXPos = staminaBar.transform.localPosition.x;
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
            healthBar.transform.localScale = new Vector3(-1f*healthX, healthBar.transform.localScale.y);
            staminaBar.transform.localScale = new Vector3(-1f*staminaX, staminaBar.transform.localScale.y);
            staminaBar.transform.localPosition = new Vector3(-1f*staminaXPos, staminaBar.transform.localPosition.y);
        }
        else{
            transform.localScale = new Vector3(1f, transform.localScale.y);
            healthBar.transform.localScale = new Vector3(healthX, healthBar.transform.localScale.y);
            staminaBar.transform.localScale = new Vector3(staminaX, staminaBar.transform.localScale.y);
            staminaBar.transform.localPosition = new Vector3(staminaXPos, staminaBar.transform.localPosition.y);

        }
    }
}
