using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
   public List<GameObject> pooledObjects = new List<GameObject>();
    public int spawnRate;
    public int maxPrefabs;
    public int maxRange;
    public int minRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddToPool(maxPrefabs);
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        prefabActivos();
    }


    public Vector3 PosRamdon(){
        return new Vector3(Random.Range(minRange,maxRange),0,Random.Range(minRange,maxRange));
    }

     IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            int activeCount = pooledObjects.Count(obj => obj.activeInHierarchy);

            if (activeCount < maxPrefabs)
            {
                GameObject obj = SpawnPrefabs();
                obj.transform.position = PosRamdon();
                obj.SetActive(true);
            }
        }
    }
    void AddToPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            // Instancia un nuevo prefab y lo desactiva
            GameObject prefabObject;
            prefabObject = Instantiate(prefab, PosRamdon(), Quaternion.identity);// se instancia la bala para ser usada
            prefabObject.SetActive(false);//se desactiva el prefab

            // Lo agrega a la lista de la piscina
            pooledObjects.Add(prefabObject);
        }
    }
    public GameObject SpawnPrefabs(){
        for (int i = 0; i < pooledObjects.Count; i++)
        {
             if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i]; 
            }
        }
        AddToPool(1);
        return pooledObjects.Last<GameObject>();
    }

    public int prefabActivos(){
        int count=0;
        foreach (GameObject prefab in pooledObjects)
        {
            if (prefab.activeInHierarchy)
            {
                count++;
                Debug.Log(count);
            }
        }
        return count;
        
    }
}
