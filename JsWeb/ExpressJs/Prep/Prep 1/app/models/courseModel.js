const mongoose = require('mongoose');
const {String, Boolean, Number, ObjectId} = mongoose.Schema.Types;

const courseSchema = new mongoose.Schema({
    title: {
        type: String,
        required: true,
        unique: true
    },
    description: {
        type: String,
        required: true,
        maxlength: 50
    },
    imageUrl: {
        type: String,
        required: true
    },
    isPublic: {
        type: Boolean,
    },
    created: {
        type: String,
        required: true
    },
    creator : {
        type: ObjectId,
        required: true
    },
    users: [{type: mongoose.Types.ObjectId, ref: 'User'}]
});

module.exports = mongoose.model('Course', courseSchema);
