using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Estados
{
    public abstract void IniciarEstado();
    public abstract void ActualizarEstado();
    public abstract void FinalizarEstado();
    public abstract GameManager.Estado GetEstado();
}
