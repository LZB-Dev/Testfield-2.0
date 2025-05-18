using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour //bap
{
    [SerializeField] private GameObject bulletDecal;
    [SerializeField] private float speed = 50f;
    [SerializeField] private GameObject trail;
    [SerializeField] public int dmg { get; set; }
    [SerializeField] public float range { get; set; }
    private Vector3 startPoint;


    private TrailRenderer TR;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void OnEnable()
    {
        TR = trail.GetComponent<TrailRenderer>();
        startPoint = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < 0.01f)
        {
            trail.transform.parent = null;
            Destroy(gameObject);
            Destroy(trail, TR.time);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contactC = other.GetContact(0);
        if (other.rigidbody == null)
        {
            GameObject.Instantiate(bulletDecal, contactC.point + contactC.normal * 0.0001f, Quaternion.LookRotation(contactC.normal));
        }
        trail.transform.parent = null;
        Destroy(gameObject);
        Destroy(trail, TR.time);
    }
}