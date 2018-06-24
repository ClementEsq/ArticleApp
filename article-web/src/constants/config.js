export const config = {
    AXIOS_CONFIG: {
        headers: {
            'Content-Type': 'application/json;charset=UTF-8',
            "Access-Control-Allow-Origin": "*",
        }
    },
    GENERAL_CONFIG: {
        sessionName: {
            AuthenticatedUser: 'AuthenticatedUser'
        },
        endpoint: {
            Login: 'http://localhost:5000/api/auth/login',
            Registration: 'http://localhost:5000/api/user/signup',
            NewArticle: 'http://localhost:5000/api/article/publish',
            ArticleListing: 'http://localhost:5000/api/article/all',
            Article: 'http://localhost:5000/api/article'
        },
        newArticleForm:{
            maxAttachmentSize: 2000000
        }
    }
};
