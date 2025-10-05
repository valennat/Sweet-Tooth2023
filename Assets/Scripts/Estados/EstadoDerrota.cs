public class EstadoDerrota : Estados
{
    private bool animacionEjecutada = false;
    public override void IniciarEstado()
    {
        AnimacionDer.Instane.estanMoviendo = false;
        UIManager.Instancie.ActivarUI(GameManager.Estado.Derrota);

        if (!animacionEjecutada)
        {
            AnimacionDer.Instane.AnimarBotonesSimultaneamente();
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
        return GameManager.Estado.Derrota;
    }
}
