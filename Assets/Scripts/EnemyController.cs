using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem deathEffect;
    public bool Alive { get; private set; }

    private SphereCollider attackZone;
    private AudioSource audioSource;
    private NavMeshAgent navMeshAgent;
    private PlayerController player;
    private float lastAttack;
    private float attackRate;
    private float followRange;


    void Start()
    {
        Alive = true;
        lastAttack = Time.time;
        attackZone = GetComponent<SphereCollider>();
        audioSource = GetComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = transform.parent.GetComponentInChildren<PlayerController>();
        attackRate = GameController.instance.configuration.enemyAttackRate;
        followRange = GameController.instance.configuration.enemyFollowRange;
    }

    private void Update()
    {
        if (navMeshAgent.enabled && Vector3.Distance(transform.position, player.transform.position) <= followRange)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time > lastAttack + attackRate)
        {
            lastAttack = Time.time;
            player.OnDamage();
            GameController.instance.OnPlayerDamaged();
        }
    }

    public void OnHit()
    {
        float destroyDelay = Mathf.Max(audioSource.clip.length, deathEffect.main.duration);

        Alive = false;
        audioSource.Play();
        deathEffect.Play();
        attackZone.enabled = false;
        navMeshAgent.enabled = false;
        GameController.instance.OnEnemyKilled();

        Destroy(gameObject, destroyDelay);
    }

}
