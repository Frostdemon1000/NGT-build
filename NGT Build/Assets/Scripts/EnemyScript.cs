using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;


    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            if (!collision.collider.gameObject.GetComponentInParent<DoorScript>().doorOpen)
            {
                collision.collider.gameObject.GetComponentInParent<DoorScript>().PlayAnimation();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _navMeshAgent.SetDestination(other.gameObject.transform.position);
        }
    }
}
