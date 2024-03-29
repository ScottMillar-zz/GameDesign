﻿using UnityEngine;
using System.Collections;

public class GrabAndDrop : MonoBehaviour
{
    GameObject grabbedObject;
    float grabbedObjectSize;

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit; Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
        {
            return raycastHit.collider.gameObject;
        }

        return null;
    }

    void TryGrabObject(GameObject grabObject)
    {
        if (grabObject == null || !CanGrab(grabObject))
        {
            return;
        }
        grabbedObject = grabObject;
        grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
    }

    bool CanGrab(GameObject canidate)
    {
        return canidate.GetComponent<Rigidbody>() != null;
    }

    void DropObject()
    {
        if (grabbedObject == null)
        {
            return;
        }
        if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            grabbedObject = null;
        }
    }

    void Update() { 

        if (Input.GetMouseButtonDown(1))
        {
            if (grabbedObject == null)
            {
                TryGrabObject(GetMouseHoverObject(5));
            }
            else
            {
                DropObject();
            }
        }
        if (grabbedObject != null)
        {
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObject.transform.position = newPosition;
            grabbedObject.transform.rotation = Camera.main.transform.rotation;
        }
    }
}
