using UnityEngine;
using System.Collections;
using InControl;

public class UserControl : MonoBehaviour
{

    PlayerCharacter pChar;

    float horizontal = 0.0f;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        pChar = GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        jump = Input.GetButtonDown("Jump");
        horizontal = Input.GetAxis("Horizontal");
        
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

    void FixedUpdate()
    {
        
    }
}
