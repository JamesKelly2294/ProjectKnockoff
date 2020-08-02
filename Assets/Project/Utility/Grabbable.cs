using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Vector3 _grabbedPosition;
    private Quaternion _grabbedRotation;
    private bool _grabbed;

    // I hate this name
    public bool IsGrabbable()
    {
        return _grabbed;
    }

    public bool Grab()
    {
        if(_grabbed) { return false; }
        _grabbedPosition = transform.parent.position;
        _grabbedRotation = transform.parent.rotation;
        _grabbed = true;

        return true;
    }

    public bool Release()
    {
        if(!_grabbed) { return true; }
        
        var moveAnimation = transform.parent.gameObject.AddComponent<TranslateAndRotateToPosition>();
        moveAnimation.startPosition = transform.parent.position;
        moveAnimation.startRotation = transform.parent.rotation;
        moveAnimation.endPosition = _grabbedPosition;
        moveAnimation.endRotation = _grabbedRotation;
        moveAnimation.duration = 0.2f;

        moveAnimation.MovementFinished += MoveAnimation_MovementFinished;

        return true;
    }

    private void MoveAnimation_MovementFinished(object sender, MovementFinishedEventArgs e)
    {
        _grabbed = false;
    }
}
