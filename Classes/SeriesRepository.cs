using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
   public class SeriesRepository : IRepository<Series>
   {
      private List<Series> seriesList = new List<Series>();
      public void Delete(int id)
      {
         seriesList[id].Delete();
      }

      public Series GetById(int id)
      {
         return seriesList[id];
      }

      public void Insert(Series entity)
      {
         seriesList.Add(entity);
      }

      public List<Series> List()
      {
         return seriesList;
      }

      public int NextId()
      {
         return seriesList.Count;
      }

      public void Update(int id, Series entity)
      {
         seriesList[id] = entity;
      }
   }
}