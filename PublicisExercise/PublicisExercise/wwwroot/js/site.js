// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//DataTables
$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        var min = parseInt($('#min').val(), 10);
        var max = parseInt($('#max').val(), 10);
        var spots = parseFloat(data[4]) || 0;

        if ((isNaN(min) && isNaN(max)) ||
            (isNaN(min) && spots <= max) ||
            (min <= spots && isNaN(max)) ||
            (min <= spots && spots <= max)) {
            return true;
        }
        return false;
    }
);

let table = $('#datatable-pages').DataTable();

$(document).ready(function () {

    $(".dataTables_filter").hide();

    $("#select-medios").on('change', function () {
        if ($("#select-medios").val() != "0") {
            table.columns(1).search($('#select-medios').val()).draw();
        }
        else {
            table.columns(1).search("").draw();
        }
    });

    $("#select-categorias").on('change', function () {
        if ($("#select-categorias").val() != "0") {
            table.columns(3).search($('#select-categorias').val()).draw();
        }
        else {
            table.columns(3).search("").draw();
        }
    });

    $('#min, #max').keyup(function () {
        table.draw();
    });

    $("#input-id").on('keyup', function () {
        if ($("#input-id").val() != "") {
            
            table.columns(0).search("^" + this.value + "$", true, false, true).draw();
        }
        else {
            table.columns(0).search("").draw();
        }
    });

});

