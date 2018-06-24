import React, { Component } from "react";
import { FormGroup, FormControl, ControlLabel } from "react-bootstrap";
import LoaderButton from "../components/LoaderButton";
import {config} from "../constants/config";
import "./NewArticle.css";
import axios from 'axios';

class NewArticle extends Component{
    constructor(props){
        super(props);

        this.state = {
            isLoading: null,
            title: '',
            body: '',
            heroImagePath: '',
            bodyImagePath: '',
            articleAuthorId: this.getUserIdFromSession()
        };     
    }

    validateForm() {
        return this.state.body.length > 0 && this.state.title.length > 0;
    }

    getUserIdFromSession(){
        var authenticatedUser = JSON.parse(sessionStorage.getItem(config.GENERAL_CONFIG.sessionName.AuthenticatedUser));
        console.log(authenticatedUser);
        return authenticatedUser.userId;
    }

    handleChange = event => {
        this.setState({
          [event.target.id]: event.target.value
        });
    }
    
    handleSubmit = async event => {
        event.preventDefault();   
        this.setState({ isLoading: true });
        this.postArticleToApi();
    }

    postArticleToApi = () => {
        
        // abstract away ??
        this.postDataToApi(this.state)
        .then( 
            response => {
                console.log(response);
                if(response.data === 200){
                    this.props.history.push("/");
                }
                throw new Error('Unable to publish article');
            }
        )
        .catch(
            error => {
                console.log(error);
                this.setState({ isLoading: false });                
            }
        ); 
    }

    async postDataToApi(articleObject) {
        console.log(articleObject);
        const result = await axios.post(config.GENERAL_CONFIG.endpoint.NewArticle, articleObject, config.AXIOS_CONFIG.headers);

        return result;
    }

    render(){
        return(
            <div className="NewNote">
                <form onSubmit={this.handleSubmit}>
                    <FormGroup controlId='title' bsSize='large'>
                        <ControlLabel>Article Title</ControlLabel>
                        <FormControl autoFocus type='text' value={this.state.title} onChange={this.handleChange} />
                    </FormGroup>

                    <FormGroup controlId="body">
                        <FormControl onChange={this.handleChange} value={this.state.body} componentClass="textarea" />
                    </FormGroup>
                    <LoaderButton block bsStyle="primary" bsSize="large" disabled={!this.validateForm()} 
                    type="submit" isLoading={this.state.isLoading} text="Publish" loadingText="Publishing..." />
                </form>
            </div>
        );
    }
}

export default NewArticle;