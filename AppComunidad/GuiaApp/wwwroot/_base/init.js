(function ($) {
    $.extend(true, $.fn.dataTable.defaults, {
        "serverSide": true,
        "ordering": false,
        "searching": false,
        "responsive": true,
        "lengthChange": false,
        "pageLength": 10,
        "pagingType": "full_numbers",
        "paging": true,
        "processing": false,
        "language": {
            "lengthMenu": "Ver _MENU_ registros por pagina",
            "zeroRecords": "No existe data",
            "info": "<h6>Página <b><i>_PAGE_</i></b> de <b><i>_PAGES_</i></b></br>Total de Registros: <b><i>_MAX_</i></b></h6>",
            "infoEmpty": "No hay información disponibles",
            "infoFiltered": "( _MAX_ total de registros)",
            "loadingRecords": "Cargando...",
            "processing": 'Cargando...',
            "emptyTable":"Registros no disponibles",
            "paginate": {
                "first": "<<",
                "last": ">>",
                "next": ">",
                "previous": "<"
            }
        }
    });

    $.fn.select2.defaults.set("maximumSelectionLength", "6");
    $.fn.select2.defaults.set("language", "es");
    $.fn.select2.defaults.set("placeholder", "Seleccione..");
    $.fn.select2.defaults.set("maximumInputLength", "20");
    $.fn.select2.defaults.set("allowClear", true);

    $(document).ajaxStart(function () {
        $.blockUI({
            message: '<img src="/img/loading.gif" width="120" />',
            centerY: 0,
            css: {
                width: '175px',
                top: ($(window).height() - 150) / 2 + 'px',
                left: ($(window).width() - 150) / 2 + 'px',
                border: '0px solid #ff8304',
                padding: '10px',
                backgroundColor: '',
                opacity: .99,
                color: '#FFFFFF'
            },
            fadeIn: 200,
            fadeOut: 400
        });
    });

    $(document).ajaxComplete(function () {
        $.unblockUI();
    });

})(jQuery);

