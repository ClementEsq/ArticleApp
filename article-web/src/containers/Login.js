import React, { Component } from "react";
import { FormGroup, FormControl, ControlLabel } from "react-bootstrap";
import LoaderButton from "../components/LoaderButton";
import {config} from "../constants/config";
import axios from 'axios';
import "./Login.css";

class Login extends Component{
    constructor(props){
        super(props);

        this.state = {
            email: '',
            password: '',
            error: null,
            isLoading: false
        };
    }

    validateForm() {
        return this.state.email.length > 0 && this.state.password.length > 0;
    }

    handleChange = event => {
        this.setState({
          [event.target.id]: event.target.value
        });
    }

    handleSubmit = event => {
        event.preventDefault();
        
        this.setState({ isLoading: true });
        // abstract away ??
        this.postCredentials(this.state)
        .then( 
            response => {
                var AuthenticatedUser = response.data.payload;
                var isAuthenticated = this.checkAuthenticationResponse(AuthenticatedUser);
                this.props.userHasAuthenticated(isAuthenticated);
                this.createUserSession(config.GENERAL_CONFIG.sessionName.AuthenticatedUser, AuthenticatedUser);
                this.props.history.push("/");
            }
        )
        .catch(
            error => {
                console.log(error);
                this.setState({ isLoading: false });                
            }
        ); 
    }

    checkAuthenticationResponse = (AuthenticatedUser) =>{
        if(AuthenticatedUser == null){
            throw new Error('Invalid login credentials');
        }

        return true;
    }

    createUserSession = (key, AuthenticatedUser) => {
        sessionStorage.setItem(key, JSON.stringify(AuthenticatedUser));
    }

    async postCredentials(credentials) {
        const result = await axios.post(config.GENERAL_CONFIG.endpoint.Login, credentials, config.AXIOS_CONFIG.headers);

        return result;
    }
    
    render(){
        return(
            <div className='Login'>
                <form onSubmit={this.handleSubmit}>
                    <FormGroup controlId='email' bsSize='large'>
                        <ControlLabel>Email</ControlLabel>
                        <FormControl autoFocus type='email' value={this.state.email} onChange={this.handleChange} />
                    </FormGroup>

                    <FormGroup controlId='password' bsSize='large'>
                        <ControlLabel>Password</ControlLabel>
                        <FormControl type='password' value={this.state.password} onChange={this.handleChange} />
                    </FormGroup>

                    <LoaderButton block bsSize='large' disabled={!this.validateForm()} type='submit' isLoading={this.state.isLoading} text='Login' loadingText='Logging in…' />
                    { this.state.error && <p>{this.state.error}</p> }
                </form>
            </div>
        );
    }
}


export default Login;