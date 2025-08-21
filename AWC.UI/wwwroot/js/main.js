

document.addEventListener("DOMContentLoaded", function () {
    const heroContent = document.querySelector('.hero-content');

    if (!heroContent) return; // Avoid errors if element not found

    const bgImages = [
        'assets/images/auth-bg.jpg',
        'assets/images/carousel/DSC_5950.jpg',
        'assets/images/carousel/DSC_4121.jpg',
        'assets/images/carousel/slider1.jpeg'
    ];

    let current = 0;

    function changeBackground() {
        heroContent.style.backgroundImage = `url('${bgImages[current]}')`;
        current = (current + 1) % bgImages.length;
    }

    changeBackground(); // Initial set
    setInterval(changeBackground, 10000); // Every 10 sec
});

// Session timer functions for Blazor interop
let sessionTimer;
let sessionStartTime;

window.startSessionTimer = (dotNetHelper) => {
    sessionStartTime = new Date();

    sessionTimer = setInterval(() => {
        const now = new Date();
        const elapsed = now - sessionStartTime;

        const hours = Math.floor(elapsed / 3600000);
        const minutes = Math.floor((elapsed % 3600000) / 60000);
        const seconds = Math.floor((elapsed % 60000) / 1000);

        const timeString =
            hours.toString().padStart(2, '0') + ':' +
            minutes.toString().padStart(2, '0') + ':' +
            seconds.toString().padStart(2, '0');

        dotNetHelper.invokeMethodAsync('UpdateTimer', timeString);
    }, 1000);
};

window.stopSessionTimer = () => {
    if (sessionTimer) {
        clearInterval(sessionTimer);
        sessionTimer = null;
    }
};
