(function($) {

    $(function() {

        var table = $('#product-info-table');

        table.DataTable({
            paging: false,
            info: true,
            language: {
                emptyTable: "Нет данных.",
                search: "Поиск:",
                zeroRecords: "Ничего не найдено.",
                info: "Всего _TOTAL_ позиций"
            },
            "columnDefs": [{  // set default column settings
                'orderable': false,
                'targets': [0]
            }, {
                "searchable": false,
                "targets": [0]
            }],
            "dom": 'fti<"bottom"><"clear">',
            "order": [
                [1, "asc"]
            ] // set first column as a default sort by asc
        });

        table.find('.group-checkable').change(function () {
            var set = jQuery(this).attr("data-set");
            var checked = jQuery(this).is(":checked");
            jQuery(set).each(function () {
                if (checked) {
                    $(this).prop("checked", true);
                    $(this).parents('tr').addClass("active");
                } else {
                    $(this).prop("checked", false);
                    $(this).parents('tr').removeClass("active");
                }
            });
        });

        table.on('change', 'tbody tr .checkboxes', function () {
            var $tr = $(this).closest('tr').toggleClass("active");
            var $unchecked = $tr.siblings('tr').find('input.checkboxes:not(:checked)');
            if (!$unchecked.length) {
                table.find('.group-checkable').prop("checked", true);
            }
        });
    });

})(jQuery);