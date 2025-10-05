using UnityEngine;

public class Canasta : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Diente"))
        {
            var diente = collision.gameObject.GetComponent<Diente>();
            if (diente != null)
            {
                collision.gameObject.SetActive(false);
                animator.Play("canasto collide", -1, 0f);
                gameController.onDiente.Invoke(diente.acariado, diente.puntos);
            }
        }
    }
}