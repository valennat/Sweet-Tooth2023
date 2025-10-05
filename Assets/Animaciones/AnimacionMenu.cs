using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimacionMenu : MonoBehaviour
{
    public static AnimacionMenu Instane;

    [SerializeField] private Button[] botonesAanimar;
    public bool estanMoviendo;

    private void Awake()
    {
        Instane = this;
    }

    public void AnimarBotonesSimultaneamente()
    {
        if (estanMoviendo)
        {
            return;
        }

        estanMoviendo = true;

        foreach (var boton in botonesAanimar)
        {
            Image imagenDelBoton = boton.targetGraphic as Image;

            if (imagenDelBoton != null)
            {
                boton.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                imagenDelBoton.color = new Color(imagenDelBoton.color.r, imagenDelBoton.color.g, imagenDelBoton.color.b, 0f);

                var escalaTween = boton.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f)
                    .SetEase(Ease.Linear);

                var escalaFinalTween = boton.transform.DOScale(Vector3.one, 0.1f)
                    .SetEase(Ease.Linear)
                    .SetDelay(0.2f);

                var fadeInTween = imagenDelBoton.DOFade(1f, 0.5f)
                    .SetEase(Ease.Linear);

                Sequence popTween = DOTween.Sequence();
                popTween.Append(fadeInTween);
                popTween.Join(escalaTween);
                popTween.Append(escalaFinalTween);

                popTween.Play();
            }
        }
    }
}

