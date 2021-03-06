const path = require('path');

module.exports  = {
    entry: './src/app.js',
    output: {
        path: path.join(__dirname, 'public/scripts'),
        filename: 'appbundle.js'
    },
    module: {
        rules:[{
            loader: 'babel-loader',
            test:/\.js$/,
            exclude: /node_modules/
        }]
    }
};
