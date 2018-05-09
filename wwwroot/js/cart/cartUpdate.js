var add = document.getElementsByClassName("cart-add-quantity-btn");
var lower = document.getElementsByClassName("cart-remove-quantity-btn");

for(var i = 0; i < add.length; i++) {
    add[i].addEventListener("click", e => plus(e));
    lower[i].addEventListener("click", e => minus(e));
}

document.addEventListener('DOMContentLoaded', function() {
    calculateTotal();
 }, false);

function calculateTotal(){
    var sums = document.getElementsByClassName("cart-item-sum");
    var sum = 0;
    for(var i = 0; i < sums.length; i++) {
        sum = parseInt(sums[i].innerHTML.split(" ")[0]) + sum;
    }
    var totalElement =  document.getElementsByClassName("cart-total");
    
    // If cart was empty on load
    if(totalElement.length === 0) {
        document.getElementsByClassName("cart-empty")[0].classList.toggle("hidden");
        return;
    }
    totalElement[0].innerHTML = sum + " kr";
    totalElement[0].setAttribute("value", sum);
    applyPromo();
    console.log(sum)
}

function plus(e) { 
    quantityUpdateAdd(e);
    updateSum(e, 1);
}

function minus(e) {
    quantityUpdateLower(e);
    updateSum(e, -1);
}

function quantityUpdateAdd(e) {
    var quantityElem = getElemOnAlterQuantity(e, "cart-quantity");
    var bookId = quantityElem.attributes[1].value;
    addQuantity(bookId, getCookie("TBCbooksInCart"));
    uptadeCart(bookId, quantityElem, 1);
}

function quantityUpdateLower(e) {
    var quantityElem = getElemOnAlterQuantity(e, "cart-quantity");
    var bookId = quantityElem.attributes[1].value;
    lowerQuantity(bookId, getCookie("TBCbooksInCart"));
    uptadeCart(bookId, quantityElem, -1);
}

function updateSum(e, plusOrMinus) {
    var price = getElemOnAlterQuantity(e, "cart-price").getAttribute("value");
    var sumElem = getElemOnAlterQuantity(e, "cart-item-sum");
    var sum = sumElem.innerHTML.split(" ")[0];
    if(sum === price && plusOrMinus === -1) {
        return;
    }
    sumElem.innerHTML = parseInt(sum) + parseInt(price)*plusOrMinus + " kr";
    calculateTotal();
}

function uptadeCart(bookId, quantityElem, plusOrMinus){
    var idContent = bookId.split("-");
    var quantity = parseInt(idContent[1]) + plusOrMinus;
    if(quantity  === 0) {
        return;
    }
    quantityElem.innerHTML = quantity + "";
    quantityElem.setAttribute("value", idContent[0] + "-" + quantity);
}


function getElemOnAlterQuantity(e, findClass) {
    var quantityElem = e.currentTarget.parentElement.parentElement.getElementsByClassName(findClass)[0];
    return quantityElem;
}