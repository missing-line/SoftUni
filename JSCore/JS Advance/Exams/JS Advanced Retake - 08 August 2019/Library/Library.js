class Library {

    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: this.libraryName.length,
            special: this.libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        }
    }

    subscribe(name, type) {
        if (type !== 'normal' && type !== 'special' && type !== 'vip') {
            throw  new Error(`The type ${type} is invalid`)
        }

        let sub = this.findSubscriber(name);

        if (!sub)
            this.subscribers.push({name: name, type: type, books: []});


        this.findSubscriber(name).type = type;

        return this.findSubscriber(name);
    }

    unsubscribe(name) {
        let sub = this.findSubscriber(name);

        if (!sub)
            throw new Error(`There is no such subscriber as ${name}`);

        let index = this.subscribers.indexOf(sub);
        this.subscribers.splice(index, 1);

        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        let sub = this.findSubscriber(subscriberName);

        if (!sub)
            throw  new Error(`There is no such subscriber as ${subscriberName}`);

        if (sub.books.length + 1 <= this.subscriptionTypes[sub.type])
            sub.books.push({title: bookTitle, author: bookAuthor});
        else
            throw  new Error(`You have reached your subscription limit ${this.subscriptionTypes[sub.type]}!`);


        return this.findSubscriber(subscriberName);
    }

    showInfo() {
        let info = '';

        for (let sub of this.subscribers) {
            info += `Subscriber: ${sub.name}, Type: ${sub.type}\nReceived books: `;
            for (let book of sub.books) {
                info += `${book.title} by ${book.author}, `
            }
            if (info[info.length - 2] !== ':')
                info = info.substring(0, info.length - 2);

            info += '\n';
        }

        if (info === '')
            return `${this.libraryName} has no information about any subscribers`;

        return info;
    }

    findSubscriber(name) {
        return this.subscribers.find(x => x.name === name);
    }
}

let lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');
lib.subscribe('John1', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');


console.log(lib.showInfo());



