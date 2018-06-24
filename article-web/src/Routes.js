import React from "react";
import { Route, Switch } from "react-router-dom";
import Home from "./containers/Home";
import NotFound from "./containers/NotFound";
import ThankYou from "./containers/ThankYou";
import Login from "./containers/Login";
import Signup from "./containers/Signup";
import NewArticle from "./containers/NewArticle";
import AppliedRoute from "./components/AppliedRoute";
import Articles from "./containers/Articles";


export default ({ childProps }) =>
  <Switch>
    <AppliedRoute path="/" exact component={Home} props={childProps} />
    <AppliedRoute path="/login" exact component={Login} props={childProps} />
    <AppliedRoute path="/signup" exact component={Signup} props={childProps} />
    <AppliedRoute path="/article/new" exact component={NewArticle} props={childProps} />
    <AppliedRoute path="/articles/:id" exact component={Articles} props={childProps} />

    <Route path='/thankyou' component={ThankYou} />
    {/*'NotFound' MUST BE LAST*/}
    <Route component={NotFound} />
  </Switch>;