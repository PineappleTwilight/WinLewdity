﻿// Place JS event hooks below

// Click event
document.addEventListener('click', function (e) {
    var element = e.target

    // Anchor tag parents are not needed
    if (element.tagName == 'A') {
        winlewdity_internal.elementClicked(element.tagName, Array.from(element.classList).toString());
        return;
    }

    // Button tag parents are not needed
    if (element.tagName == 'BUTTON') {
        winlewdity_internal.elementClicked(element.tagName, Array.from(element.classList).toString());
        return;
    }

    // Check if an element in the hierarchy is a div
    while (element && element.tagName !== 'DIV') {
        if (element.parentNode == null) {
            break;
        } else {
            element = element.parentNode
        }
    }

    // Call click on the hierarchal div element
    winlewdity_internal.elementClicked(element.tagName, Array.from(element.classList).toString());
}, false);