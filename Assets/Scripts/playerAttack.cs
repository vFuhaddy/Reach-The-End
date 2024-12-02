using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private playerController playerController;
    private float cooldownTimer =  Mathf.Infinity;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<playerController>();
    }

    private void Update()
    {
            
            if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerController.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

        //pool fireballs 
        fireballs[0].transform.position = firePoint.position;
        fireballs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
