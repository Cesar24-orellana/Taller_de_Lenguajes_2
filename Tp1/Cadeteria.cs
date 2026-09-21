using model.Cadetes;
using model.Clientes;
using model.Pedidos;

using System.Globalization;
namespace model.cadeteria;
public class Cadeteria
{
    public string? Nombre{get;set;}
    public double Telefono{get;set;}
    public List<Cadete>? ListaCadetes{get;set;}

    public static void ReasignarPedido(Cadete cadete1, Cadete cadete2, Pedido pedido)
    {
        cadete1.ListaPedidos?.Remove(pedido);
        cadete2.AgregarPedido(pedido);
    }

    public void CambiarEstado(Pedido pedido, Pedido.Estado nuevoEstado)
    {
        pedido.CambiarEstado(nuevoEstado);
    }

    public static void AsignarPedido(Cadete cadete, Pedido pedido)
    {
        cadete.AgregarPedido(pedido);
    }

    public Pedido DarDeAlta(int nro, string? obs, string? nombre, string? direccion, double telefono, string? datosRef)
    {
        var nuevoCliente = new Cliente(nombre, direccion, telefono, datosRef);
        var nuevoPedido = new Pedido(nro, obs, nuevoCliente, Pedido.Estado.Pendiente);
        return nuevoPedido;
    }

    public void InformePago()
    {
        int TotalPedidosEntregados = 0;
        int TotalPedidos = 0;
        double TotalJornal = 0;
        Console.WriteLine("- - - Informe de Jornada - - -");
        foreach (var cadete in ListaCadetes ?? new List<Cadete>())
        {
            int cantPedidosEntregados = cadete.ListaPedidos?.Where(x => x.estado == Pedido.Estado.Entregado).Count() ?? 0;
            int cantPedidos = cadete.ListaPedidos?.Count() ?? 0;
            double JornalACobrar = cadete.JornalACobrar();

            Console.WriteLine($"Cadete: {cadete.Nombre}");
            Console.WriteLine($"Cantidad de pedidos: {cantPedidos}");
            Console.WriteLine($"Cantidad de pedidos entregados: {cantPedidosEntregados}");
            Console.WriteLine($"Jornal a cobrar: {JornalACobrar}");
            TotalPedidosEntregados += cantPedidosEntregados;
            TotalPedidos += cantPedidos;
            TotalJornal += JornalACobrar;
        }
        int cantCadetes = ListaCadetes?.Count() ?? 0;
        double promedioEntregados = (double)TotalPedidosEntregados / TotalPedidos;

        Console.WriteLine(" - - - Total - - -");
        Console.WriteLine($"Total de Envios: {TotalPedidos}");
        Console.WriteLine($"Total de Entregados: {TotalPedidosEntregados}");
        Console.WriteLine($"Total del Jornal a pagar: ${TotalJornal}");
        Console.WriteLine($"Promedio de envios por cadete: {promedioEntregados:F2}");
    }
}