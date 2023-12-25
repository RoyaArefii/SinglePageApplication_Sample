namespace SinglePageApplication.Models.Contracts.RepositoryFrameworks
{
    public interface IRepository<T> where T : class
    {
            Task<IEnumerable<T>> Select();
            Task<T> SelectById(Guid id);
            Task Insert(T obj);
            Task Update(T obj);
            Task Delete(T obj);
            Task Save();
    }
}
