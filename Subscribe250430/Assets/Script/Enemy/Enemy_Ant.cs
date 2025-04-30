using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ant : Enemy
{
    private void Awake()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
}
