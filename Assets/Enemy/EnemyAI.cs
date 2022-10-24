using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f; 
    
    NavMeshAgent navMeshAgent;
    EnemyHealth health;
    // [SerializeField] 
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead) {
            enabled = false;
            navMeshAgent.enabled = false;
        }
		else {
			distanceToTarget = Vector3.Distance(target.position, transform.position);
			
			if (isProvoked) {
				EngageTarget();
			} else if (distanceToTarget <= chaseRange) {
				isProvoked = true;
			}
		}
    }

    private void EngageTarget() {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        } else if (distanceToTarget < navMeshAgent.stoppingDistance) {
            AttackTarget();
        } 
    }

    private void OnDamageTaken () {
        isProvoked = true;
    }

    private void ChaseTarget () {
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget () {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void FaceTarget () {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(0, 1, 1, 1F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
