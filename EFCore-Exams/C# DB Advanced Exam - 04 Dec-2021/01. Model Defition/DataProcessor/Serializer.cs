 namespace Theatre.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                //.Include(t => t.Tickets)
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls)
                .Where(t => t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = Decimal.Parse(t.Tickets
                    .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                    .Sum(tc => tc.Price).ToString("F2")),
                    Tickets = t.Tickets
                    .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                    .Select(tc => new
                    {
                        Price = Decimal.Parse(tc.Price.ToString("F2")),
                        RowNumber = tc.RowNumber
                    })
                    .OrderByDescending(tk => tk.Price)
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres,Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            throw new NotImplementedException();
        }
    }
}