//FUNCIONES
//Variables
let activeId;
let activeRow;
//************************ ALTA
function insertRegister() {

    $('#modal-loading').modal('show');

    if ($('#select-insert-medio').val() == null) {

        $('#modal-loading').modal('hide');
        $('#modal-loading').on('shown.bs.modal', function (e) {
            $("#modal-loading").modal("hide");
        });

        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Campo faltante: "Medio"'
        })
    }
    else if ($('#input-insert-fecha').val() == '') {

        $('#modal-loading').modal('hide');
        $('#modal-loading').on('shown.bs.modal', function (e) {
            $("#modal-loading").modal("hide");
        });

        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Campo faltante: "Fecha"'
        })
    }
    else if ($('#select-insert-categoria').val() == null) {

        $('#modal-loading').modal('hide');
        $('#modal-loading').on('shown.bs.modal', function (e) {
            $("#modal-loading").modal("hide");
        });

        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Campo faltante: "Categoria"'
        })
    }
    else {
        $.ajax({
            type: "POST",
            url: '/Catalogues/InsertRegister',
            datatype: "json",
            data: { "medio": $('#select-insert-medio').val(), "fecha": $('#input-insert-fecha').val(), "categoria": $('#select-insert-categoria').val(), "spots": $('#input-insert-spots').val()},
            cache: false,
            success: function (data) {

                table.row.add([data[0], data[1], data[2], data[3]]).draw()

                $('#modal-loading').modal('hide');
                $('#modal-loading').on('shown.bs.modal', function (e) {
                    $("#modal-loading").modal("hide");
                });

                $('#modal-alta').modal('hide');

                Swal.fire({
                    icon: 'success',
                    title: 'Tu registro ha sido guardado',
                    showConfirmButton: false,
                    timer: 1500
                })

            },
            error: function (error) {

                $('#modal-loading').on('shown.bs.modal', function (e) {
                    $("#modal-loading").modal("hide");
                });

                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Algo salio mal. Intentalo de nuevo más tarde.'
                })

            }
        });
    }
}
//************************ BAJA
function deleteRegister(id, rowId) {

    Swal.fire({
        title: '¿Seguro que deseas eliminar el registro?',
        showDenyButton: true,
        confirmButtonText: 'Borrar',
        denyButtonText: `No Borrar`,
    }).then((result) => {
        if (result.isConfirmed) {

            $('#modal-loading').modal('show');

            $.ajax({
                type: "POST",
                url: '/Catalogues/DeleteRegister',
                datatype: "json",
                data: { "id": id },
                cache: false,
                success: function (data) {

                    if (data != 2) {

                        let rowid = '#row_' + rowId;
                        $("#datatable-pages tbody").find(rowid).remove();

                        $('#modal-loading').modal('hide');
                        $('#modal-loading').on('shown.bs.modal', function (e) {
                            $("#modal-loading").modal("hide");
                        });

                        $('#modal-alta').modal('hide');

                        Swal.fire('Borrado!', '', 'success')

                    }
                    else {

                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'No se encontró el registro que estabas buscando.'
                        })

                    }

                },
                error: function (error) {

                    $('#modal-loading').on('shown.bs.modal', function (e) {
                        $("#modal-loading").modal("hide");
                    });

                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Algo salio mal. Intentalo de nuevo más tarde.'
                    })

                }
            });

        } else if (result.isDenied) {
            Swal.fire('Registro conservado', '', 'info')
        }
    })

}
//************************ MODIFICACION
function loadRegisterData(id, rowId) {

    activeId = id;
    activeRow = rowId;

    $('#modal-loading').modal('show');

    $.ajax({
        type: "POST",
        url: '/Catalogues/LoadRegisterData',
        datatype: "json",
        data: { "id": id },
        cache: false,
        success: function (data) {

            if (data != 2) {

                let fecha = moment(data.fecha).format("YYYY-MM-DD");

                //Asignación de variables regresados
                $('#select-update-medio').val(data.medio).change();
                $('#input-update-fecha').val(fecha);
                $('#select-update-categoria').val(data.idCategory).change();
                $('#input-update-spots').val(data.spots);

                $('#modal-loading').modal('hide');
                $('#modal-loading').on('shown.bs.modal', function (e) {
                    $("#modal-loading").modal("hide");
                });

                $('#modal-modificacion').modal('show');

            }
            else {

                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'No se encontró el registro que buscabas consultar.'
                })

            }

        },
        error: function (error) {

            $('#modal-loading').on('shown.bs.modal', function (e) {
                $("#modal-loading").modal("hide");
            });

            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Algo salio mal. Intentalo de nuevo más tarde.'
            })

        }
    });

}
function updateRegister() {

    $('#modal-loading').modal('show');

    if ($('#select-update-medio').val() == null) {

        $('#modal-loading').modal('hide');
        $('#modal-loading').on('shown.bs.modal', function (e) {
            $("#modal-loading").modal("hide");
        });

        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Campo faltante: "Medio"'
        })
    }
    else if ($('#input-update-fecha').val() == '') {

        $('#modal-loading').modal('hide');
        $('#modal-loading').on('shown.bs.modal', function (e) {
            $("#modal-loading").modal("hide");
        });

        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Campo faltante: "Fecha"'
        })
    }
    else if ($('#select-update-categoria').val() == null) {

        $('#modal-loading').modal('hide');
        $('#modal-loading').on('shown.bs.modal', function (e) {
            $("#modal-loading").modal("hide");
        });

        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Campo faltante: "Categoria"'
        })
    }
    else {
        $.ajax({
            type: "POST",
            url: '/Catalogues/UpdateRegister',
            datatype: "json",
            data: { "id": activeId, "medio": $('#select-update-medio').val(), "fecha": $('#input-update-fecha').val(), "categoria": $('#select-update-categoria').val(), "spots": $('#input-update-spots').val() },
            cache: false,
            success: function (data) {

                table.row(activeRow).data([data[0], data[1], data[2], data[3], '<button type="button" value="' + activeId + '" class="btn btn-danger" onclick="deleteRegister(this.value,' + activeRow + ')">Baja</button>', '<button type="button" value="' + activeId + '" class="btn btn-primary" onclick="loadRegisterData(this.value,' + activeRow + ')">Modificación</button>']).draw()

                $('#modal-loading').modal('hide');
                $('#modal-loading').on('shown.bs.modal', function (e) {
                    $("#modal-loading").modal("hide");
                });

                $('#modal-modificacion').modal('hide');

                Swal.fire({
                    icon: 'success',
                    title: 'Tu registro ha sido guardado',
                    showConfirmButton: false,
                    timer: 1500
                })

            },
            error: function (error) {

                $('#modal-loading').on('shown.bs.modal', function (e) {
                    $("#modal-loading").modal("hide");
                });

                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Algo salio mal. Intentalo de nuevo más tarde.'
                })

            }
        });
    }
}