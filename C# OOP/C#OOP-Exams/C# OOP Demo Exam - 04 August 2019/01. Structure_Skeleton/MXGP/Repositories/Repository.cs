namespace MXGP.Repositories
{
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;

    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models;
        protected Repository()
        {
            this.models = new List<T>();
        }

        public abstract T GetByName(string name);

        public IReadOnlyCollection<T> GetAll()
         => this.models.AsReadOnly();

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
