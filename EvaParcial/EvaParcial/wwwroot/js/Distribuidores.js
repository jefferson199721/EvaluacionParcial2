class ClaseDistribuidor {
    constructor(Nombres, Direccion, listaReseptor, accion) {
        this.Nombres = Nombres;
        this.Direccion = Direccion;
        this.listaReseptor = listaReseptor;
        this.accion = accion;

    }

    Nuevo_Distribuidor(idDistribuidor) {
        var Nombres = this.Nombres;
        var Direccion = this.Direccion;
        var listaReseptor = this.listaReseptor;
        var accion = this.accion;
        if (idDistribuidor == '') {
            try {
                $.post(
                    accion,
                    { Nombres, Direccion, listaReseptor },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Distribuidores', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Distribuidores', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        } else {
            try {
                $.post(
                    accion,
                    { idDistribuidor, Nombres, Direccion, listaReseptor },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Distribuidores', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Distribuidores', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Distribuidor(idDistribuidor) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { idDistribuidor },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById("Nombres").value = respuesta.nombres;
                document.getElementById("Direccion").value = respuesta.direccion;
                document.getElementById("listaReseptor").value = respuesta.listaReseptor;
                document.getElementById("idDistribuidor").value = respuesta.idDistribuidor;
            }
        });
    }

    eliminar_Distribuidor(idDistribuidor) {
        swal({
            title: "¿Eliminar Distribuidor?",
            text: "Esta seguro que desea eliminar el Distribuidor..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { idDistribuidor },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Distribuidores', respuesta.description, 'success');
                                this.limpiar();
                            } else {
                                swal('Distribuidores', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Distribuidores', 'Usted a cancelo la accion', 'warning');
                }
            });



    }


    listaDistribuidor() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#Cuerpo_Distribuidor').html(val[0]);
                });
                // $('#cuerpo_Cliente').html(respuesta);
            }
        );
    }




    limpiar() {
        document.getElementById("Nombres").value = '';
        document.getElementById("Direccion").value = '';
        document.getElementById("listaReseptor").value = '';
        document.getElementById("idDistribuidor").value = '';
        $('#Ingreso_Distribuidor').modal('hide');
        listaDistribuidor();
    }




}