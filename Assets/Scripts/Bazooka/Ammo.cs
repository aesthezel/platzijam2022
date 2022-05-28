using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    float damage;

    [SerializeField] private float damageRange;

    float blastRadious;

    [SerializeField] private float ammoSpeed;
    Vector3 initialPos;

    private void Update()
    {
        Move();
        CheckEndRange();
    }

    public void Move()
    {
        transform.Translate(this.transform.up * ammoSpeed * Time.deltaTime,Space.World);   
    }

    public abstract void ExplosionFX();

    public void CheckEndRange()
    {
        if(Vector3.Distance(initialPos,transform.position) > damageRange) Destroy(gameObject);
    }
}
