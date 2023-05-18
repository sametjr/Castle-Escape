using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    // --------- Events ---------
    public UnityEvent<Vector3> onPlayerKilledEnemy;
    public UnityEvent<Vector3> onEnemyKilledPlayer;

    // --------- References to other scripts ---------
    PlayerScript _playerScript;
    EnemyScript _enemyScript;

    // --------- References to components ---------
    private NavMeshAgent agent;
    private Animator animator;

    // --------- Variables ---------
    private Vector3 target;
    private int waypointIndex = 0;

    // --------- Serialized Variables ---------
    public EnemyType enemyType;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float timeToRotate = 2f;

    private void Start()
    {
        _enemyScript = GetComponent<EnemyScript>();
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if(enemyType == EnemyType.JustRotate)
        {
            StartCoroutine(Rotate());
        }

        if(enemyType == EnemyType.Patrol)
            target = waypoints[waypointIndex].position;
        


    }

    private IEnumerator Rotate()
    {
        while(true)
        {
            LeanTween.rotateY(gameObject, transform.rotation.eulerAngles.y + 180, 1f).setEaseOutQuad();
            yield return new WaitForSeconds(timeToRotate);
        }
    }

    private void Update()
    {
        if (enemyType == EnemyType.Static || enemyType == EnemyType.JustRotate) return;
        // Debug.Log(Vector3.Distance(transform.position, target));
        if (Vector3.Distance(transform.position, target) < 2)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
            target = waypoints[waypointIndex].position;
        }
        agent.SetDestination(target);

        if (agent.velocity.magnitude > 0.1f)
        {
            var targetRotation = Quaternion.LookRotation(agent.velocity);
            LeanTween.rotate(gameObject, targetRotation.eulerAngles, 0.2f).setEaseOutQuad();
            // transform.rotation = Quaternion.LookRotation(agent.velocity);
            animator.SetBool("isRunning", true);
        }

        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void PlayerSeen()
    {
        // Will Make desicion to attack or not
        // Debug.Log("Player Seen");
        if (_enemyScript.level > _playerScript.level)
        {
            // Attack
            onEnemyKilledPlayer.Invoke(transform.position);
            agent.isStopped = true;
        }
        else
        {
            // die
            onPlayerKilledEnemy.Invoke(transform.position);
            agent.isStopped = true;
        }
    }

    public enum EnemyType
    {
        Static,
        Patrol,
        JustRotate
    }




}
