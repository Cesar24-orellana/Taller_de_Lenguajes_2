using Pedido;
namespace Cadetes;

public class Cadete
{
    public int Id{get;set;}
    public string? Nombre{get;set;}
    public string? Direccion{get;set;}
    public double Telefono{get;set;}
    public List<Pedidos> ListaPedidos{get;set;}
    public Cadete(int id, string? nombre, string? direccion, double telefono, List<Pedidos> listaPedidos)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.ListaPedidos = listaPedidos;
    }
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

    public static List<Cadete> CaargarCadetes(string archivo)
    {
        var lista = new List<Cadete>();
        if (!File.Exists(archivo))
        {
            Console.WriteLine($"El archivo {archivo} no fue encontrado!!");
            return lista;
        }
        var lineas = File.ReadAllLines(archivo);
        for(int i=0; i< (lineas.Length-1); i++)
        {
            var separar = lineas[i+1].Split(',');
            var cadete = new Cadete(int.Parse(separar[0]), separar[1], separar[2], double.Parse(separar[3]), new List<Pedidos>());
            lista.Add(cadete);
        }

        return lista;
    }
}