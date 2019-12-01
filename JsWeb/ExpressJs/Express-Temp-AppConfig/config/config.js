const env = process.env.NODE_ENV || 'development';

const config = {
    development = {
        port: process.env.port || 3000,
        dbURl: 'mongodb://localhost:27107/SET_NAME_DB'
    },
    process = {}
};

module.exports = config[env];