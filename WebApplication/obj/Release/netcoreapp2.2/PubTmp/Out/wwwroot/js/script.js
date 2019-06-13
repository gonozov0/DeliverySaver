$(document).ready(function () {
    $('.mdb-select').materialSelect();
});

jQuery(function ($) {
    $('tbody tr[data-href]').addClass('clickable').click(function () {
        window.location = $(this).attr('data-href');
    });
});

function deleteData(index) {
    $.ajax({
        url: "/employee/" + index,
        type: 'DELETE'
        //success: getData
    });
}

function remove_item(event) {
    var parent = $(event.target).parent()
    alert(parent.attr("method"))
    parent.attr("method", "delete")
    var button = parent.children("button[type]")
    //alert(button)
    button.submit()
}