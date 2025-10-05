using UnityEngine;
using UnityEngine.UI;

public class DerrotaUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip musicaDer;
 
    private void OnEnable()
    {
        source.clip = musicaDer;
        source.Play();
        source.loop = true;

        menuButton.onClick.AddListener(OnMenuButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnMenuButtonClick()
    {
        source.Stop();
        gameManager.CambiarEstado(new EstadoMenu());
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