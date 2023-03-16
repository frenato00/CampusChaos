using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;


    private bool isPoweredUp = false;
    private float powerTimeLimit=10f;
    private float powerTimer = 0f;
    [SerializeField] private HealthBar staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.GameIsPaused){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
            if (attacking)
            {
                timer += Time.deltaTime;

                if(timer >= timeToAttack) {
                    timer = 0;
                    attacking = false;
                    attackArea.SetActive(attacking);
                }
            }
            if(isPoweredUp){
                powerTimer+=Time.deltaTime;
                if(powerTimer>=powerTimeLimit){
                    powerTimer=0;
                    isPoweredUp=false;
                    attackArea.transform.GetComponent<AttackArea>().setDamage(10);
                }
                staminaBar.SetSize(1-(powerTimer/powerTimeLimit));
            }else{
                staminaBar.SetSize(0f);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

    public void Boost(){
        powerTimer=0;
        isPoweredUp=true;
        attackArea.transform.GetComponent<AttackArea>().setDamage(20);
    }
}
