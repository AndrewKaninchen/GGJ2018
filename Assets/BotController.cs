using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class BotController : MonoBehaviour {

	public enum ControlState
    {
        Player,
        AI
    }

    #region Components
    private CharacterController p_cController;
    private FirstPersonController p_fpController;
    
    private NavMeshAgent ai_navMeshAgent;
    private AIMoveController ai_aIMoveController;
    #endregion
    private GameObject p_cameraHolder;

    public bool startAsPlayer;
    private ControlState currentController;

    private void Start()
    {
        if (!p_cController) p_cController = GetComponent<CharacterController>();
        if (!p_fpController) p_fpController = GetComponent<FirstPersonController>();
        if (!ai_navMeshAgent) ai_navMeshAgent = GetComponent<NavMeshAgent>();
        if (!ai_aIMoveController) ai_aIMoveController = GetComponent<AIMoveController>();

        if (!p_cameraHolder) p_cameraHolder = transform.Find("CameraHolder").gameObject;

        if (startAsPlayer)
            ChangeState(ControlState.Player);
        else
            ChangeState(ControlState.AI);
    }

    private void ChangeState(ControlState state)
    {
        if(state == ControlState.Player)
        {
            p_cameraHolder.SetActive(true);
            p_cController.enabled = true;
            p_fpController.enabled = true;
            ai_navMeshAgent.enabled = false;
            ai_aIMoveController.enabled = false;
            currentController = ControlState.AI;
        }
        else
        {
            p_cameraHolder.SetActive(false);
            p_cController.enabled = false;
            p_fpController.enabled = false;
            ai_navMeshAgent.enabled = true;
            ai_aIMoveController.enabled = true;
            currentController = ControlState.Player;
        }
    }

}
