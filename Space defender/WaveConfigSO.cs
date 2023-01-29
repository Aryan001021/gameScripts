using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create Wave Configure",fileName ="New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float movSpeed;
    [SerializeField] List<GameObject> enemiesPrefabs;
    [SerializeField] float spawnTime=1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0.2f;

    public int GetEnemiesCount()
    {
        return enemiesPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int num)
    {
        return enemiesPrefabs[num];
    }
    public Transform GetStartingWavePoint()
    {
        return  pathPrefab.GetChild(0);
    }
    public List<Transform> GetWavePoints()
    {
        List<Transform> wayPoint = new List<Transform>();
        foreach(Transform t in pathPrefab) 
        {
            wayPoint.Add(t);
        }
        return wayPoint;
    }
    public float GetMovSpeed() 
    {
        return movSpeed;
    }
    public float GetSpawnTime()
    {
        float spawnTimeReal=Random.Range(spawnTime-spawnTimeVariance, spawnTime+spawnTimeVariance);
        return Mathf.Clamp(spawnTimeReal,minSpawnTime,float.MaxValue);
    }
}
