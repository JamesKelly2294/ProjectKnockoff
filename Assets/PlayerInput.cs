using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FindGrabbableObject();
        HandleGrabbedObject();
    }

    Grabbable _grabbedObject;
    const int _interactablePlaneLayer = 9;
    const int _grabbableLayer = 10;

    void FindGrabbableObject()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(_grabbedObject && _grabbedObject.Release())
            {
                _grabbedObject = null;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            int layerMask = 1 << _grabbableLayer;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Grabbable grabbable = hit.transform.gameObject.GetComponent<Grabbable>();
                if(grabbable && grabbable.Grab())
                {
                    _grabbedObject = grabbable;
                }
            }
        }
    }

    void HandleGrabbedObject()
    {
        if (!_grabbedObject) { return; }

        if (!Input.GetMouseButton(0)) { return; }
        int layerMask = 1 << _interactablePlaneLayer;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            _grabbedObject.transform.parent.position = hit.point;
            _grabbedObject.transform.parent.rotation = hit.transform.rotation * Quaternion.Euler(-90, 180, 0);
        }
    }
}
