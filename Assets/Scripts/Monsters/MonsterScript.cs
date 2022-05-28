using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveForce;

    private void Start()
    {
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }


    public void FollowTarget()
    {
        Vector3 dirVector = (target.transform.position - transform.position).normalized;
        rb.AddForce(dirVector * moveForce);
    }
}
