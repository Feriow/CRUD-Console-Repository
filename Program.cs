using System;

namespace DIO.Series
{
   class Program
   {
      static SeriesRepository repository = new SeriesRepository();

      static void Main(string[] args)
      {
         string userInput = GetUserInput();
         while (userInput.ToUpper() != "X")
         {
            switch (userInput.ToUpper())
            {
               case "1":
                  ListSeries();
                  break;
               case "2":
                  InsertSeries();
                  break;
               case "3":
                  UpdateSeries();
                  break;
               case "4":
                  DeleteSeries();
                  break;
               case "5":
                  SelectSeries();
                  break;
               case "C":
                  Console.Clear();
                  break;
               default:
                  throw new ArgumentOutOfRangeException();
            }

            userInput = GetUserInput();
         }

         Console.WriteLine("Thank you for using our service!");
      }

      private static void InsertSeries()
      {
         Console.WriteLine("***Insert new series***");

         Series newSeries = CreateSeries(id: repository.NextId());

         repository.Insert(newSeries);
      }
      private static void UpdateSeries()
      {
         Console.WriteLine("***Update series***");

         Console.Write("Insert series ID: ");
         int seriesId = int.Parse(Console.ReadLine());

         if (!CheckDatabase(seriesId))
         {
            return;
         }
         Series updatedSeries = CreateSeries(id: seriesId);
         repository.Update(seriesId, updatedSeries);

      }
      private static Series CreateSeries(int id)
      {
         foreach (int i in Enum.GetValues(typeof(Genre)))
         {
            Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
         }

         Console.WriteLine();
         Console.Write("Select Genre from above: ");
         int genreInput = int.Parse(Console.ReadLine());
         Console.Write("Insert series title: ");
         string titleInput = Console.ReadLine();
         Console.Write("Insert series year: ");
         int yearInput = int.Parse(Console.ReadLine());
         Console.Write("Insert series description: ");
         string descInput = Console.ReadLine();

         Series newSeries = new Series(
         id: id,
         genre: (Genre)genreInput,
         title: titleInput,
         description: descInput,
         year: yearInput);

         return newSeries;
      }

      private static void DeleteSeries()
      {
         Console.WriteLine("***Delete series***");

         Console.Write("Insert series ID: ");
         int seriesId = int.Parse(Console.ReadLine());

         if (seriesId > repository.List().Count - 1 || seriesId < 0)
         {
            Console.WriteLine($"There's no series with #ID: {seriesId}");
            return;
         }

         if (!CheckDatabase(seriesId))
         {
            return;
         }

         string seriesTitle = repository.GetById(seriesId).GetTitle();
         Console.WriteLine($"Do you really want to delete #ID {seriesId}: - {seriesTitle}?");
         Console.WriteLine("Select Y - Yes / N - No: ");
         string userInput = Console.ReadLine().ToUpper();

         switch (userInput)
         {
            case "Y":
               repository.Delete(seriesId);
               Console.WriteLine("Series deleted");
               break;
            case "N":
               Console.WriteLine("Series not deleted");
               break;
            default:
               Console.WriteLine("Insert a valid option");
               break;
         }
      }

      private static void SelectSeries()
      {
         Console.WriteLine("***Select series***");

         Console.Write("Insert series ID: ");
         int seriesId = int.Parse(Console.ReadLine());

         if (!CheckDatabase(seriesId))
         {
            return;
         }

         var series = repository.GetById(seriesId);

         Console.WriteLine(series);
      }

      private static bool CheckDatabase(int seriesId)
      {
         if (seriesId > repository.List().Count - 1 || seriesId < 0)
         {
            Console.WriteLine($"There's no series with #ID: {seriesId}");
            return false;
         }
         else
         {
            return true;
         }
      }
      private static void ListSeries()
      {
         Console.WriteLine("***List series***");

         var list = repository.List();

         if (list.Count == 0)
         {
            Console.WriteLine("0 series in database");
            return;
         }

         foreach (var series in list)
         {
            var deleted = series.GetDeleted();
            Console.WriteLine($"#ID {series.GetId()}: - {series.GetTitle()} {(deleted ? "*deleted*" : "")}");
         }
      }

      private static string GetUserInput()
      {
         Console.WriteLine();
         Console.WriteLine("FERIOW series at your service!");
         Console.WriteLine("Select an option:");

         Console.WriteLine("1 - List series");
         Console.WriteLine("2 - Insert new series");
         Console.WriteLine("3 - Update series");
         Console.WriteLine("4 - Delete series");
         Console.WriteLine("5 - Select series");
         Console.WriteLine("C - Clear console");
         Console.WriteLine("X - Exit");
         Console.WriteLine();

         string userInput = Console.ReadLine().ToUpper();
         Console.WriteLine();
         return userInput;
      }
   }
}
