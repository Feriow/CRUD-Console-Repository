using System;

namespace DIO.Series
{
   public class Series : BaseEntity
   {
      //Properties
      private Genre Genre { get; set; }
      private string Title { get; set; }
      private string Description { get; set; }
      private int Year { get; set; }

      private bool Deleted { get; set; }

      //Methods
      public Series(int id, Genre genre, string title, string description, int year)
      {
         this.Id = id;
         this.Genre = genre;
         this.Title = title;
         this.Description = description;
         this.Year = year;
         this.Deleted = false;
      }

      public override string ToString()
      {
         string toReturn = "";
         toReturn += "Genre: " + this.Genre + Environment.NewLine;
         toReturn += "Title: " + this.Title + Environment.NewLine;
         toReturn += "Description: " + this.Description + Environment.NewLine;
         toReturn += "Year: " + this.Year + Environment.NewLine;
         toReturn += "Deleted: " + this.Deleted;
         return toReturn;
      }

      public string GetTitle()
      {
         return this.Title;
      }
      public int GetId()
      {
         return this.Id;
      }
      public void Delete()
      {
         this.Deleted = true;
      }

      public bool GetDeleted()
      {
         return this.Deleted;
      }
   }
}