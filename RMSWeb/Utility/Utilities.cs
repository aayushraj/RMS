////using RMS.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.Data.SqlClient;
//using RMS.Models;
//using RMS.Models.Common;
//using RMS.Repository;
//using System.Data;

//namespace RMS.Utility
//{
//    public static class Utilities
//    {
//        private readonly IDapperService _dapperService;
//        private static string? connString;
//        public static void UtilitiesService(IDapperService dapperService)
//        {
//            _dapperService = dapperService;
//        }
//        public static IEnumerable<SelectListItem> GetState()
//        {
//            string sql = @"SELECT StateId AS [Key],StateName AS [Value] FROM RMS_INFO_STATE";
//            var list = _dapperService.Query<DDLModel>(sql);
//            return new SelectList(list, "Key", "Value");
//        }
//        public static IEnumerable<SelectListItem> GetTenant()
//        {
//            string sql = @"SELECT id,FirstName,FloorNumber FROM RMS_INFO ";
//            var list = _dapperService.Query<TenantInfoModel>(sql).ToList();
//            //using (IDbConnection con = new SqlConnection(connString))
//            //{
//            //    con.Open();
//            //    SqlCommand cmd = new SqlCommand(sql, con);
//            //    SqlDataReader rd = cmd.ExecuteReader();
//            //    List<TenantInfoModel> list = new List<TenantInfoModel>();
//            //    list = 
//            //    while (rd.Read())
//            //    {

//            //        TenantInfoModel model = new TenantInfoModel();
//            //        model.Id = Convert.ToInt32(rd["Id"].ToString());
//            //        model.FirstName = rd["FirstName"].ToString();
//            //        model.FloorNumber = Convert.ToInt32(rd["FloorNumber"].ToString());
//            //        list.Add(model);
//            //    }
//            //}
//            return new SelectList(list, "Id", "FirstName", "FloorNumber");

//        }

//        public static int GetFloor(int Id)
//        {
//            //string sql = @"Select * from RMS_INFO where id=@Id";

//            //using (SqlConnection con = new SqlConnection(connString))
//            //{
//            //    con.Open();
//            //    SqlCommand cmd = new SqlCommand(sql, con);
//            //    cmd.Parameters.AddWithValue("id", Id);
//            //    SqlDataReader reader = cmd.ExecuteReader();

//            //    //List<FloorModel> list = new List<FloorModel>();
//            //    TenantInfoModel model = new TenantInfoModel();

//            //    while (reader.Read())
//            //    {
//            //        model.FloorNumber = Convert.ToInt32(reader["FloorNumber"].ToString());
//            //        //model.FloorName = reader["FloorName"].ToString();
//            //        //list.Add(model);
//            //    }



//            //    return model.FloorNumber;
//            //}
//            throw new NotImplementedException();
//        }

//        public static IEnumerable<SelectListItem> GetDistrict(int stateId)
//        {
//            string sql = @"Select DistrictId AS [Key],DistrictName AS [Value] from RMS_INFO_DISTRICT where StateId = @StateId";
//            var list = _dapperService.Query<DDLModel>(sql);
//            return new SelectList(list, "Key", "Value");
//            //using (SqlConnection con = new SqlConnection(connString))
//            //{
//            //    con.Open();
//            //    SqlCommand Cmd = new SqlCommand(sql, con);

//            //    Cmd.Parameters.AddWithValue("StateId", stateId);

//            //    SqlDataReader DataReader = Cmd.ExecuteReader();

//            //    List<DistrictModel> list = new List<DistrictModel>();
//            //    while (DataReader.Read())
//            //    {
//            //        DistrictModel model = new DistrictModel();

//            //        model.DistrictId = Convert.ToInt32(DataReader["DistrictId"].ToString());
//            //        model.DistrictName = DataReader["DistrictName"].ToString();
//            //        list.Add(model);
//            //    }
//            //    return new SelectList(list, "DistrictId", "DistrictName");
//            //}
//        }
//        public static IEnumerable<SelectListItem> GetRelationship()
//        {

//            var selectList = new SelectList(
//                new List<SelectListItem>
//                    {
//                        new SelectListItem {Text = "Mother", Value = "Mother"},
//                        new SelectListItem {Text = "Father", Value = "Father"},
//                        new SelectListItem {Text = "Brother", Value = "Brother"},
//                        new SelectListItem {Text = "Sister", Value = "Sister"},
//                        new SelectListItem {Text = "Daughter", Value = "Daughter"},
//                        new SelectListItem {Text = "Son", Value = "Son"},
//                    }, "Value", "Text");

//            return selectList;

//        }

//        public static string GetMonth(int id)
//        {
//            var Month = "a";
//            switch (id)
//            {
//                case 1:
//                    Month = "January";
//                    break;

//                case 2:
//                    Month = "February";
//                    break;
//                case 3:
//                    Month = "March";
//                    break;
//                case 4:
//                    Month = "April";
//                    break;
//                case 5:
//                    Month = "May";
//                    break;
//                case 6:
//                    Month = "June";
//                    break;
//                case 7:
//                    Month = "July";
//                    break;
//                case 8:
//                    Month = "August";
//                    break;
//                case 9:
//                    Month = "September";
//                    break;
//                case 10:
//                    Month = "October";
//                    break;
//                case 11:
//                    Month = "November";
//                    break;
//                case 12:
//                    Month = "December";
//                    break;
//            };

//            return Month;
//        }


//        public static string GetTenantNameOnly(int id)
//        {

//            string sql = @"SELECT FirstName FROM RMS_INFO  where id=@id";
//            using (SqlConnection con = new SqlConnection(connString))
//            {
//                con.Open();
//                SqlCommand cmd = new SqlCommand(sql, con);
//                cmd.Parameters.AddWithValue("id", id);
//                SqlDataReader rd = cmd.ExecuteReader();
//                TenantInfoModel model = new TenantInfoModel();
//                while (rd.Read())
//                {



//                    model.FirstName = rd["FirstName"].ToString();


//                }
//                return model.FirstName;

//            }


//        }
//    }
//}