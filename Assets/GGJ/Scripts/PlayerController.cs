using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {

    private BotController botController;
    private BotStatsHolder stats;
    //[SerializeField]
    //private Transform weaponTransform;
    private FirstPersonController firstPersonController;

    private Camera cam;

    private void Start()
    {
        botController = GetComponent<BotController>();
        stats = GetComponent<BotStatsHolder>();
        cam = GetComponentInChildren<Camera>();
        firstPersonController = GetComponent<FirstPersonController>();

        firstPersonController.m_WalkSpeed = stats.moveStats.speed;
        firstPersonController.m_RunSpeed = stats.moveStats.speed * 1.5f;

    }

    public void OnEnable()
    {
        GameManager.currentPlayerControlledBot = gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            foreach (WeaponController w in stats.weapons)
            {
                w.Fire();
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, hitInfo: out hit, maxDistance: 100f, radius: .15f, layerMask: LayerMask.GetMask("Default", "AI")))
            {
                if (hit.transform.gameObject.tag == "Bot")
                {
                    hit.transform.GetComponent<BotController>().ChangeState(BotController.ControlState.Player);
                    botController.ChangeState(BotController.ControlState.AI);
                }
            }
        }
        //if (weaponTransform) {
        //    var targetPosition = cam.transform.position + cam.transform.forward;
        //    targetPosition = new Vector3(weaponTransform.position.x,
        //                                targetPosition.y,
        //                                weaponTransform.position.z);
        //    weaponTransform.LookAt(targetPosition);
        //    //weaponTransform.Rotate(new Vector3( 0f, 90f, 0f));
        //}
        //if (weaponTransform) weaponTransform.LookAt(cam.transform.position + cam.transform.forward, Vector3.up);
    }
}
