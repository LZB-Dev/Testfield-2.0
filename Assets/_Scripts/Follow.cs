using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour //bap
{
    public GameObject player;
    public Vector3 offset_3pv = new Vector3(0, 7, -9);
    public Vector3 offset_1pv = new Vector3(0, 7, -9);
    public bool ThirdPersonCamera = true;
    private Quaternion tempCamRotation;

    void CameraStatusChange()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ThirdPersonCamera = !ThirdPersonCamera;
        }
    }

    void Start()
    {
        tempCamRotation = transform.rotation;
    }

    void LateUpdate()
    {
        CameraStatusChange();
        if (ThirdPersonCamera == true)
        {
            transform.position = player.transform.position + offset_3pv;
            transform.rotation = tempCamRotation;
        }
        else
        {
            transform.position = player.transform.position + offset_1pv;
            transform.rotation = player.transform.rotation;
        }
    }
}
