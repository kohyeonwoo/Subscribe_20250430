using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ant : Enemy
{

    public float speed;

    private void Awake()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

        this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
    }

    private void Update()
    {
        rigid.velocity = this.transform.forward * speed;

        anim.SetBool("bMove", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(attackPoint);
                this.gameObject.SetActive(false);
                Debug.Log("적에게 피해를 입혔습니다");
            }
        }
    }

}
