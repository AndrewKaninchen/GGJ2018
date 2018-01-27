using System.Collections;
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
        Ray ray = new Ray(barrel.position, barrel.forward * stats.range);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            lineRenderer.SetPositions(new Vector3[] { barrel.position, hit.point });
        }
        else
            lineRenderer.SetPositions(new Vector3[] { barrel.position, barrel.forward * stats.range });
    }
   
    public void DrawBeam()
    {
        

        while (beamRemainingTime > 0f)
        {
            
        }
    }

    public void Update()
    {
        if(!isInCooldown && Input.GetKeyDown(KeyCode.K))
        {
            lineRenderer.enabled = true;
            beamRemainingTime = stats.beamDuration;
            isInCooldown = true;
            Fire();
        }
        
        if(beamRemainingTime > 0)
        {
            Debug.DrawLine(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1));

            lineRenderer.widthMultiplier = stats.beamWidth * beamRemainingTime / stats.beamDuration;
            beamRemainingTime -= Time.deltaTime;
            //var emitParams = new ParticleSystem.EmitParams();
            //emitParams.position = lineRenderer.GetPosition(1);

            //hitParticles.Emit(emitParams,1);
        }
        else
        {
            lineRenderer.enabled = false;
            isInCooldown = false;
        }
    }
}
