using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    KillCounter killCounterScript;
    public Collider col;
    EnemySpawner enemySpawnerScript;

    public float health = 100f;
    public Slider healthSlider;
    
    public GameObject player;
    public NavMeshAgent enemy;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        killCounterScript = GameObject.Find("KKK").GetComponent<KillCounter>();
        enemySpawnerScript = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        enemy = GetComponent<NavMeshAgent>();

        

    }
    void Update()
    {
        healthSlider.value = health;

        if (player != null)
        {
            enemy.destination = player.transform.position;
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(healthSlider);
        Destroy(col);
        enemy.speed = 0f;
        anim.SetBool("Die", true);

        StartCoroutine(DS());
        killCounterScript.AddKill();
        IEnumerator DS()
        {
            yield return new WaitForSeconds(4f);
            {
                Destroy(this.gameObject);
                enemySpawnerScript.EnemyCounter();
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AttackRange"))
        {
            player = other.gameObject;

        }
    }
}


