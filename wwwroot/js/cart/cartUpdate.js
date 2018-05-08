var add = document.getElementsByClassName("cart-add-quantity-btn");
var lower = document.getElementsByClassName("cart-remove-quantity-btn");

for(var i = 0; i < add.length; i++) {
    add[i].addEventListener("click", e => quantityUpdateAdd(e));
    lower[i].addEventListener("click", e => quantityUpdateLower(e));
}

function quantityUpdateAdd(e) {
    var quantityElem = getQuantityElemAdd(e)
    var bookId = quantityElem.attributes[1].value
    addQuantity(bookId, getCookie("TBCbooksInCart"));
    uptadeChart(bookId, quantityElem, 1);
}

function quantityUpdateLower(e) {
    var quantityElem = getQuantityElemLower(e)
    var bookId = quantityElem.attributes[1].value
    lowerQuantity(bookId, getCookie("TBCbooksInCart"));
    uptadeChart(bookId, quantityElem, -1);
}

function uptadeChart(bookId, quantityElem, plusOrMinus){
    var idContent = bookId.split("-");
    var quantity = parseInt(idContent[1]) + plusOrMinus;
    if(quantity  === -1) {
        return;
    }
    quantityElem.innerHTML = quantity + "";
    quantityElem.setAttribute("value", idContent[0] + "-" + quantity);
}

function getQuantityElemLower(e) {
    var quantityElem = e.target.nextElementSibling;
    if(quantityElem === null) {
        quantityElem = e.target.parentElement.nextElementSibling;
    }
    return quantityElem;
}


function getQuantityElemAdd(e) {
    var quantityElem = e.target.previousElementSibling;
    if(quantityElem === null) {
        quantityElem = e.target.parentElement.previousElementSibling;
    }
    return quantityElem;
}