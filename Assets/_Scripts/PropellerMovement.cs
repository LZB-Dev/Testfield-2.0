using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerMovement : MonoBehaviour //bap
{
    [SerializeField] float turnSpeed;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }
}
