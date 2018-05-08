
function removeBookFromCart(e) {
    removeCartItem(e);
    e.stopPropagation();
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

    var element = e.path[2];
    if(e.target.className === "cart-remove-btn") {
        element = e.path[1];
    }
    console.log(element)
    element.outerHTML = "";
    delete element;

}


var rmButtons = document.getElementsByClassName("cart-remove-btn");

for(var i = 0; i < rmButtons.length; i++) {
    rmButtons[i].addEventListener("click", e => removeBookFromCart(e))
}