(function () {
    var btnDowload = document.getElementById('btn-dowload');

    document.addEventListener("DOMContentLoaded", function () {
        pagination();
        btnDowload.addEventListener('click', dowloadExcel);
    });

    $('body').on('click', '.btn-delete', function () {
        var input = this;
        eliminarConfirm(() => eliminar(input));
    });

    var eliminar = function (input) {
        var data = 'id=' + input.name;
        $.ajax({
            url: url.Delete,
            type: 'DELETE',
            async: true,
            data: data,
            dataType: 'json',
            success: function (response) {
                if (response) {
                    $('#tblMenu').DataTable().ajax.reload();
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    };

    var pagination = function () {
        $('#tblMenu').DataTable({
            "ajax": {
                "url": url.Pagination,
                "type": "GET",
                "contentType": "application/json; charset=utf-8"
            },
            "columns": [
                {
                    "data": "nombre"
                },
                {
                    "data": null, "name": "Acciones"
                }
            ],
            "columnDefs": [
                {
                    "targets": 1,
                    "render": function (data, type, row) {
                        return '<a class="btn btn-warning btn-sm" href="' + url.Edit + '/' + data.id + '"><i class="btn-text">Editar &nbsp;&nbsp;</i><i class="fa fa-pencil"></i></a>&nbsp;<a class="btn btn-danger btn-sm btn-delete" name="' + data.id + '"><i class="btn-text">Eliminar &nbsp;&nbsp;</i><i class="fa fa-trash"></i></a>';
                    }
                }

            ]
        });
    };

    var dowloadExcel = function () {
        window.open(url.Excel, '_blank');
    };

})();