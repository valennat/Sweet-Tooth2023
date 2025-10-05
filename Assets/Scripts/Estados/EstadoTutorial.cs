public class EstadoTutorial : Estados
{
    public override void IniciarEstado()
    {
        UIManager.Instancie.ActivarUI(GameManager.Estado.Tutorial);
    }
    public override void ActualizarEstado()
    {
    }

    public override void FinalizarEstado()
    {
    }

    public override GameManager.Estado GetEstado()
    {
        return GameManager.Estado.Tutorial;
    }
}
