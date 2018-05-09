
function removeBookFromCart(e) {
    removeCartItem(e);
    var bookIds = getCookie("TBCbooksInCart").split(".");
    var bId = e.target.attributes[1].nodeValue.toString();
    var newString = "";
    for(var i = 0; i < bookIds.length; i++) {
        if( bookIds[i].split("-")[0] == bId ){
            if(i === bookIds.length - 1){
                newString = newString.substring(0, newString.length-1)
            }
            continue;
        }
        else {
            if(i === bookIds.length - 1){
                newString = newString + bookIds[i];
            }
            else {
                newString = newString + bookIds[i] + ".";
            }
        }
    }
    setCookie("TBCbooksInCart", newString, 3);
}

function removeCartItem(e){
    var element = e.currentTarget.parentElement;
    element.outerHTML = "";
    delete element;
    calculateTotal();
    handleLastRemove();
}

// Toggles classes if last cart item is removed
function handleLastRemove() {
    cartItems = document.getElementsByClassName("cart-remove-btn");
    if(cartItems.length === 0) {
        document.getElementsByClassName("cart-sum-container")[0].classList.toggle("hidden");
        document.getElementsByClassName("cart-empty")[0].classList.toggle("hidden");
    }
}


var rmButtons = document.getElementsByClassName("cart-remove-btn");

for(var i = 0; i < rmButtons.length; i++) {
    rmButtons[i].addEventListener("click", e => removeBookFromCart(e))
}