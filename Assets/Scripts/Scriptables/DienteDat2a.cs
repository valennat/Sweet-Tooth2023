using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoDienteData", menuName = "ScriptableObjects/DienteDat2a")]

public class DienteDat2a : ScriptableObject
{
    public Sprite sprite;
    public AnimationClip animacion;
    public int puntos;
    public bool acariado;
}