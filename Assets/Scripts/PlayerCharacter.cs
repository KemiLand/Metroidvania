﻿using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] bool isTurnedRight = true;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void Move(float horizontal, bool jump)
    {
        transform.position += new Vector3(speed * horizontal * Time.deltaTime, 0.0f, 0.0f);

        if (horizontal > 0 && !isTurnedRight)
        {
            Flip();
        }
        else if (horizontal < 0 && isTurnedRight)
        {
            Flip();
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
