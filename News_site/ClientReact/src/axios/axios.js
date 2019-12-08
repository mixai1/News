import axios from 'axios';

const instane = axios.create({
 baseURL: 'http://localhost:5000',
 headers:{
     headerType: 'example header type'
 }
});

export default instane;