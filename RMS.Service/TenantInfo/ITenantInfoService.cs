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
    }

    public class TenantInfoService : ITenantInfoService
    {
        private readonly ITenantInfoRepository repo;

        public TenantInfoService()
        {
            repo = new TenantInfoRepository();
        }

        public TenantInfoModel Create(TenantInfoModel model)
        {
            model.flag = 0;
            var isCreate = repo.Create(model);
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
            return repo.GetById(id);
           
        }

        public TenantInfoModel Edit(TenantInfoModel model)
        {
            var Edited = repo.Edit(model);

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
           var list= repo.GetList();
           return list;
        }

        public TenantInfoModel Delete(TenantInfoModel model)
        {
            var Deleted = repo.Delete(model);

            if (Deleted)
            {
                model.flag = 1;
                model.IsSuccess = true;
                model.SuccessMessage = "Deleted Successfully";
            }

            else
            {
                model.flag = 2;
                model.IsSuccess = false;
                model.SuccessMessage = "Fail to Delete";
            }

            return model;
        }
    }
}
