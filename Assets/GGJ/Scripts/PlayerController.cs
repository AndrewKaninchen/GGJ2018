using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public void OnEnable()
    {
        GameManager.currentPlayerControlledBot = gameObject;
    }

    //private void Update()
    //{
    //    if(Input.GetMouseButtonDown(1))
    //    {
    //        Ray ray = new Ray()
    //        RaycastHit hit;
    //    }
    //}
}
