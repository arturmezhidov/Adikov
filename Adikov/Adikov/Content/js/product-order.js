(function ($) {

    $('#order-modal-open').click(function () {
        var $modal = $('#order-modal');
        var $orderList = $('#order-list');
        var $table = $('#product-info-table');
        var $tableHeader = $table.find('thead th:not(:first)');
        var $selectedRows = $table.find('.checkboxes:checked').closest('tr');
        $orderList.html('');
        if ($selectedRows.length) {
            $selectedRows.each(function (index) {
                var $listItem = createOrderListItem(index, this, $tableHeader);
                $orderList.append($listItem);
            });
            $('#order-list-wrapper').show();
            $('#order-modal-wrapper').attr('class', 'col-md-6');
        } else {
            $('#order-list-wrapper').hide();
            $('#order-modal-wrapper').attr('class', 'col-md-12');
        }
    });

    function createOrderListItem(index, tableRow, $tableHeader) {
        var notes = ['success', 'info', 'danger', 'warning'];
        var $row = $(tableRow);
        var $item = $('<div class="list-item note note-' + notes[index % 4] + '"/>');
        var $close = $('<i class="fa fa-times pull-right" ></i >');
        var $tds = $row.find('td:not(:first)');
        $tds.each(function (index, td) {
            var type = $(td).data('data-type');
            var label = $tableHeader.get(index).innerText;
            var value = this.innerHTML;
            var $content = null;
            if (type === 'Status') {
                $content = $('<p><span class="item-label"><span class="status-label">' + label + ' <i class="fa fa-times pull-right"></i></span></span> ' + value + '</p>');
                $content.find('.fa-times').click(function () {
                    $content.remove();
                });
            } else {
                $content = $('<p><span class="item-label">' + label + ': </span> ' + value + '</p>');
            }
            $item.append($content);
        });
        $item.prepend($close);
        $close.click(function () {
            $item.remove();
            $row.find('.checkboxes').click();
            if (!$('#order-list .list-item').length) {
                $('#order-list-wrapper').hide();
                $('#order-modal-wrapper').attr('class', 'col-md-12');
            }
        });

        function createStatusRow(index, td) {
            
        }

        return $item; 
    }

})(jQuery);