using Microsoft.Extensions.DependencyInjection;
using RMS.Repository.FamilyInfo;
//using RMS.Repository.Payment;
using RMS.Repository.Report;
using RMS.Repository.TenantInfo;
using RMS.Repository.Payment;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Repository.Dashboard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
//using RMSWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace RMS.Repository
{
    public static class RepositoryServices
    {
        public static void AddRepositoryService(this IServiceCollection ser)
        {
           
            ser.AddScoped<IDapperService, DapperService>();
            ser.AddScoped<ICommonUtilityRepository, CommonUtilityRepository>();
            ser.AddScoped<IPaymentRepository,PaymentRepository>();
            ser.AddScoped<IReportRepository,ReportRepository>();
            ser.AddScoped<IRentSetupRepository, RentSetupRepository>();
            ser.AddScoped<ISetupRepository, SetupRepository>();
            ser.AddScoped<IFamilyInfoRepository, FamilyInfoRepository>();
            ser.AddScoped<ITenantInfoRepository, TenantInfoRepository>();
            ser.AddScoped<IDashboardRepository, DashBoardRepository>();
            
            
        }
    }
}
