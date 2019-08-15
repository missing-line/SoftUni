function solve(tickets, sortType) {
    let arr = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for (let i = 0; i < tickets.length; i++) {
        let currTicket = tickets[i].split('|');
        let destination = currTicket[0];
        let price = +currTicket[1];
        let status = currTicket[2];

        let ticket = new Ticket(destination, price, status);
        arr.push(ticket);
    }

    switch (sortType) {
        case 'destination':
            return arr.sort((a, b) => a.destination.localeCompare(b.destination));
        case 'price':
            return arr.sort((a, b) => a.price - b.price);

        case 'status':
            return arr.sort((a, b) => a.status.localeCompare(b.status));
    }
}


console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
));