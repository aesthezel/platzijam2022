using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //[SerializeField] private float gravity;
    [SerializeField] private float jumpSpeed;
    private Rigidbody body;

    [SerializeField] float groundCheckDistance;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
        Jump();
    }

    void Fall()
    {
        //gameObject.transform.Translate(-this.transform.up * gravity * Time.deltaTime);
    }

    void Jump()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.Translate(this.transform.up * jumpSpeed * Time.deltaTime);
        }
        */

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            body.AddForce(new Vector3(0f, jumpSpeed));
        }

        
    }

    bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, groundCheckDistance);
    }
}
