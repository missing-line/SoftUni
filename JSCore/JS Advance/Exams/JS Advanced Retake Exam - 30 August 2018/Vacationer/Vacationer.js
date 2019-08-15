class Vacationer {
    constructor(...params) {
        this.fullName = {
            firstName: params[0][0],
            middleName: params[0][1],
            lastName: params[0][2]
        };
        this.creditCard = {
            cardNumber: 1111,
            expirationDate: '',
            securityNumber: 111
        };
        if (params[1]) {
            this.creditCard = this.addCreditCardInfo(params[1]);
        }
        this.idNumber = this.generateIDNumber();
        this.wishList = [];
    }

    get fullName() {
        return this._fullName;
    }

    set fullName(value) {
        if (!value.firstName || !value.middleName || !value.lastName) {
            throw  Error('Name must include first name, middle name and last name');
        }
        const regex = /^[A-Z][a-z]+$/g;
        if (!regex.test(value.firstName)) {
            throw  Error('Invalid full name');
        }
        regex.test(value.firstName);
        if (!regex.test(value.middleName)) {
            throw  Error('Invalid full name');
        }
        regex.test(value.middleName);
        if (!regex.test(value.lastName)) {
            throw  Error('Invalid full name');
        }
        this._fullName = value;
    }

    generateIDNumber() {
        //231 * firstName’s first letter’s ASCII code + 139 * middleName length
        let vowel = ["a", "e", "o", "i", "u"];
        let firstLetter = this.fullName.firstName.charCodeAt(0);
        let lastLetter = this.fullName.lastName.charCodeAt(this.fullName.lastName.length - 1);
        let id = (231 * firstLetter) + (139 * this.fullName.middleName.length);
        id = id.toString();
        if (vowel.includes(this.fullName.lastName[this.fullName.lastName.length - 1])) {
            id += 8;
        } else {
            id += 7;
        }
        return id;
    }

    addCreditCardInfo(input) {
        if (input.length !== 3) {
            throw  Error('Missing credit card information');
        }

        if (typeof input[0] === 'string' || typeof input[2] === 'string') {
            throw  Error('Invalid credit card details');
        }

        return this.creditCard = {
            cardNumber: input[0],
            expirationDate: input[1],
            securityNumber: input[2]
        };
    }

    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) {
            throw  error('Destination already exists in wishlist');
        }
        this.wishList.push(destination);
        this.wishList.sort((a, b) => a.length - b.length);
    }

    getVacationerInfo() {

        return `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}\n` +
            `ID Number: ${this.idNumber}\n` +
            `Wishlist:\n` +
            `${this.wishList.length === 0 ? 'empty' : this.wishList.join(', ')}\n` +
            `Credit Card:\n` +
            `Card Number: ${this.creditCard.cardNumber}\n` +
            `Expiration Date: ${this.creditCard.expirationDate}\n` +
            `Security Number: ${this.creditCard.securityNumber}\n`;
    }
}


//let classInstance1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
//let classInstance2 = new Vacationer(["Vania", "Ivanova", "Zhivk0va"]);
//let classInstance3 = new Vacationer(["Tania", "Ivanova", "Zhivkova"], [123456789, "10/01/2018", 777]);
let classInstance4 = new Vacationer(["Tania", "Ivanova", "Zhivkova"], ['123456789', "10/01/2018", 777]);



