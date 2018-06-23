import React, { Component, Fragment } from "react";
import { withRouter } from "react-router-dom";
import { Nav, Navbar, NavItem } from "react-bootstrap";
import './App.css';
import Routes from "./Routes";
import { LinkContainer } from "react-router-bootstrap";
import  {Is_User_Authenticated} from './constants/sessions';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthenticated: false,
      isAuthenticating: true
    };
  }

  userHasAuthenticated  = authenticated => {
    this.setState({ isAuthenticated: authenticated });
  }
  
  logUserOut = event => {
    this.userHasAuthenticated(false);
    sessionStorage.removeItem(Is_User_Authenticated);
    this.props.history.push("/login");
  }

  componentDidMount(){
    try{
      var authenticated = JSON.parse(sessionStorage.getItem(Is_User_Authenticated));
      console.log(authenticated);
      if(authenticated){
        this.userHasAuthenticated(true);
      }  
    }
    catch(exception){
      console.log(exception);
    }

    this.setState({ isAuthenticating: false });
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

        <Routes childProps={childProps} />
      </div>
    );
  }
}

export default withRouter(App);
