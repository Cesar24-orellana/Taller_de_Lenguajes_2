using System.Globalization;
using model.Clientes;
using model.Pedidos;
using model.Cadetes;
using model.cadeteria;

var NuevoCliente = new Cliente("Miguel Angel", "Entrega Inmediata", 3813649582, "Auto azul en la entrada");
var NuevoPedido=new Pedido(
                        1, "Entrega Inmediata", NuevoCliente,
                        Pedido.Estado.Pendiente
);

NuevoPedido.VerDatosCliente();
NuevoPedido.VerDireccionCliente();
Console.WriteLine("- - - -");

var ListaPedidos = Pedido.CargarPedidos("pedidos.csv");
Pedido.MostrarPedidos(ListaPedidos);
Console.WriteLine("- - - -");

var ListaCadetes = Cadete.CaargarCadetes("cadetes.csv");
Cadete.MostarListaCadetes(ListaCadetes);
Console.WriteLine("- - - -");