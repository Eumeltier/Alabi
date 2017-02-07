using UnityEngine;
using System.Collections;

public class SuicideBomber : MonoBehaviour {

    public bool hasWalkAnimation = false;
    public float damage;

    NavMeshAgent agent;


    private GameObject target;
    private Animator animator;


	// Use this for initialization
	void Start () {
        if (hasWalkAnimation)
        {
            animator = GetComponent<Animator>();
        }
        agent = GetComponent<NavMeshAgent>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            target = other.gameObject;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (target)
        {
            agent.SetDestination(target.transform.position);
            if (hasWalkAnimation)
            {
                animator.SetFloat("Speed", agent.velocity.magnitude);
            }
        }
    }

}
