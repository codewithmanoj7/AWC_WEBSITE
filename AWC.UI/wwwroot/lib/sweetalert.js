window.showCustomAlert = function (title, message, type) {
    let alertBox = document.getElementById("custom-sweetalert");
    let alertTitle = document.getElementById("alert-title");
    let alertMessage = document.getElementById("alert-message");
    let alertIcon = document.getElementById("alert-icon");

    alertTitle.innerText = title;
    alertMessage.innerText = message;

    alertBox.style.display = "flex";

    // Clear previous styles
    alertIcon.className = "sweetalert-icon";

    // Set icon and styles based on type
    if (type === "success") {
        alertIcon.innerHTML = "✔";
        alertIcon.classList.add("success");
    } else if (type === "error") {
        alertIcon.innerHTML = "✖";
        alertIcon.classList.add("error");
    } else if (type === "warning") {
        alertIcon.innerHTML = "⚠";
        alertIcon.classList.add("warning");
    } else {
        alertIcon.innerHTML = "ℹ";
        alertIcon.classList.add("info");
    }
};

window.hideCustomAlert = function () {
    document.getElementById("custom-sweetalert").style.display = "none";
};


window.copyTextToClipboard = (text) => {
    navigator.clipboard.writeText(text).then(() => {
        console.log("Copied:", text); // Debugging
        alert("✅ Copied to clipboard!");
    }).catch(err => {
        console.error("Clipboard copy failed:", err);
    });
};


    window.blockRestrictedUrl = function (url) {
        if (url.includes("media.zip")) {
        alert("Access Denied: This URL is restricted.");
    return false; // Block the navigation
        }
    return true; // Allow navigation
    };

    // Prevent clicking on the restricted URL
    document.addEventListener("click", function (event) {
        let target = event.target;
    while (target && target.tagName !== "A") {
        target = target.parentElement;
        }
    if (target && target.href && target.href.includes("media.zip")) {
        alert("Access Denied: This URL is restricted.");
    event.preventDefault(); // Stop navigation
        }
    });

