using Pedido;
namespace Cadetes;

public class Cadete
{
    public int Id{get;set;}
    public string? Nombre{get;set;}
    public string? Direccion{get;set;}
    public double Telefono{get;set;}
    public List<Pedidos> ListaPedidos{get;set;}
    public Cadete()
    {
    }

    public double JornalACobrar()
    {
        if(ListaPedidos == null) return 0;
        double CantidadEntregados = ListaPedidos.Where(x => x.estado == Pedidos.Estado.Entregado).Count();
        return CantidadEntregados * 500;
    }

    public void AgregarPedido(Pedidos nuevo)
    {
        ListaPedidos.Add(nuevo);
    }
}