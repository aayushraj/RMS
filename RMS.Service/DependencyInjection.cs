using Microsoft.Extensions.DependencyInjection;
using RMS.Service.Helpers;
using RMS.Service.Report;
using RMS.Service.TenantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Service
{
    public static class DependencyInjection
    {
        public static void AddService(this IServiceCollection ser)
        {
            ser.AddScoped<IReportService, ReportService>();
            ser.AddScoped<ICommonUtilityService, CommonUtilityService>();
            //ser.AddScoped<IPaymentServices, PaymentServices>();
            ser.AddScoped<ITenantInfoService, TenantInfoService>();
            ser.AddScoped<IFamilyInfoService, FamilyInfoService>();
            //ser.AddScoped<IRentSetupService, RentSetupService>();
            //ser.AddScoped<ISetupServices, SetupService>();
        }
    }
}
