using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Models;
using RMS.Repository;

namespace RMS.Service
{
    public interface ISetupServices 
    {
        SetupModel Create(SetupModel model);
        SetupModel Delete(SetupModel model);
        SetupModel Edit(SetupModel model);
        SetupModel GetById(int? id);
        SetupModel GetByFloorId(int? id);
        List<SetupModel> GetList();

    }
    public class SetupService : ISetupServices
    {
        private readonly ISetupRepository _setupRepo;
        public SetupService(ISetupRepository setupRepo)
        {
            _setupRepo = setupRepo;
        }
        public SetupModel Create(SetupModel model)
        {
            var Created = _setupRepo.Create(model);

            if (Created)
            {
                model.flag = 1;
                model.SuccessMessage = "created successfully";
                model.IsSuccess = true;
            }

            else
            {
                model.flag = 2;
                model.SuccessMessage = "Failed to create";
                model.IsSuccess = false;
            }

            return (model);
        }

        public SetupModel Delete(SetupModel model)
        {
            var deleted = _setupRepo.Delete(model);
            if (deleted)
            {
                model.IsSuccess = true;
                model.SuccessMessage = "deleted succesfully";
                model.flag = 1;
            }

            else
            {
                model.IsSuccess = false;
                model.SuccessMessage = " Cannot be deleted ";
                model.flag = 2;
            }

            return model;
        }

        public SetupModel Edit(SetupModel model)
        {
            var Edited = _setupRepo.Edit(model);

            if (Edited)
            {
                model.flag = 0;
                model.SuccessMessage = "created successfully";
                model.IsSuccess = true;
            }

            else
            {
                model.flag = 1;
                model.SuccessMessage = "Failed to create";
                model.IsSuccess = false;
            }

            return (model);
        }

        public SetupModel GetById(int? id)
        {
            return (_setupRepo.GetById(id));
        }

        public SetupModel GetByFloorId(int? id)
        {
            return (_setupRepo.GetById(id));
        }

        public List<SetupModel> GetList()
        {
            return (_setupRepo.GetList());
        }
    }
}

