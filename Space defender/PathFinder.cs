using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemiesSponner enemiesSponner;
    WaveConfigSO waveConfigSO;
    List<Transform> wayPoints;
    int wavePointIndex = 0;

    private void Awake()
    {
        enemiesSponner=FindObjectOfType<EnemiesSponner>();
    }
    void Start()
    {
        waveConfigSO = enemiesSponner.GetCurrentWave();
        wayPoints = waveConfigSO.GetWavePoints();
        transform.position = wayPoints[wavePointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (wavePointIndex < wayPoints.Count)
        {
            Vector3 targetPosition= wayPoints[wavePointIndex].position;
            float delta = waveConfigSO.GetMovSpeed()*Time.deltaTime;
            transform.position=Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                wavePointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
