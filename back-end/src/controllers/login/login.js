const UsersModel = require("../../models/login/login");
const { ObjectId } = require('mongodb')
const login = async function (req, res) {

    try {

        const user = await UsersModel.findOne({ username: req.body.username });
        if (user) {
            const finalResult = {
                username: user.username,
                login: true
            }

            const result = req.body.password === user.password;
            if (result) {
                res.status(200).json(finalResult);
            } else {
                res.status(200).json({
                    login: false,
                    message: "Password doesn't match!"
                });
            }
        } else {
            res.status(200).json({
                login: false,
                message: "Password doesn't match!"
            });
        }
    } catch (error) {
        res.status(400).json({ error });
    }
};

const createUser = async (req, res) => {

    try {
        const finalData = {
            ...req.body,
            id: new ObjectId(),
        }
        const rs = await UsersModel.create(finalData)
        res.status(200).send(rs)

    }
    catch (error) {

        res.status(500).json({ message: error.message });
    }
}

module.exports = { login, createUser }