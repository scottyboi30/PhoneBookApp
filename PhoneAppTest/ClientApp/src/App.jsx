import React, { Component } from 'react';
import { Route } from 'react-router';

import Layout from './components/Layout';
import ContactsForm from './components/Contacts/form/ContactsForm';
import ContactsDisplay from './components/Contacts/ContactsDisplay';
import ContactsSearch from './components/Contacts/ContactsSearch';

import './custom.css'

export default class App extends Component {

  render () {
    return (
      <Layout>
        <Route exact path='/' component={ContactsForm} />
        <Route exact path='/contacts' component={ContactsDisplay} />
        <Route exact path='/search' component={ContactsSearch} />
      </Layout>
    );
  }
}
