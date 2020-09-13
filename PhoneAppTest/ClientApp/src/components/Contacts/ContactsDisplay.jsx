import React, { useState, useEffect } from "react";

import api from "../../api";
import ContactsList from "./ContactsList";

const ContactsDisplay = () => {
  const [contacts, setContacts] = useState([]);

  useEffect(() => {
    getContacts();
  }, []);

  const getContacts = async () => {
    const result = await api.Contacts.list();
    setContacts(result);
  };

  return (
    <div className="mt-3">
      <h1>Contacts</h1>
      <ContactsList contacts={contacts} />
    </div>
  );
};

export default ContactsDisplay;
