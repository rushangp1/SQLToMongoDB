import React, { Component } from 'react';
import { Route,Redirect } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Employees } from './components/Employees';
import { Counter } from './components/Counter';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path="/" render={() => (
                <Redirect to="/fetch-data" />
            )} />
        <Route path='/counter' component={Counter} />
            <Route path='/fetch-data' component={Employees} />
      </Layout>
    );
  }
}
