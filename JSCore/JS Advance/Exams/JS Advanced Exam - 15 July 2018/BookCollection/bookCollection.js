class BookCollection {
    constructor(shelfGenre, room, shelfCapacity) {
//– room(String), shelfGenre(String), shelf(an array), shelfCapacity(Number).
        this.room = room;
        this.shelfGenre = shelfGenre;
        this.shelfCapacity = shelfCapacity;
        this.shelf = [];
    }

    get room() {
        return this._room;
    }

    set room(value) {
        if (value !== 'livingRoom' && value !== 'bedRoom' && value !== 'closet') {
            throw  new Error(`Cannot have book shelf in ${value}`)
        }
        this._room = value;
    }

    get shelfCondition() {
        return this.shelfCapacity - this.shelf.length;
    }

    addBook(bookName, bookAuthor, genre) {
        let book = {
            bookName,
            bookAuthor,
            genre
        };

        if (this.shelfCapacity <= this.shelf.length) {
            this.shelf.splice(0,1);
        }
        this.shelf.push(book);
        this.shelf.sort((a, b) => a.bookAuthor.localeCompare(b.bookAuthor));
        return this;
    }

    throwAwayBook(bookName) {
        let findBook = this.shelf.find(x => x.bookName);
        let index = this.shelf.indexOf(findBook);
        this.shelf.splice(index, 1);

    }

    showBooks(genre) {
        let findBooks = this.shelf.filter(x => x.genre);

        let find = [];
        find.push(`Results for search "${genre}":`);
        for (let i = 0; i < findBooks.length; i++) {
            find.push(`\uD83D\uDCD6 ${findBooks[i].bookAuthor} - "${findBooks[i].bookName}"`)
        }
        return find.join('\n');

    }

    toString() {
        let info = [];
        if (this.shelf.length === 0) {
            return 'It\'s an empty shelf';
        }
        info.push(`"${this.shelfGenre}" shelf in ${this.room} contains:`);
        for (let book of this.shelf) {
            info.push(`\uD83D\uDCD6 "${book.bookName}" - ${book.bookAuthor}`)
        }
        return info.join('\n');
    }
}

let livingRoom = new BookCollection("Programming", "livingRoom", 5)
    .addBook("Introduction to Programming with C#", "Svetlin Nakov")
    .addBook("Introduction to Programming with Java", "Svetlin Nakov")
    .addBook("Programming for .NET Framework", "Svetlin Nakov");
console.log(livingRoom.toString());

