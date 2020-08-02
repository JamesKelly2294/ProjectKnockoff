using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrAnglesArms : MonoBehaviour
{

    private Vector3 startRot;
    private Vector3 endRot;
    private float currentTime = 0;

    [Range(0.1f, 10.0f)]
    public float totalTime;

    [Range(0f, 1000f)]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startRot = RandomUnitVector3();
        endRot = RandomUnitVector3();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > totalTime) {
            currentTime -= totalTime;
            startRot = endRot;
            endRot = RandomUnitVector3();
        }

        float progress = currentTime / totalTime;
        Vector3 rotation = Vector3.Lerp(startRot, endRot, progress);
        transform.Rotate(rotation * speed);
    }

    Vector3 RandomUnitVector3() {
        Vector3 vec = new Vector3(Random.Range(-1f, 1.0f), Random.Range(-1f, 1.0f), Random.Range(-1.0f, 1.0f));
        vec.Normalize();
        return vec;
    }
}
