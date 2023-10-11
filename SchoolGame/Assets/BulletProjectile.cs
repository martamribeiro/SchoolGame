using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    [SerializeField] private Transform vfxHit;

    private Rigidbody bulletRigidbody;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<LoveBarHit>() != null)
        {
            //hit target
            Instantiate(vfxHit, transform.position, Quaternion.identity);

        } else
        {
            //hit something else
        }
        Destroy(gameObject);
    }

}
