using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private BotController botController;

    private Camera cam;

    private void Start()
    {
        botController = GetComponent<BotController>();
        cam = GetComponentInChildren<Camera>();
    }

    public void OnEnable()
    {
        GameManager.currentPlayerControlledBot = gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Bot")
                {
                    botController.ChangeState(BotController.ControlState.AI);
                    hit.transform.GetComponent<BotController>().ChangeState(BotController.ControlState.Player);
                }
            }
            
        }
    }
}
