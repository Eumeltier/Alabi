using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

    public float detectionRadius = 10;
    public LayerMask detectionLayer;
    
    private NavMeshAgent myNavMeshAgent;
    private float nextCheck;
    private float checkRate;

	// Use this for initialization
	void Start () {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        checkRate = Random.Range(0.8f, 1.2f);

    }
	
	// Update is called once per frame
	void Update () {
        CheckIfPlayerInRange();
	}

    void CheckIfPlayerInRange()
    {
        if (Time.time > nextCheck && myNavMeshAgent.enabled == true)
        {
            nextCheck = Time.time + checkRate;

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

            if (hitColliders.Length > 0)
            {
                myNavMeshAgent.SetDestination(hitColliders[0].transform.position);
            }
        }
    }
}
