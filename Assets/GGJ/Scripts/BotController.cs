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
    private WeaponController p_playerWeapon;

    private HealthManager healthManager;
    #endregion
    private Camera p_camera;

    public bool startAsPlayer;
    private ControlState currentController;

    private void Awake()
    {
        if (!p_cController) p_cController = GetComponent<CharacterController>();
        if (!p_fpController) p_fpController = GetComponent<FirstPersonController>();
        if (!ai_navMeshAgent) ai_navMeshAgent = GetComponent<NavMeshAgent>();
        if (!ai_AIMoveController) ai_AIMoveController = GetComponent<AIMoveController>();
        if (!p_playerController) p_playerController = GetComponent<PlayerController>();
        if (!healthManager) healthManager = GetComponent<HealthManager>();

        healthManager.onDeath += () => GameOver();

        if (!p_camera) p_camera = GetComponentInChildren<Camera>();

        if (startAsPlayer)
            ChangeState(ControlState.Player);
        else
            ChangeState(ControlState.AI);
    }
    

    public void ChangeState(ControlState state)
    {
        if (state == ControlState.Player)
        {
            p_camera.gameObject.SetActive(true);
            //p_camera.enabled = true;
            p_playerController.enabled = true;
            p_cController.enabled = true;
            p_fpController.enabled = true;
            ai_navMeshAgent.enabled = false;
            ai_AIMoveController.enabled = false;
            currentController = ControlState.Player;
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        else
        {
            p_camera.gameObject.SetActive(false);
            // p_camera.enabled = false;
            p_playerController.enabled = false;
            p_cController.enabled = false;
            p_fpController.enabled = false;
            ai_navMeshAgent.enabled = true;
            ai_AIMoveController.enabled = true;
            currentController = ControlState.AI;
            gameObject.layer = LayerMask.NameToLayer("AI");
        }
    }

    private void SetMoveStats()
    {
        
    }

    private void GameOver()
    {
        if(currentController == ControlState.Player)
        {
            GameManager.Instance.DEATHCamera.SetActive(true);
            GameObject ui = GameManager.Instance.UI;
            ui.transform.Find("u dead").gameObject.SetActive(true);
            ui.transform.Find("Score").gameObject.SetActive(false);
        }
    }
}
