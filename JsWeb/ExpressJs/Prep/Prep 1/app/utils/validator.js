const {body} = require('express-validator');

module.exports = [

    body('title', 'invalid data length')
        .isLength({min: 5})
        .isAlphanumeric(),
    body('description', 'out of range')
        .isLength({max: 50})
        .isAlphanumeric(),
    body('imageUrl')
        .custom(value => {
            console.log(typeof value);
            if (!value.startsWith('http')) {
                throw new Error('Invalid link!');
            }
            return true;
        })

];