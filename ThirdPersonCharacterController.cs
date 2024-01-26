using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{


    public float Speed;

    public float jumpForce;
    public float jumpCoolDown;
    public bool readyToJump;
    public Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        readyToJump = true;
    }



    //hyppy
    public KeyCode jumpKey = KeyCode.Space;




    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKey(jumpKey) && readyToJump)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCoolDown);
        }


    }

    private void Jump()
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);
        playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }


    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

       

    }




    
}
