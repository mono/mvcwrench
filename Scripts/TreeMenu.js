function ToggleVisibility(element, childid) {
    if (element.className == 'expand') {
        element.className = 'collapse';
        document.getElementById(childid).style.display = 'inherit';
    } else {
        element.className = 'expand';
        document.getElementById(childid).style.display = 'none';
    }
}

function Resize() {
    //document.getElementById('main').style.height = (window.innerHeight - 154) + 'px';
    //document.getElementById('content').style.height = (window.innerHeight - 126) + 'px';

    $("#content").css("height", ($(window).height() - 126) + 'px');
}