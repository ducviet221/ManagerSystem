const InfoModel = require("../../models/Info/Info.model");
const { ObjectId } = require('mongodb')

const getListInfo = async (req, res) => {

    try {
        const rs = await InfoModel.find({})

        res.setHeader("Content-Type", "application/json")
        res.end(
            JSON.stringify(rs)
        );
        res.status(200)

    }
    catch (error) {
        res.status(500).json({ message: error.message });
    }
}

const completeInfo = async (req, res) => {

    try {
        const id = req.params.id
        const result = await InfoModel.findOneAndUpdate({ id }, { status: 'complete', modifiedDate: new Date() });
        console.log(result);
        res.status(200).json({ ...result, result: true });

    }
    catch (error) {
        res.status(400).json({ message: error.message, result: false })
    }
}

const updateInfo = async (req, res) => {

    try {
        const id = req.body.id
        const value = req.body
        const result = await InfoModel.findOneAndUpdate({ id }, { ...value, modifiedDate: new Date() });
        res.status(200).json({ ...result, result: true });

    }
    catch (error) {
        res.status(400).json({ message: error.message, result: false })

    }
}

const saveInfo = async (req, res) => {
    var length = (await InfoModel.find({})).length;

    var nextId = length + 1
    try {
        const finalData = {
            ...req.body,
            id: nextId.toString(),
            status: "pending"
        }
        const rs = await InfoModel.create(finalData)
        res.status(200).send(rs)

    }
    catch (error) {
        console.log(error);
        res.status(500).json({ message: error.message });
    }
}

const getInfoDetailById = async (req, res) => {

    const id = req.params.id

    try {
        const result = await InfoModel.findOne({ id })
        const processedResult = {
            ...result?._doc, id: result?._doc?.id ?? null,
            cif: result?._doc?.cif ?? null,
            time: result?._doc?.time ?? null,
            deliveryroom: result?._doc?.deliveryroom ?? null,
            affairsofficer: result?._doc?.affairsofficer ?? null,
            recive: result?._doc?.recive ?? null,
            status: result?._doc?.status ?? null,
            note: result?._doc?.note ?? null,
            name: result?._doc?.name ?? null,
        }
        res.status(200).send(processedResult)
    }
    catch (error) {
        res.status(500).json({ message: error.message });
    }
}

const deleteInfo = async (req, res) => {
    try {
        const id = req.params.id
        const result = await InfoModel.deleteOne({ id: id });
        res.status(200).json({ ...result, result: true });

    }
    catch (error) {
        console.log(error);
        res.status(400).json({ message: error.message, result: false })
    }
}


module.exports = {
    getListInfo, updateInfo, getInfoDetailById, saveInfo, completeInfo, deleteInfo
}
