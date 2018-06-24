import React, { Component, Fragment } from "react";
import { withRouter } from "react-router-dom";
import { Nav, Navbar, NavItem } from "react-bootstrap";
import './App.css';
import Routes from "./Routes";
import { LinkContainer } from "react-router-bootstrap";
import {config} from "./constants/config";

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthenticated: false,
      isAuthenticating: true,
      appStatus: '',
      userName: ''
    };
  }

  userHasAuthenticated  = authenticated => {
    this.setState({ isAuthenticated: authenticated });
  }
  
  logUserOut = event => {
    this.userHasAuthenticated(false);
    sessionStorage.removeItem(config.GENERAL_CONFIG.sessionName.AuthenticatedUser);
    this.props.history.push("/login");
  }

  componentDidMount(){
    try{
      var authenticatedUser = JSON.parse(sessionStorage.getItem(config.GENERAL_CONFIG.sessionName.AuthenticatedUser));
      if(authenticatedUser){
        this.userHasAuthenticated(true);
        this.setState({ appStatus: this.getUserAppStatus(authenticatedUser)});
        this.setState({ userName: `${authenticatedUser.firstName} ${authenticatedUser.lastName}`});
      }  
    }
    catch(exception){
      console.log(exception);
    }

    this.setState({ isAuthenticating: false });
  }

  getUserAppStatus = authenticatedUser => {
    return authenticatedUser.isPublisher ? 'Publisher' : '';
  }

  render() {
    const childProps = {
      isAuthenticated: this.state.isAuthenticated,
      userHasAuthenticated: this.userHasAuthenticated
    };

    return (
      !this.state.isAuthenticating &&
      <div className="App container">
        <Navbar fluid collapseOnSelect>
          <Navbar.Header>
            
            <Navbar.Brand>
              <LinkContainer to="/">
                <NavItem>KPMG Articles</NavItem>
              </LinkContainer>
            </Navbar.Brand>
            
            <Navbar.Toggle/>

          </Navbar.Header>

          <Navbar.Collapse>
            <Nav pullRight>
              {
                this.state.isAuthenticated ? 
                <NavItem onClick={this.logUserOut}>Logout</NavItem> :
                <Fragment>
                  <LinkContainer to="/signup">
                    <NavItem>Sign Up</NavItem>
                  </LinkContainer>

                  <LinkContainer to="/login">
                    <NavItem>Login</NavItem>
                  </LinkContainer>
                </Fragment>
              }
            </Nav>
          </Navbar.Collapse>
        </Navbar>
        {
        this.state.isAuthenticated ? 
          <div>
            Logged In As {this.state.userName}{' '}({this.state.appStatus})
          </div> :
          null
        }
        <Routes childProps={childProps} />
      </div>
    );
  }
}

export default withRouter(App);
