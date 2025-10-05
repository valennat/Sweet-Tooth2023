using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public static GameController Instance; //necesito en estados
    [SerializeField] private corazonesManager corazones_manager;
    [SerializeField] private GameManager gameManager;

    private int PuntajeInicial = 0;
    private int PuntajeVictoria = 200;
    private int VidasIniciales = 3;
    [SerializeField] private float TiempoInicial = 60.0f;
    private float TiempoAesperar = 2f;

    [SerializeField] private Slider slider;
    [SerializeField] private Slider sliderPuntos;
    [SerializeField] private Spawner spawner;
    [SerializeField] private ObjectPool pool;

    private int puntajeActual;
    private int vidasActuales;
    private float tiempoActual;
    private TimeSpan time;
    private const bool gano=true;

    public bool juegoTerminado;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip musicaJuego;
    [SerializeField] private AudioClip popBueno;
    [SerializeField] private AudioClip popMalo;

    public Action<bool, int> onDiente;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        onDiente = DienteCollide;
    }
    private void Start()
    {
        slider.minValue = 0;
        slider.maxValue = TiempoInicial;
        sliderPuntos.minValue = 0;
        sliderPuntos.maxValue = PuntajeVictoria;
    }

    /// <summary>
    /// Esta funcion es el setteo inicial del juego. 
    /// </summary>
    /// <returns></returns>
    public IEnumerator IniciarJuegoCoroutine()
    {
        source.clip = musicaJuego;
        source.Play();
        source.loop = true;

        juegoTerminado = false;
        puntajeActual = PuntajeInicial;
        vidasActuales = VidasIniciales;
        tiempoActual = TiempoInicial;

        yield return new WaitForSeconds(TiempoAesperar);

        spawner.IniciarSpawner();
    }

    /// <summary>
    /// Esta funcion es el Update del juego. Checkea las condiciones de derrota y victoria y actualiza la UI.
    /// </summary>
    public void ActualizarJuego()
    {
        tiempoActual -= Time.deltaTime;
        time = TimeSpan.FromSeconds(tiempoActual);

        if (time.TotalSeconds > 0)
        {
            slider.value = tiempoActual;
            if (puntajeActual >= PuntajeVictoria)
            {
                gameManager.FinalizarJuego(gano);
            }else if (vidasActuales <= 0)
                gameManager.FinalizarJuego(!gano);
        }
        else
        {
            gameManager.FinalizarJuego(!gano);
        }

        corazones_manager.ActualizarVidas(vidasActuales);
        sliderPuntos.value = puntajeActual;
    }

    /// <summary>
    /// Esta funcion se utiliza para manejar los sonidos y los puntajes una vez que el diente toca el canasto
    /// </summary>
    /// <param name="esCarie">Referencia sobre si es una carie o no</param>
    /// <param name="puntos">Referencia a los puntos que otorga el diente</param>
    private void DienteCollide (bool esCarie, int puntos)
    {
        if (esCarie)
        {
            source.PlayOneShot(popMalo);
            ReducirVida();
        }
        else
        {
            source.PlayOneShot(popBueno);
        }

        IncrementarPuntaje(puntos);
    }

    /// <summary>
    /// Esta funcion se utiliza para aumentar o decrementar el puntaje actual.
    /// </summary>
    /// <param name="cantidad">Es el puntaje a sumar o restar</param>
    private void IncrementarPuntaje(int cantidad)
    {
        puntajeActual += cantidad;
        sliderPuntos.value = puntajeActual;
    }
    /// <summary>
    /// Esta funcion se utiliza para reducir en uno la vida actual del jugador
    /// </summary>
    private void ReducirVida()
    {
        vidasActuales--;
        corazones_manager.ActualizarVidas(vidasActuales);

    }
    /// <summary>
    /// Esta funcion para la musica de juego.
    /// </summary>
    public void FrenarMusica()
    {
        source.Stop();
    }
}
