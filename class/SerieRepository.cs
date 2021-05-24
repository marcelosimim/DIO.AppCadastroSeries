using System;
using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();
        public bool Delete(int id)
        {
            bool deleted = false;
            int position = 0, count = 0;

            foreach (Serie s in serieList)
            {
                if (s.Id == id)
                {
                    deleted = true;
                    position = count;
                }
                count++;
            }

            if (deleted)
            {
                serieList.RemoveAt(position);
            }

            return deleted;
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