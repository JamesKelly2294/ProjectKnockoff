using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFinishedEventArgs
{
    public MovementFinishedEventArgs(GameObject go) { GameObject = go; }
    public GameObject GameObject { get; } // readonly
}

public class TranslateAndRotateToPosition : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Quaternion startRotation;
    public Quaternion endRotation;
    public float duration = 1;
    
    public delegate void MovementFinishedEventHandler(object sender, MovementFinishedEventArgs e);
    public event MovementFinishedEventHandler MovementFinished;
    
    protected virtual void RaiseMovementFinishedEvent()
    {
        MovementFinished?.Invoke(this, new MovementFinishedEventArgs(gameObject));
    }

    public void Start()
    {
        if (endPosition == null)
        {
            endPosition = startPosition;
        }

        if (endRotation == null)
        {
            endRotation = startRotation;
        }
    }

    private float time = 0;
    public void Update()
    {
        time += Time.deltaTime;
        float pct = time / duration;
        if (pct > 1) { pct = 1; }
        transform.position = Vector3.Lerp(startPosition, endPosition, pct);
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, pct);

        if(pct >= 1)
        {
            RaiseMovementFinishedEvent();
            Destroy(this);
        }
    }
}
