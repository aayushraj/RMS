using RMS.Models;
using RMS.Repository.Dashboard;
using RMS.Service.Report;
using RMS.Service.TenantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Service.Dashboard
{
    public interface IDashboardService
    {
        DashboardModel GetRecords();
        List<DashboardModel> GetAmountPaidByTenant();
        List<DashboardModel> GetAdvance();
        List<DashboardModel> GetDue();
    }
    public class DashboardService : IDashboardService
    {
        private readonly ITenantInfoService _tenantSerivce;
        private readonly IReportService _reportService;
        private readonly IDashboardRepository _dashBoardRepo;
        public DashboardService(ITenantInfoService tenantSerivce, IReportService reportService, IDashboardRepository dashBoardRepo)
        {
            _tenantSerivce = tenantSerivce;
            _reportService = reportService;
            _dashBoardRepo = dashBoardRepo;
        }
        public DashboardModel GetRecords()
        {
            DashboardModel model = new DashboardModel();
            TenantInfoModel tenantModel = new TenantInfoModel();
            ReportModel reportModel = new ReportModel();

            tenantModel.List = _tenantSerivce.GetList();
            model.ActiveTenant = tenantModel.List.Count;
            reportModel.list = _reportService.GetAll();
            decimal? TotalReceivedAmount = 0;
            decimal? TotalDue = 0;
            decimal? TotalAdvance = 0;
            for (int i = 0; i < reportModel.list.Count; i++)
            {
                TotalReceivedAmount = TotalReceivedAmount + reportModel.list[i].PaidAmount;
                
                if(reportModel.list[i].Status == 0)
                {
                    TotalDue =TotalDue + reportModel.list[i].DueAmount;
                }
                if(reportModel.list[i].Status == 2)
                {
                    TotalAdvance =TotalAdvance + reportModel.list[i].Advance;
                }
            }
            
            model.TotalReceivedAmount = TotalReceivedAmount;
            model.Advance = TotalAdvance;
            model.DueAmount = TotalDue;
            return model;

        }

        public List<DashboardModel> GetAmountPaidByTenant()
        {
            return _dashBoardRepo.GetAmountPaidByTenant();
        }

        public List<DashboardModel> GetAdvance()
        {
            return _dashBoardRepo.GetAdvance();
        }

        public List<DashboardModel> GetDue()
        {
            return _dashBoardRepo.GetDue();
        }
    }
}
