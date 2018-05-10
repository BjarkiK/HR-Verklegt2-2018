function addBookToCart(e) {
   /* var bookId = e.target.attributes[1].nodeValue;
    $.post("/cart/addBookToCart", bookId, function(data, status) {
        console.log("Success id:" + bookId)
    }).fail(function() {
        console.log("Failed");
    })*/
   
    var bookId = e.target.attributes[1].nodeValue.toString();
    var cookie = getCookie("TBCbooksInCart");
    var cartIconElem = document.getElementsByClassName("glyphicon-shopping-cart")[0];
    if(!idAlreadyAdded(cookie, bookId)) {
        bookId = bookId + "-1";
        if(cookie === ""){
            setCookie("TBCbooksInCart", bookId, 3);
        }
        else {
            cookie = cookie + "." + bookId;
            setCookie("TBCbooksInCart", cookie, 3);
        }
        alertBookAdd();
        addCartBadge();
    }
    else {
        alertBookAdd();
    }
}

function alertBookAdd() {
    var bookTitle = document.getElementsByClassName("book-detail-title")[0];
    if (bookTitle != null) {
        $('.book-detail-addtocart-button').popover({content: "" + bookTitle.innerHTML + " added to cart!", trigger: "focus", placement: "bottom"});
        $('.book-detail-addtocart-button').popover('show');
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