// Place JS event hooks below

// Click event
document.addEventListener('click', function (e) {
    var el = e.target

    if (el.tagName == 'A') {
        winlewdity_internal.elementClicked(el.tagName, Array.from(el.classList).toString());
        return;
    }

    if (el.tagName == 'BUTTON') {
        winlewdity_internal.elementClicked(el.tagName, Array.from(el.classList).toString());
        return;
    }

    while (el && el.tagName !== 'DIV') {
        if (el.parentNode == null) {
            break;
        }
        el = el.parentNode
    }

    winlewdity_internal.elementClicked(el.tagName, Array.from(el.classList).toString());
}, false);