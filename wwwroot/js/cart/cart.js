// https://www.w3schools.com/js/js_cookies.asp
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays*24*60*60*1000));
    var expires = "expires="+ d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    console.log(cvalue)
    //test();
}

function test() {
    $.ajax({
        url: "/Cart",
        method: "POST",
        success: function (responseData) {
            console.log($(responseData))
            console.log($(responseData).find('.cart-item-container').prevObject[26])
            $('.cart-item-container').replaceWith($(responseData).find('.cart-item-container').prevObject[26]);
        }
    })
}

// https://www.w3schools.com/js/js_cookies.asp
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for(var i = 0; i <ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}


function addQuantity(oldId, cookieValue){
    var split = oldId.split("-");
    var quant = parseInt(split[1]) + 1;
    updateCookie(split[0] + "-" + quant, oldId, cookieValue);
}

function lowerQuantity(oldId, cookieValue){
    var split = oldId.split("-");
    var quant = parseInt(split[1]) - 1;
    if(quant === -1) {
        return;
    }
    updateCookie(split[0] + "-" + quant, oldId, cookieValue);
}

function updateCookie(newId, oldId, cvalue) {
    var newCookie =  cvalue.replace(oldId, newId);
    setCookie("TBCbooksInCart", newCookie, 3);
}