(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str))
            return str + this.toString();

        return this.toString();
    };

    String.prototype.ensureEnd  = function (str) {
        if (!this.endsWith(str))
            return this.toString() + str;

        return this.toString();
    };

    String.prototype.truncate = function (n) {
        if (this.length <= n) { //
            return this.toString();
        }

        if (!this.includes(' ')) {
            return this.toString().splice(this.length - 2) + '...';
        }

        if (n < 4) {
            return '.'.replace(n);
        }

        let currentString = this.toString();

        while (currentString.length + 3 > n) {
            let words = currentString.split(' ');
            words.pop();
            currentString = words.join(' ');
        }

        return currentString + '...';
    };

    String.prototype.isEmpty = function () {
        return this.length === 0;
    };

    String.format = function (string, ...params) {
        for (let i = 0; i < params.length; i++) {
            string = string.replace(`{${i}}`, params[i]);
        }

        return string;
    }
})();