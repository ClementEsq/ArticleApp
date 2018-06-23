import React, { Component } from 'react';
import {
  HelpBlock,
  FormGroup,
  FormControl,
  ControlLabel
} from 'react-bootstrap';
import LoaderButton from '../components/LoaderButton';
import './Signup.css';
import axios from 'axios';
import  { REGISTRATION_API_ENDPOINT} from '../constants/endPoints';
import  {AXIOS_CONFIG} from '../constants/configs';

class Signup extends Component{
    constructor(props) {
        super(props);
    
        this.state = {
          isLoading: false,
          firstName: '',
          lastName: '',
          isPublisher: false,
          userEmail: '',
          password: '',
          confirmPassword: '',
          confirmationCode: ''
        };
    }

    validateForm() {
        return (
            this.state.firstName.length > 0 && 
            this.state.lastName.length > 0 &&
            this.state.userEmail.length > 0 &&
            this.state.password.length > 0 &&
            this.state.password === this.state.confirmPassword
        );
    }

    handleChange = event => {
        this.setState({
          [event.target.id]: event.target.value
        });
    }

    handleSubmit = async event => {
        event.preventDefault();
    
        this.setState({ isLoading: true });
    
        this.postRegistrationDataToApi();
        
    }

    postRegistrationDataToApi = () => {
        
        // abstract away ??
        this.postDataToApi(this.state)
        .then( 
            response => {
                console.log(response.data.payload);
                //var isAuthenticated = response.data.payload === true;
                //this.checkRegistrationResponse(isAuthenticated);
                //this.props.history.push("/");
            }
        )
        .catch(
            error => {
                console.log(error);
                this.setState({ isLoading: false });                
            }
        ); 
    }

    async postDataToApi(registrationDataObject) {
        const result = await axios.post(REGISTRATION_API_ENDPOINT, registrationDataObject, AXIOS_CONFIG);

        return result;
    }



    // make reusable as component
    renderForm() {
        return (
          <form onSubmit={this.handleSubmit}>
            <FormGroup controlId="firstName" bsSize="large">
                <ControlLabel>
                    First Name
                </ControlLabel>
                <FormControl autoFocus type="text" value={this.state.firstName} onChange={this.handleChange} />
            </FormGroup>
            <FormGroup controlId="lastName" bsSize="large">
                <ControlLabel>
                    Last Name
                </ControlLabel>
                <FormControl type="text" value={this.state.lastName} onChange={this.handleChange} />
            </FormGroup>
            <FormGroup controlId="userEmail" bsSize="large">
                <ControlLabel>
                    Email
                </ControlLabel>
                <FormControl type='email' value={this.state.userEmail} onChange={this.handleChange} />
            </FormGroup>
            <FormGroup controlId="isPublisher">
                <HelpBlock>
                    Are you a publisher?
                </HelpBlock>
                <FormControl type="checkbox" value={this.state.isPublisher} onChange={this.handleChange} />
            </FormGroup>
            <FormGroup controlId="password" bsSize="large">
                <ControlLabel>
                    Password
                </ControlLabel>
                <FormControl value={this.state.password} onChange={this.handleChange} type="password" />
            </FormGroup>
            <FormGroup controlId="confirmPassword" bsSize="large">
                <ControlLabel>
                    Confirm Password
                </ControlLabel>
                <FormControl value={this.state.confirmPassword} onChange={this.handleChange} type="password" />
            </FormGroup>
            <LoaderButton block bsSize="large" disabled={!this.validateForm()} type="submit" isLoading={this.state.isLoading} text="Signup" loadingText="Signing up…" />
          </form>
        );
    }

    render() {
        return (
          <div className="Signup">
            {
                this.renderForm()
            }
          </div>
        );
    }
}


export default Signup;