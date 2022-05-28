using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{

    [SerializeField] private int maxAmmo;

    int currentAmmoQuantity;

    [SerializeField] private float shootDelay;
    [SerializeField] private float impulseDelay;
    [SerializeField] private Ammo ammoType;

    bool canShoot;

    bool canImpulse;

    [SerializeField] private Rigidbody body;

    [SerializeField] Transform barrelExitPoint;

    [SerializeField] public float ImpulseForce;

    [SerializeField] Camera cam;

    [SerializeField] GameObject Freddy;

    [SerializeField] GameObject ExplosionPoint;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        canImpulse = true;
        currentAmmoQuantity = maxAmmo;
    }

    private void Update()
    {
        Shoot();
        //Impulse();
        Reload();
        if (Input.GetMouseButtonDown(1))
        {
            Impulse();
        }
    }

    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentAmmoQuantity = maxAmmo;
        }
    }

    public void Shoot()
    {
        if(Input.GetMouseButton(0))
        {
            if (currentAmmoQuantity <= 0) return; 
            currentAmmoQuantity -= 1;

            if (!canShoot)
            {
                return;
            }

            StartCoroutine(ShootDelay(shootDelay));

            var bullet = Instantiate(ammoType, this.transform);

            bullet.transform.position = barrelExitPoint.position;
            bullet.transform.rotation = barrelExitPoint.rotation;
            bullet.transform.parent = null;
        }

    }

    public void Impulse()
    {
        body.AddExplosionForce(1000f, ExplosionPoint.transform.position, 10f);

    }

    IEnumerator ShootDelay(float time)
    {
        canShoot = false;
        yield return new WaitForSeconds(time);
        canShoot = true;
    }

    IEnumerator ImpulseDelay(float time)
    {
        canImpulse = false;
        yield return new WaitForSeconds(time);
        canImpulse = true;
    }

    void ShootFX()
    {

    }

    void ImpulseFX()
    {

    }

}
