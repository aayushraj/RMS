using RMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Repository.Dashboard
{
    public interface  IDashboardRepository
    {
        List<DashboardModel> GetAmountPaidByTenant();
        List<DashboardModel> GetAdvance();
        List<DashboardModel> GetDue();
    }
    
    public class DashBoardRepository : IDashboardRepository
    {
        private readonly IDapperService _dapperService;
        public DashBoardRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        public List<DashboardModel> GetAmountPaidByTenant()
        {
            string sql = @"Select TenantID, sum(PaidAmount) as PaidAmount from payment Group By TenantId";
            var list = _dapperService.Query<DashboardModel>(sql);
            return list;

        }
        public List<DashboardModel> GetAdvance()
        {
            var sql = @"select tenantId,Advance from payment where status =2";
            var list = _dapperService.Query<DashboardModel>(sql);
            return list;

        }
        public List<DashboardModel> GetDue()
        {
            var sql = @"select tenantId,DueAmount from payment where status =0";
            var list = _dapperService.Query<DashboardModel>(sql);
            return list;

        }
    }
}
