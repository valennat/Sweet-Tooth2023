using UnityEngine;
public class EstadoMenu : Estados
{
    private bool animacionEjecutada = false;

    public override void IniciarEstado()
    {
        AnimacionMenu.Instane.estanMoviendo = false;
        MenuController.Instance.Setup();
        Spawner.spawner.PararSpawner();
        UIManager.Instancie.ActivarUI(GameManager.Estado.Menu);

        if (!animacionEjecutada)
        {
            AnimacionMenu.Instane.AnimarBotonesSimultaneamente();
            animacionEjecutada = true;
        }
    }

    public override void ActualizarEstado()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.gameManager.CambiarEstado(new EstadoTutorial());
        }
    }

    public override void FinalizarEstado()
    {
    }

    public override GameManager.Estado GetEstado()
    {
        return GameManager.Estado.Menu;
    }
}
