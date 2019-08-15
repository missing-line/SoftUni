function solution(input) {

    if (input === 'upvote') {
        this.upvotes++;
    } else if (input === 'downvote') {
        this.downvotes++;
    } else {
        return score(this);
    }

    function score(object) {
        let modifier = 0;

        if (object.upvotes + object.downvotes > 50) {
            modifier = Math.ceil(Math.max(object.upvotes, object.downvotes) * 0.25);
        }

        let score = object.upvotes - object.downvotes;
        let rating = '';

        if (object.upvotes + object.downvotes < 10) {
            rating = 'new';

        } else if (score < 0) {
            rating = 'unpopular';

        } else if (object.upvotes / (object.upvotes + object.downvotes) > 0.66) {
            rating = 'hot';

        } else if (object.upvotes > 100 || object.downvotes > 100) {
            rating = 'controversial';

        } else {
            rating = 'new';
        }

        return [object.upvotes + modifier,
            object.downvotes + modifier,
            score,
            rating];
    }
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solution.call(post, 'upvote');
solution.call(post, 'downvote');
console.log(solution.call(post, 'score'));
solution.call(post, 'downvote');
for (let i = 0; i < 50; i++) {
    solution.call(post, 'downvote');
}
console.log(solution.call(post, 'score'));
