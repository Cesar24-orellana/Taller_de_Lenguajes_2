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

var NuevaCadeteria = new Cadeteria("Juan Cadetes", 0800654368, ListaCadetes);

Console.WriteLine("Cambiar Estado de Pedido.");
Console.WriteLine($"Estado actual del pedido: {NuevoPedido.estado}");
NuevaCadeteria.CambiarEstado(NuevoPedido, Pedido.Estado.Entregado);
Console.WriteLine($"Nuevo estado del pedido: {NuevoPedido.estado}");

// Crear Nuevos Cadetes
var Cadete1 = new Cadete(1, "Manuel", "Calle Nueva Esperanza", 3816549684, new List<Pedido>());
var Cadete2 = new Cadete(2, "Emiliano", "Calle Corrientes", 3817859684, new List<Pedido>());

Cadete1.MostrarCadete();
Cadeteria.AsignarPedido(Cadete1, NuevoPedido);
Cadete1.MostrarCadete();

Console.WriteLine("- - - -");
Cadeteria.ReasignarPedido(Cadete1, Cadete2, NuevoPedido);

Cadete1.MostrarCadete();
Console.WriteLine("- - - -");
Cadete2.MostrarCadete();

Console.WriteLine("- - - -");
var NuevoPedido2 = NuevaCadeteria.DarDeAlta(2, "Entrega inmediata", "Juan Perez", "Av. Roca 2000", 3815469826, "Casa de 2 pisos");
NuevoPedido2.MostrarPedido();
Cadeteria.AsignarPedido(Cadete2, NuevoPedido2);
double Sueldo = Cadete2.JornalACobrar();
Console.WriteLine($"Cobro por la jornada de Cadete2 es: ${Sueldo}");


Console.WriteLine("- - - -");
NuevaCadeteria.ListaCadetes?.Add(Cadete2);
Cadete1.ListaPedidos?.AddRange(ListaPedidos);
NuevaCadeteria.ListaCadetes?.Add(Cadete1);
NuevaCadeteria.InformePago();