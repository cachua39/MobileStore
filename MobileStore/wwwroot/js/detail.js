function plus(id) {
    var strId = "#" + id.toString();
    var quantity = $(strId).val();

    quantity = parseInt(quantity) + 1;
    
    $(strId).val(quantity);
    
//    var subTotal = parseFloat($('#subTotal'+id).text()) * quantity;
//    $('#subTotal'+id).text(subTotal.toFixed(1));
};

function minus(id) {
    var strId = "#" + id.toString();
    var quantity = $(strId).val();

    quantity = parseInt(quantity) - 1;

    if (quantity < 1) {
        quantity = 1;
    }

    $(strId).val(quantity);
    
//    var subTotal = parseFloat($('#subTotal'+id).text()) * quantity;
//    $('#subTotal'+id).text(subTotal.toFixed(1));
}