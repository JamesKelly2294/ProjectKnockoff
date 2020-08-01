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
        
    }

    void FixedUpdate()
    {
        FindGrabbableObject();
        HandleGrabbedObject();
    }

    GameObject _grabbedObject;
    const int _interactablePlaneLayer = 9;
    const int _grabbableLayer = 10;

    void FindGrabbableObject()
    {
        if (Input.GetMouseButtonUp(0) && !_grabbedObject)
        {
            Debug.Log("Released " + _grabbedObject);
            _grabbedObject = null;
        } else if (Input.GetMouseButtonDown(0)) {
            int layerMask = 1 << _grabbableLayer;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("========");
                Debug.Log("selected " + hit.transform.gameObject);
                Debug.Log("========");
                _grabbedObject = hit.transform.gameObject;
            }
        }
    }

    void HandleGrabbedObject()
    {
        if (!_grabbedObject) { return; }

        if (!Input.GetMouseButton(0)) { return; }
        {
            int layerMask = 1 << _interactablePlaneLayer;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("dragging on " + hit.transform.gameObject);
                _grabbedObject.transform.position = hit.point;
                _grabbedObject.transform.rotation = hit.transform.rotation;
            }
        }
    }
}
