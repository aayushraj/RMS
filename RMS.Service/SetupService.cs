//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using RMS.Models;
//using RMS.Repository;

//namespace RMS.Service
//{
//    public interface ISetupServices:IGenericService<SetupModel>
//    {

//    }
//    public class SetupService : ISetupServices
//    {
//        private readonly ISetupRepository repo;
//        public SetupService()
//        {
//            repo = new SetupRepository();
//        }
//        public SetupModel Create(SetupModel model)
//        {
//            var Created = repo.Create(model);

//            if (Created)
//            {
//                model.flag = 1;
//                model.SuccessMessage = "created successfully";
//                model.IsSuccess = true;
//            }

//            else
//            {
//                model.flag = 2;
//                model.SuccessMessage = "Failed to create";
//                model.IsSuccess = false;
//            }

//            return (model);
//        }

//        public SetupModel Delete(SetupModel model)
//        {
//            var deleted = repo.Delete(model);
//            if(deleted)
//            {
//                model.IsSuccess = true;
//                model.SuccessMessage = "deleted succesfully";
//                model.flag = 1;
//            }

//            else
//            {
//                model.IsSuccess = false;
//                model.SuccessMessage = " Cannot be deleted ";
//                model.flag = 2;
//            }

//            return model;
//        }

//        public SetupModel Edit(SetupModel model)
//        {
//            var Edited = repo.Edit(model);

//            if (Edited)
//            {
//                model.flag = 0;
//                model.SuccessMessage = "created successfully";
//                model.IsSuccess = true;
//            }

//            else
//            {
//                model.flag = 1;
//                model.SuccessMessage = "Failed to create";
//                model.IsSuccess = false;
//            }

//            return (model);
//        }

//        public SetupModel GetById(int? id)
//        {
//            return (repo.GetById(id));
//        }

//        public SetupModel GetByFloorId(int? id)
//        {
//            return (repo.GetById(id));
//        }

//        public List<SetupModel> GetList()
//        {
//            return (repo.GetList());
//        }
//    }
//}
