using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Controller : MonoBehaviour //bap
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 3 - 3);
    [SerializeField] float vertical;
    [SerializeField] float turnSpeed = 3f;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        vertical = Input.GetAxis("Mouse Y");
        transform.position = player.transform.position + offset;
        transform.Rotate(vertical * Vector3.right * turnSpeed, Space.World);
    }
}
