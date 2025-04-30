using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LongDistanceRobot : Player
{

    public GameObject projectilePrefab;
    public Transform muzzleLocation;

    private void Awake()
    {
        maxHealth = currentHealth;

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
        {
            anim.SetBool("bAttack", false);
            return;
        }

        //Ÿ�� ����
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,
            lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);

        if (fireCoolDown <= 0.0f)
        {
            Shoot();
            fireCoolDown = 1.0f / fireRate;
        }

        fireCoolDown -= Time.deltaTime;
    }

    public void Shoot()
    {
        anim.SetBool("bAttack", true);
        GameObject bulletGameObject = Instantiate(projectilePrefab, muzzleLocation.position, muzzleLocation.rotation);
        //bulletGameObject.GetComponent<Rigidbody>().velocity = (muzzleLocation.transform.forward) * 40.0f;
        Projectile projectile = bulletGameObject.GetComponent<Projectile>();

        if(projectile != null)
        {
            projectile.FindTarget(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
