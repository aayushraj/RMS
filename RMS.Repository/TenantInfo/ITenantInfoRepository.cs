﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RMS.Models;

namespace RMS.Repository.TenantInfo
{
    public interface ITenantInfoRepository : IGenericRepository<TenantInfoModel>
    {
        List<TenantInfoModel> GetListBySearch(string search);
        bool Delete(int? id);
    }

    public class TenantInfoRepository : ITenantInfoRepository
    {
        //private string connString = ConfigurationManager.ConnectionStrings["DBstring"].ToString();
        private readonly IDapperService _dapperService;
        public TenantInfoRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public bool Create(TenantInfoModel model)
        {
            //string tenantInsertSql = @"Insert into RMS_INfO values(@FirstName , @LastName , @Address,@Contact,@FloorNumber,@StateId,@City,@WardNo,@Email,@District,@Status,@MiddleName) Select Scope_Identity()";

            //using (var con = _connection)
            //{
            //    con.Open();
            //    con.BeginTransaction();


            //    SqlCommand tenantCmd = new SqlCommand(sql,con, transaction);

            //    tenantCmd.Parameters.AddWithValue("FirstName", model.FirstName);
            //    tenantCmd.Parameters.AddWithValue("LastName", model.LastName);
            //    tenantCmd.Parameters.AddWithValue("Address", model.Address);
            //    tenantCmd.Parameters.AddWithValue("Contact", model.Contact);
            //    tenantCmd.Parameters.AddWithValue("FloorNumber", model.FloorNumber);
            //    tenantCmd.Parameters.AddWithValue("StateId", model.State);
            //    tenantCmd.Parameters.AddWithValue("City", model.City);
            //    tenantCmd.Parameters.AddWithValue("WardNo", model.WardNo);
            //    tenantCmd.Parameters.AddWithValue("Email", model.Email);
            //    tenantCmd.Parameters.AddWithValue("District", model.District);
            //    tenantCmd.Parameters.AddWithValue("Status", 1);
            //    tenantCmd.Parameters.AddWithValue("MiddleName", model.MiddleName);

            //}
            //SqlConnection con = new SqlConnection(_connection.ConnectionString.ToString());
            //// SqlTransaction transaction = con.BeginTransaction();
            //con.Open();
            //SqlTransaction transaction = con.BeginTransaction();

            //try
            //{
            //    string sql = @"Insert into RMS_INfO values(@FirstName , @LastName , @Address,@Contact,@FloorNumber,@StateId,@City,@WardNo,@Email,@District,@Status,@MiddleName) Select Scope_Identity()";
            //    SqlCommand tenantCmd = new SqlCommand(sql, con, transaction);

            //    tenantCmd.Parameters.AddWithValue("FirstName", model.FirstName);
            //    tenantCmd.Parameters.AddWithValue("LastName", model.LastName);
            //    tenantCmd.Parameters.AddWithValue("Address", model.Address);
            //    tenantCmd.Parameters.AddWithValue("Contact", model.Contact);
            //    tenantCmd.Parameters.AddWithValue("FloorNumber", model.FloorNumber);
            //    tenantCmd.Parameters.AddWithValue("StateId", model.State);
            //    tenantCmd.Parameters.AddWithValue("City", model.City);
            //    tenantCmd.Parameters.AddWithValue("WardNo", model.WardNo);
            //    tenantCmd.Parameters.AddWithValue("Email", model.Email);
            //    tenantCmd.Parameters.AddWithValue("District", model.District);
            //    tenantCmd.Parameters.AddWithValue("Status", 1);
            //    tenantCmd.Parameters.AddWithValue("MiddleName", model.MiddleName);

            //    int last_insertId = int.Parse(tenantCmd.ExecuteScalar().ToString());


            //    foreach (var item in model.FamilyList)
            //    {
            //        string sql2 = @"Insert into FamilyInfo Values(@FirstName,@LastName,@Address,@Contact,@FloorId,@ParentId,@gender,@Relationship,@Dob,@Status)";

            //        SqlCommand cmd = new SqlCommand(sql2, con,transaction);

            //        cmd.Parameters.AddWithValue("FirstName", item.FirstName);
            //        cmd.Parameters.AddWithValue("LastName", item.LastName);
            //        cmd.Parameters.AddWithValue("Address", model.Address);
            //        cmd.Parameters.AddWithValue("Contact", model.Contact);
            //        cmd.Parameters.AddWithValue("FloorId", model.FloorNumber);
            //        cmd.Parameters.AddWithValue("ParentID", last_insertId);
            //        cmd.Parameters.AddWithValue("gender", item.Gender);
            //        cmd.Parameters.AddWithValue("Relationship", item.Relationship);
            //        cmd.Parameters.AddWithValue("Dob", item.DOB);
            //        cmd.Parameters.AddWithValue("Status", 1);

            //        cmd.ExecuteNonQuery();
            //    }


            //    transaction.Commit();
            //    con.Close();
            //    return true;
            //}


            //catch(Exception ex)
            //{
            //    transaction.Rollback();
            //    return false;


            //}
            return true;
        }

