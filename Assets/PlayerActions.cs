using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

	public GameObject projectile;
	public int poolSize;
	public Transform firePoint;

	ObjectPooler projectilePool;

	void Start (){
		projectilePool = new ObjectPooler (projectile, poolSize);
	}

	void Update(){
		if (Input.GetButtonDown("Fire1")){
			Fire();
		}
	}

	void Fire(){
		GameObject pro = projectilePool.getPooledObject ();

		if (pro != null) {
			pro.transform.position = firePoint.position;
            pro.GetComponent<ProjectileScript>().SetSpawnPosition(firePoint.position);
            pro.SetActive(true);
		}
	}
}
