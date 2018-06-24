import React, { Component } from "react";
import { PageHeader, ListGroup, ListGroupItem } from "react-bootstrap";
import {config} from "../constants/config";
import axios from 'axios';
import "./Home.css";

class Home extends Component {
  constructor(props) {
    super(props);
    this.isLoggedInUserPublisher = false;
    this.state = {
      isLoading: true,
      articles: []
    };
  }

  async componentDidMount() {

    try{
      this.getArticlesFromApi();
      this.isLoggedInUserPublisher = this.getUserPublisherStatusFromSession();
    }catch(exception){
      alert(exception);
    }
  
    this.setState({ isLoading: false });
  }

  getArticlesFromApi = () => {
        
    // abstract away ??
    this.getArticles()
    .then( 
        response => {
            console.log(response.data.payload);
            var articles = response.data.payload;
            this.setState({ articles });

        }
    )
    .catch(
        error => {
            console.log(error);
            this.setState({ isLoading: false });                
        }
    ); 
  }

async getArticles() {
    const result = await axios.get(config.GENERAL_CONFIG.endpoint.ArticleListing, config.AXIOS_CONFIG.headers);
    return result;
}

getUserPublisherStatusFromSession(){
  var authenticatedUser = JSON.parse(sessionStorage.getItem(config.GENERAL_CONFIG.sessionName.AuthenticatedUser));
  console.log(authenticatedUser);
  return authenticatedUser != null ? authenticatedUser.isPublisher : false;
}

  renderArticles() {
    return (
      <div className="articleListing">
        <PageHeader>Articles</PageHeader>
        <ListGroup>
          {!this.state.isLoading && this.renderArticleListList(this.state.articles)}
        </ListGroup>
      </div>
    );
  }

  renderArticleListList(articles) {
    return [{}].concat(articles).map(
      (article, i) =>
        i !== 0 ? 
        <ListGroupItem key={article.articleId} href={`/articles/${article.articleId}`} onClick={this.handleArticleClick} header={article.body.trim().split("\n")[0]}>
            {"Published On: " + new Date(article.crDate).toLocaleString()}
        </ListGroupItem> :
        this.isLoggedInUserPublisher && this.renderNewArticlePublishButton()
    );
  }

  renderNewArticlePublishButton(){
    return(
      <ListGroupItem key="new" href="/article/new" onClick={this.handleArticleClick} >
        <h4>
          <b>{"\uFF0B"}</b> Publish an article
        </h4>
      </ListGroupItem>
    );
  }

  handleArticleClick = event => {
    event.preventDefault();
    this.props.history.push(event.currentTarget.getAttribute("href"));
  }


  render() {
    return (
      <div className="Home">
        {
          this.renderArticles()
        }
      </div>
    );
  }
}

export default Home;