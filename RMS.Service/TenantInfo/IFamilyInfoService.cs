using RMS.Models;
using RMS.Repository.FamilyInfo;

namespace RMS.Service.TenantInfo
{
    public interface IFamilyInfoService : IGenericService<FamilyInfoModel>
    {
        FamilyInfoModel Create(int? id);
        List<FamilyInfoModel> FamilyList(int? id);
    }
    public class FamilyInfoService : IFamilyInfoService
    {
        private readonly IFamilyInfoRepository repo;
        public FamilyInfoService()
        {
            repo = new FamilyInfoRepository();
                
        }
        public FamilyInfoModel Create(FamilyInfoModel model)
        {
            model.flag = 0;

            var isCreate = repo.Create(model);
            if(isCreate)
            {
                model.flag = 1;
                model.SuccessMessage = "Successs";
                model.IsSuccess = true;
            }
            else
            {
                model.flag = 2;
                model.SuccessMessage = "Failure";
            }

            return model;

        }

        public FamilyInfoModel Create(int? id)
        {
            return repo.Create(id);
        }

        public FamilyInfoModel Delete(FamilyInfoModel model)
        {
            var deleted = repo.Delete(model);
            model.flag = 0;

            if (deleted)
            {
                model.flag = 1;
                model.SuccessMessage = "successfull";
                model.IsSuccess = true;
            }

            else
            {
                model.flag = 2;
                model.SuccessMessage = "Failed";
                model.IsSuccess = false;
            }

            return model;
        }

        public FamilyInfoModel Edit(FamilyInfoModel model)
        {
            var edit = repo.Edit(model);
            model.flag = 0;

            if(edit)
            {
                model.flag = 1;
                model.SuccessMessage = "successfull";
                model.IsSuccess = true;
            }

            else
            {
                model.flag = 2;
                model.SuccessMessage = "Failed";
                model.IsSuccess = false;
            }

            return model;
            
        }

        public List<FamilyInfoModel> FamilyList(int? id)
        {
            return repo.FamilyList(id);
        }

        public FamilyInfoModel GetById(int? id)
        {
            return repo.GetById(id);
        }

        public List<FamilyInfoModel> GetList()
        {

            var list = repo.GetList();
            return list;
        }
    }
}
