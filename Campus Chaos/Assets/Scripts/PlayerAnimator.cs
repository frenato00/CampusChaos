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
    Transform aim;
    float healthX;
    float staminaX;
    float staminaXPos;
    float aimScale;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = transform.Find("HealthBarPlayer");
        staminaBar = transform.Find("StaminaBar");
        aim = transform.Find("Thrower");
        healthX = healthBar.transform.localScale.x;
        staminaX = staminaBar.transform.localScale.x;
        staminaXPos = staminaBar.transform.localPosition.x;
        aimScale = aim.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.moveDir.x != 0 || playerMovement.moveDir.y != 0)
        {
            animator.SetBool("Move", true);
            SpriteDirectionChecker();
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecker()
    {
        if (playerMovement.lastHorizontalVector < 0)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y);
            healthBar.transform.localScale = new Vector3(-1f * healthX, healthBar.transform.localScale.y);
            staminaBar.transform.localScale = new Vector3(-1f * staminaX, staminaBar.transform.localScale.y);
            staminaBar.transform.localPosition = new Vector3(-1f * staminaXPos, staminaBar.transform.localPosition.y);
            aim.transform.localScale = new Vector3(-1f * aimScale, aim.transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, transform.localScale.y);
            healthBar.transform.localScale = new Vector3(healthX, healthBar.transform.localScale.y);
            staminaBar.transform.localScale = new Vector3(staminaX, staminaBar.transform.localScale.y);
            staminaBar.transform.localPosition = new Vector3(staminaXPos, staminaBar.transform.localPosition.y);
            aim.transform.localScale = new Vector3(aimScale, aim.transform.localScale.y);
        }
    }
}
