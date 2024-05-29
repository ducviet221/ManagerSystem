

const express = require('express');
const { getListInfo, getInfoDetailById, saveInfo, updateInfo, completeInfo, deleteInfo } = require('../../controllers/Info/Info');
const router = express.Router();


router.post('/saveInfo', saveInfo);
router.get('/completeInfo/:id', completeInfo);
router.put('/updateInfo', updateInfo);
router.get('/getListInfo', getListInfo);
router.get('/deleteInfo/:id', deleteInfo)
router.get('/getInfoDetail/:id', getInfoDetailById);


module.exports = {
    infor: router
}