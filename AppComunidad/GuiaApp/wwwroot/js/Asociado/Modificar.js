(function () {
    //var btnDowload = document.getElementById('btn-dowload');
    var btnGuardarImagen = document.getElementById('btnGuardarImagen');
    var btnCancelarImagen = document.getElementById('btnCancelarImagen');
    var btnGuardarRed = document.getElementById('btnGuardarRed');
    var btnCancelarRed = document.getElementById('btnCancelarRed');
    var btnActualizar = document.getElementById('btnActualizar');
    var btnRegistrarNegocio = document.getElementById('btnRegistrarNegocio');
    

    document.addEventListener("DOMContentLoaded", function () {
        paginationImagenes();
        paginationRedes();
        //btnDowload.addEventListener('click', dowloadExcel);
        btnGuardarImagen.addEventListener('click', UploadImagen);
        btnGuardarRed.addEventListener('click', GuardarRed);
        btnActualizar.addEventListener('click', ActualizarUsuario);
        btnRegistrarNegocio.addEventListener('click', RegistrarNegocio);
    });

    $('body').on('click', '.btn-delete-Imagen', function () {
        var input = this;
        eliminarConfirm(() => eliminarImagen(input));
    });

    $('body').on('click', '.btn-delete-Red', function () {
        var input = this;
        eliminarConfirm(() => eliminarRed(input));
    });

    var eliminarImagen = function (input) {
        var data = 'id=' + input.name;
        $.ajax({
            url: url.DeleteImagen,
            type: 'DELETE',
            async: true,
            data: data,
            dataType: 'json',
            success: function (response) {
                if (response) {
                    $('#tblImagenes').DataTable().ajax.reload();
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    };

    var eliminarRed = function (input) {
        var data = 'id=' + input.name;
        $.ajax({
            url: url.DeleteRed,
            type: 'DELETE',
            async: true,
            data: data,
            dataType: 'json',
            success: function (response) {
                if (response) {
                    $('#tblRedes').DataTable().ajax.reload();
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    };

    var paginationImagenes = function () {
        var id = $('#IdUsuario').val();
        $('#tblImagenes').DataTable({
            "ajax": {
                "url": url.PaginationImagenes,
                "data": {
                    "id": id
                },
                "type": "GET",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                {
                    "data": "tipoImagen"
                },
                {
                    "data": "nombre"
                },
                {
                    "data": "extension"
                },
                {
                    "data": null, "name": "Acciones"
                }
            ],
            "columnDefs": [
                {
                    "targets": 3,
                    "render": function (data, type, row) {
                        //<a class="btn btn-warning btn-sm" href="' + url.Edit + '/' + data.id + '"><i class="btn-text">Editar &nbsp;&nbsp;</i><i class="fa fa-pencil"></i></a>&nbsp;
                        return '<a class="btn btn-danger btn-sm btn-delete-Imagen" name="' + data.id + '"><i class="btn-text">Eliminar &nbsp;&nbsp;</i><i class="fa fa-trash"></i></a>';
                    }
                }

            ]
        });
    };

    var paginationRedes = function () {
        var id = $('#IdUsuario').val();
        $('#tblRedes').DataTable({
            "ajax": {
                "url": url.PaginationRed,
                "data": {
                    "id": id
                },
                "type": "GET",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                {
                    "data": "tipoRed"
                },
                {
                    "data": "recurso"
                },
                {
                    "data": null, "name": "Acciones"
                }
            ],
            "columnDefs": [
                {
                    "targets": 2,
                    "render": function (data, type, row) {
                        //<a class="btn btn-warning btn-sm" href="' + url.Edit + '/' + data.id + '"><i class="btn-text">Editar &nbsp;&nbsp;</i><i class="fa fa-pencil"></i></a>&nbsp;
                        return '<a class="btn btn-danger btn-sm btn-delete-Red" name="' + data.id + '"><i class="btn-text">Eliminar &nbsp;&nbsp;</i><i class="fa fa-trash"></i></a>';
                    }
                }

            ]
        });
    };

    var dowloadExcel = function () {
        window.open(url.Excel, '_blank');
    };

    var UploadImagen = function () {
        var formData = new FormData();
        formData.append('file', $('#myfile')[0].files[0]);
        formData.append('IdUsuario', $('#IdUsuario').val());
        formData.append('TipoImagenId', $('#ddlTipoImagen option:selected').val());

        $.ajax({
            url: url.UploadImagen,
            type: 'POST',
            async: true,
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response) {
                    if (response.estado) {
                        btnCancelarImagen.click();
                        $.toast({
                            heading: '¡Exito!',
                            text: response.message,
                            showHideTransition: 'slide',
                            icon: 'success'
                        });
                        $('#tblImagenes').DataTable().ajax.reload();
                    }
                    else {
                        btnCancelarImagen.click();
                        $.toast({
                            heading: 'Error al Cargar Imagen',
                            text: response.message,
                            showHideTransition: 'slide',
                            icon: 'error'
                        });
                    }
                }
            },
            error: function (error) {
                console.log(error);
            }
        });

        $('#modal-imagenes').on('show.bs.modal', function () {
            $('#myfile').val('');
            $('#txtImagenNombre').val('');
            $('#ddlTipoImagen').val("0");
        })
    };

    var GuardarRed = function () {
        var formData = new FormData();

        formData.append('Recurso', $('#txtRecurso').val());
        formData.append('IdUsuario', $('#IdUsuario').val());
        formData.append('TipoRedId', $('#ddlTipoRed option:selected').val());

        $.ajax({
            url: url.GuardarRed,
            type: 'POST',
            async: true,
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response) {
                    if (response.estado) {
                        btnCancelarRed.click();
                        $.toast({
                            heading: '¡Exito!',
                            text: response.message,
                            showHideTransition: 'slide',
                            icon: 'success'
                        });
                        $('#tblRedes').DataTable().ajax.reload();
                    }
                    else {
                        btnCancelarRed.click();
                        $.toast({
                            heading: 'Error al Cargar Imagen',
                            text: response.message,
                            showHideTransition: 'slide',
                            icon: 'error'
                        });
                    }
                }
            },
            error: function (error) {
                console.log(error);
            }
        });

        $('#modal-redessociales').on('show.bs.modal', function () {
            $('#txtRecurso').val('');
            $('#ddlTipoRed').val("0");
        })
    }

    var ActualizarUsuario = function () {
        var formData = new FormData();

        formData.append('IdUsuario', $('#IdUsuario').val());
        formData.append('Nombre', $('#txtUsuarioNombre').val());
        formData.append('Apellido', $('#txtUsuarioApellido').val());
        formData.append('Password', $('#txtUsuarioPassword').val());

        $.ajax({
            url: url.ActualizarUsuario,
            type: 'POST',
            async: true,
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response) {
                    if (response.estado) {
                        $.toast({
                            heading: '¡Exito!',
                            text: response.message,
                            showHideTransition: 'slide',
                            icon: 'success'
                        });
                    }
                    else {
                        $.toast({
                            heading: 'Error al Actualizar Datos',
                            text: response.message,
                            showHideTransition: 'slide',
                            icon: 'error'
                        });
                    }
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    var RegistrarNegocio = function ()
    {
        var formData = new FormData();

        formData.append('IdUsuario', $('#IdUsuario').val());
        formData.append('Descripcion', $('#txtDescripcion').val());
        formData.append('CategoriaId', $('#ddlCategoria option:selected').val());
        formData.append('SubCategoriaId', $('#ddlSubCategoria option:selected').val());

        $.ajax({
            url: url.RegistrarNegocio,
            type: 'POST',
            async: true,
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response) {
                    if (response.estado) {
                        $.toast({
                            heading: '¡Exito!',
                            text: response.message,
                            showHideTransition: 'slide',
                            icon: 'success'
                        });
                    }
                    else {
                        $.toast({
                            heading: 'Error al Actualizar Datos',
                            text: response.message,
                            showHideTransition: 'slide',
                            icon: 'error'
                        });
                    }
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

})();