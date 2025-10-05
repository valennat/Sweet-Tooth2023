using UnityEngine;
using UnityEngine.UI;

public class corazonesManager : MonoBehaviour
{
    public Image coraImage; 
    public Sprite[] coraSprites;

    /// <summary>
    /// Actualiza la cantidades de corazones en la UI.
    /// </summary>
    /// <param name="vidasRestantes">Referencia a la cantidad de corazones a mostrar</param>
    public void ActualizarVidas(int vidasRestantes)
    {
        int spriteIndex = Mathf.Clamp(vidasRestantes - 1, 0, coraSprites.Length - 1);
        coraImage.sprite = coraSprites[spriteIndex];
    }
}
