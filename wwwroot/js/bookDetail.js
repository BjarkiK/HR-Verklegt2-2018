defaultRating();

function createElementFromHTML(htmlString) {
    var div = document.createElement('div');
    div.innerHTML = htmlString.trim();
    return div.firstChild; 
}

function defaultRating() {
    var gradeElem = document.getElementsByClassName("book-detail-grade")[0];
    var grade = gradeElem.getAttribute("value").replace(",", ".");
    if (grade % 1 != 0) {
        grade = fixRating(grade);
    }
    displayStars(grade);
}

function fixRating(grade) {
    return parseFloat(grade).toFixed(1);
}

// Made in a hurry. Tidy up if time
function displayStars(grade) {
    var gradeElem = document.getElementsByClassName("book-detail-grade")[0];
    gradeElem.innerHTML = grade;

    var starElem = document.getElementsByClassName("starRating")[0];
    starElem.innerHTML = "";

    var antiGrade = 0;
    var counter = 0;

    while(grade >= 0.0 && grade <= 5.0 ) {
        if(grade >= 1) {
            grade--;
            antiGrade++;
            counter++;
            var star = createElementFromHTML("<span class=\"fa fa-star star-yellow\" value=\"" + counter + "\"></span>");
            starElem.insertBefore(star, null);
        }
        else if(grade >= 0.5) {
            grade -= 0.5;
            antiGrade += 0.5;
            counter++;
            var halfStar = createElementFromHTML("<span class=\"fa fa-star-half star-yellow\" value=\"" + counter + "\"></span>");
            starElem.insertBefore(halfStar, null);
        }
        else {
            break;
        }
    }

    while(antiGrade !== 5 ) {
        if(antiGrade % 1 !== 0) {
            antiGrade += 0.5;
            counter++;
            var star = createElementFromHTML("<span class=\"fa fa-star-half star fa-flip-horizontal\" value=\"" + counter + "\"></span>");
            starElem.insertBefore(star, null);
        }
        else {
            antiGrade++;
            counter++;
            //var star = createElementFromHTML("<span class=\"fa fa-star star\" onclick=\"submitRating(" + counter + ")\" onmouseout='defaultRating()' onmouseover=\"displayStars(" + counter + ")\" value=\"" + counter + "\"></span>");
            var star = createElementFromHTML("<span class=\"fa fa-star star\" value=\"" + counter + "\"></span>");
            starElem.insertBefore(star, null);
        }
    }
    
    for (var i = 0; i < starElem.childElementCount; i++) {
        starElem.children[i].addEventListener("click", function() { submitRating( this.getAttribute("value") )});
        starElem.children[i].addEventListener("mouseout", defaultRating);
        starElem.children[i].addEventListener("mouseover", function() { displayStars( this.getAttribute("value")) });
    }
}

function submitRating(rating) {
    var bookId = Number(location.pathname.split('/')[3]);
    $.post('/book/totalGradeUpdate',{ bid : bookId, grade : rating }, function(returnData) {
        console.log(status + " " + returnData);
        if (returnData % 1 != 0) {
            returnData = fixRating(returnData);
        }
        displayStars(returnData);
    }).fail(function(response) {
        console.log("failed" + response);
    })
}