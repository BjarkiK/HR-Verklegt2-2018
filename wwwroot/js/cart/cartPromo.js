document.getElementsByClassName("cart-promo-btn")[0].addEventListener("click", e => checkPromo(e));

function checkPromo(e) {
    var code = document.getElementsByClassName("cart-promo-input")[0].value.toString();

    $.post("/cart/validatePromoCode", { code: code }, function(data, status) {
        document.getElementsByClassName("promo-message")[0].innerHTML = "Promocode " + code + " added. You received " + data + "% discount" ;
        setPromoValue(data);
        setPromoCookie(data, code);
        applyPromo();
    }).fail(function(response) {
        document.getElementsByClassName("promo-message")[0].innerHTML = "Promocode not valid. Try another."
    })
}

function setPromoValue(data) {
    var promoCodeValue = document.getElementsByClassName("promo-code-value")[0];
    promoCodeValue.innerHTML = data + "% OFF";
    promoCodeValue.setAttribute("value", data);
    document.getElementsByClassName("promo-col")[0].classList.remove("hidden");
    var totalElement =  document.getElementsByClassName("cart-total")[0];
    totalElement.style.textDecoration = "line-through";
}

// Used whan seting discount and when updating cart()
function applyPromo() {
    var discount = document.getElementsByClassName("promo-code-value")[0].getAttribute("value");
    // If value has not been set, for example on refresh
    if(discount === null) {
        var cookie = getCookie("TBCPromoCode");
        if(cookie != "") {
            var promo = JSON.parse(cookie);
            var discount = promo.discount;
            setPromoValue(discount);
        }
        else {
            return;
        }
    }
    var total =  document.getElementsByClassName("cart-total")[0].getAttribute("value");
    var totalDiscountElem =  document.getElementsByClassName("cart-discount-total")[0];
    totalDiscountElem.innerHTML = parseInt(total)*(1-parseInt(discount)/100) + "kr";
    totalDiscountElem.classList.remove("hidden");
}


// promo code will be acrive untill cookie expires or is deleted. Mac 2 days
function setPromoCookie(discount, code) {
    var promo = { "code":code, "discount":discount};
    var promoJSON = JSON.stringify(promo);
    setCookie("TBCPromoCode", promoJSON, 2);
}