        public List<TenantInfoModel> GetList()
        {
            string sql = @"SP_GETTENANT_INFO";
            var parameter = _dapperService.AddParam("GetList");
            var list = _dapperService.SPQuery<TenantInfoModel>(sql,parameter);
            return list;
        }
        #region Using SQLConnection for Reference
        //SqlConnection con = new SqlConnection(connString);

        //SqlCommand Command = new SqlCommand(sql, con);

        //con.Open();

        //SqlDataReader dataReader = Command.ExecuteReader();

        //List<TenantInfoModel> list = new List<TenantInfoModel>();

        //while (dataReader.Read())
        //{
        //    TenantInfoModel model = new TenantInfoModel();

        //    model.Id = Convert.ToInt32(dataReader["id"].ToString());
        //    model.FirstName = dataReader["Firstname"].ToString();
        //    model.LastName = dataReader["Lastname"].ToString();
        //    model.Address = dataReader["Address"].ToString();
        //    model.Contact = Convert.ToDecimal(dataReader["Contact"].ToString());
        //    model.StateName = dataReader["StateName"].ToString();
        //    model.FloorNumber = Convert.ToInt32(dataReader["FloorNumber"].ToString());
        //    model.City = dataReader["City"].ToString();
        //    model.WardNo = Convert.ToInt32(dataReader["WardNo"].ToString());
        //    model.Email = dataReader["Email"].ToString();
        //    model.DistrictName = dataReader["DistrictName"].ToString();

        //    list.Add(model);
        //}

        //con.Close();

        //return list; 
        #endregion


        public TenantInfoModel GetById(int? id)
        {
            string getTenantSql = @"select rf.id,rf.FirstName,rf.LastName,rf.Address,rf.Contact,rf.City,rf.District,rf.StateId,rf.FloorId,rf.WardNo,rf.Email,rf.MiddleName,D.DistrictName,r.StateName   
                            from  RMS_INFO rf 
                            inner join RMS_INFO_STATE as r on r.StateId = rf.StateId
                            inner join RMS_INFO_District as D on D.DistrictId = rf.District  where id=@Id ";
            string sql1 = @"	select * from FamilyInfo where ParentID = @id";

            var tenantParam = _dapperService.AddParam(id);
            var tenantInfo = _dapperService.Query<TenantInfoModel>(getTenantSql, tenantParam).FirstOrDefault();

            var famaliParam = _dapperService.AddParam(tenantInfo.Id);
            var familyinfo = _dapperService.Query<FamilyInfoModel>(sql1, famaliParam);
            tenantInfo.FamilyList = familyinfo;
            

            //SqlConnection con = new SqlConnection(_connection.ConnectionString);
            //SqlCommand cmd = new SqlCommand(getTenantSql, con);
            //cmd.Parameters.AddWithValue("id", id);

            //SqlCommand familyCmd = new SqlCommand(sql1, con);
            //familyCmd.Parameters.AddWithValue("id", id);

            //con.Open();
            //SqlDataReader dataReader = cmd.ExecuteReader();

            //TenantInfoModel model = new TenantInfoModel();

            //while (dataReader.Read())
            //{
            //    model.Id = Convert.ToInt32(dataReader["id"].ToString());
            //    model.FirstName = dataReader["Firstname"].ToString();
            //    model.LastName = dataReader["Lastname"].ToString();
            //    model.Address = dataReader["Address"].ToString();

            //    model.Contact = Convert.ToDecimal(dataReader["contact"].ToString());
            //    model.City = dataReader["City"].ToString();
            //    model.FloorNumber = Convert.ToInt32(dataReader["FloorNumber"].ToString());
            //    model.StateName = dataReader["StateName"].ToString();

            //    model.WardNo = Convert.ToInt32(dataReader["WardNo"].ToString());
            //    model.Email = dataReader["Email"].ToString();
            //    model.DistrictName = dataReader["DistrictName"].ToString();
            //    model.MiddleName = dataReader["MiddleName"].ToString();

            //}
            //con.Close();


            //con.Open();
            //SqlDataReader dataReader1 = familyCmd.ExecuteReader();
            //List<FamilyInfoModel> list = new List<FamilyInfoModel>();
            //while (dataReader1.Read())
            //{
            //    FamilyInfoModel fmodel = new FamilyInfoModel();
            //    fmodel.Id = Convert.ToInt32(dataReader1["id"].ToString());
            //    fmodel.FirstName = dataReader1["FirstName"].ToString();
            //    fmodel.LastName = dataReader1["LastName"].ToString();
            //    fmodel.Gender = dataReader1["Gender"].ToString();
            //    fmodel.Relationship = dataReader1["Relationship"].ToString();
            //    //fmodel.DOB = Convert.ToDateTime(dataReader1["DOB"].ToString());
            //    list.Add(fmodel);


            //}
            //model.FamilyList = list;
            //con.Close();
            return tenantInfo;
        }

