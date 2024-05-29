import axios from "axios";
axios.defaults.baseURL = "http://localhost:5096/api/";

export const login = async (value: any) => {
  const { data } = await axios.post("Login/login", value);
  return data;
};

export const createUser = async (value: any) => {
  const data = await axios.post("Login/createuser", value);
  return data;
};
