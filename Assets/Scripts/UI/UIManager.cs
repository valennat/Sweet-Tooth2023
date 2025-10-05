using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instancie = null; //necesito para estados

    public GameObject menuUI;
    public GameObject juegoUI;
    public GameObject derrotaUI;
    public GameObject victoriaUI;
    public GameObject tutorialUI;

    private void Awake()
    {
        if (Instancie == null)
        {
            Instancie = this;
        }
    }
    /// <summary>
    ///Esta funcion se encarga de activar la UI asociada a los estados.
    /// </summary>
    /// <param name="estado">Es la referencia al estado del cual se busca activar su UI.</param>
    public void ActivarUI(GameManager.Estado estado)
    {
        menuUI.SetActive(estado == GameManager.Estado.Menu);
        juegoUI.SetActive(estado == GameManager.Estado.Juego);
        derrotaUI.SetActive(estado == GameManager.Estado.Derrota);
        victoriaUI.SetActive(estado == GameManager.Estado.Victoria);
        tutorialUI.SetActive(estado == GameManager.Estado.Tutorial);
    }
}