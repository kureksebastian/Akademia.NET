using ReportService.Core.Domains;
using System;
using System.Collections.Generic;

namespace ReportService.Core.Repository
{
    public class ReportRepository
    {
        public Report GetLastNotSentReport()
        {
            // pobieranie z bazy danych ostatniego raportu

            return new Report
            {
                Id = 1,
                Title = "R/1/2023",
                Date = new DateTime(2023, 1, 1, 12, 0, 0),
                Position = new List<ReportPostion>
                {
                    new ReportPostion
                    {
                        Id = 1,
                        ReportId = 1,
                        Title = "Position 1",
                        Description = "Description 1",
                        Value = 34.01m,
                    },
                    new ReportPostion
                    {
                        Id = 2,
                        ReportId = 1,
                        Title = "Position 2",
                        Description = "Description 2",
                        Value = 44.01m,
                    },
                    new ReportPostion
                    {
                        Id = 3,
                        ReportId = 1,
                        Title = "Position 3",
                        Description = "Description 3",
                        Value = 14.99m,
                    },
                }
            };
        }

        public void ReportSent(Report report)
        {
            report.IsSend = true;
            //zapis do bazy
        }
    }
}
