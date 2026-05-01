namespace API.Data.Enum.Multibarbero
{
    /// <summary>
    /// Estados posibles de una suscripción
    /// </summary>
    public enum EstadoSuscripcion
    {
        PendienteAprobacion = 0,
        Activa = 1,
        Vencida = 2,
        Cancelada = 3,
        Rechazada = 4,
        EnEspera = 5
    }
}
