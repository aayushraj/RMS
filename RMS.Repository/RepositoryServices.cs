using Microsoft.Extensions.DependencyInjection;
using RMS.Repository.FamilyInfo;
//using RMS.Repository.Payment;
using RMS.Repository.Report;
using RMS.Repository.TenantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Repository
{
    public static class RepositoryServices
    {
        public static void AddRepositoryService(this IServiceCollection ser)
        {
            ser.AddScoped<IDapperService, DapperService>();
            //ser.AddScoped<IPaymentRepository,PaymentRepository>();
            ser.AddScoped<IReportRepository,ReportRepository>();
            //ser.AddScoped<IRentSetupRepository, RentSetupRepository>();
            //ser.AddScoped<ISetupRepository, SetupRepository>();
            ser.AddScoped<IFamilyInfoRepository, FamilyInfoRepository>();
            ser.AddScoped<ITenantInfoRepository, TenantInfoRepository>();
        }
    }
}
