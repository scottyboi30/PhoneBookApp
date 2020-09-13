import React from 'react';
import NavBar from './NavBar/NavBar';

const Layout = ({children}) => (
  <>
    <NavBar />
    <div className="container">
      {children}
    </div>
  </>
);

export default Layout;
