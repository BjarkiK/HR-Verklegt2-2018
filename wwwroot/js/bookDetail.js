displayStars();

function addBookToCart(e) {
    var bookId = e.target.attributes[1].nodeValue.toString();
    var books = getCookie("TBCbooksInCart");
    if(!idAlreadyAdded(books, bookId)) {
        if(books === ""){
            setCookie("TBCbooksInCart", bookId, 1);
        }
        else {
            books = books + "." + bookId;
            setCookie("TBCbooksInCart", books, 1);
        }
    }
}

function idAlreadyAdded(cvalue, bId) {
    var bookIds = cvalue.split(".");
    for(var i = 0; i < bookIds.length; i++) {
        if( bookIds[i] == bId ){
            return true
        }
    }
    return false;
}

document.getElementsByClassName("book-detail-addtocart-button")[0].addEventListener("click", e => addBookToCart(e))

function createElementFromHTML(htmlString) {
    var div = document.createElement('div');
    div.innerHTML = htmlString.trim();
    return div.firstChild; 
}

// Made in a hurry. Tidy up if time
function displayStars() {
    var gradeElem = document.getElementsByClassName("book-detail-grade")[0];
    var grade = gradeElem.getAttribute("value").replace(",", ".");
    var antiGrade = 0;
    while(grade >= 0.0 && grade <= 5.0 ) {
        if(grade >= 1) {
            grade--;
            antiGrade++;
            var star = createElementFromHTML("<i class=\"fa fa-star star-yellow\"></i>")
            gradeElem.parentElement.insertBefore(star, gradeElem)
        }
        else if(grade >= 0.5) {
            grade -= 0.5;
            antiGrade += 0.5;
            var halfStar = createElementFromHTML("<i class=\"fa fa-star-half star-yellow\"></i>")
            gradeElem.parentElement.insertBefore(halfStar, gradeElem)
        }
        else {
            break;
        }
    }
    while(antiGrade !== 5 ) {
        if(antiGrade % 1 !== 0) {
            antiGrade += 0.5;
            var star = createElementFromHTML("<i class=\"fa fa-star-half star fa-flip-horizontal\"></i>")
            gradeElem.parentElement.insertBefore(star, gradeElem)
        }
        else {
            antiGrade++;
            var star = createElementFromHTML("<i class=\"fa fa-star star\"></i>")
            gradeElem.parentElement.insertBefore(star, gradeElem)
        }
    }
}