import React from "react";
import { Link } from "react-router-dom";

const NavBar = () => (
  <header>
    <nav className="navbar navbar-light bg-light d-flex justify-content-center">
      <ul className="nav">
        <li className="nav-item">
          <Link className="nav-link" to="/">
            Add Contacts
          </Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link" to="/contacts">
            Contacts
          </Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link" to="/search">
            Search
          </Link>
        </li>
      </ul>
    </nav>
  </header>
);

export default NavBar;
