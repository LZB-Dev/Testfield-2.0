using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour //bap
{
    [SerializeField] private GameObject gunPoint;
    [SerializeField] private GameObject bulletHole;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private float speed = 50f;
    [SerializeField] public int dmg { get; set; }
    [SerializeField] public int range { get; set; }
    private Vector3 startPoint;

    private void OnEnable()
    {
        startPoint = transform.position;

    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
        ContactPoint contactPoint = other.GetContact(0);
        Unit target = other.collider.transform.GetComponent<Unit>();

        if (other.rigidbody == null)
        {
            GameObject.Instantiate(bulletHole, contactPoint.point + contactPoint.normal * 0.0001f, Quaternion.LookRotation(contactPoint.normal));
        }
        else if (target != null)
        {
            target.TakeDamage(dmg);
        }
        trail.transform.parent = null;
        Destroy(gameObject);
        Destroy(trail, trail.time);
    }
}
