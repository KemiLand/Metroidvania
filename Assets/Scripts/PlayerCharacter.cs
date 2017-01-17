using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] bool isTurnedRight = true;
    [SerializeField] bool grounded = false;
    [SerializeField] float groundRadius = 0.01f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float jumpForce = 350f;
    [SerializeField] int maxHealth = 5;
    public int currentHealth; // Public because of the HudScript

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    
	void FixedUpdate ()
    {
        //Checks if the player is on the ground or not
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}

    public void Move(float horizontal, bool jump)
    {
        transform.position += new Vector3(speed * horizontal * Time.deltaTime, 0.0f, 0.0f);
        

        //Horizontal is used to start the walking animation
        anim.SetFloat("Speed", Mathf.Abs(horizontal));

        if (horizontal > 0 && !isTurnedRight)
        {
            Flip();
        }
        else if (horizontal < 0 && isTurnedRight)
        {
            Flip();
        }

        if (grounded && jump) //Jump when grounded and button is pressed
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
        }
    }

    public void Attack(bool punch)
    {
        anim.SetBool("Punch", punch);
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        isTurnedRight = !isTurnedRight;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
    }

    void Die() //Reloads the first scene upon death
    {
        SceneManager.LoadScene(0);
    }
}
