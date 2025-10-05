public class EstadoVictoria : Estados
{
    private bool animacionEjecutada = false;
    public override void IniciarEstado()
    {
        AnimacionVictoria.Instane.estanMoviendo = false;

        UIManager.Instancie.ActivarUI(GameManager.Estado.Victoria);
        if (!animacionEjecutada)
        {
            AnimacionVictoria.Instane.AnimarBotonesSimultaneamente();
            animacionEjecutada = true;
        }
    }

    public override void ActualizarEstado()
    {
    }

    public override void FinalizarEstado()
    {
    }

    public override GameManager.Estado GetEstado()
    {
        return GameManager.Estado.Victoria;
    }
}
