using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public int maxHealth;
    public int currentHealth;

    public int attackPoint;

    public Animator anim;
    public Rigidbody rigid;

    public void Damage(int Damage)
    {
        currentHealth -= Damage;

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        this.gameObject.SetActive(false);

        GameManager.Instance.money++;
    }


}
