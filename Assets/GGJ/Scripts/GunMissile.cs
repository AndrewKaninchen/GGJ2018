using System.Collections;
using UnityEngine;

public class GunMissile : WeaponController
{

    public float damage = 25f;
    public float range = 100f;
    public float rateOfFire = 15f;

    public Camera fpsCam;

    public GameObject Missile;
    public GameObject Missile_Laucher;
    public float Bullet_Forward_Force;

    public ParticleSystem muzzleFlash;

    //Temporário, depois trocar pra usar o controller ou sei lá
    private bool isAI = false;

    private bool isInCooldown;

    private void Start()
    {
        if (!muzzleFlash) muzzleFlash = GetComponentInChildren<ParticleSystem>();

        if (!fpsCam) fpsCam = transform.parent.Find("CameraHolder").GetComponent<Camera>();
    }

    private IEnumerator Cooldown()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(5f / rateOfFire);
        isInCooldown = false;
    }

    public override void Fire()
    {
        if (!isInCooldown)
        {
            Debug.Log(muzzleFlash);
            muzzleFlash.Play();

            //RaycastHit hit;
            LayerMask layerMask = LayerMask.GetMask("Default", isAI ? "Player" : "AI");

            GameObject temp_missile;
            temp_missile = Instantiate(Missile, Missile_Laucher.transform.position, Missile_Laucher.transform.rotation) as GameObject;

            Rigidbody temp_rigidbody;
            temp_rigidbody = temp_missile.GetComponent<Rigidbody>();

            //temp_rigidbody.AddForce(transform.forward * Bullet_Forward_Force);
            temp_missile.transform.rotation = fpsCam.transform.rotation;
            temp_rigidbody.velocity = fpsCam.transform.forward * Bullet_Forward_Force;

            Destroy(temp_missile, 4.0f);

            /*if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, layerMask: layerMask.value))
            {
                Debug.Log(hit.transform);

                HealthManager target = hit.transform.GetComponent<HealthManager>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }*/

            StartCoroutine(Cooldown());
        }
    }
}
