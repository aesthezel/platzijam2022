using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterScript : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveForce;
    [SerializeField] public GameObject Freddier;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Freddy"){
            Freddier.transform.position = new Vector3(11.83f, 8.598f, 12.55f);
        }
    }
}
