using ReportService.Core.Domains;
using System;
using System.Collections.Generic;

namespace ReportService.Core.Repository
{
    public class ErrorRepository
    {
        public List<Error> GetLastErrors(int intervalInMinutes)
        {
            // pobieranie z bazy danych 

            return new List<Error>
            {
                new Error {Id = 1, Message = "Bład 1", Date = DateTime.Now},
                new Error {Id = 2, Message = "Bład 2", Date = DateTime.Now},
            };
        }
    }
}
