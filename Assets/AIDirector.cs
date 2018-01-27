using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public struct SpawnerParams
{
    public float timeBetweenWaves;
    public int botsPerWave;
    public int spawnPointsUsedPerWave;
    public int maxActiveBots;
    public float samePointSpawnInterval;

    private int currentActiveBots;
}

public class AIDirector : MonoBehaviour
{
    public static int activeWalkers = 0;
    public SpawnerParams walkerSpawnerParams;
    public List<Spawner> walkerSpawnPoints;

    private bool isInCooldown; 

    public IEnumerator CooldownBetweenWaves()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(walkerSpawnerParams.timeBetweenWaves);
        isInCooldown = false;
    }

    public void Update()
    {
        if (isInCooldown)
            return;

        var orderedSps = from s in walkerSpawnPoints
                         where !s.IsSpawning
                         orderby Vector3.Distance(GameManager.currentPlayerControlledBot.transform.position, s.transform.position) descending
                         select s;

        if (activeWalkers < walkerSpawnerParams.maxActiveBots)
        { 
            var amountToSpawn = Mathf.Min(walkerSpawnerParams.maxActiveBots - activeWalkers, walkerSpawnerParams.botsPerWave);

            for (int i = 0; i < walkerSpawnerParams.spawnPointsUsedPerWave; i++)
            {
                walkerSpawnPoints[i].Spawn(amountToSpawn / walkerSpawnerParams.spawnPointsUsedPerWave, walkerSpawnerParams.samePointSpawnInterval);
            }

            StartCoroutine(CooldownBetweenWaves());
        }

    }
}
