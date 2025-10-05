using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSpawn : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Spawner spawner;
    [SerializeField] private float velocidad = 1.0f;
    [SerializeField] private float rangoMovimiento = 5.0f;
    private float direccion = 1.0f;
    private Vector3 posicionInicial;

    private void Awake()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (spawner.isSpawning && !gameController.juegoTerminado)
        {
            MoverSpawner();
        }
    }

    private void MoverSpawner()
    {
        float nuevaPosX = transform.position.x + (direccion * velocidad * Time.deltaTime);

        if (Mathf.Abs(nuevaPosX - posicionInicial.x) >= rangoMovimiento)
        {
            direccion *= -1.0f;
        }
        transform.position = new Vector3(nuevaPosX, transform.position.y, transform.position.z);
    }
}
