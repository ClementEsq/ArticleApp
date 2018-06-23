import React, { Component } from "react";
import { FormGroup, FormControl, ControlLabel } from "react-bootstrap";
import LoaderButton from "../components/LoaderButton";
import  {Login_API_ENDPOINT} from '../constants/endPoints';
import  {AXIOS_CONFIG} from '../constants/configs';
import  {Is_User_Authenticated} from '../constants/sessions';
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
                var isAuthenticated = response.data.payload === true;
                this.checkAuthenticationResponse(isAuthenticated);
                this.props.userHasAuthenticated(isAuthenticated);
                this.createUserSession(Is_User_Authenticated, isAuthenticated);
                this.props.history.push("/");
            }
        )
        .catch(
            error => {
                console.log(error);
                this.setState({ isLoading: false });                }
        ); 
    }

    checkAuthenticationResponse = (isAuthenticated) =>{
        if(!isAuthenticated){
            throw new Error('Invalid login credentials');
        }
    }

    createUserSession = (key, isUserAuthenticated) => {
        if(isUserAuthenticated) {
            sessionStorage.setItem(key, "true");
        }
    }

    async postCredentials(credentials) {
        const result = await axios.post(Login_API_ENDPOINT, {
            email: credentials.email,
            password: credentials.password
        }, AXIOS_CONFIG);

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