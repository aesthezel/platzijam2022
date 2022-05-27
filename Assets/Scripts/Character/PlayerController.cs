using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //[SerializeField] private float gravity;
    [SerializeField] private float jumpSpeed;
    private Rigidbody body;

    [SerializeField] float groundCheckDistance;

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

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
        Move();
        RotateCamera();
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
            moveVelocity += transform.forward * moveSpeed * Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            moveVelocity += -transform.right * moveSpeed * Input.GetAxis("Vertical");
        }

        body.velocity = new Vector3(moveVelocity.x,body.velocity.y, moveVelocity.z);
    }

    float pitch;
    float yaw;
    [SerializeField] public float rotationSpeed;

    public void RotateCamera()
    {
        pitch += rotationSpeed * Input.GetAxis("Mouse Y");
        yaw += rotationSpeed * Input.GetAxis("Mouse X");

        // Clamp pitch:
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Wrap yaw:
        while (yaw < 0f)
        {
            yaw += 360f;
        }
        while (yaw >= 360f)
        {
            yaw -= 360f;
        }

        // Set orientation:
        transform.eulerAngles = new Vector3(0f, yaw, - pitch);
    }



}
