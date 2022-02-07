using System.Configuration;
using Microsoft.Data.SqlClient;
using RMS.Models;

namespace RMS.Repository.FamilyInfo
{
    public interface IFamilyInfoRepository:IGenericRepository<FamilyInfoModel>
    {
         FamilyInfoModel Create(int? id);
        List<FamilyInfoModel> FamilyList(int? id);
    }

    public class FamilyInfoRepository : IFamilyInfoRepository
    {
        private string connString = ConfigurationManager.ConnectionStrings["DBstring"].ToString();
        public bool Create(FamilyInfoModel model)
        {
            string sql = @"Insert into FamilyInfo Values(@FirstName,@LastName,@Address,@Contact,@FloorId,@ParentId,@gemfer,@Relationship,@Dob)";
            SqlConnection con = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("FirstName", model.FirstName);
            cmd.Parameters.AddWithValue("LastName", model.LastName);
            cmd.Parameters.AddWithValue("Address", model.Address);
            cmd.Parameters.AddWithValue("Contact", model.Contact);
            cmd.Parameters.AddWithValue("FloorId", model.FloorId);
            cmd.Parameters.AddWithValue("ParentID", model.Id);
            cmd.Parameters.AddWithValue("gender", model.Gender);
            cmd.Parameters.AddWithValue("Relationship", model.Relationship);
            cmd.Parameters.AddWithValue("Dob", model.DOB);

            con.Open();
               int infectedRows = cmd.ExecuteNonQuery();
            con.Close();

            if(infectedRows>=1)
            {
                return true;            
            }
            else
            {
                return false;
            }
        }

        public FamilyInfoModel Create(int? id)
        {
            //string Name;
            string sql = @"Select FirstName ,FloorNumber From RMS_INFO where id=@id";

            

            SqlConnection con = new SqlConnection(connString);


            SqlCommand cmd = new SqlCommand(sql, con);

            FamilyInfoModel model = new FamilyInfoModel();

            cmd.Parameters.AddWithValue("id", id);
            //cmd.Parameters.AddWithValue("FirstName",model.FirstName );
            //cmd.Parameters.AddWithValue("LastName",model.LastName);



            con.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                model.FirstName = dataReader["FirstName"].ToString();
                
                model.FloorId = Convert.ToInt32(dataReader["FloorNumber"].ToString());
            }

           // Name = $" {model.FirstName} {model.LastName}";

            con.Close();

            return model;


        }

        public bool Delete(FamilyInfoModel model)
        {
            string sql = @"delete  from FamilyInfo where id = @id";

            SqlConnection con = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("id", model.Id);

            con.Open();

            int Rowsaffected = cmd.ExecuteNonQuery();

            con.Close();

            if (Rowsaffected >= 1)
                return true;
            else
                return false;
        }

        public bool Edit(FamilyInfoModel model)
        {
            string sql = @"Update FamilyInfo set firstName=@FirstName,LastName=@LastName,Address=@Address,Contact=@Contact,gender=@gender,Relationship=@Relationship,Dob=@Dob where id=@id";

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("FirstName", model.FirstName);
            cmd.Parameters.AddWithValue("LastName", model.LastName);
            cmd.Parameters.AddWithValue("Address", model.Address);
            cmd.Parameters.AddWithValue("Contact", model.Contact);
            cmd.Parameters.AddWithValue("gender", model.Gender);
            cmd.Parameters.AddWithValue("Relationship", model.Relationship);
            cmd.Parameters.AddWithValue("Dob", model.DOB);
            cmd.Parameters.AddWithValue("id", model.Id);

            con.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            con.Close();

            if (affectedRows >= 1)
                return true;
            else
                return false;


        }

        public List<FamilyInfoModel> FamilyList(int? id)
        {
            string sql = @"Select * from FamilyInfo where ParentId=@id";
            SqlConnection con = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("id", id);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();


            List<FamilyInfoModel> list = new List<FamilyInfoModel>();
            while (reader.Read())
            {
                FamilyInfoModel model = new FamilyInfoModel();

                model.Id = Convert.ToInt32(reader["id"].ToString());
                model.FirstName = reader["FirstName"].ToString();
                model.LastName = reader["LastName"].ToString();
                model.Address = reader["Address"].ToString();
                model.Contact = Convert.ToDecimal(reader["Contact"].ToString());
                model.Gender = reader["gender"].ToString();
                model.Relationship = reader["Relationship"].ToString();
                model.DOB = Convert.ToDateTime(reader["Dob"].ToString());
                list.Add(model);
            }
            con.Close();
             return list;
        }

        public FamilyInfoModel GetById(int? id)
        {
            string sql = @"Select * from FamilyInfo where id=@id";
            SqlConnection con = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("id", id);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            FamilyInfoModel model = new FamilyInfoModel();
            while (reader.Read())
            {

                model.Id = Convert.ToInt32(reader["id"].ToString());
                model.FirstName = reader["FirstName"].ToString();
                model.LastName = reader["LastName"].ToString();
                model.Address = reader["Address"].ToString();
                model.Contact = Convert.ToDecimal(reader["Contact"].ToString());
                model.Gender = reader["gendet"].ToString();
                model.Relationship = reader["Relationship"].ToString();
                model.DOB = Convert.ToDateTime(reader["Dob"].ToString());

            }
            con.Close();
            return model;
        }

        public List<FamilyInfoModel> GetList()
        {
            string sql = @"Select * from FamilyInfo";
            SqlConnection con = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            
           List<FamilyInfoModel> list = new List<FamilyInfoModel>();
            while(reader.Read())
            {
                FamilyInfoModel model = new FamilyInfoModel();

                model.Id=Convert.ToInt32(reader["id"].ToString());
                model.FirstName = reader["FirstName"].ToString();
                model.LastName = reader["LastName"].ToString();
                model.Address = reader["Address"].ToString();
                model.Contact = Convert.ToDecimal(reader["Contact"].ToString());
                model.Gender = reader["gender"].ToString();
                model.Relationship = reader["Relationship"].ToString();
                model.DOB = Convert.ToDateTime(reader["Dob"].ToString());
                list.Add(model);
            }
            con.Close();
            return list;
        }
    }
}
