using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //[SerializeField] private float gravity;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] float groundCheckDistance;

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
        Jump();
        Move();
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
            rigidBody.AddForce(new Vector3(0f, jumpSpeed));
        }


    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, groundCheckDistance);
    }

    void Move()
    {
        float moveSpeed = Input.GetKeyDown(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxis("Horizontal") != 0)
        {
            moveVelocity += transform.right* moveSpeed * Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            moveVelocity += transform.forward * moveSpeed * Input.GetAxis("Vertical");
        }

        rigidBody.velocity = new Vector3(moveVelocity.x,rigidBody.velocity.y, moveVelocity.z);
    }
}
