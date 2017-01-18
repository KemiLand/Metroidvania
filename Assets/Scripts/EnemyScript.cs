using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] float velocity = 0.2f;
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] float timeToDie = 0.8f;

    [SerializeField] Transform sightStart;
    [SerializeField] Transform sightEnd;
    [SerializeField] LayerMask detecting;

    [SerializeField] bool colliding;

    Animator anim;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(velocity, 0.0f, 0.0f);

        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, detecting);

        if(colliding)
        {
            Flip();
            velocity *= -1;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnDrawGizmos() //Draws a line showing what makes the enemy rotate
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(sightStart.position, sightEnd.position);
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
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
