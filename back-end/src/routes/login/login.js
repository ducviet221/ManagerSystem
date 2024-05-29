

const express = require('express');
const { login, createUser } = require('../../controllers/login/login');
const router = express.Router();


router.post('/login', login);
router.post('/createuser', createUser);

module.exports = {
    user: router
}