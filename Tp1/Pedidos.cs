using Clientes;
namespace Pedido;

public class Pedidos
{
    public int Nro {get;set;}
    public string? Obs {get;set;}
    private Cliente? cliente {get;set;}
    public Estado estado {get;set;}

    public string? VerDireccionCliente()
    {
        return cliente.Direccion;
    }
    public void VerDatosCliente()
    {
        Console.WriteLine("Nombre: " + cliente.Nombre);
        Console.WriteLine("Direccion: " + cliente.Direccion);
        Console.WriteLine("Telefono: " + cliente.Telefono);
        Console.WriteLine("Datos de Referencia de direccion: " + cliente.DatosReferenciaDireccion);
    }


    public enum Estado
    {
        Entregado,
        Espera,
        NoEntregado
    }

}