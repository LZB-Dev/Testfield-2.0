﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    [SerializeField] private Vector3 offset;

    void Start()
    {

    }

    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
