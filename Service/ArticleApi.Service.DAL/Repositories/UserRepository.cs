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
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@UserId", id);

                var user = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstOrDefaultAsync<User>("GetUser", parameter, transaction: _dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByEmail(string emailAdress)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@EmailAddress", emailAdress);

                var user = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstOrDefaultAsync<User>("GetUserByEmail", parameter, transaction: _dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);

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
                _dalSession.UnitOfWork.Begin();

                var parameter = new DynamicParameters();
                parameter.Add("@FirstName", entity.FirstName);
                parameter.Add("@LastName", entity.LastName);
                parameter.Add("@IsPublisher", entity.IsPublisher);
                parameter.Add("@UserEmail", entity.UserEmail);
                parameter.Add("@Password", entity.Password);

                var returnValue = await _dalSession.UnitOfWork.RepositoryConnection.Connection.ExecuteScalarAsync<int>("CreateUser", parameter, transaction: _dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);

                if (returnValue != 0)
                {
                    throw new Exception("Unable to save user.");
                }

                _dalSession.UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _dalSession.UnitOfWork.Rollback();
                throw ex;
            }
        }

        public void Dispose()
        {
            _dalSession.Dispose();
        }
    }
}
