var arrows = document.getElementsByClassName("arrow");

for(var i = 0; i < arrows.length; i++) {
    arrows[i].addEventListener("click", e => handleArrowClick(e));
}

function handleArrowClick(e) {
    var direction = e.target.value;
    var path = e.composedPath();
    var bookContainer = path[2].children[1].children[0];
    var bookContainerWidth = bookContainer.offsetWidth;
    if(direction === "right") {
        bookContainer.children[0].style.marginLeft = "-" + bookContainerWidth + "px";
    }
    else {
        bookContainer.children[0].style.marginLeft = "0px";
    }
}