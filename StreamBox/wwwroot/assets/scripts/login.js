var loginButton = document.getElementById('login-button'),
    svgIcon = document.getElementsByTagName('path');

loginButton.addEventListener("mouseover", function() {
    for (var pathes = [], i = 0; i <= svgIcon.length; i++) {
        pathes[i] = svgIcon.item(i);
        if (i === svgIcon.length) {
            pathes.forEach(element => {
                element.style.stroke = "#444C8C";
            });
            break;
        }
    }
})

loginButton.addEventListener("mouseout", function() {
    for (var pathes = [], i = 0; i <= svgIcon.length; i++) {
        pathes[i] = svgIcon.item(i);
        if (i === svgIcon.length) {
            pathes.forEach(element => {
                element.style.stroke = `#0c1221`;
            });
            break;
        }
    }
})