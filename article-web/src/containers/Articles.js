import React, { Component } from "react";
import axios from 'axios';
import {config} from "../constants/config";

class Articles extends Component {
    constructor(props) {
        super(props);

        this.state = {
          title: '',
          body: ''       
        };
    }

    
  async componentDidMount() {
    try {
        await this.getArticleFromApi();
    } catch (exception) {
      alert(exception);
    }
  }

  getArticleFromApi = () => {
        
    // abstract away ??
    this.getArticle()
    .then( 
        response => {
            console.log(response.data.payload);
            var article = response.data.payload;
            const title = article.title;
            const body = article.body;
      
            this.setState({ title, body });
        }
    )
    .catch(
        error => {
            console.log(error);
        }
    ); 
  }

async getArticle() {
    console.log(this.props);
    const result = await axios.get(`${config.GENERAL_CONFIG.endpoint.Article}/${this.props.match.params.id}`, config.AXIOS_CONFIG.headers);
    return result;
}


  render() {
    return (
        <div className='Articles'>
            <div className='title'> 
                <h2>{this.state.title}</h2>
            </div>
            <br/>
            <div className='body'> 
                {this.state.body} 
            </div>
        </div>
    );
  }

}

export default Articles