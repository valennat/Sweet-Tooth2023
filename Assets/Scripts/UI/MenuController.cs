using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public static MenuController Instance; //necesito en estado menu
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private GameObject creditsCanvas;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip musicaMenu;
 
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        source.clip = musicaMenu;
        source.Play();
        source.loop = true;
    }

    private void OnEnable()
    {
        source.PlayOneShot(musicaMenu);
        startButton.onClick.AddListener(OnStartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
        creditsButton.onClick.AddListener(OnCreditsButtonClick);
    }
 
    public void Setup()
    {
        creditsCanvas.SetActive(false);
    }

    private void OnStartButtonClick()
    { 
        source.Stop();
        GameManager.gameManager.CambiarEstado(new EstadoTutorial());
    }

    private void OnExitButtonClick()
    {
        source.Stop();
 
        Application.Quit();
    }

    private void OnCreditsButtonClick()
    {
        creditsCanvas.SetActive(true);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
    }
}
