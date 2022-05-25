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

    [SerializeField] Transform barrelExitPoint;


    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        canImpulse = true;
    }

    public void Reload()
    {
        currentAmmoQuantity = maxAmmo;
    }

    public void Shoot()
    {

        currentAmmoQuantity -= 1;

        if (!canShoot) return;

        StartCoroutine(ShootDelay(shootDelay));

        var bullet = Instantiate(ammoType,this.transform);
        bullet.transform.position = barrelExitPoint.position;
        bullet.transform.rotation = barrelExitPoint.rotation;
        bullet.transform.parent = null;
    }

    public void Impulse()
    {
        if (!canImpulse) return;

        StartCoroutine(ShootDelay(impulseDelay));
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
