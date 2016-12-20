using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] bool isTurnedRight = true;
    [SerializeField] bool grounded = false;
    [SerializeField] float groundRadius = 0.2f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float jumpForce = 350f;

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    
	void FixedUpdate ()
    {
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

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        isTurnedRight = !isTurnedRight;
    }
}
