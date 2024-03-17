
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private InputAction grabAndDropButton = new InputAction(type: InputActionType.Button);
    [SerializeField] private Transform playerCameraTransform; // player camera transform
    [SerializeField] private Transform objectGrabPointTransform; 
    [SerializeField] private LayerMask pickUpLayerMask; // Defining the layer of objects that can be picked up and drop
    private ObjectGrabbable objectGrabbable;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnEnable()
    {
        grabAndDropButton.Enable();
    }

    void OnDisable()
    {
        grabAndDropButton.Disable();
    }
    void Update()
    {
        if (grabAndDropButton.WasPressedThisFrame())
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
                        audioManager.PlaySFX(audioManager.garb);
                    }
                }
            } else
            {
                // Currently carrying something, drop
                objectGrabbable.Drop(); // drop the object
                audioManager.PlaySFX(audioManager.drop);
                objectGrabbable = null; // reset for the next object

            }
        }
    }
}
