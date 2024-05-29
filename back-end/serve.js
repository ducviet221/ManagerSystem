const express = require("express")
const app = express()
const port = process.env.PORT || 2109
const http = require("http")

const mongoose = require("mongoose")
var cors = require('cors');

const path = require('path');
require('./database')();
http.createServer((req, res) => {
    res.setHeader("Content-Type", "application/json")
})

app.use((req, res, next) => {
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT');
    res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
    res.setHeader("Content-Type", "application/json")
    res.header("Access-Control-Allow-Headers", "x-access-token, Origin, X-Requested-With, Content-Type, Accept");
    next();
});
const bodyParser = require('body-parser');
const info = require("./src/routes/info/info")
const { user } = require("./src/routes/login/login")

app.use(bodyParser.json());

app.use('/api/info', info.infor)
app.use('/api/user', user)
app.listen(port)
app.use(cors());