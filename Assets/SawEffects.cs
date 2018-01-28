using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawEffects : MonoBehaviour
{



    public float damage = 10f;

    public GameObject explosionEffect;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("aee");
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("a:");
        Debug.Log(collision);

        Debug.Log(collision.gameObject.tag);

        HealthManager target = collision.transform.GetComponent<HealthManager>();
        Debug.Log(target);
        if (target != null)
        {
            target.TakeDamage(damage);
            Explode();
        }

        /*foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log(contact.point);
            //Debug.Log(contact.point, contact.normal, Color.white);
        }*/
    }

    void Explode()
    {
        //Show effect
        Destroy(Instantiate(explosionEffect, transform.position, transform.rotation), 2f);


        //Get nearby objects

        //Remove missile
        Destroy(gameObject);
    }

}
