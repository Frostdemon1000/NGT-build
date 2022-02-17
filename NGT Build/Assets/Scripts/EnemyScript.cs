using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyScript : MonoBehaviour
{
    private GameManager gameManager;
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
        gameManager = FindObjectOfType<GameManager>();
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
            gameManager.GameOver();
        }
    }

    private void OnCollisionStay(Collision collision)
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
            
            int newPoint = Mathf.RoundToInt(Random.Range(0f, _patrolPoints.Length - 1));

            targetPos = _patrolPoints[newPoint].transform.position;
            _navMeshAgent.SetDestination(targetPos);
            }
        
    }

    public void ChangeEnemySpeed(float value)
    {
        _navMeshAgent.speed = value;
    }
}
