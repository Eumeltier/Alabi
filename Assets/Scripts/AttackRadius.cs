using UnityEngine;
using System.Collections;

public class AttackRadius : MonoBehaviour {

    Skeleton enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Skeleton>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            enemy.Attack();
        }
    }
}
