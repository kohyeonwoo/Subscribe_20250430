using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LongDistanceRobot : Player
{

    public GameObject projectilePrefab;
    public List<GameObject> poolObject = new List<GameObject>();
    public Transform muzzleLocation;

    public int limitCount;

    private void Awake()
    {
        maxHealth = currentHealth;

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);

        CreateBulletPool();
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
           // StartCoroutine(Spawn)
            anim.SetBool("bAttack", true);
            fireCoolDown = 1.0f / fireRate;
        }

        fireCoolDown -= Time.deltaTime;
    }

    public void Shoot()
    {

        AudioManager.Instance.PlaySFX("GunShootSound");
        StartCoroutine(SpawnBulletCoroutine());
        // GameObject bulletGameObject = Instantiate(projectilePrefab, muzzleLocation.position, muzzleLocation.rotation);
        //bulletGameObject.GetComponent<Rigidbody>().velocity = (muzzleLocation.transform.forward) * 40.0f;
        Projectile projectile = projectilePrefab.GetComponent<Projectile>();

        if(projectile != null)
        {
            projectile.FindTarget(target);
        }
    }

    private IEnumerator SpawnBulletCoroutine()
    {
        SpawnBulletObject();

        yield return new WaitForSeconds(0.5f);
    }

    public void SpawnBulletObject()
    {
        GameObject objects = GetBulletPoolObject();

        if(objects != null)
        {
            objects.transform.position = muzzleLocation.position;
            objects.SetActive(true);
        }
    }

    private void CreateBulletPool()
    {
        for(int i =0; i < limitCount; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            poolObject.Add(obj);
        }
    }


    public GameObject GetBulletPoolObject()
    {
        for(int i =0; i < poolObject.Count; i++)
        {
            if(!poolObject[i].activeInHierarchy)
            {
                return poolObject[i];
            }
        }

        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
