function addBookToCart(e) {
   /* var bookId = e.target.attributes[1].nodeValue;
    $.post("/cart/addBookToCart", bookId, function(data, status) {
        console.log("Success id:" + bookId)
    }).fail(function() {
        console.log("Failed");
    })*/
   
    var bookId = e.target.attributes[1].nodeValue.toString();
    var cookie = getCookie("TBCbooksInCart");
    if(!idAlreadyAdded(cookie, bookId)) {
        bookId = bookId + "-1";
        if(cookie === ""){
            setCookie("TBCbooksInCart", bookId, 3);
        }
        else {
            cookie = cookie + "." + bookId;
            setCookie("TBCbooksInCart", cookie, 3);
        }
        //TODO let user know book was added
    }
    else {
        //TODO let user know book quantity was updated
    }
}

function idAlreadyAdded(cvalue, bId) {
    var bookIds = cvalue.split(".");
    for(var i = 0; i < bookIds.length; i++) {
        var currId = bookIds[i].split("-")[0];
        if( currId == bId ){
            addQuantity(bookIds[i], cvalue)
            return true
        }
    }
    return false;
}

document.getElementsByClassName("book-detail-addtocart-button")[0].addEventListener("click", e => addBookToCart(e))