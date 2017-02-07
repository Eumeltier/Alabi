using UnityEngine;
using System.Collections;

public class Skeleton : Enemy {

    public float attackCooldown = 2;
    public bool hasWalkAnimation = false;

    [SerializeField]
    private float currentSpeed;

    NavMeshAgent agent;


    private GameObject target;
    private Animator animator;


    private bool isAttacking = false;
    private bool agentStopped = false;


    private float lastAttackTime;


    // Use this for initialization
    void Start()
    {
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

    private void Update()
    {
        AnimatorStateInfo currentBaseState = animator.GetCurrentAnimatorStateInfo(0);

        if (currentBaseState.IsName("Attack"))
        {
            isAttacking = true;
            agent.Stop();
            agentStopped = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
        }

        else
        {
            isAttacking = false;
            if (agentStopped)
            {
                agent.Resume();
                agentStopped = false;
            }
        }
        //currentSpeed = agent.desiredVelocity.magnitude;

        if (target)
        {
            agent.SetDestination(target.transform.position);
            if (hasWalkAnimation)
            {
                animator.SetFloat("Speed", currentSpeed);
            }
        }
    }

    public void Attack()
    {
        if (lastAttackTime + attackCooldown < Time.time)
        {
            Vector3 lookAtVector = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.LookAt(lookAtVector);
            lastAttackTime = Time.time;
            animator.SetTrigger("Attack");
        }
    }

    public void OnAttackIsInHitPhase()
    {
        Debug.Log("OnHitPhase");
        //Check if player is infront
        Vector3 toOther = target.transform.position - transform.position;

        if (Vector3.Dot(toOther, transform.forward) > 0.5f)
        {
            target.GetComponent<Health>().TakeDamage(100);
        }
    }


    Vector3 lastPosition;
    void FixedUpdate()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, (transform.position - lastPosition).magnitude / Time.deltaTime, 0.75f);
        lastPosition = transform.position;

        print(currentSpeed);
    }
}


