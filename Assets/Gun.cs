﻿using UnityEngine;

public class Gun : WeaponController {

    public float damage = 25f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private void Start()
    {
        if(!muzzleFlash) muzzleFlash = GetComponentInChildren<ParticleSystem>();

        if (!fpsCam) fpsCam = transform.parent.Find("CameraHolder").GetComponent<Camera>();
    }

    public override void Fire ()
    {
        Debug.Log(muzzleFlash);
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform);

            HealthManager target = hit.transform.GetComponent<HealthManager>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
