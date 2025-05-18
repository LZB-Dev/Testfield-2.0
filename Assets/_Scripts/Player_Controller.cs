using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour //bap
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float maxSpeed = 40f;
    //[SerializeField] float turnSpeed = 3f;
    [SerializeField] Rigidbody rb;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude >= maxSpeed / 2.237) return;
        if (Input.GetKey(KeyCode.W)) rb.AddForce(moveSpeed * rb.transform.forward);
        if (Input.GetKey(KeyCode.S)) rb.AddForce(moveSpeed * -rb.transform.forward);
        if (Input.GetKey(KeyCode.A)) rb.AddForce(moveSpeed * -rb.transform.right);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(moveSpeed * rb.transform.right);

    }
}
