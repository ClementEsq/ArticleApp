using ArticleApi.Service.DAL.Interfaces;

namespace ArticleApi.Service.DAL
{
    public class DalSession : IDalSession
    {
        private readonly IUnitOfWork _unitOfWork;

        public DalSession(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.RepositoryConnection.Connection.Open();
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public void Dispose()
        {
            _unitOfWork.RepositoryConnection.Connection.Close();
            _unitOfWork.RepositoryConnection.Connection.Dispose();
        }
    }
}
