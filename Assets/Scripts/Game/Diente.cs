using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diente : MonoBehaviour
{
    public int puntos;
    public Sprite sprite;
    public bool acariado;
    [SerializeField] private Animator animator;  
 /// <summary>
 /// Esta funcion settea un diente desde la lista de scriptables.
 /// </summary>
 /// <param name="data">Es la referencia a la lista de scriptables</param>
    public void SetDiente(DienteDat2a data)
    {
        sprite = data.sprite;
        acariado = data.acariado;
        puntos = data.puntos;

        if (animator != null)
        {
            if (data.animacion != null)
            {
                animator.Play(data.animacion.name, -1, 0f);
            }
        }
    }
}
