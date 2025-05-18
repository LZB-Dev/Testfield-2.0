using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour //bap
{
    [SerializeField] GameObject Enemy;

    public void Spawn()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
    void Start()
    {
        foreach(Transform gameObject in transform)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        Spawn();
    }

    void Update()
    {
        
    }
}
