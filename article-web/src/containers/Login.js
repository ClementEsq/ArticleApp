import React, { Component } from "react";
import { Button, FormGroup, FormControl, ControlLabel } from "react-bootstrap";
import  {Login_API_ENDPOINT} from '../constants/endPoints';
import  {AXIOS_CONFIG} from '../constants/configs';
import axios from 'axios';
import "./Login.css";

class Login extends Component{
    constructor(props){
        super(props);

        this.state = {
            email: '',
            password: '',
            error: null
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
        this.postCredentials(this.state)
        .then( 
            response => {
                var isAuthenticated = response.data.payload === true;
                console.log(this.props);
                this.props.userHasAuthenticated(isAuthenticated);
            }
        )
        .catch(
            error => {
                console.log(error);
            }
        );  
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

                    <Button block bsSize='large' disabled={!this.validateForm()} type='submit'>
                        Login
                    </Button>

                    { this.state.error && <p>{this.state.error}</p> }
                </form>
            </div>
        );
    }
}


export default Login;