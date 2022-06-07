using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using RMS.Models;

namespace RMS.Repository
{
    public interface ISetupRepository 
    {
        bool Create(SetupModel model);
        bool Delete(SetupModel model);
        bool Edit(SetupModel model);
        SetupModel GetById(int? id);
        SetupModel GetByFloorId(int? id);
        List<SetupModel> GetList();
    }
    public class SetupRepository : ISetupRepository
    {
        private readonly IDapperService _dapperService;
        public SetupRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public bool Create(SetupModel model)
        {
            string sql = @"Insert into RentSetup values(@FloorId,@Amount)";
            var parameters = _dapperService.AddParam(model);
            int affectrows = _dapperService.Execute(sql, parameters);
            if (affectrows >= 1)
                return true;
            else
                return false;
        }

        public bool Delete(SetupModel model)
        {
            string sql = @"Delete from RentSetup where id=@id";
            var parameter = _dapperService.AddParam(model.Id);
            int affectedrows = _dapperService.Execute(sql, parameter);
            if (affectedrows >= 1)
                return true;
            else
                return false;
        }

        public bool Edit(SetupModel model)
        {
            string sql = @"update RentSetup set FloorId=@floorId , Amount =@Amount where id=@id";
            var parameter = _dapperService.AddParam(model);
            int affectedrows = _dapperService.Execute(sql, parameter);
            if (affectedrows >= 1)
                return true;
            else
                return false;

        }

        public SetupModel GetById(int? id)
        {
            string sql = @"select * from RentSetup where id=@id";
            var parameter = _dapperService.AddParam(id);
            SetupModel model = new SetupModel();
            model = _dapperService.Query<SetupModel>(sql, parameter).FirstOrDefault();
            return model;

        }
        public SetupModel GetByFloorId(int? id)
        {
            string sql = @"select * from RentSetup where FloorId=@id";
            var parameter = _dapperService.AddParam(id);
            var model = _dapperService.Query<SetupModel>(sql, parameter).FirstOrDefault();
            return model;
        }

        public List<SetupModel> GetList()
        {
            string sql = @"Select * from RentSetup";
            var list = _dapperService.Query<SetupModel>(sql);
            return list;

        }
    }
}
