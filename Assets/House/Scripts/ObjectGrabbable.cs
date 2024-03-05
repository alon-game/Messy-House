using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectGrabbable : MonoBehaviour
{
    [SerializeField] GameObject objectArrow; // arrow for the tutorial
    [SerializeField] GameObject placementArrow; // arrow for the tutorial
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    private bool inPlace = false; // boolean variable that indicates whether the object is in its place
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>(); // Get the rigidbody reference
    }
    // function responsible for grab object
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform; // transform of the object grap point 
        objectRigidbody.useGravity = false; // disable object gravity when grabbing
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            objectArrow.GetComponent<MeshRenderer>().enabled = false; // disable object arrow Mesh and enable placement arrow Mesh for tutorial mode
            placementArrow.GetComponent<MeshRenderer>().enabled = true;
        }

    }

    // function responsible for drop object
    public void Drop()
    {
        this.objectGrabPointTransform = null; // reset the trasform of the object grab point
        objectRigidbody.useGravity = true; // enable object gravity
    }

    // function responsible of smoother grab motion
    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed); // for smoother motion of grab objects
            objectRigidbody.MovePosition(newPosition);
        }
    }

    public void DisablePlacementArrow() // disable placement arrow for tutorial mode
    {
        placementArrow.GetComponent<MeshRenderer>().enabled = false;
    }

    public bool IsInPlace() // return true if the object is in his place
    {
        return inPlace;
    }

    public void SetObjectInPlace(bool condition) // set the object in or not in place
    {
        inPlace = condition;
    }
}
