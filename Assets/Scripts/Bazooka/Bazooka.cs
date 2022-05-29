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

    [SerializeField] public int maxImpulseQuantity;
    private int currImpulseQuantity;
    

    bool canShoot;

    bool canImpulse;

    [SerializeField] private Rigidbody body;

    [SerializeField] private PlayerController bodyLogic;

    [SerializeField] Transform barrelExitPoint;

    [SerializeField] public float ImpulseForce;

    [SerializeField] Camera cam;

    [SerializeField] GameObject Freddy;

    [SerializeField] GameObject ExplosionPoint;

    [SerializeField] AudioManager audioManager;

    [SerializeField] AudioClip bazookaSound;

    [SerializeField] GameObject BOOOOOOM;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        canImpulse = true;
        currImpulseQuantity = maxImpulseQuantity;
    }

    private void Update()
    {
        //Shoot();
        //Impulse();
        if(bodyLogic.IsGrounded())Reload();
        if (Input.GetMouseButtonDown(0) && currImpulseQuantity > 0)
        {
            currImpulseQuantity -= 1;
            Impulse();
        }
    }

    public void Reload()
    {
        currImpulseQuantity = maxImpulseQuantity;
    }

    /*
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
    */

    public void Impulse()
    {
        body.velocity = Vector3.zero;
        Vector3 force = -ExplosionPoint.transform.forward.normalized * ImpulseForce;
        body.AddForce(force, ForceMode.VelocityChange);
        ImpulseFX();

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

    void ImpulseFX()
    {
        audioManager.SFXSource.PlayOneShot(bazookaSound);
        GameObject bum = Instantiate(BOOOOOOM,barrelExitPoint);
        Destroy(bum, 0.5f);
    }

}
