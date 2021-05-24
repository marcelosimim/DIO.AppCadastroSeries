using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();
        public void Delete(int id)
        {
            serieList.RemoveAt(id);
        }

        public void Insert(Serie entity)
        {
            serieList.Add(entity);
        }

        public List<Serie> List()
        {
            return serieList;
        }

        public int nextId()
        {
            return serieList.Count;
        }

        public Serie ReturnById(int id)
        {
            return serieList[id];
        }

        public void Update(int id, Serie entity)
        {
            serieList[id] = entity;
        }
    }
}