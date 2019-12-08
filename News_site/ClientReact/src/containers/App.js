import React, { Component } from 'react';
import './App.css';
import Layuot from '../components/Layout/Layout';
import Home from '../components/Home/Home';
import NotFound from '../components/ErrorPages/NotFound/NotFound';
import { Route, Switch, BrowserRouter } from 'react-router-dom';
import NewsList from './News/NewsList/NewsList';

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Layuot>
          <Switch>
            <Route path = "/home" exact component={Home}/>
            <Route path = "/news-list" exact component={NewsList}/>
            <Route path = "/notfound" exact component={NotFound}/>
          </Switch>
        </Layuot>
      </BrowserRouter>
    )
  }
}

export default App;
