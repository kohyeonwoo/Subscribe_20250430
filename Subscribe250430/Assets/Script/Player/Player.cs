using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{

    public int maxHealth;
    public int currentHealth;

    public float range;
    public float turnSpeed;

    public float fireRate;
    public float fireCoolDown;

    public Animator anim;
    public Rigidbody rigid;
    
    public Transform target;
    public Transform partToRotate;

    private string targetTag = "Enemy";

    public int attackPoint;

    public void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);

        float shortestDistance = Mathf.Infinity; //�� ���� �����Ǿ� ���� ���� ���

        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,
                enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;

                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    public void Damage(int Damage)
    {
        currentHealth -= Damage;

        if(currentHealth < 0)
        {
            Death();
        }
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
    }

}
