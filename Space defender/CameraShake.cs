using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration=1f;
    [SerializeField] float shakeMagnitude=0.5f;
    Vector3 initialCameraPosition;
    void Start()
    {
        initialCameraPosition = transform.position;       
    }

    public void Play()
    {
        StartCoroutine(ShakeCamera());
    }
    IEnumerator ShakeCamera()
    {
        float escapeTime = 0;
        while (escapeTime < shakeDuration)
        {
            transform.position = initialCameraPosition +
                (Vector3)Random.insideUnitCircle * shakeMagnitude;
            escapeTime+=Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        transform.position = initialCameraPosition;
    }
}
