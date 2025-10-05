using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager; //necesito p estados

    private Estados estadoControl;
    private Estados estadoActual;
 
    public enum Estado
    {
        Menu,
        Tutorial,
        Juego,
        Derrota,
        Victoria,
    };

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        estadoControl = new EstadoMenu();
        estadoActual = estadoControl;
    }

    private void Start()
    {
        estadoControl.IniciarEstado();
    }

    void Update()
    {
        if (estadoActual != null)
        {
            estadoActual.ActualizarEstado();
        }
    }

    /// <summary>
    /// Esta funcion se utiliza para cambiar entre estados
    /// </summary>
    /// <param name="nuevoEstado"> Es el estado al que se va a entrar </param>
    public void CambiarEstado(Estados nuevoEstado)
    {
        if (nuevoEstado != estadoActual)
        {
            estadoControl.FinalizarEstado();
            estadoControl = nuevoEstado;
            estadoControl.IniciarEstado();
            estadoActual = estadoControl;
        }
    }

    /// <summary>
    /// Esta funcion se utiliza para terminar el estado juego e iniciar el estado victoria o derrota
    /// </summary>
    /// <param name="gano">Se pasa como referencia si gano o no</param>
    public void FinalizarJuego(bool gano)
    {
       if (gano)
       {
            CambiarEstado(new EstadoVictoria());
       }
       else
       {
            CambiarEstado(new EstadoDerrota());
       }
    }
}