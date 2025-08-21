        //window.setCookie = function (name, value, days) {
        //    var expires = "";
        //    if (days) {
        //        var date = new Date();
        //        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        //        expires = "; expires=" + date.toUTCString();
        //    }
        //    document.cookie = name + "=" + (value || "") + expires + "; path=/";
        //};

        //window.getCookie = function (name) {
        //    var nameEQ = name + "=";
        //    var ca = document.cookie.split(';');
        //    for (var i = 0; i < ca.length; i++) {
        //        var c = ca[i];
        //        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        //        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        //    }
        //    return null;
        //};

        //window.deleteCookie = function (name) {
        //    document.cookie = name + '=; Max-Age=-99999999;';
        //};

     


     
        //window.replaceHistoryState = function (url) {
        //    history.replaceState(null, '', url);
        //};
     

     
        //// This will block the user from going back to the login page
        //window.replaceHistoryState = function (newUrl) {
        //    // Replace current page in the history
        //    history.pushState(null, "", newUrl);
        //    history.replaceState(null, "", newUrl);
        //};

        //window.onload = function () {
        //    // Disable back button on login page
        //    if (window.location.pathname === "/auth/login") {
        //        history.pushState(null, "", location.href);
        //        history.pushState(null, "", location.href);
        //        window.onpopstate = function () {
        //            history.go(1); // This will disable the back button.
        //        };
        //    }
        //};
     

     
        //function hideGoogleTranslate() {
        //    var translateElement = document.getElementById('google-translate-container');
        //    if (translateElement) {
        //        translateElement.style.display = 'none'; // Hide the translate container
        //    }
        //}

        //function showGoogleTranslate() {
        //    var translateElement = document.getElementById('google-translate-container');
        //    if (translateElement) {
        //        translateElement.style.display = 'block'; // Show the translate container
        //    }
        //}
     


     
        //window.blockRestrictedUrl = function (url) {
        //    if (url.includes("media.zip")) {
        //        alert("Access Denied: This URL is restricted.");
        //        return false; // Block the navigation
        //    }
        //    return true; // Allow navigation
        //};

        //// Prevent clicking on the restricted URL
        //document.addEventListener("click", function (event) {
        //    let target = event.target;
        //    while (target && target.tagName !== "A") {
        //        target = target.parentElement;
        //    }
        //    if (target && target.href && target.href.includes("media.zip")) {
        //        alert("Access Denied: This URL is restricted.");
        //        event.preventDefault(); // Stop navigation
        //    }
        //});
     



     
        //function translateLanguage(language) {
        //    var selectField = document.querySelector("select.goog-te-combo");

        //    if (selectField) {
        //        selectField.value = language;
        //        selectField.dispatchEvent(new Event("change"));
        //    } else {
        //        console.error("Google Translate is not loaded yet.");
        //    }
        //}

        //document.addEventListener("DOMContentLoaded", function () {
        //    setTimeout(function () {
        //        if (!document.querySelector("select.goog-te-combo")) {
        //            console.warn("Google Translate widget not found. Retrying...");
        //        }
        //    }, 3000); // Delay in case translation widget takes time to load
        //});
     


     
        //function initializeCarousel() {
        //    const carouselElement = document.getElementById('heroCarousel');
        //    if (carouselElement) {
        //        new bootstrap.Carousel(carouselElement, {
        //            interval: 3000,
        //            ride: 'carousel',
        //        });
        //    }
        //}

        //function playNextVideo(carouselId) {
        //    var carousel = document.getElementById(carouselId);
        //    var activeItem = carousel.querySelector('.carousel-item.active');
        //    var nextItem = activeItem.nextElementSibling || carousel.querySelector('.carousel-item:first-child');

        //    if (nextItem) {
        //        var nextVideo = nextItem.querySelector('video');
        //        if (nextVideo) {
        //            nextVideo.play();
        //        }
        //    }
        //}

     

     
        //let scrollInProgress = false;

        //window.autoScrollNotifications = () => {
        //    const notificationList = document.getElementById('notificationList');
        //    if (notificationList && !scrollInProgress) {
        //        const scrollHeight = notificationList.scrollHeight;
        //        const clientHeight = notificationList.clientHeight;

        //        // Reset the scroll position to the top before starting scrolling
        //        notificationList.scrollTop = 0;

        //        // Flag to indicate scrolling is in progress
        //        scrollInProgress = true;

        //        // Scroll the list up slowly (adjust the scrollStep for speed)
        //        let scrollPosition = 0;
        //        const scrollStep = 1; // Adjust this value to make scrolling slower or faster

        //        const scrollInterval = setInterval(() => {
        //            if (scrollPosition < scrollHeight - clientHeight) {
        //                scrollPosition += scrollStep;
        //                notificationList.scrollTop = scrollPosition;
        //            } else {
        //                clearInterval(scrollInterval);
        //                // Once the scroll reaches the end, reset the flag and restart the scrolling after 3 seconds
        //                setTimeout(() => {
        //                    scrollInProgress = false;
        //                    window.autoScrollNotifications();
        //                }, 3000); // Wait for 3 seconds before starting from the top again
        //            }
        //        }, 50); // Interval of 50ms for smooth scrolling
        //    }
        //};

        //// Trigger auto-scrolling function when the page loads
        //window.addEventListener('load', () => {
        //    window.autoScrollNotifications(); // Start the auto-scroll immediately on page load
        //});


    

     
        //document.addEventListener('DOMContentLoaded', () => {
        //    const body = document.body;
        //    const root = document.documentElement;
        //    const defaultFontSize = 16;
        //    let currentFontSize = defaultFontSize;

        //    document.getElementById('increase-font')?.addEventListener('click', () => {
        //        currentFontSize += 2;
        //        root.style.fontSize = `${currentFontSize}px`;
        //    });

        //    document.getElementById('decrease-font')?.addEventListener('click', () => {
        //        if (currentFontSize > 10) {
        //            currentFontSize -= 2;
        //            root.style.fontSize = `${currentFontSize}px`;
        //        }
        //    });

        //    document.getElementById('reset-font')?.addEventListener('click', () => {
        //        currentFontSize = defaultFontSize;
        //        root.style.fontSize = `${defaultFontSize}px`;
        //    });

        //    document.getElementById('light-theme')?.addEventListener('click', () => {
        //        body.classList.remove('bg-dark', 'text-white');
        //        body.classList.add('bg-light', 'text-dark');
        //    });

        //    document.getElementById('dark-theme')?.addEventListener('click', () => {
        //        body.classList.remove('bg-light', 'text-dark');
        //        body.classList.add('bg-dark', 'text-white');
        //    });
        //});
     

     
        //$(document).ready(function () {
        //    const prevBtn = $('.collaborations-prev-btn');
        //    const nextBtn = $('.collaborations-next-btn');
        //    const carousel = $('.collaborations-carousel');
        //    const scrollAmount = 200;

        //    prevBtn.on('click', function () {
        //        carousel.animate({
        //            scrollLeft: carousel.scrollLeft() - scrollAmount
        //        }, 300);
        //    });

        //    nextBtn.on('click', function () {
        //        carousel.animate({
        //            scrollLeft: carousel.scrollLeft() + scrollAmount
        //        }, 300);
        //    });
        //});
     

     
        //document.addEventListener('DOMContentLoaded', () => {
        //    const body = document.body;
        //    const root = document.documentElement;
        //    const defaultFontSize = 16;
        //    let currentFontSize = defaultFontSize;

        //    document.getElementById('increase-font')?.addEventListener('click', () => {
        //        currentFontSize += 2;
        //        root.style.fontSize = `${currentFontSize}px`;
        //    });

        //    document.getElementById('decrease-font')?.addEventListener('click', () => {
        //        if (currentFontSize > 10) {
        //            currentFontSize -= 2;
        //            root.style.fontSize = `${currentFontSize}px`;
        //        }
        //    });

        //    document.getElementById('reset-font')?.addEventListener('click', () => {
        //        currentFontSize = defaultFontSize;
        //        root.style.fontSize = `${defaultFontSize}px`;
        //    });

        //    document.getElementById('light-theme')?.addEventListener('click', () => {
        //        body.classList.remove('bg-dark', 'text-white');
        //        body.classList.add('bg-light', 'text-dark');
        //    });

        //    document.getElementById('dark-theme')?.addEventListener('click', () => {
        //        body.classList.remove('bg-light', 'text-dark');
        //        body.classList.add('bg-dark', 'text-white');
        //    });
        //});

        //$(document).ready(function () {
        //    const prevBtn = $('.collaborations-prev-btn');
        //    const nextBtn = $('.collaborations-next-btn');
        //    const carousel = $('.collaborations-carousel');
        //    const scrollAmount = 200;

        //    function initializeCarousel() {
        //        if (carousel.length > 0 && carousel.children().length > 0) {
        //            prevBtn.off('click').on('click', function () {
        //                carousel.animate({
        //                    scrollLeft: carousel.scrollLeft() - scrollAmount
        //                }, 300);
        //            });

        //            nextBtn.off('click').on('click', function () {
        //                carousel.animate({
        //                    scrollLeft: carousel.scrollLeft() + scrollAmount
        //                }, 300);
        //            });
        //        }
        //    }

        //    initializeCarousel();
        //    window.initializeCarousel = initializeCarousel;
        //});

        //document.addEventListener('DOMContentLoaded', function () {
        //    const navElements = document.querySelectorAll('.navbar-toggler');
        //    navElements.forEach((navElement) => {
        //        navElement.addEventListener('click', () => {
        //            const targetId = navElement.getAttribute('data-bs-target');
        //            const menuElement = document.querySelector(targetId);
        //            if (!menuElement) {
        //                console.error(`Menu element with target ID ${targetId} not found.`);
        //            }
        //        });
        //    });
        //});


        //document.addEventListener("DOMContentLoaded", () => {
        //    const root = document.documentElement;
        //    let currentFontSize = 16;

        //    const attachFontControls = () => {
        //        const increaseFontBtn = document.getElementById("increase-font");
        //        const decreaseFontBtn = document.getElementById("decrease-font");
        //        const resetFontBtn = document.getElementById("reset-font");

        //        if (increaseFontBtn) {
        //            increaseFontBtn.addEventListener("click", () => {
        //                currentFontSize += 2;
        //                root.style.fontSize = `${currentFontSize}px`;
        //            });
        //        }

        //        if (decreaseFontBtn) {
        //            decreaseFontBtn.addEventListener("click", () => {
        //                if (currentFontSize > 10) {
        //                    currentFontSize -= 2;
        //                    root.style.fontSize = `${currentFontSize}px`;
        //                }
        //            });
        //        }

        //        if (resetFontBtn) {
        //            resetFontBtn.addEventListener("click", () => {
        //                currentFontSize = 16;
        //                root.style.fontSize = "16px";
        //            });
        //        }
        //    };

        //    const attachThemeControls = () => {
        //        const lightThemeBtn = document.getElementById("light-theme");
        //        const darkThemeBtn = document.getElementById("dark-theme");

        //        if (lightThemeBtn) {
        //            lightThemeBtn.addEventListener("click", () => {
        //                root.setAttribute("data-theme", "light");
        //            });
        //        }

        //        if (darkThemeBtn) {
        //            darkThemeBtn.addEventListener("click", () => {
        //                root.setAttribute("data-theme", "dark");
        //            });
        //        }
        //    };

        //    attachFontControls();
        //    attachThemeControls();
        //});
     

     
        //window.tinymceInterop = {
        //    init: (editorId, dotNetHelper) => {
        //        tinymce.init({
        //            selector: `#${editorId}`,
        //            setup: (editor) => {
        //                editor.on('change', () => {
        //                    const content = editor.getContent();
        //                    dotNetHelper.invokeMethodAsync("UpdateValue", content);
        //                });
        //            }
        //        });
        //    },
        //    remove: (editorId) => {
        //        const editor = tinymce.get(editorId);
        //        if (editor) {
        //            editor.remove();
        //        }
        //    }
        //};
     

     
        //window.playVideo = (videoUrl, videoPlayerId) => {
        //    // Get the iframe element by its unique ID
        //    let iframe = document.getElementById("videoPlayer" + videoPlayerId);

        //    // Ensure the iframe exists before trying to manipulate it
        //    if (iframe) {
        //        iframe.style.display = "block";  // Show the iframe
        //        iframe.src = videoUrl;  // Set the src to the clicked video URL
        //    } else {
        //        console.error("Iframe not found with ID: " + "videoPlayer" + videoPlayerId);
        //    }
        //};
     


     
        //function startIndianTimeClock() {
        //    function updateClock() {
        //        const options = {
        //            timeZone: 'Asia/Kolkata',
        //            year: 'numeric',
        //            month: 'short',
        //            day: '2-digit',
        //            hour: '2-digit',
        //            minute: '2-digit',
        //            second: '2-digit',
        //            hour12: true
        //        };
        //        const now = new Date();
        //        const timeString = now.toLocaleString('en-IN', options);
        //        const clockElement = document.getElementById('indian-time');
        //        if (clockElement) {
        //            clockElement.textContent = timeString;
        //        }
        //    }

        //    updateClock();
        //    setInterval(updateClock, 1000);
        //}
     


     
        //window.customSearch = {
        //    findText: function (text) {
        //        // Remove previous highlights
        //        const prev = document.querySelectorAll('.highlighted-text');
        //        prev.forEach(el => {
        //            const parent = el.parentNode;
        //            parent.replaceChild(document.createTextNode(el.textContent), el);
        //            parent.normalize();
        //        });

        //        if (!text) return;

        //        const walk = document.createTreeWalker(document.body, NodeFilter.SHOW_TEXT);
        //        while (walk.nextNode()) {
        //            const node = walk.currentNode;
        //            const idx = node.nodeValue.toLowerCase().indexOf(text.toLowerCase());
        //            if (idx >= 0) {
        //                const match = node.splitText(idx);
        //                const after = match.splitText(text.length);
        //                const span = document.createElement('span');
        //                span.textContent = match.nodeValue;
        //                span.className = 'highlighted-text';
        //                span.style.backgroundColor = 'yellow';
        //                span.style.color = 'black'; // Set text color to black
        //                span.style.fontWeight = 'bold';
        //                match.parentNode.replaceChild(span, match);
        //                break; // Only highlight first match
        //            }
        //        }
        //    }
        //};
     