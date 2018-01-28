using System.Collections;
using UnityEngine;

public class GunSaw : WeaponController
{

    public float damage = 25f;
    public float range = 100f;
    public float rateOfFire = 15f;

    public GameObject saw;

    public Camera fpsCam;

    public GameObject FighterSaw;
    public GameObject FighterSaw1;
    public GameObject FighterSaw2;
    public GameObject FighterSaw3;

    //public float Bullet_Forward_Force;

    //public ParticleSystem muzzleFlash;

    //Temporário, depois trocar pra usar o controller ou sei lá
    private bool isAI = false;

    private bool isInCooldown;

    private void Start()
    {
        //if (!muzzleFlash) muzzleFlash = GetComponentInChildren<ParticleSystem>();

        if (!fpsCam) fpsCam = transform.parent.Find("CameraHolder").GetComponent<Camera>();
    }

    private IEnumerator Cooldown()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(0f / rateOfFire);
        isInCooldown = false;
    }

    public override void Fire()
    {
        if (!isInCooldown)
        {

            saw.SetActive(true);

            FighterSaw.transform.Rotate(Vector3.forward * 500f * Time.deltaTime);
            FighterSaw1.transform.Rotate(Vector3.forward * 500f * Time.deltaTime);
            FighterSaw2.transform.Rotate(Vector3.forward * 500f * Time.deltaTime);
            FighterSaw3.transform.Rotate(Vector3.forward * 500f * Time.deltaTime);

            //StartCoroutine(Cooldown());
        }
        //saw.SetActive(false);
    }
}
