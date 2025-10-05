using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner; //necesito en estados

    [SerializeField] private Transform respawnPoint1;
    [SerializeField] private Transform respawnPoint2;
    [SerializeField] private Transform respawnPoint3;
    [SerializeField] private Transform respawnPoint4;

    [SerializeField] private ObjectPool pool;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float timeToSpawn = 1.0f;

    [SerializeField] private ScriptableDienteData dienteData;
    public bool isSpawning = false;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip fallBueno;

    [SerializeField] private AudioClip fallMalo;

    private void Awake()
    {
        spawner = this;
    }

    /// <summary>
    /// Esta funcion activa el spawner de dientes.
    /// </summary>
    public void IniciarSpawner()
    {
        isSpawning = true;
        StartCoroutine(SpawnDientes());
    }

    /// <summary>
    /// Esta funcion desactiva el spawner de dientes.
    /// </summary>
    public void PararSpawner()
    {
        isSpawning = false;
        StopCoroutine(SpawnDientes());
    }

    private IEnumerator SpawnDientes()
    {
        var lugaresSpawn = new List<Transform> { respawnPoint1, respawnPoint2, respawnPoint3, respawnPoint4 };
        while (isSpawning && !GameController.Instance.juegoTerminado)
        {
            GameObject dienteObjeto = pool.GetPooledDiente();

            if (dienteObjeto != null)
            {
                var dienteComponente = dienteObjeto.GetComponent<Diente>();
                int index = Random.Range(0, dienteData.dataList.Count);

                dienteObjeto.SetActive(true); 

                dienteComponente.SetDiente(dienteData.dataList[index]);
                int lugarIndex = Random.Range(0, lugaresSpawn.Count);
                dienteObjeto.transform.position = lugaresSpawn[lugarIndex].position;

                if (dienteComponente.acariado)
                {
                    source.pitch = 0.5f;
                    source.PlayOneShot(fallMalo, 0.1f);
                }
                else
                {
                    source.pitch = 1.0f;
                    source.PlayOneShot(fallBueno, 0.05f);
                }
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}