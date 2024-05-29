const mongoose = require("mongoose")

const Schema = mongoose.Schema

const InfoSchema = new Schema({
    id: { type: String, require: false },
    cif: { type: Number, require: true },
    time: { type: Date },
    deliveryroom: { type: String, require: false },
    affairsofficer: { type: String, require: false },
    recive: { type: String, require: false },
    status: { type: String, require: false },
    note: { type: String, require: false },
    name: { type: String, require: false },
}, { timestamps: true });

const InfoModel = mongoose.model("curriculum", InfoSchema);
module.exports = InfoModel 