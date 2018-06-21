import React, { Component } from 'react';
import {
  Link,
  withRouter,
} from 'react-router-dom';


import * as routes from '../constants/routes';


class SignUpForm extends Component {

  constructor(props) {
    super(props);
    this.state = {
      firstName: '',
      lastName: '',
      isPublisher: false,
      userEmail: '',
      password: '',
      passwordConfirm: '',
      error: null,
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({firstName: event.target.firstName});
    this.setState({lastName: event.target.lastName});
    this.setState({isPublisher: event.target.isPublisher});
    this.setState({userEmail: event.target.userEmail});
    this.setState({password: event.target.password});
    this.setState({passwordConfirm: event.target.passwordConfirm});
  }

  handleSubmit(event) {
    alert('A name was submitted: ' + this.state.firstName);
    event.preventDefault();
  }

  render() {

    return (
      <form onSubmit={this.handleSubmit}>
        <label>
          First Name:
          <input type="text" value={this.state.firstName} onChange={this.handleChange} placeholder="First Name" />
        </label>
        <label>
          Last Name:
          <input type="text" value={this.state.lastName} onChange={this.handleChange} placeholder="Last Name" />
        </label>
        <label>
          Publisher:
          <input type="checkbox" value={this.state.isPublisher} onChange={this.handleChange} />
        </label>
        <label>
          Email Address:
          <input type="text" value={this.state.userEmail} onChange={this.handleChange} placeholder="Email Address" />
        </label>
        <label>
          Password:
          <input type="password" value={this.state.password} onChange={this.handleChange} placeholder="Password" />
        </label>
        <label>
          Confirm Password:
          <input type="password" value={this.state.passwordConfirm} onChange={this.handleChange} placeholder="Password" />
        </label>

         <button type="submit">submit</button>

         { this.state.error && <p>{this.state.error}</p> }
      </form>
    );
  }

}

const SignUpPage = () =>
  <div>
    <h1>SignUp</h1>
    <SignUpForm />
  </div>

export default withRouter(SignUpPage);
