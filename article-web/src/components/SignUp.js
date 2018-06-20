import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import * as routes from '../constants/routes';


const SignUpPage = () =>
  <div>
    <h1>SignUp</h1>
    <SignUpForm />
  </div>

const INITIAL_STATE = {
  firstName: '',
  lastName: '',
  isPublisher: false,
  userEmail: '',
  password: '',
  passwordConfirm: '',
  error: null,
};

class SignUpForm extends Component {
  constructor(props) {
    super(props);
  }

  onSubmit = (event) => {

  }

  render() {

    this.state = {
      firstName: '',
      lastName: '',
      isPublisher: false,
      userEmail: '',
      password: '',
      passwordConfirm: '',
      error: null,
    };

    const isInvalid =
    this.state.password !== this.state.passwordConfirm ||
    this.state.password === '' ||
    this.state.userEmail === '' ||
    this.state.firstName === '' ||
    this.state.firstName === '';

    return (
      <form onSubmit={this.onSubmit}>
        <input value="" onChange={event => this.setState({firstName: event.target.value})} type="text" placeholder="First Name"/>
        <input value={this.state.lastName} onChange={event => this.setState({lastName: event.target.value})} type="text" placeholder="Last Name"/>
        <input value={this.state.isPublisher} onChange={event => this.setState({isPublisher: event.target.checked})} type="checkbox" />
        <input value={this.state.userEmail} onChange={event => this.setState({userEmail: event.target.value})} type="text" placeholder="Email Address"/>
        <input value={this.state.password} onChange={event => this.setState({password: event.target.value})} type="password" placeholder="Password"/>
        <input value={this.state.passwordConfirm} onChange={event => this.setState({passwordConfirm: event.target.value})} type="password" placeholder="Password"/>
        
        <button type="submit">Sign Up</button>

        { this.state.error && <p>{this.state.error}</p> }
      </form>
    );
  }

}

const SignUpLink = () =>
  <p>
    <Link to={routes.SIGN_UP}>Sign Up</Link>
  </p>

export {
  SignUpForm,
  SignUpLink,
};

export default SignUpPage;