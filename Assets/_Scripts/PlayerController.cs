using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //bap
{
    //Variables
    [SerializeField] float speed = 30f;
    [SerializeField] float turnSpeed = 50f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;
    void Start()
    {
        
    }

    void Update()
    {
        //Getting player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Moving car forward or backwards
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Turn car left or right
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

    }
}
