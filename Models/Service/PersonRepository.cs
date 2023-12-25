using Microsoft.EntityFrameworkCore;
using SinglePageApplication.Models.Contracts;
using SinglePageApplication.Models.Contracts.RepositoryFrameworks;
using SinglePageApplication.Models.DomainModels;

namespace SinglePageApplication.Models.Service
{
    
    public class PersonRepository : IPersonRepository
    {

        private readonly OnlineshopDbContext _context;

        #region [- Ctor -]
        public PersonRepository(OnlineshopDbContext context)
        {
            _context = context;
        }
        #endregion

        #region [- Select() -]
        public async Task<IEnumerable<Person>> Select()
        {
            try
            {

                var persons = await _context.Person.ToListAsync();
                return persons;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- SelectById(Guid id) -]
        public async Task<Person> SelectById(Guid id)
        {
            try
            {
                var persons = await _context.Person.FindAsync(id);
                return persons;
            }
            catch (Exception)
            {

                throw;
            };
        }
        #endregion

        #region [- Delete(Person person) -]
        public async Task Delete(Person person)
        {
            try
            {
                var q = _context.Person.Find(person.Id);
                if (q != null)
                {
                    _context.Remove(q);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- Insert(Person person) -]
        public async Task Insert(Person person)
        {
            try
            {
                await _context.AddAsync(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- Update(Person person) -]
        public async Task Update(Person person)
        {
            try
            {
                var q = await _context.Person.FindAsync(person.Id);
                if (q != null)
                {
                    q.FName = person.FName;
                    q.LName = person.LName;
                }
                await Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- Save() -]
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
