using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private BotController botController;
    private BotStatsHolder stats;
    [SerializeField]
    private Transform weaponTransform;

    private Camera cam;

    private void Start()
    {
        botController = GetComponent<BotController>();
        stats = GetComponent<BotStatsHolder>();
        cam = GetComponentInChildren<Camera>();
    }

    public void OnEnable()
    {
        GameManager.currentPlayerControlledBot = gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.gameObject.tag == "Bot")
                {
                    hit.transform.GetComponent<BotController>().ChangeState(BotController.ControlState.Player);
                    botController.ChangeState(BotController.ControlState.AI);
                }
            }
        }

        //weaponTransform.LookAt(cam.transform.position + cam.transform.forward, Vector3.up);
    }
}
