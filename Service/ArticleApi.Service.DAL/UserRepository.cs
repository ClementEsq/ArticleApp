using System.Collections.Generic;
using ArticleApi.Service.DAL.Interfaces;
using ArticleApi.Service.Models;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ArticleApi.Service.DAL
{
    public class UserRepository : IRepository<User, int>
    {
        private readonly IArticleRepositoryConnection ArticleRepositoryConnection;

        public UserRepository(IArticleRepositoryConnection ArticleRepositoryConnection)
        {
            this.ArticleRepositoryConnection = ArticleRepositoryConnection;
        }

        public Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(int id)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@UserId", id);

                var user = await ArticleRepositoryConnection.Connection.QueryFirstOrDefaultAsync<User>("GetUser", parameter, commandType: CommandType.StoredProcedure);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Save(User entity)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@FirstName", entity.FirstName);
                parameter.Add("@LastName", entity.LastName);
                parameter.Add("@IsPublisher", entity.IsPublisher);
                parameter.Add("@UserEmail", entity.UserEmail);
                parameter.Add("@Password", entity.Password);

                var returnValue = await ArticleRepositoryConnection.Connection.QueryFirstAsync<int>("CreateUser", parameter, commandType: CommandType.StoredProcedure);

                if(returnValue != 0)
                {
                    throw new Exception("Unable to save user.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
