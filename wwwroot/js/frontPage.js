var arrows = document.getElementsByClassName("arrow");

for(var i = 0; i < arrows.length; i++) {
    arrows[i].addEventListener("click", e => handleArrowClick(e));
}

function handleArrowClick(e) {
    var direction = e.target.value;
    var bookContainer = e.path[2].children[1].children[0];
    var bookContainerWidth = bookContainer.offsetWidth;
    if(direction === "left") {
        bookContainer.children[0].style.marginLeft = "-" + bookContainerWidth + "px";
    }
    else {
        bookContainer.children[0].style.marginLeft = "0px";
    }
}