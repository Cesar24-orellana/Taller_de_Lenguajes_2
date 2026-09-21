using System.Globalization;
using Clientes;
using Pedidos;
using model.cadeteria;

var NuevoCliente = new Cliente("Miguel Angel", "Entrega Inmediata", 3813649582, "Auto azul en la entrada");
var NuevoPedido=new Pedido(
                        1, "Entrega Inmediata", NuevoCliente,
                        Pedido.Estado.Pendiente
);

NuevoPedido.VerDatosCliente();
NuevoPedido.VerDireccionCliente();
Console.WriteLine("- - - -");