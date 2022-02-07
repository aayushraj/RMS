//using RMS.Models;

//namespace RMS.Repository.Payment
//{
//    public interface IPaymentRepository:IGenericRepository<PaymentModel>
//    {
//         PaymentModel Getdue(int id);
//         PaymentModel GetAdvance(int id);  
//         int Edit(int id);
//    }
//    public class PaymentRepository : IPaymentRepository
//    {
//        private readonly SetupRepository setupRepo;
//        public PaymentRepository()
//        {
//            setupRepo = new SetupRepository();
//        }
//        public bool Create(PaymentModel model)
//        {
//            string sql = @"Insert into Payment values(@TenantID,@FloorId,@PaidAmount,@PaymentDate,@DueAmount,@Advance,@status,@CreatedDate)";

//            var paramters = DapperService.AddParam(model);
//            paramters.Add("CreatedDate", DateTime.Now);
//            int affectedRows = DapperService.Execute(sql, paramters);
            
//            if (affectedRows > 0)
//                return true;
//            else
//                return false;
            
//        }

//        public bool Delete(PaymentModel model)
//        {
//            throw new NotImplementedException();
//        }

//        public bool Edit(PaymentModel model)
//        {
//            throw new NotImplementedException();
//        }

//        public int Edit(int id)
//        {
//            string sql = @"Update Payment set status=1 where TenantId=@id";
//            var param = DapperService.AddParam(id);
//            int affeectedrows =DapperService.Execute(sql, param);
//            if (affeectedrows >= 1)
//                return 1;
//            else
//                return 0;
//        }
//        public PaymentModel Getdue(int id)
//        {
//            string sql = @"Select * from Payment where status=0 and TenantID=@Id";
//            var param = DapperService.AddParam(id);
//            var model = DapperService.Query<PaymentModel>(sql, param).FirstOrDefault();
//            return model;
//        }

//        public PaymentModel GetAdvance(int id)
//        {
//            string sql = @"select * from Payment where status=2 and TenantId=@Id";
//            var param = DapperService.AddParam(id);
//            var model = DapperService.Query<PaymentModel>(sql, param).FirstOrDefault();
//            return model;
//        }

//        public PaymentModel GetById(int? id)
//        {
//            throw new NotImplementedException();
//        }


//        public List<PaymentModel> GetList()
//        {
//            throw new NotImplementedException();
//        }

       
//    }
//}
