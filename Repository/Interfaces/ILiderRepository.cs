using employesControl_V2.Models;

namespace employesControl_V2.Repository.Interfaces
{
    public interface ILiderRepository
    {
        public Task<IEnumerable<Lider>> Get();

        public Task<Lider> GetById(int id);

        public void Post(Lider entity);

        public void Put(Lider entity);

        public void Delete(Lider entity);

        public Task<bool> SaveChangesAsync();
    }
}