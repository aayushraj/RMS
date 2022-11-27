using Microsoft.Extensions.DependencyInjection;
using RMS.Service.Helpers;
using RMS.Service.Report;
using RMS.Service.TenantInfo;
//using RMS.Service.Category;
//using RMS.Service.Payment;
using RMS.Service.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Service.Payment;
using RMS.Service.Dashboard;
using System.Configuration;

namespace RMS.Service
{
    public static class DependencyInjection
    {
        public static void AddService(this IServiceCollection ser)
        {
            //ser.AddScoped<IAccountService, AccountService>();
            ser.AddScoped<IReportService, ReportService>();
            ser.AddScoped<ICommonUtilityService, CommonUtilityService>();
            ser.AddScoped<IPaymentServices, PaymentServices>();
            ser.AddScoped<ITenantInfoService, TenantInfoService>();
            ser.AddScoped<IFamilyInfoService, FamilyInfoService>();
            ser.AddScoped<IRentSetupService, RentSetupService>();
            ser.AddScoped<ISetupServices, SetupService>();
            ser.AddScoped<IDashboardService,DashboardService>();
            
            
        }
    }
}
