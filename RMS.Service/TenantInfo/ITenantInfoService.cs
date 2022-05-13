using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Models;
using RMS.Repository.TenantInfo;

namespace RMS.Service.TenantInfo
{
    public interface ITenantInfoService:IGenericService<TenantInfoModel>
    {
        List<TenantInfoModel> GetListBySearch(string search);
    }

    public class TenantInfoService : ITenantInfoService
    {
        private readonly ITenantInfoRepository _tenantInfoRepository;
        public TenantInfoService(ITenantInfoRepository tenantInfoRepository)
        {
            _tenantInfoRepository = tenantInfoRepository;
        }

        public TenantInfoModel Create(TenantInfoModel model)
        {
            model.flag = 0;
            var isCreate = _tenantInfoRepository.Create(model);
            if (isCreate)
            {
                model.flag = 1;
                model.IsSuccess = true;
                model.SuccessMessage = "Successfully Inserted!";
            }

            else
            {
                model.flag = 2;
                model.SuccessMessage = " fail to create";
                model.IsSuccess = false;
            }

            return model;
        }

        public TenantInfoModel GetById(int? id)
        {
            return _tenantInfoRepository.GetById(id);
           
        }

        public TenantInfoModel Edit(TenantInfoModel model)
        {
            var Edited = _tenantInfoRepository.Edit(model);

            if(Edited)
            {
                model.flag = 1;
                model.IsSuccess = true;
                model.SuccessMessage = "Edited Successfully";
            }

            else
            {
                model.flag = 2;
                model.IsSuccess = false;
                model.SuccessMessage = "Fail to Edit";
            }

            return model;
        }

        public List<TenantInfoModel> GetList()
        {
           var list= _tenantInfoRepository.GetList();
           return list;
        }

        public TenantInfoModel Delete(TenantInfoModel model)
        {
            var Deleted = _tenantInfoRepository.Delete(model);

            if (Deleted)
            {
                DeleteSuccess(model);
            }

            else
            {
                DeleteFail(model);
            }

            return model;
        }

        private static void DeleteFail(TenantInfoModel model)
        {
            model.flag = 2;
            model.IsSuccess = false;
            model.SuccessMessage = "Fail to Delete";
        }

        private static void DeleteSuccess(TenantInfoModel model)
        {
            model.flag = 1;
            model.IsSuccess = true;
            model.SuccessMessage = "Deleted Successfully";
        }

        public List<TenantInfoModel> GetListBySearch(string search)
        {
            return _tenantInfoRepository.GetListBySearch(search);
        }
    }
}
