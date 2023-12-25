namespace SinglePageApplication.ApplicationService.Contracts.IApplicationService
{
    public interface IApplicationService<T, TCreate, TSelect, TUpdate, TDelete>

    {
        Task<IEnumerable<TSelect>> Select();
        Task<TSelect> SelectById(Guid id);
        Task Insert(TCreate obj);
        Task Update(TUpdate obj);
        Task Delete(TDelete obj);
        Task Save();
    }
}
