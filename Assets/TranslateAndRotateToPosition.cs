using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateAndRotateToPosition : MonoBehaviour
{
    public Transform startTransform;
    public Transform endTransform;
    public float duration;

    public void Start()
    {
        if (!(startTransform && endTransform)) {
            return;
        }
    }
}
