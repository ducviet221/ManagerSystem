import axios from "axios";

export interface IInfoBodyModel {
  id?: string;
  cif?: string;
  time?: string;
  deliveryroom?: string;
  affairsofficer?: string;
  recive?: string;
  status?: string;
  note?: string;
}
export const getListInfo = async () => {
  const data = await axios.get("/Info/getListInfo");
  return data;
};

export const createInfo = async (data: IInfoBodyModel) => {
  return await axios.post("/info/createInfo", data);
};

export const getInfoById = async (id: string) => {
  const data = await axios.get("/Info/getInfoDetail/" + id);
  return data;
};

export const completeInfo = async (id: string) => {
  const { data } = await axios.get("/info/completeInfo/" + id);
  return data;
};

export const updateInfo = async (value: IInfoBodyModel) => {
  const { data } = await axios.post("/Info/updateInfo", value);
  return data;
};

export const deleteInfoById = async (id: string) => {
  const { data } = await axios.delete("/Info/deleteInfo/" + id);
  return data;
};