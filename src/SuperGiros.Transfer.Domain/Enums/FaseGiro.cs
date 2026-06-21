namespace SuperGiros.Transfer.Domain.Enums
{
    public enum FaseGiro
    {
        Registrado = 1, // Creado por el cajero en ventanilla
        Pagado = 2, // Pago verificado de manera gratuita con Niubiz
        Envio = 3, // Giro en camino a la sede de destino
        Completado = 4  // Dinero retirado por el destinatario
    }
}