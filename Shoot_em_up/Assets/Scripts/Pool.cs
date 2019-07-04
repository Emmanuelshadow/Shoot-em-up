using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand;
}

public class Pool : MonoBehaviour
{

    public static Pool Pooler;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> pooledObjects;

    void Awake()
    {
        Pooler = this;
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            int nb = 0;
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.name += nb.ToString();
                obj.gameObject.transform.parent = transform.parent;
                obj.SetActive(false);
                pooledObjects.Add(obj);
                nb++;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
      
    }

    public GameObject GetObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
       
        return null;
    }


}
