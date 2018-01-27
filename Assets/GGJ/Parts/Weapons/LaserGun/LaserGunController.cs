﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunController : WeaponController
{
    public LaserGunStats stats;
    public Transform barrel;

    public ParticleSystem hitParticles;
    public LineRenderer lineRenderer;
    private bool isInCooldown;

    private float beamRemainingTime = 1f;

    private void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    public override void Fire()
    {
        if (!isInCooldown)
        {
            lineRenderer.enabled = true;
            beamRemainingTime = stats.beamDuration;
            isInCooldown = true;

            Ray ray = new Ray(barrel.position, barrel.forward * stats.range);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                lineRenderer.SetPositions(new Vector3[] { barrel.position, hit.point });
            }
            else
                lineRenderer.SetPositions(new Vector3[] { barrel.position, barrel.forward * stats.range });

            var healthManager = hit.transform.GetComponent<HealthManager>();
            if(healthManager)
            {
                healthManager.TakeDamage(stats.damage);
            }
        }
    }

    public void Update()
    {
        
        
        if(beamRemainingTime > 0)
        {
            Debug.DrawLine(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1));

            lineRenderer.widthMultiplier = stats.beamWidth * beamRemainingTime / stats.beamDuration;
            beamRemainingTime -= Time.deltaTime;
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.position = lineRenderer.GetPosition(1);
            //emitParams.startColor = Color.red;
            emitParams.startSize = 0.8f;

            hitParticles.Emit(emitParams,15);
        }
        else
        {
            lineRenderer.enabled = false;
            isInCooldown = false;
        }
    }
}
