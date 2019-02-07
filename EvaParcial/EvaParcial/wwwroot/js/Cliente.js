class ClaseClientes {
    constructor(Nombre, Direccion, Ruc, accion) {
        this.Nombre = Nombre;
        this.Direccion = Direccion;
        this.Ruc = Ruc;
        this.accion = accion;
        
    }

    Nuevo_Cliente(idCliente) {
        var Nombre = this.Nombre;
        var Direccion = this.Direccion;
        var Ruc = this.Ruc;
        var accion = this.accion;
        if (idCliente == '') {
            try {
                $.post(
                    accion,
                    { Nombre, Direccion, Ruc },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Clientes', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Clientes', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        } else {
            try {
                $.post(
                    accion,
                    { Nombre, Direccion, Ruc},
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Clientes', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Clientes', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Cliente(idCliente) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { idCliente },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById("Nombre").value = respuesta.Nombre;
                document.getElementById("Direccion").value = respuesta.Direccion;
                document.getElementById("Ruc").value = respuesta.Ruc;
                document.getElementById("idCliente").value = respuesta.idCliente;
            }
        });
    }  
            
                
               

    eliminar_cliente(idCliente) {
        swal({
            title: "¿Eliminar Cliente?",
            text: "Esta seguro que desea eliminar el cliente..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { idCliente },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Clientes', respuesta.description, 'success');
                                this.limpiar();
                            } else {
                                swal('Clientes', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Clientes', 'Usted a cancelo la accion', 'warning');
                }
            });



    }


    listaClientes() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {

                $.each(respuesta, (index, val) => {
                    $('#Cuerpo_Cliente').html(val[0])
                });
                // $('#cuerpo_Cliente').html(respuesta);
            }
        );
    }




    limpiar() {
        document.getElementById("Nombre").value = '';
        document.getElementById("Direccion").value = '';
        document.getElementById("Ruc").value = '';
        document.getElementById("idCliente").value = '';
        $('#Ingreso_Cliente').modal('hide');
        listaClientes();
    }




}