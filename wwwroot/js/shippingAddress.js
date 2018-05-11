    document.getElementsByClassName("ToggleShowOrHide")[0].addEventListener("change", () => toggleclass("shippingAdress") );
   
    function toggleclass(className) {
        document.getElementsByClassName(className)[0].classList.toggle("hidden");
    }