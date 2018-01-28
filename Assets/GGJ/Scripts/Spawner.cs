using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public bool IsSpawning { get; private set; }


    public void Spawn()
    {
        var i = Instantiate(prefab, position: transform.position, rotation: transform.rotation);
        i.GetComponent<BotController>().ChangeState(BotController.ControlState.AI);
    }

    public void Spawn(int amount, float interval)
    {
        StartCoroutine(SpawnC(amount, interval));
    }

    public IEnumerator SpawnC(int amount, float interval)
    {
        yield return new WaitForSeconds(interval);
        AIDirector.activeWalkers++;
        Debug.Log(AIDirector.activeWalkers);
        Spawn();
    }


    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    Spawn();
        //}
    }
}
