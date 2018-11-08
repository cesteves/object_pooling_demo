using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	List<GameObject> pooledObjects;
    GameObject objectToPool;

	public ObjectPooler(GameObject objectToPool, int poolSize)
	{
		// Instantiate our pool
		pooledObjects = new List<GameObject> ();
        this.objectToPool = objectToPool;

		// Instantiate the amount of objects we need
		for (int i = 0; i < poolSize; i++) {
			GameObject obj = Instantiate (objectToPool);
			// Set each object inactive
			obj.SetActive (false);
			// Add it to the pool
			pooledObjects.Add (obj);
		}
	}

	public GameObject getPooledObject(){
		// Loop through our pool
		for (int i = 0; i < pooledObjects.Count; i++) {
			// If we find an object that is not active, return it
			if (!pooledObjects [i].activeInHierarchy) {
				return pooledObjects [i];
			}
		}

        GameObject newObject = Instantiate (objectToPool);
        pooledObjects.Add(newObject);

		// There are no inactive objects - the pool is empty
		return newObject;
	}
}
