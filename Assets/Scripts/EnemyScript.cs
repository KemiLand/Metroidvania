using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] float velocity = 0.2f;
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] float timeToDie = 0.8f;
    [SerializeField] int enemyDamage = 3;
    private int playerHit = 0; // Preventing the monster to spam hits on the player

    [SerializeField] Transform sightStart;
    [SerializeField] Transform sightEnd;
    [SerializeField] LayerMask detecting;

    [SerializeField] Transform playerCheckStart;
    [SerializeField] Transform playerCheckEnd;
    [SerializeField] LayerMask detectingPlayer;

    [SerializeField] bool colliding;
    [SerializeField] bool collidingPlayer;

    private PlayerCharacter player;

    Animator anim;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(velocity, 0.0f, 0.0f);

        //Checks if the monster walked into a wall
        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, detecting);

        //Check if the monster walked into the player character
        collidingPlayer = Physics2D.Linecast(playerCheckStart.position, playerCheckEnd.position, detectingPlayer);

        if (colliding)
        {
            Flip();
            velocity *= -1;
        }

        if(collidingPlayer)
        {
            if (playerHit == 0)
            {
                playerHit = 1;
                player.Damage(enemyDamage);
            } 
        }
        else
        {
            playerHit = 0;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void OnDrawGizmos() 
    {
        //Draws a line showing what makes the enemy rotate
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(sightStart.position, sightEnd.position);

        //Draws a line showing where the player gets hit
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(playerCheckStart.position, playerCheckEnd.position);
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        //GetComponent<Animation>().Play("Player_RedFlash");
    }

    void Die()
    {
        velocity = 0.0f;
        anim.SetBool("killed", true);
        Destroy(this.gameObject, timeToDie);
        gameObject.tag = "Dead";
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
