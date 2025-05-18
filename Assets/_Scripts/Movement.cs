using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour //bap
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float rotSpeed = 40f;
    [SerializeField] float maxSpeed = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        rb.transform.Rotate(horizontal * rotSpeed * Vector3.up, Space.World);
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude >= maxSpeed / 2.237f) return;
        if (Input.GetKeyDown(KeyCode.W)) rb.AddForce(moveSpeed * rb.transform.forward);
        if (Input.GetKeyDown(KeyCode.D)) rb.AddForce(moveSpeed * rb.transform.right);
        if (Input.GetKeyDown(KeyCode.S)) rb.AddForce(moveSpeed * -rb.transform.forward);
        if (Input.GetKeyDown(KeyCode.A)) rb.AddForce(moveSpeed * -rb.transform.right);
    }
}