        public bool Edit(TenantInfoModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int? id)
        {
            string sql = @"Update RMS_Info set status=0 where id=@Id";
            var parameter = _dapperService.AddParam(id);
            var rowsAffected=_dapperService.Execute(sql, parameter);
            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

        public List<TenantInfoModel> GetListBySearch(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return GetList();
            }
            else
            {
                var list = GetList();
                return list.Where(x => x.FirstName.Contains(search)).ToList();
            }
        }

        public bool Delete(TenantInfoModel model)
        {
            throw new NotImplementedException();
        }



        //public bool Edit(TenantInfoModel model)
        //{
        //    SqlConnection con = new SqlConnection(_connection.ConnectionString);
        //    con.Open();

        //    SqlTransaction transaction = con.BeginTransaction();
        //    try
        //    {
        //        string sql = @"update RMS_Info set FirstName=@FirstName,LastName=@LastName,Address=@Address,Contact=@Contact,FloorNumber=@FloorNumber,City=@City,WardNo=@WardNo,Email=@Email,District=@District,MiddleName=@MiddleName where id=@id";

        //        SqlCommand cmd = new SqlCommand(sql, con, transaction);

        //        cmd.Parameters.AddWithValue("id", model.Id);
        //        cmd.Parameters.AddWithValue("FirstName", model.FirstName);
        //        cmd.Parameters.AddWithValue("LastName", model.LastName);
        //        cmd.Parameters.AddWithValue("Address", model.Address);
        //        cmd.Parameters.AddWithValue("Contact", model.Contact);
        //        cmd.Parameters.AddWithValue("FloorNumber", model.FloorNumber);
        //        cmd.Parameters.AddWithValue("City", model.City);
        //        cmd.Parameters.AddWithValue("WardNo", model.WardNo);
        //        cmd.Parameters.AddWithValue("Email", model.Email);
        //        cmd.Parameters.AddWithValue("District", model.District);
        //        cmd.Parameters.AddWithValue("MiddleName", model.MiddleName);



        //        foreach (var item in model.FamilyList)
        //        {
        //            string sql1 = @"update Familyinfo set FirstName=@FirstName,LastName=@LastName,Address=@Address,Contact=@Contact,Floorid=@Floorid,Gender=@Gender,Relationship=@Relationship,DOB=@DOB where id=@id";

        //            SqlCommand familycmd = new SqlCommand(sql1, con, transaction);

        //            familycmd.Parameters.AddWithValue("id", item.Id);
        //            familycmd.Parameters.AddWithValue("FirstName", item.FirstName);
        //            familycmd.Parameters.AddWithValue("LastName", item.LastName);
        //            familycmd.Parameters.AddWithValue("Address", model.Address);
        //            familycmd.Parameters.AddWithValue("Contact", model.Contact);
        //            familycmd.Parameters.AddWithValue("Floorid", model.FloorNumber);
        //            familycmd.Parameters.AddWithValue("Gender", item.Gender);
        //            familycmd.Parameters.AddWithValue("Relationship", item.Relationship);
        //            familycmd.Parameters.AddWithValue("DOB", item.DOB);

        //            familycmd.ExecuteNonQuery();
        //        }




        //        cmd.ExecuteNonQuery();

        //        transaction.Commit();
        //        con.Close();
        //        return true;

        //    }

        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        return false;
        //    }

        //}

        //public bool Delete(TenantInfoModel model)
        //{
        //    SqlConnection con = new SqlConnection(_connection.ConnectionString);
        //    con.Open();
        //    SqlTransaction transaction = con.BeginTransaction();
        //    try
        //    {
        //        string sql = @"update RMS_info set status=0 where id=@id";

        //        SqlCommand cmd = new SqlCommand(sql, con, transaction);


        //        cmd.Parameters.AddWithValue("id", model.Id);

        //        foreach (var item in model.FamilyList)
        //        {
        //            string sql1 = @"update FamilyInfo set status=0 where id=@id";

        //            SqlCommand familycmd = new SqlCommand(sql1, con, transaction);

        //            familycmd.Parameters.AddWithValue("id", item.Id);

        //            familycmd.ExecuteNonQuery();
        //        }



        //        cmd.ExecuteNonQuery();
        //        transaction.Commit();

        //        con.Close();
        //        return true;
        //    }


        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        return false;
        //    }
        //}

        //private SqlCommand GetParam(object model,SqlConnection con,string sql)
        //{
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    foreach (var item in model.GetType().)
        //    {
        //        cmd.Parameters.AddWithValue(model.GetType().Name,model.GetType().)
        //    }

        //}

        //private int ExecuteNonQuery(SqlCommand cmd)
        //{
        //    return cmd.ExecuteNonQuery();
        //}


    }


}


