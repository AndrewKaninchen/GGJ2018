using UnityEngine;

public class MissileGun : WeaponController
{

    public float damage = 25f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    //Temporário, depois trocar pra usar o controller ou sei lá
    private bool isAI = false;

    private void Start()
    {
        if (!muzzleFlash) muzzleFlash = GetComponentInChildren<ParticleSystem>();

        if (!fpsCam) fpsCam = transform.parent.Find("CameraHolder").GetComponent<Camera>();
    }

    public override void Fire()
    {
        Debug.Log(muzzleFlash);
        muzzleFlash.Play();

        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Default", isAI ? "Player" : "AI");
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, layerMask: layerMask.value))
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
