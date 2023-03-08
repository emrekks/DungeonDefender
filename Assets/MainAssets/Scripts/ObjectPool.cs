using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{  
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        
        public GameObject objectPrefab;
       
        public int poolSize;
    }

    [SerializeField] private Pool[] pools = null;

    public static ObjectPool Instance;
    
    private void Awake()
    {
        Instance = this;
        
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();

            for (int i = 0; i <  pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab);
                
                obj.SetActive(false);
            
                pools[j].pooledObjects.Enqueue(obj);
            }
        }
    }

    public GameObject GetPooledObject(int objectType, Transform transform, Vector3 rotation)
    {
        if (objectType >= pools.Length)
        {
            return null;
        }
        
        GameObject obj =  pools[objectType].pooledObjects.Dequeue();

        obj.transform.SetParent(transform);

        obj.transform.position = transform.position;

        obj.transform.eulerAngles = rotation;
        
        obj.transform.SetParent(null);

        obj.SetActive(true);

        return obj;
    }

    public void BackToPoolObject(GameObject pooledObject, int objectType)
    {
        if (objectType >= pools.Length)
        {
            return;
        }
        
        pools[objectType].pooledObjects.Enqueue(pooledObject);
        
        pooledObject.SetActive(false);
    }
}
