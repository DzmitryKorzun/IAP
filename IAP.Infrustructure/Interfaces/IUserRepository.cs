namespace IAP.Infrustructure.Interfaces
{    
    public interface IUserRepository
    {
        public Task<int> GetCountOfUser();
    }
}
