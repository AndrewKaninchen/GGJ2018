using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunController : WeaponController
{
    public LaserGunStats stats;
    public Transform barrel;

    public LineRenderer lineRenderer;
    private bool isInCooldown;

    private void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    public override void Fire()
    {
        //if (!isInCooldown)
        {
            StartCoroutine(Cooldown(stats.cooldown));
            Ray ray = new Ray(barrel.position, barrel.forward * stats.range);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                lineRenderer.SetPositions(new Vector3[] { barrel.position, hit.point });
            }
            else
                lineRenderer.SetPositions(new Vector3[] { barrel.position, barrel.forward * stats.range });

            DrawBeam();
        }
    }
   
    public IEnumerator DrawBeam()
    {
        float duration = 1f;
        float remTime = duration;
        lineRenderer.enabled = true;

        while (remTime > 0)
        {
            Debug.DrawLine(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1));
            //lineRenderer.widthMultiplier = remTime / duration;
            remTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        lineRenderer.enabled = false;
    }

    public IEnumerator Cooldown(float time)
    {
        isInCooldown = true;
        yield return new WaitForSeconds(time);
        isInCooldown = false;
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        
    }
}
