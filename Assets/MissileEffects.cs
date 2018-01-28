using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEffects : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("aee");
	}

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("a:");
        Debug.Log(collision);
        /*foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log(contact.point);
            //Debug.Log(contact.point, contact.normal, Color.white);
        }*/
    }

}
