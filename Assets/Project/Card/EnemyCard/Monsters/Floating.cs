using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{

    private float currentTime;
    
    [Range(0.1f, 10.0f)]
    public float TotalTime;

    [Range(0.1f, 10.0f)]
    public float Range;

    private Vector3 aroundPoint;
    public AnimationCurve AnimationCurve;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        aroundPoint = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > TotalTime) {
            currentTime -= TotalTime;
        }

        Vector3 newPoint = aroundPoint + Vector3.up * Range * AnimationCurve.Evaluate((currentTime * 2) / TotalTime);
        gameObject.transform.localPosition = newPoint;
    }
}
