window.govTopBarInit = function () {
    console.log("Top bar JS loaded");

    // Initialize Bootstrap dropdowns
    var dropdownElementList = [].slice.call(document.querySelectorAll('.dropdown-toggle'));
    dropdownElementList.map(function (el) {
        return new bootstrap.Dropdown(el);
    });

    let currentFontSize = parseFloat(localStorage.getItem('fontSize')) || 1;

    function updateFontControls() {
        document.querySelectorAll('.font-control').forEach(btn => btn.classList.remove('active'));
    }

    window.increaseFontSize = function () {
        if (currentFontSize < 1.3) {
            currentFontSize += 0.15;
            document.body.style.fontSize = currentFontSize + 'em';
            localStorage.setItem('fontSize', currentFontSize);
            updateFontControls();
        }
    };

    window.decreaseFontSize = function () {
        if (currentFontSize > 0.85) {
            currentFontSize -= 0.15;
            document.body.style.fontSize = currentFontSize + 'em';
            localStorage.setItem('fontSize', currentFontSize);
            updateFontControls();
        }
    };

    window.resetFontSize = function () {
        currentFontSize = 1;
        document.body.style.fontSize = '1em';
        localStorage.setItem('fontSize', currentFontSize);
        updateFontControls();
    };

    window.setTheme = function (theme) {
        document.body.classList.remove('dark-theme', 'blue-theme');
        if (theme === 'dark') document.body.classList.add('dark-theme');
        if (theme === 'blue') document.body.classList.add('blue-theme');
        localStorage.setItem('theme', theme);
    };

    window.setLanguage = function (lang) {
        console.log("Language switched to", lang);
        localStorage.setItem('language', lang);
    };

    // Apply saved settings
    document.body.style.fontSize = currentFontSize + 'em';
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme) window.setTheme(savedTheme);
};
