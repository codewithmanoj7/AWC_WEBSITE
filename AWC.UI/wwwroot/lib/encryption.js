window.encryptPassword = function (password, secretKey) {
    if (!password || !secretKey) return null;

    var key = CryptoJS.enc.Utf8.parse(secretKey);

    // Generate a random IV
    var iv = CryptoJS.lib.WordArray.random(128 / 8);

    var encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(password), key, {
        keySize: 128 / 8,
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
    });

    // Concatenate the IV (Base64 encoded) and the encrypted string
    var encryptedPassword = CryptoJS.enc.Base64.stringify(iv) + ":" + encrypted.toString();

    return encryptedPassword;
};
