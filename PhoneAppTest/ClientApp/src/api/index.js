import axios from 'axios';

axios.defaults.baseURL = '/api';

const responseBody = response => response.data;

const requests = {
  get: url => axios.get(url).then(responseBody),
  post: (url, body) => axios.post(url, body).then(responseBody),
};

const Contacts = {
  list: () => requests.get('/contacts'),
  create: (activity) => requests.post('/contacts', activity),
  search: (searchTerm) => requests.get(`/contacts?searchTerm=${searchTerm}`),
}

export default {
  Contacts
}