using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSponner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    float timeBetweenWaves = 0f;
    WaveConfigSO currentWave;
    [SerializeField]bool isLooping = true;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemiesCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWavePoint().position,
                    Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }while(isLooping);
    }
}
