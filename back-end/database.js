'use strict';
const mysql = require("mysql");

const PORT = process.env.PORT || 3306
module.exports = () => {
    //We need to work with "MongoClient" interface in order to connect to a mongodb server.
    var conn = mysql.createConnection({
        host: 'localhost',
        user: 'admin',
        password: 'admin1',
        database: 'NhanSu',
        charset: 'utf8_general_ci',
    });

    // connect database
    conn.connect(function (err) {

        if (err) {
            console.log(err);
        }
        else {
            console.log(1);
        }

    });
}