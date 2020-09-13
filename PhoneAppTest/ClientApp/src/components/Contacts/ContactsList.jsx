import React from "react";

const ContactsList = ({ contacts=[] }) => {
  return (
    <div>
        <table className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Number</th>
            </tr>
          </thead>
          <tbody>
            {contacts.map((c, index) => (
              <tr key={c.name}>
                <td>{index+1}</td>
                <td>{c.name}</td>
                <td>{c.number}</td>
              </tr>
            ))}
          </tbody>
        </table>
        {contacts.length === 0 && <p>No current contacts found</p>}
    </div>
  );
};

export default ContactsList;
