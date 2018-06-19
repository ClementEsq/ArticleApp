using ArticleApi.Service.DAL.Interfaces;
using ArticleApi.Service.Models;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ArticleApi.Service.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly IDalSession _dalSession;

        public UserRepository(IDalSession dalSession)
        {
            _dalSession = dalSession;
        }

        public Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(int id)
        {
            using (_dalSession)
            {
                try
                {
                    _dalSession.UnitOfWork.Begin();

                    var parameter = new DynamicParameters();
                    parameter.Add("@UserId", id);

                    var user = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstOrDefaultAsync<User>("GetUser", parameter, commandType: CommandType.StoredProcedure);

                    _dalSession.UnitOfWork.Commit();

                    return user;
                }
                catch (Exception ex)
                {
                    _dalSession.UnitOfWork.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<User> GetUserByEmail(string emailAdress)
        {
            using (_dalSession)
            {
                try
                {
                    _dalSession.UnitOfWork.Begin();

                    var parameter = new DynamicParameters();
                    parameter.Add("@EmailAddress", emailAdress);

                    var user = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstOrDefaultAsync<User>("GetUserByEmail", parameter, commandType: CommandType.StoredProcedure);

                    _dalSession.UnitOfWork.Commit();

                    return user;
                }
                catch (Exception ex)
                {
                    _dalSession.UnitOfWork.Rollback();
                    throw ex;
                }
            }
        }

        public async Task Save(User entity)
        {
            using (_dalSession)
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@FirstName", entity.FirstName);
                    parameter.Add("@LastName", entity.LastName);
                    parameter.Add("@IsPublisher", entity.IsPublisher);
                    parameter.Add("@UserEmail", entity.UserEmail);
                    parameter.Add("@Password", entity.Password);

                    var returnValue = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstAsync<int>("CreateUser", parameter, commandType: CommandType.StoredProcedure);

                    if (returnValue != 0)
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
}
