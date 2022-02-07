using RMS.Models;

namespace RMS.Repository.Report
{
    public interface IReportRepository
    {
        List<ReportModel> Getlist(ReportModel model);
        ReportModel LastPaid(int? id);
        ReportModel MonthlySummary(ReportModel model);
        List<ReportModel> DailyReport(ReportModel model);
    }

   public class ReportRepository: IReportRepository
    {
        private readonly IDapperService _dapper;
        public ReportRepository(IDapperService dapper)
        {
            _dapper = dapper;
        }
        public List<ReportModel> Getlist(ReportModel model)
        {
            string sql = @"Select tenantId,floorId,PaidAmount,PaymentDate,DueAmount,Advance from payment where((MONTH(PaymentDate) between @From and @To) and tenantId = @Id)";

            var parameters = _dapper.AddParam(model.TenantId);
            parameters.Add("From", model.From);
            parameters.Add("To", model.To);

            var list = _dapper.Query<ReportModel>(sql, parameters).ToList();

            return list;

        }
         
        public ReportModel LastPaid(int? id)
        {
            string sql = @"Select * from Payment where TenantID =@id";
            var parameters = _dapper.AddParam(id);

            var model = _dapper.Query<ReportModel>(sql, parameters).LastOrDefault();

            return model;
        }

        public ReportModel MonthlySummary(ReportModel model)
        {
            string sql = @"select * from payment where MONTH(PaymentDate) = @Month and TenantId=@id";
            var parameter = _dapper.AddParam(model.TenantId);
            parameter.Add("Month", model.From);

             model = _dapper.Query<ReportModel>(sql, parameter).LastOrDefault();
             
            return model;
        } 

        public List<ReportModel> DailyReport(ReportModel model)
        {
            string sql = @"Select * from Payment where (PaymentDate between @From and @To) and TenantId = @id";
            var parameter = _dapper.AddParam(model.TenantId);
            parameter.Add("From",model.FromDate);
            parameter.Add("To", model.ToDate);

            var list = _dapper.Query<ReportModel>(sql, parameter).ToList();

            return list;
        }


    }
}
