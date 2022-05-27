using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{

    [SerializeField] private Camera _camera;

    float pitch;
    float yaw;
    [SerializeField] public float rotationSpeed;
    [SerializeField] Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveAim();
    }


    void moveAim()
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
        _camera.transform.eulerAngles = new Vector3(-pitch, yaw, 0f);
        body.transform.eulerAngles = new Vector3(0f, yaw, 0f);
    }
}
