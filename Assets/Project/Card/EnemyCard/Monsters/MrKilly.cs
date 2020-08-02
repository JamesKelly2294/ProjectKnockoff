using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrKilly : MonoBehaviour
{

    private Vector3 startPoint;
    private Vector3 endPoint;
    private float currentTime = 0;

    [Range(0.1f, 10.0f)]
    public float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = RandomLookAtVector3();
        endPoint = RandomLookAtVector3();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > totalTime) {
            currentTime -= totalTime;
            startPoint = endPoint;
            endPoint = RandomLookAtVector3();
        }

        float progress = currentTime / totalTime;
        Vector3 currentPoint = Vector3.Lerp(startPoint, endPoint, progress);
        transform.LookAt(currentPoint);
    }

    Vector3 RandomLookAtVector3() {
        Vector3 vec = new Vector3(Random.Range(-1f, 1.0f), Random.Range(-1f, 1.0f), Random.Range(-1.0f, 1.0f));
        vec.Normalize();

        if (Random.Range(0, 2.0f) > 0.5f) {
            return vec / 10 + Camera.main.transform.position;
        } else {
            return vec / 10 + transform.position;
        }
    }
}
