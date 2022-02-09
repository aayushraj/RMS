using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Models;
using RMS.Repository.Report;

namespace RMS.Service.Report
{
    public interface IReportService
    {
        List<ReportModel> Getlist(ReportModel model);
        ReportModel LastPaid(int? id);
        ReportModel MonthlySummary(ReportModel model);
        ReportModel DailyReport(ReportModel model);
    }
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public List<ReportModel> Getlist(ReportModel model)
        {
            var list = _reportRepository.Getlist(model);
            return list;
        }

        public ReportModel LastPaid(int? id)
        {
            ReportModel model = new ReportModel();
            model = _reportRepository.LastPaid(id);
            return model;
        }

        public ReportModel MonthlySummary(ReportModel model)
        {
            var Month = 0;
            List<ReportModel> list = new List<ReportModel>();
            while (Month < 13)
            {
                Month++;
                decimal? TotalPaid = 0;
                model.From = Month.ToString();
                model.To = Month.ToString();
                var model1 = _reportRepository.MonthlySummary(model);

                if (model1 == null)
                    continue;
                else
                {
                    model1.list = _reportRepository.Getlist(model);
                    model1.From = Month.ToString();
                    foreach (var item in model1.list)
                    {
                        TotalPaid += item.PaidAmount;
                    }
                    model1.TotalPaid = TotalPaid;
                    list.Add(model1);
                }
            }
            model.list = list;
            return model;
        }

        public ReportModel DailyReport(ReportModel model)
        {
            model.list = _reportRepository.DailyReport(model);
            return model;
        }
    }
}
