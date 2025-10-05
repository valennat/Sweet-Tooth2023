using UnityEngine;
public class EstadoJuego : Estados
{
    private bool transicionMenu = false;

    public override void IniciarEstado()
    {
        UIManager.Instancie.ActivarUI(GameManager.Estado.Juego);
        GameController.Instance.StartCoroutine(GameController.Instance.IniciarJuegoCoroutine());
    }

    public override void ActualizarEstado()
    {
        GameController.Instance.ActualizarJuego();

        if (!transicionMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            transicionMenu = true;
            Spawner.spawner.PararSpawner();
            GameController.Instance.FrenarMusica();
            GameManager.gameManager.CambiarEstado(new EstadoMenu());
        }
    }

    public override void FinalizarEstado()
    {
        if (!transicionMenu)
        {
            GameController.Instance.FrenarMusica();
            Spawner.spawner.PararSpawner();  
        }
    }
    public override GameManager.Estado GetEstado()
    {
        return GameManager.Estado.Juego;
    }
}