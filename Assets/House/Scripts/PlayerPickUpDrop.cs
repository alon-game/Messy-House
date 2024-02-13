using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private InputAction test;
    [SerializeField] private Transform playerCameraTransform; // player camera transform
    [SerializeField] private Transform objectGrabPointTransform; 
    [SerializeField] private LayerMask pickUpLayerMask; // Defining the layer of objects that can be picked up and drop

    private ObjectGrabbable objectGrabbable;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // if the spece button is press
        {
            if (objectGrabbable == null)
            { 
                // Not carrying an object, try to grab
                float pickUpDistance = 2f; // distance to pick up object
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform); // grab the object
                    }
                }
            } else
            {
                // Currently carrying something, drop
                objectGrabbable.Drop(); // drop the object
                objectGrabbable = null; // reset for the next object

            }
        }
    }
}
