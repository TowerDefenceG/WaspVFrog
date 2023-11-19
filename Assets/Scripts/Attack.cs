using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
private Transform target;

public float speed = 70f;

public int damage = 50;

public float explosionRadius = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        //if the target is destroyed, destroy the bullet
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        //transform is the bullet and target is the enemy
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //if the distance between the bullet and the enemy is less than the distance the bullet will travel this frame, then the bullet has hit the enemy
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        //move the bullet towards the enemy
        transform.Translate (dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    
    void HitTarget()
    {
        moveEnemy e = target.GetComponent<moveEnemy>();

        if (explosionRadius > 0f){
			Explode();
		} else{
			Damage(target);
		}

		Destroy(gameObject);
        
    }

	void Explode ()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders){

			if (collider.tag == "Enemy"){
				Damage(collider.transform);
			}
		}
	}

    void Damage(Transform enemy){
        moveEnemy e = enemy.GetComponent<moveEnemy>();
        if (e != null){
            e.TakeDamage(damage); 
        }
    }
    

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}   

