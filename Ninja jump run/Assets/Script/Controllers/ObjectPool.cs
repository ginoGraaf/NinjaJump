using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPool Instace { get; set; }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public void Awake()
    {
        Instace = this;

        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                obj.transform.SetParent(this.transform);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

    }

    public GameObject SpawnFromPool(string tag, Vector3 pos)
    {
        if (poolDictionary[tag].Count == 0)
        {
            AddObject(1, tag);
        }
        return DequeObject(tag, pos);
    }

    public void AddObject(int count, string tag)
    {
        foreach (Pool pool in pools)
        {
            if (pool.tag == tag)
            {
                for (int i = 0; i < count; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    poolDictionary[tag].Enqueue(obj);
                }
            }
        }
    }

    GameObject DequeObject(string tag, Vector3 pos)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;

        return objectToSpawn;
    }

    public void ReturnToPool(string tag, GameObject obj)
    {
        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
    }
}
