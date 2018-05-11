function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        var picture = "";
        reader.onload = function (e) {
            picture = e.target.result;
            document.getElementsByClassName("profile-picture")[0].style.backgroundImage = "url('" + picture + "')";

            // Check for maxsize
            $.ajax({
                url: "/account/editProfilePicture",
                type: 'POST',
                data: { picture: picture },
                success: function(result) {
                    console.log("Success")
                },
                fail: function() {
                    console.log("fail")
                }
            });
        };
        reader.readAsDataURL(input.files[0]);
    }
}

window.onload = function() {
    var elem = document.getElementsByClassName("profile-picture")[0];
    var picture = elem.getAttribute("value");
    elem.style.backgroundImage = "url('" + picture + "')";
}
