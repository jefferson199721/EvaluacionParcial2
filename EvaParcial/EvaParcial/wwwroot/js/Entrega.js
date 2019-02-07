class ClaseEntrega {
    constructor(Fecha, ResponsableResive, accion) {
        this.Fecha = Fecha;
        this.ResponsableResive = ResponsableResive;
        this.accion = accion;

    }

    Nuevo_Entrega(idEntrega) {
        var Fecha = this.Fecha;
        var ResponsableResive = this.ResponsableResive;
        var accion = this.accion;
        if (idEntrega == '') {
            try {
                $.post(
                    accion,
                    { Fecha, ResponsableResive },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Entregas', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Entregas', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        } else {
            try {
                $.post(
                    accion,
                    { idEntrega, Fecha, ResponsableResive },
                    (respuesta) => {
                        if (respuesta.code == "ok") {
                            swal('Entregas', respuesta.description, 'success');
                            this.limpiar();
                        } else {
                            swal('Entregas', respuesta.description, 'Error');
                        }
                    });
            } catch (e) {
                alert(e.message);
            }
        }

    }

    Un_Entrega(idEntrega) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { idEntrega },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById("Fecha").value = respuesta.Fecha;
                document.getElementById("ResponsableResive").value = respuesta.ResponsableResive;
                document.getElementById("idEntrega").value = respuesta.idEntrega;
            }
        });
    }

    eliminar_Entrega(idEntrega) {
        swal({
            title: "¿Eliminar la Entrega?",
            text: "Esta seguro que desea eliminar la Entrega..!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var accion = this.accion;
                    $.post(accion, { idEntrega },
                        (respuesta) => {
                            if (respuesta.code == "ok") {
                                swal('Entregas', respuesta.description, 'success');
                                this.limpiar();
                            } else {
                                swal('Entregas', respuesta.description, 'Error');
                            }
                        });
                } else {
                    swal('Entregas', 'Usted a cancelo la accion', 'warning');
                }
            });



    }


    listaEntregas() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#Cuerpo_Entregas').html(val[0]);
                });
                // $('#cuerpo_Cliente').html(respuesta);
            }
        );
    }




    limpiar() {
        document.getElementById("Fecha").value = '';
        document.getElementById("ResponsableResive").value = '';
        document.getElementById("idEntrega").value = '';
        $('#Ingreso_Entrega').modal('hide');
        listaEntrega();
    }




}