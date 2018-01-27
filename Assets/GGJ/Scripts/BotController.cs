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
    private BotStatsHolder statsHolder;

    private CharacterController p_cController;
    private FirstPersonController p_fpController;
    private PlayerController p_playerController;

    private NavMeshAgent ai_navMeshAgent;
    private AIMoveController ai_AIMoveController;
    private Gun p_playerGun;
    #endregion
    private GameObject p_cameraHolder;

    public bool startAsPlayer;
    private ControlState currentController;

    private void Start()
    {
        if (!p_cController) p_cController = GetComponent<CharacterController>();
        if (!p_fpController) p_fpController = GetComponent<FirstPersonController>();
        if (!ai_navMeshAgent) ai_navMeshAgent = GetComponent<NavMeshAgent>();
        if (!ai_AIMoveController) ai_AIMoveController = GetComponent<AIMoveController>();
        if (!p_playerController) p_playerController = GetComponent<PlayerController>();
        
        if (!p_playerGun) p_playerGun = GetComponentInChildren<Gun>();

        if (!p_cameraHolder) p_cameraHolder = transform.Find("CameraHolder").gameObject;

        if (startAsPlayer)
            ChangeState(ControlState.Player);
        else
            ChangeState(ControlState.AI);

        SetMoveStats();
    }

    public void ChangeState(ControlState state)
    {
        if (state == ControlState.Player)
        {
            p_cameraHolder.SetActive(true);
            p_playerController.enabled = true;
            p_cController.enabled = true;
            p_fpController.enabled = true;
            p_playerGun.enabled = true;
            ai_navMeshAgent.enabled = false;
            ai_AIMoveController.enabled = false;
            currentController = ControlState.Player;
        }
        else
        {
            p_cameraHolder.SetActive(false);
            p_playerController.enabled = false;
            p_cController.enabled = false;
            p_fpController.enabled = false;
            p_playerGun.enabled = false;
            ai_navMeshAgent.enabled = true;
            ai_AIMoveController.enabled = true;
            currentController = ControlState.AI;
        }
    }

    private void SetMoveStats()
    {
        //ai_navMeshAgent.speed = p_fpController.m_WalkSpeed = statsHolder.moveStats.speed;
        //p_fpController.m_RunSpeed = statsHolder.moveStats.speed *1.5f;
    }
}
