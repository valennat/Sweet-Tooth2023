using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool pool;
    [SerializeField] private GameObject dientePrefab;
    private List<GameObject> pooledDientes;
    [SerializeField] private int amountToPool = 6;

    void Start()
    {
        pooledDientes = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject dienteObjeto = Instantiate(dientePrefab);
            dienteObjeto.SetActive(false);
            pooledDientes.Add(dienteObjeto);
        }
    }

    public GameObject GetPooledDiente()
    {
        for (int i = 0; i < pooledDientes.Count; i++)
        {
            if (!pooledDientes[i].activeInHierarchy)
            {
                return pooledDientes[i];
            }
        }
        GameObject dienteObjeto = Instantiate(dientePrefab);
        dienteObjeto.SetActive(false);
        pooledDientes.Add(dienteObjeto);
        return dienteObjeto;
    }
}