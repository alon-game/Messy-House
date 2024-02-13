using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";

    [SerializeField] private float normalMovementSpeed = 2f;
    [SerializeField] private float sprintMovementSpeed = 4f;

    private bool isSprinting = false;
    private CharacterController charController;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * normalMovementSpeed;     //CharacterController.SimpleMove() applies deltaTime
        float horizInput = Input.GetAxis(horizontalInputName) * normalMovementSpeed;

        float currentSpeed = isSprinting ? sprintMovementSpeed : normalMovementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput * currentSpeed;
        Vector3 rightMovement = transform.right * horizInput * currentSpeed;

        //simple move applies delta time automatically
        charController.SimpleMove(forwardMovement + rightMovement);
    }
}
