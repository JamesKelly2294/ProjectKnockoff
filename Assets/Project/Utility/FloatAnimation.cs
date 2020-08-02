using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAnimation : MonoBehaviour
{
    public Vector3 offset = Vector3.up;
    public float period = 1;

    private Vector3 _startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;        
    }

    // Update is called once per frame
    float time;
    void Update()
    {
        time += Time.deltaTime;

        transform.position = _startingPosition + offset * Mathf.Sin(time / period);
    }

    private void OnDestroy()
    {
        transform.position = _startingPosition;
    }
}
