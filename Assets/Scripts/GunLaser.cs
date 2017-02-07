using UnityEngine;
using System.Collections;
using System;

public class GunLaser : MonoBehaviour
{
    public float range;
    public float damage;
    public GameObject explosion;
    public Transform rayCastOrigin;

    //public AudioSource laserSound;

    private Animator animator;

    // GetComponentInParent

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("RT1") < 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        //animator.SetTrigger("Shoot");
        //laserSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Instantiate(explosion, hit.point, Quaternion.identity);
            Health healthScript = hit.collider.gameObject.GetComponent<Health>();
            if (healthScript)
            {
                healthScript.TakeDamage(damage);
            }
        } 
    }
}
