using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    List<GameObject> pooledObjects;
    GameObject objectToPool;
    bool resizable;

    public ObjectPooler(GameObject objectToPool, int poolSize, bool resizable)
    {
        // Instantiate our pool
        pooledObjects = new List<GameObject>();
        this.objectToPool = objectToPool;
        this.resizable = resizable;

        // Instantiate the amount of objects we need
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            // Set each object inactive
            obj.SetActive(false);
            // Add it to the pool
            pooledObjects.Add(obj);
        }
    }

    public GameObject getPooledObject()
    {
        // Loop through our pool
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // If we find an object that is not active, return it
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // If we can resize this pool, do so.
        if (resizable)
        {
            // If the pool is empty, instantiate a new object and add it to the pool
            GameObject newObject = Instantiate(objectToPool);
            pooledObjects.Add(newObject);

            // Return the newly instantated 
            return newObject;
        }
        else
        {
            // Return null if we cannot resize this pool
            return null;
        }
    }
}
