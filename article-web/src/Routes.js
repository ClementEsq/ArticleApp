import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import Home from "./containers/Home";
import NotFound from "./containers/NotFound";
import Login from "./containers/Login";
import AppliedRoute from "./components/AppliedRoute";


class ArticleRoutes extends Component{
    
    render(){
        return(
            <Switch>
                <AppliedRoute path='/' exact component={Home} props={this.props} />
                <AppliedRoute path="/login" exact component={Login} props={this.props} />

                {/*'NotFound' MUST BE LAST*/}
                <Route component={NotFound} />
            </Switch>
        );
    }
}

export default ArticleRoutes;