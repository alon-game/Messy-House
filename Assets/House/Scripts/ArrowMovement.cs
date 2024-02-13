using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] float height = 0.1f; // גובה התנועה
    [SerializeField] float speed = 4.0f; // מהירות התנועה

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // תנועה לאורך הציר ה-Y בצורה תלת מימדית על פי פונקציית סינוס
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
