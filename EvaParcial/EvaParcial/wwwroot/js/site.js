// Write your JavaScript code.
$().ready(
    () => {
        listaClientes();
        listaDistribuidor();
        listaPedidos();
        listaEntrega();
    });



var nuevo_Cliente = () => {
    var Nombre = document.getElementById('Nombres').value;
    var Direccion = document.getElementById('Direccion').value;
    var Ruc = document.getElementById('Ruc').value;

    var idCliente = document.getElementById("idCliente").value;

    if (idCliente == '') {
        var accion = '../Clientes/Nuevo_Cliente_Controller';
    } else {
        var accion = '../Clientes/Editar_Cliente_Controller';
    }   
        
    if (Nombre == '') {
        $('#control_Nombre').removeClass('hidden');
    } else {
        $('#control_Nombre').addClass('hidden');
        if (Direccion == '') {
            $('#control_Direccion').removeClass('hidden');
        } else {
            $('#control_Direccion').addClass('hidden');
            if (Ruc == '') {
                $('#control_Ruc').removeClass('hidden');
            } else {
                $('#control_Ruc').addClass('hidden');
                var clasecli = new ClaseClientes(Nombre, Direccion, Ruc, accion);
                clasecli.Nuevo_Cliente(idCliente);

            }
        }
    
    }
    
}

var nuevo_Distribuidor = () => {
    var Nombre = document.getElementById('Nombres').value;
    var Direccion = document.getElementById('Direccion').value;
    var listaReseptor = document.getElementById('listaReseptor').value;

    var idDistribuidor = document.getElementById("idDistribuidor").value;

    if (idDistribuidor == '') {
        var accion = '../Distribuidores/Nuevo_Distribuidor_Controller';
    } else {
        var accion = '../Distribuidores/Editar_Distribuidor_Controller';
    }

    if (Nombres == '') {
        $('#control_Nombre').removeClass('hidden');
    } else {
        $('#control_Nombre').addClass('hidden');
        if (Direccion == '') {
            $('#control_Direccion').removeClass('hidden');
        } else {
            $('#control_Direccion').addClass('hidden');
            if (listaReseptor == '') {
                $('#control_listaReseptor').removeClass('hidden');
            } else {
                $('#control_listaReseptor').addClass('hidden');
                var clasedis = new ClaseDistribuidor(Nombre, Direccion, listaReseptor, accion);
                clasedis.Nuevo_Distribuidor(idDistribuidor);

            }
        }

    }

}

var nuevo_Pedido = () => {
    var Fecha = document.getElementById('Fecha').value;
    var NomCorte = document.getElementById('NomCorte').value;
    var NPiezas = document.getElementById('NPiezas').value;
    var PesoCarne = document.getElementById('PesoCarne').value;

    var idPedidos = document.getElementById("idPedidos").value;

    if (idPedidos == '') {
        var accion = '../Pedidos/Nuevo_Pedido_Controller';
    } else {
        var accion = '../Pedidos/Editar_Pedidos_Controller';
    }

    if (Fecha == '') {
        $('#control_Fecha').removeClass('hidden');
    } else {
        $('#control_Fecha').addClass('hidden');
        if (NomCorte == '') {
            $('#control_NomCorte').removeClass('hidden');
        } else {
            $('#control_NomCorte').addClass('hidden');
            if (NPiezas == '') {
                $('#control_NPiezas').removeClass('hidden');
            } else {
                $('#control_NPiezas').addClass('hidden');
                if (PesoCarne == '') {
                    $('#control_PesoCarne').removeClass('hidden');
                } else {
                    $('#control_PesoCarne').addClass('hidden');
                    var clasePed = new ClasePedidos(Fecha,NomCorte,NPiezas,PesoCarne,accion);
                    clasePed.Nuevo_Pedido(idPedidos);
                }
               
            }

        }

    }

}

var nuevo_Entrega = () => {
    var Fecha = document.getElementById('Fecha').value;
    var ResponsableResive = document.getElementById('ResponsableResive').value;
    var idEntrega = document.getElementById("idEntrega").value;

    if (idEntrega == '') {
        var accion = '../Entregas/Nuevo_Entrega_Controller';
    } else {
        var accion = '../Entregas/Editar_Entrega_Controller';
    }

    if (Fecha == '') {
        $('#control_Fecha').removeClass('hidden');
    } else {
        $('#control_Fecha').addClass('hidden');
        if (ResponsableResive == '') {
            $('#control_ResponsableResive').removeClass('hidden');
        } else {
            $('#control_ResponsableResive').addClass('hidden');
            var claseEnt = new ClaseEntrega(Fecha, ResponsableResive, accion);
            claseEnt.Nuevo_Entrega(idEntrega);
        }

    }

}

////Ingreso de Un/////
var Un_Cliente = (idCliente) => {
    var accion = "../Clientes/Un_Cliente_Controller";
    var cliente = new ClaseClientes(' ', ' ', ' ', accion);
    cliente.Un_Cliente(idCliente);
}

