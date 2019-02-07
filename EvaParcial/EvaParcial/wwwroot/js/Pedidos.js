class ClasePedidos{
    constructor(Fecha, NomCorte, NPiezas, PesoCarne, accion) {
        this.Fecha = Fecha;
        this.NomCorte = NomCorte;
        this.NPiezas = NPiezas;
        this.PesoCarne = PesoCarne;
        this.accion = accion;

    }

    Nuevo_Pedido(idPedidos) {
        var Fecha = this.Fecha;
        var NomCorte = this.NomCorte;
        var NPiezas = this.NPiezas;
        var PesoCarne = this.PesoCarne;
        var accion = this.accion;
        if (idPedidos == '') {
            try {
                $.post(
                    accion,
                    { Fecha, NomCorte, NPiezas, PesoCarne },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Pedidos', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Pedidos', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        } else {
            try {
                $.post(
                    accion,
                    { idPedidos, Fecha, NomCorte, NPiezas, PesoCarne },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Pedidos', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Pedidos', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Pedido(idPedidos) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { idPedidos },
            success: (respuesta) => {                
                document.getElementById("Fecha").value = respuesta.fecha;
                document.getElementById("NomCorte").value = respuesta.nomCorte;
                document.getElementById("NPiezas").value = respuesta.nPiezas;
                document.getElementById("PesoCarne").value = respuesta.pesoCarne;
                document.getElementById("idPedidos").value = respuesta.idPedidos;
            }
        });
    }

    eliminar_Pedido(idPedidos) {
        swal({
            title: "¿Eliminar el Pedido?",
            text: "Esta seguro que desea eliminar el Pedido..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { idPedidos },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Pedidos', respuesta.description, 'success');
                                this.limpiar();
                            } else {
                                swal('Pedidos', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Pedidos', 'Usted a cancelo la accion', 'warning');
                }
            });



    }


    listaPedidos() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#Cuerpo_Pedidos').html(val[0]);
                });
                // $('#cuerpo_Cliente').html(respuesta);
            }
        );
    }




    limpiar() {
        document.getElementById("Fecha").value = '';
        document.getElementById("NomCorte").value = '';
        document.getElementById("NPiezas").value = '';
        document.getElementById("PesoCarne").value = '';
        document.getElementById("idPedidos").value = '';
        $('#Ingreso_Pedidos').modal('hide');
        listaPedidos();
    }




}