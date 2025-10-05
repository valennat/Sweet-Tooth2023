using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VicotoriaUI : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip musicaVic;
 
    private void Start()
    {
        source.clip = musicaVic;
        source.Play();
        source.loop = true;
    }

    private void OnEnable()
    {
        menuButton.onClick.AddListener(OnMenuButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnMenuButtonClick()
    {
        source.Stop();
        GameManager.gameManager.CambiarEstado(new EstadoMenu());

    }
    private void OnExitButtonClick()
    {
        source.Stop();
        Application.Quit();
    }

    private void OnDisable()
    {
        source.Stop();
        menuButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }
}