var Un_Distribuidor = (idDistribuidor) => {
    var accion = "../Distribuidores/Un_Distribuidor_Controller";
    var distribuidor = new ClaseDistribuidor(' ', ' ', ' ', accion);
    distribuidor.Un_Distribuidor(idDistribuidor);
}

var Un_Entrega = (idEntrega) => {
    var accion = "../Entregas/Un_Entrega_Controller";
    var entrega = new ClaseEntrega(' ', ' ', accion);
    entrega.Un_Entrega(idEntrega);
}

var Un_Pedido = (idPedidos) => {
    var accion = "../Pedidos/Un_Pedidos_Controller";
    var pedidos = new ClasePedidos(' ',' ',' ',' ',accion);
    pedidos.Un_Pedido(idPedidos);
}



////Ingreso de Eliminar/////
var eliminar_cliente = (idCliente) => {
    var accion = "Clientes/Eliminar_Cliente_Controller";
    var cliente = new ClaseClientes(' ',' ',' ', accion);
    cliente.eliminar_cliente(idCliente);
}

var eliminar_distribuidor = (idDistribuidor) => {
    var accion = "../Distribuidores/Eliminar_Distribuidor_Controller";
    var distribuidor = new ClaseDistribuidor(' ', ' ', ' ', accion);
    distribuidor.eliminar_Distribuidor(idDistribuidor);
}

var eliminar_pedidos = (idPedidos) => {
    var accion = "../Pedidos/Eliminar_Pedidos_Controller";
    var pedidos = new ClasePedidos(' ', ' ', ' ', ' ', accion);
    pedidos.eliminar_Pedido(idPedidos);
}

var eliminar_entrega = (idEntrega) => {
    var accion = "../Entregas/Eliminar_Entrega_Controller";
    var entrega = new ClaseEntrega(' ', ' ', ' ', ' ', accion);
    entrega.eliminar_Entrega(idEntrega);
}
////Validacion cedulas o ruc/////

var validarRUC = () => {
    var ruc = document.getElementById('Ruc').value;
    if (ruc == '') {
        $('#control_Ruc').removeClass("hidden");

    } else {
        var accion = 'Proveedors/Validar_Ruc_Proveedor_Controller';
        var proveedor = new ClaseProveedores(ruc, ' ', ' ', ' ', ' ', accion);
        proveedor.validarRUC();
    }
}


////Validacion correos/////


////Ingreso de Listas/////
var listaClientes = () => {
    var accion = 'Clientes/Lista_Clientes_Controller';
    var cliente = new ClaseClientes('', '', '', accion);
    cliente.listaClientes();
}

var listaDistribuidor = () => {
    var accion = 'Distribuidores/Lista_Distribuidor_Controller';
    var distribuidor = new ClaseDistribuidor('', '', '', accion);
    distribuidor.listaDistribuidor();
}

var listaPedidos = () => {
    var accion = 'Pedidos/Lista_Pedidos_Controller';
    var pedidos = new ClasePedidos(' ', ' ', ' ', ' ', accion);
    pedidos.listaPedidos();
}

var listaEntrega = () => {
    var accion = 'Entregas/Lista_Entrega_Controller';
    var entrega = new ClaseEntrega(' ', ' ', accion);
    entrega.listaEntregas();
}





var Imprimir_Cliente = () => {
    var contenido = document.getElementById('Imprimir_Clientes').innerHTML;
    var contenidopaginaoriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
    document.body.innerHTML = contenidopaginaoriginal;
    $('#Reporte').modal('hide');
}

var Imprimir_Distribuidor = () => {
    var contenido = document.getElementById('Imprimir_Distribuidor').innerHTML;
    var contenidopaginaoriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
    document.body.innerHTML = contenidopaginaoriginal;
    $('#Reporte').modal('hide');
}

var Imprimir_Pedidos = () => {
    var contenido = document.getElementById('Imprimir_Pedidos').innerHTML;
    var contenidopaginaoriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
    document.body.innerHTML = contenidopaginaoriginal;
    $('#Reporte').modal('hide');
}

var Imprimir_Entrega = () => {
    var contenido = document.getElementById('Imprimir_Entrega').innerHTML;
    var contenidopaginaoriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
    document.body.innerHTML = contenidopaginaoriginal;
    $('#Reporte').modal('hide');
}

var quitar_Botones = () => {
    var contador = 0;
    $('#Cuerpo_Cliente tr').each(function () {
        var celdas = $(this).find('td');

        $(celdas[5]).addClass('hidden');

    });
}

var quitar_Botones1 = () => {
    var contador = 0;
    $('#Cuerpo_Distribuidor tr').each(function () {
        var celdas = $(this).find('td');

        $(celdas[5]).addClass('hidden');

    });
}

var quitar_Botones2 = () => {
    var contador = 0;
    $('#Cuerpo_Pedidos tr').each(function () {
        var celdas = $(this).find('td');

        $(celdas[5]).addClass('hidden');

    });
}

var quitar_Botones3 = () => {
    var contador = 0;
    $('#Cuerpo_Entrega tr').each(function () {
        var celdas = $(this).find('td');

        $(celdas[5]).addClass('hidden');

    });
}