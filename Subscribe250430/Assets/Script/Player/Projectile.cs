using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed = 70.0f;

    public int attackPoint;

    public void FindTarget(Transform Target)
    {
        target = Target;
    }

    private void Update()
    {
        if(target == null)
        {
            this.gameObject.SetActive(false);
            return;
        }

        Vector3 direction = target.position - this.transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {

        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
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
