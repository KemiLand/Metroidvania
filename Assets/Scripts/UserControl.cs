using UnityEngine;
using System.Collections;
using InControl;

public class UserControl : MonoBehaviour {

    PlayerCharacter pChar;

    float horizontal = 0.0f;
    bool jump = false;
    bool crouch = false;
    bool punch = false;


    void Awake()
    {
        pChar = GetComponent<PlayerCharacter>();
    }
    void Start()
    {
        
    }

  
    void FixedUpdate()
    {
        jump = Input.GetButtonDown("Jump");
        horizontal = Input.GetAxis("Horizontal");
        punch = Input.GetButton("Fire1");
        

        if (InputManager.Devices.Count > 0)
        {
            var inputDevice = InputManager.Devices[0];
            horizontal += inputDevice.LeftStickX;
        }

        if (Mathf.Abs(horizontal) > 1.0f) //capping horizontal
        {
            horizontal = Mathf.Sign(horizontal);
        }

        pChar.Move(horizontal, jump);
        
    }

    void Update()
    {
        pChar.Attack(punch);
    }
}
