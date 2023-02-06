import axios from 'axios';
const baseDomain = 'http://localhost:5002';
//const baseDomain = 'http://198.12.227.32:5002';
const baseURL = baseDomain + '/api';
export default axios.create({ baseURL });
