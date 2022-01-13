using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private EnemyStates _currentState = EnemyStates.Idle;

    private enum EnemyStates
    {
        Idle,
        Patrolling,
        Chasing
    }

    [SerializeField]
    private GameObject[] _patrolPoints;


    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(EnemyPatrol());
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

        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("game over");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _navMeshAgent.SetDestination(other.gameObject.transform.position);
            _currentState = EnemyStates.Chasing;
        }
        else
        {
            _currentState = EnemyStates.Idle;
        }
    }

    private IEnumerator EnemyPatrol()
    {

        yield return new WaitForSeconds(10f);

        if (_currentState == EnemyStates.Idle)
        {
            Vector3 targetPos;
            
            _currentState = EnemyStates.Patrolling;
            
            int newPoint = Mathf.RoundToInt(Random.Range(0f, _patrolPoints.Length));

            targetPos = _patrolPoints[newPoint].transform.position;
            _navMeshAgent.SetDestination(targetPos);
            }
        
    }
}
