class CheckingAccount {

    constructor(id, email, firstName, lastName) {
        this.id = id;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get id() {
        return this._id;
    }

    set id(value) {
        const regex = /^\d{6}$/;
        if (!regex.test(value)) {
            throw  new TypeError('Client ID must be a 6-digit number');
        }
        this._id = value;
    }

    get email() {
        return this._email;
    }

    set email(value) {
        const regex = /^\w+@\w+(.[a-z]+)*$/gm;
        if (!regex.test(value)) {
            throw  new TypeError('Invalid e-mail');
        }
        this._email = value;
    }

    get firstName() {
        this._firstName;
    }

    set firstName(value) {
        if (value.length < 3 || value.length > 20)
            throw  new TypeError(`First name must be between 3 and 20 characters long`);

        const regex = /^[A-Z][a-z]+$/gm;

        if (!regex.test(value))
            throw  new TypeError(`First name must contain only Latin characters`);

        this._firstName = value;
    }

    get lastName() {
        this._lastName;
    }

    set lastName(value) {
        if (value.length < 3 || value.length > 20) {
            throw  new TypeError(`Last name must be between 3 and 20 characters long`);
        }
        const regex = /^[A-Z][a-z]+$/gm;
        if (!regex.test(value))
            throw  new TypeError(`Last name must contain only Latin characters`);

        this._lastName = value;
    }
}

let acc = new CheckingAccount('1315', 'ivan@', 'Ivan', 'Petrov');