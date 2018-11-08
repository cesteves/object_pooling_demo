using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	public float speed;
	public int maxDistance;

	Rigidbody rb;
	Vector3 spawnPosition;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
    }

	void Update(){
        rb.velocity = gameObject.transform.forward * speed;

        if (Vector3.Distance (spawnPosition, transform.position) >= maxDistance) {
			gameObject.SetActive (false);
		}
	}

	public void SetSpawnPosition(Vector3 t){
		spawnPosition = t;
    }
}
