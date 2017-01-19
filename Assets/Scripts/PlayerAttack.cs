using UnityEngine;
using System.Collections;
using InControl;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    private bool punching = false;

    [SerializeField] float attackTimer = 0f;
    [SerializeField] float attackCooldown = 0.3f;

    public Collider2D attackTrigger;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        punching = Input.GetButtonDown("Fire1");

        if(punching == true && attacking == false)
        {
            attacking = true;
            attackTimer = attackCooldown;

            attackTrigger.enabled = true;
        }

        if(attacking)
        {
            if(attackTimer > 0) //Can't spam the attack too much
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        anim.SetBool("Punch", attacking);
    }
}
