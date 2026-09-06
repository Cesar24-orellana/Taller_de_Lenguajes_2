using Cadetes;
using Clientes;
using Pedido;

public class Cadeteria
{
    public string? Nombre{get;set;}
    public double Telefono{get;set;}
    public List<Cadete>? ListaCadetes{get;set;}

    public static void ReasignarPedido(Cadete cadete1, Cadete cadete2, Pedidos pedido)
    {
        cadete1.ListaPedidos.Remove(pedido);
        cadete2.AgregarPedido(pedido);
    }

    public void CambiarEstado(Pedidos pedido, Pedidos.Estado nuevoEstado)
    {
        pedido.CambiarEstado(nuevoEstado);
    }

    public static void AsignarPedido(Cadete cadete, Pedidos pedido)
    {
        cadete.AgregarPedido(pedido);
    }

    public Pedidos DarDeAlta(int nro, string? obs, string? nombre, string? direccion, double telefono, string? datosRef)
    {
        var nuevoCliente = new Cliente(nombre, direccion, telefono, datosRef);
        var nuevoPedido = new Pedidos(nro, obs, nuevoCliente, Pedidos.Estado.Pendiente);
        return nuevoPedido;
    }

    public virtual InformePago()
    {
        int TotalPedidosEntregados = 0;
        int TotalPedidos = 0;
        double TotalJornal = 0;
        Console.WriteLine("- - - Informe de Jornada - - -");
        foreach (var cadete in ListaCadetes)
        {
            
        }
    }
}