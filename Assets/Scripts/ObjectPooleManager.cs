using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooleManager : MonoBehaviour
{
    public static ObjectPooleManager instance;
    public int poolSize;
    public GameObject poole;
    Queue<GameObject> pooledObjects = new Queue<GameObject>();
    private void Awake()
    {
        if(instance == null)
        {
           instance = this;
        }      
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(poole);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetFromPool()
    {
        if(pooledObjects.Count > 0)
        {
            GameObject o = pooledObjects.Dequeue();
            return o;
        }
        else
        {
            return null;
        }
    }

    public void ReturnToPool(GameObject returnedObj)
    {
        pooledObjects.Enqueue(returnedObj);
        returnedObj.SetActive(false);
    }
}
