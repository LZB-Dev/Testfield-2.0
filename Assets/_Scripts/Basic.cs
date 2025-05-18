using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour //bap
{
    [SerializeField] GameObject obj;
    [SerializeField] Transform trans;
    [SerializeField] Rigidbody rig;
    [SerializeField] float speed = 60f;
    [SerializeField] float rotSpeed = 5f;
    #region Unused global methods
    private void Awake()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    #endregion


    void Start()
    {
        obj.name = "Edited Cube";
        rig.useGravity = true;
    }

    void Update()
    {
        if (trans != null)
        {
            if (trans.position.x >= 10) Destroy(obj);
            trans.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            trans.Rotate(new Vector3(5, 0, 0) * rotSpeed * Time.deltaTime, Space.World);
        }
    }
}
