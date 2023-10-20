using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem deathEffect;
    [SerializeField] float moveSpeed;
    Transform player;
    private bool isDead;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    private void Start()
    {
        isDead = false;
    }

    private void Update()
    {
        if(isDead) 
            return;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        transform.LookAt(player.transform.position);
    }



    private void PlayDeathAnim()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 1.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDead = true;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            PlayDeathAnim();          
            GameManager.instance.enemiesKilled++;
        }
    }
}
