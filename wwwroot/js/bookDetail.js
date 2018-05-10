document.addEventListener("DOMContentLoaded", function(event) { 
    var bookTitle = document.getElementsByClassName("book-detail-title")[0];
    $('.book-detail-addtocart-button').popover({content: "" + bookTitle.innerHTML + " added to cart!", trigger: "focus", placement: "bottom"});
  });

var StarRating = (function () {
    function StarRating(target) {
        function attr(name, d) {
            var a = target.getAttribute(name);
            return (a ? a : d);
        }

        var rateElem = document.getElementsByClassName("book-detail-grade")[0],
            defaultRating = rateElem.getAttribute("value").replace(",", "."),
            currentRating = -1,
            stars = [];


        target.style.display = 'inline-block';

        for (var s = 0; s < 5; s++) {
            var n = document.createElement('span');
            n.className = 'star';
            n.addEventListener('click', starClick);
            if (s > 0)
                stars[s - 1].appendChild(n);
            else
                target.appendChild(n);

            stars.push(n);
        }

        function fixFloat(num) {
            return parseFloat(num).toFixed(1);
        }

        function setCurrentRating(rating) {
            currentRating = rating;
            target.setAttribute('data-rating', currentRating);
            showCurrentRating();
        }
        this.setCurrentRating = setCurrentRating;

        function setDefaultRating(rating) {
            defaultRating = rating;

            if (rating % 1 != 0)
                defaultRating = fixFloat(defaultRating);

            rateElem.innerHTML = defaultRating;
            showRating(defaultRating);
        }
        this.setDefaultRating = setDefaultRating;

        setDefaultRating(rateElem.getAttribute("value").replace(",","."));

        this.onrate = function (rating) {};

        target.addEventListener('mouseout', function () {
            showCurrentRating();
        });

        target.addEventListener('mouseover', function () {
            clearRating();
        });

        function showRating(r) {
            clearRating();
            for (var i = 0; i < stars.length; i++) {
                if (i >= r)
                    break;
                if (i === Math.floor(r) && i !== r)
                    stars[i].classList.add('half');
                stars[i].classList.add('active');
            }
        }

        function showCurrentRating() {
            var ratingAttr = parseFloat(attr('data-rating', 0));
            if (ratingAttr) {
                currentRating = ratingAttr;
                showRating(currentRating);
            } else {
                showRating(defaultRating);
            }
        }

        function clearRating() {
            for (var i = 0; i < stars.length; i++) {
                stars[i].classList.remove('active');
                stars[i].classList.remove('half');
            }
        }

        function starClick(e) {
            if (this === e.target) {
                var starClicked = stars.indexOf(e.target);
                if (starClicked !== -1) {
                    var sRating = starClicked + 1;
                    setCurrentRating(sRating);
                    if (typeof this.onrate === 'function')
                        this.onrate(currentRating);
                    var evt = new CustomEvent('rate', {
                        detail: sRating,
                    });
                    target.dispatchEvent(evt);
                }
            }
        }
    }
    return StarRating;
})();


var stars = document.getElementsByClassName('rating');
for (var i = 0; i < stars.length; i++) {
    var r = new StarRating(stars[i]);

    stars[i].addEventListener('rate', function(e) {
        console.log('Rating: ' + e.detail);
        var bookId = Number(location.pathname.split('/')[3]);
        $.post('/book/totalGradeUpdate',{ bid : bookId, grade : e.detail }, function(returnData) {
            console.log(status + " " + returnData);
            r.setDefaultRating(returnData);
        }).fail(function(response) {
            console.log("failed" + response);
        })
    });
}