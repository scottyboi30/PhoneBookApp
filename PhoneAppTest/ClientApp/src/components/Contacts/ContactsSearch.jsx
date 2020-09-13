import React, { useState } from "react";

import api from "../../api";
import ContactsList from './ContactsList';

const ContactsSearch = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [contacts, setContacts] = useState([]);

  const handleKeyPress = (event) => {
    if (event.key === "Enter") {
      submit();
    }
  };

  const submit = async () => {
    const contacts = await api.Contacts.search(searchTerm);
    setContacts(contacts);
  };

  return (
    <div className="my-3">
      <h1>Search</h1>
      <p className="mt-3">Will search for contacts containing the search term in there name or by a exact number</p>
      <div className="row my-3 mx-0">
        <input
          onKeyPress={handleKeyPress}
          className="form-control col-6 mr-sm-2"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          placeholder="Search"
        ></input>
        <button
          onClick={e => submit()}
          className="btn btn-outline-success"
          type="button"
        >
          Search
        </button>
      </div>
      <ContactsList contacts={contacts} />
    </div>
  );
};

export default ContactsSearch;
