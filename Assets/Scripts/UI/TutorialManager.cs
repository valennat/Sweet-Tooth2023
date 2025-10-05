using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject[] slides;
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;
    [SerializeField] private Button buttonExit;

    private int slideActual = 0;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip musicaTutorial;

    private void OnEnable()
    {
        MostrarSlide(slideActual);
        buttonLeft.onClick.AddListener(RetrocederSlide);
        buttonRight.onClick.AddListener(AvanzarSlide);
        buttonExit.onClick.AddListener(SalirTutorial);
    }

    private void Start()
    {
        source.clip = musicaTutorial;
        source.Play();
        source.loop = true;
    }

    private void MostrarSlide(int indice)
    {
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == indice);
        }
    }
    private void AvanzarSlide()
    {
        if (slideActual < slides.Length - 1)
        {
            slideActual++;
            MostrarSlide(slideActual);
        }
    }

    private void RetrocederSlide()
    {
        if (slideActual > 0)
        {
            slideActual--;
            MostrarSlide(slideActual);
        }
    }
    private void SalirTutorial()
    {
        source.Stop();
        gameManager.CambiarEstado(new EstadoJuego());
    }
    private void OnDisable()
    {
        source.Stop();
        buttonLeft.onClick.RemoveAllListeners();
        buttonRight.onClick.RemoveAllListeners();
        buttonExit.onClick.RemoveAllListeners();
    }
}


