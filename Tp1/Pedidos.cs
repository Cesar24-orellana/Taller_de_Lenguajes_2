using Clientes;
namespace Pedido;

public class Pedidos
{

    public int Nro {get;set;}
    public string? Obs {get;set;}
    public Cliente cliente {get;set;}
    public Estado estado {get;set;} = Estado.Pendiente;
    public Pedidos(int numPedido, string? obs, Cliente cliente, Estado estado = default)
    {
        this.Nro = numPedido;
        this.Obs = obs;
        this.cliente = cliente;
        this.estado = estado;
    }
    public Pedidos()
    {
    }
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

    public void CambiarEstado(Estado nuevo)
    {
        estado = nuevo;
    }

    public static List<Pedidos> CargarPedidos(string archivo)
    {
        var lista = new List<Pedidos>();
        if (!File.Exists(archivo))
        {
            Console.WriteLine($"El archivo {archivo} no fue encontrado!!");
            return lista;
        }
        var lineas = File.ReadAllLines(archivo);
        for (int i = 0; i < (lineas.Length-1); i++)
        {
            var separar = lineas[i+1].Split(',');
            bool exits = Enum.TryParse<Estado>(separar[2],true,out Estado result);
            var pedido = new Pedidos(int.Parse(separar[0]),separar[1], new Cliente(separar[3],separar[4], double.Parse(separar[5]),separar[6]), result);
            lista.Add(pedido);
        }

        return lista;
    }

    public enum Estado
    {
        Entregado,
        Pendiente,
        NoEntregado
    }

}