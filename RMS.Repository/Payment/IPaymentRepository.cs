using RMS.Models;

namespace RMS.Repository.Payment
{
    public interface IPaymentRepository 
    {
        PaymentModel Getdue(int id);
        PaymentModel GetAdvance(int id);
        int Edit(int id);
        List<PaymentModel> GetList();
        bool Create(PaymentModel model);
    }
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDapperService _dapper;
        public PaymentRepository(IDapperService Dapper)
        {
            _dapper = Dapper;
        }
        public bool Create(PaymentModel model)
        {
            string sql = @"Insert into Payment values(@TenantID,@FloorId,@PaidAmount,@PaymentDate,@DueAmount,@Advance,@status,@CreatedDate)";

            var paramters = _dapper.AddParam(model);
            paramters.Add("CreatedDate", DateTime.Now);
            int affectedRows = _dapper.Execute(sql, paramters);

            if (affectedRows > 0)
                return true;
            else
                return false;

        }

        public bool Delete(PaymentModel model)
        {
            throw new NotImplementedException();
        }

        public bool Edit(PaymentModel model)
        {
            throw new NotImplementedException();
        }

        public int Edit(int id)
        {
            string sql = @"Update Payment set status=1 where TenantId=@id";
            var param = _dapper.AddParam(id);
            int affeectedrows = _dapper.Execute(sql, param);
            if (affeectedrows >= 1)
                return 1;
            else
                return 0;
        }
        public PaymentModel Getdue(int id)
        {
            string sql = @"Select * from Payment where status=0 and TenantID=@Id";
            var param = _dapper.AddParam(id);
            var model = _dapper.Query<PaymentModel>(sql, param).FirstOrDefault();
            return model;
        }

        public PaymentModel GetAdvance(int id)
        {
            string sql = @"select * from Payment where status=2 and TenantId=@Id";
            var param = _dapper.AddParam(id);
            var model = _dapper.Query<PaymentModel>(sql, param).FirstOrDefault();
            return model;
        }

        public PaymentModel GetById(int? id)
        {
            throw new NotImplementedException();
        }


        public List<PaymentModel> GetList()
        {
            throw new NotImplementedException();
        }


    }
}
