window.campusCore = {

    writeCookie: function (name, value, dateTime = "") {

        var expires;
        if (dateTime) {
            var date = new Date(dateTime);
            expires = "; expires=" + date.toUTCString();
        }
        else {
            expires = "";
        }
        document.cookie = name + "=" + value + expires + "; path=/; Secure; SameSite=Lax";
    },

    getCookie: function (name) {
        const cookie = document.cookie.split(';').find(c => c.trim().startsWith(name + '='));
        if (cookie) {
            return cookie.split('=')[1]; // return the cookie's value
        }
        return null;
    },

    deleteCookie: function(name) {
        if (this.getCookie(name)) {
            document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
        }
    }
}