//using RMS.Models;
//using RMS.Repository.Payment;
//using RMS.Service.SetUp;

//namespace RMS.Service.Payment
//{
//    public interface IPaymentServices : IGenericService<PaymentModel>
//    {
//        PaymentModel CheckAdvance(PaymentModel model , int Advance);
//        PaymentModel CheckDue(PaymentModel model , int Due);
//        PaymentModel CalculateDueAndAdvance(RentSetupModel rentSetUpModel, PaymentModel model, bool CheckPayment);
//    }
//    public class PaymentServices : IPaymentServices
//    {
//        //private readonly IPaymentRepository repo;
//        private readonly IRentSetupService rentSer;

//        public PaymentServices()
//        {
//            //repo = new PaymentRepository();
//            rentSer = new RentSetupService();
//        }

//        public PaymentModel CalculateDueAndAdvance(RentSetupModel rentSetUpModel, PaymentModel model, bool CheckPayment)
//        {
//            if (CheckPayment)
//            {

//                if (model.PaidAmount == rentSetUpModel.Amount)
//                {
//                    model.DueAmount = 0;
//                    model.Advance = 0;
//                    model.Status = 1;
//                }

//                if (model.PaidAmount > rentSetUpModel.Amount)
//                {
//                    model.DueAmount = 0;
//                    model.Advance = model.PaidAmount - rentSetUpModel.Amount;
//                    model.Status = 2;
//                }

//                if (model.PaidAmount < rentSetUpModel.Amount)
//                {
//                    model.DueAmount = rentSetUpModel.Amount - model.PaidAmount;
//                    model.Advance = 0;
//                    model.Status = 0;
//                }
//            }
//            else
//            {
//                var Amount = model.PaidAmount - model.DueAmount;

//                if (Amount == 0)
//                {
//                    model.DueAmount = Amount;
//                    model.Advance = 0;
//                    model.Status = 1;
//                }
//                else if (Amount > 0)
//                {
//                    model.DueAmount = 0;
//                    model.Advance = Amount;
//                    model.Status = 2;
//                }

//                else
//                {
//                    model.DueAmount = Math.Abs(Amount ?? 0);
//                    model.Advance = 0;
//                    model.Status = 0;
//                }
//                repo.Edit(model.TenantId);

//            }

//            return model;
//        }

//        public PaymentModel CheckAdvance(PaymentModel model , int Advance)
//        {
//            if (model.Advance == 0 && model.DueAmount == 0)
//            {
//                model.Advance = Advance;
//                model.Status = 2;
//            }

//            else if (model.Advance == 0 && model.DueAmount > 0)
//            {
//                var amount = Advance - model.DueAmount;
//                if (amount < 0)
//                {
//                    model.DueAmount = Math.Abs(amount ?? 0);
//                    model.Status = 0;
//                }
//                else if(amount == 0)
//                {
//                    model.Advance = 0;
//                    model.DueAmount = 0;
//                    model.Status = 1;
//                }
//                else
//                {

//                    model.Advance = amount;
//                    model.DueAmount = 0;
//                    model.Status = 2;
//                }

                
//            }

//            else
//            {
//                model.Advance = model.Advance + Advance;
//                model.Status = 2;
//            }
//            repo.Edit(model.TenantId);
//            return model;
//        }

//        public PaymentModel CheckDue(PaymentModel model, int Due)
//        {
//            if (model.DueAmount == 0 && model.Advance == 0)
//            {
//                model.DueAmount = Due;
//                model.Status = 0;
//            }
//            else if (model.Advance == 0 && model.DueAmount > 0)
//            {
//                model.DueAmount = Due + model.DueAmount;
//                model.Status = 0;
//            }
//            else
//            {
//                var amount = model.Advance - Due;
//                if(amount==0)
//                {
//                    model.DueAmount = 0;
//                    model.Advance = 0;
//                    model.Status = 1;
//                }
//                else if(amount>0)
//                {
//                    model.Advance = amount;
//                    model.DueAmount = 0;
//                    model.Status = 2;
//                }

//                else
//                {
//                    model.DueAmount = Math.Abs(amount ?? 0);
//                    model.Advance = 0;
//                    model.Status = 0;
//                }
//            }
//                repo.Edit(model.TenantId);
//                return model;
//        }
        

//        public PaymentModel Create(PaymentModel model)
//        {
//            bool flag = false;
//            var rentSetupModel = rentSer.GetByFloorId(model.FloorId);
//            var dueModel = repo.Getdue(model.TenantId);
//            var advanceModel = repo.GetAdvance(model.TenantId);

//            //var calculatedModel = new PaymentModel();
//            if ((dueModel == null) && (advanceModel==null) )
//            {
//                flag = true;
//                model = CalculateDueAndAdvance(rentSetupModel,model, flag);
//            }
//            else if(advanceModel==null)
//            {

//                model.DueAmount = dueModel.DueAmount;
//                if(dueModel.PaymentDate.Month==model.PaymentDate.Month)
//                {
//                    model = CalculateDueAndAdvance(rentSetupModel, model, flag);
//                }

//                if(dueModel.PaymentDate.Month < model.PaymentDate.Month)
//                {
//                     var Due = dueModel.DueAmount;
//                     model = CalculateDueAndAdvance(rentSetupModel, model,true);
//                     var Calculatedmodel = CheckDue(model,Convert.ToInt32(Due));
//                     model.DueAmount = Calculatedmodel.DueAmount;
//                     model.Advance = Calculatedmodel.Advance;
//                     model.Status = Calculatedmodel.Status;
//                }

//                if(dueModel.PaymentDate.Year < model.PaymentDate.Year)
//                {
//                    var Due = dueModel.DueAmount;
//                    model = CalculateDueAndAdvance(rentSetupModel, model, true);
//                    var Calculatedmodel = CheckDue(model, Convert.ToInt32(Due));
//                    model.DueAmount = Calculatedmodel.DueAmount;
//                    model.Advance = Calculatedmodel.Advance;
//                    model.Status = Calculatedmodel.Status;
//                }
                
//            }

//            else
//            {
//                var Advance = advanceModel.Advance;
//                if(advanceModel.PaymentDate.Month == model.PaymentDate.Month)
//                {
//                    model.Advance = advanceModel.Advance + model.PaidAmount;
//                    model.DueAmount = 0;
//                    model.Status = 2;
//                    repo.Edit(model.TenantId);
//                }
//               if( advanceModel.PaymentDate.Month < model.PaymentDate.Month) 
//                {
                    
//                    model = CalculateDueAndAdvance(rentSetupModel, model, true);
//                    var calculateModel = CheckAdvance(model, Convert.ToInt32(Advance));
//                    model.Advance = calculateModel.Advance;
//                    model.DueAmount = calculateModel.DueAmount;
//                    model.Status = calculateModel.Status;
                    
//                }
//               if(advanceModel.PaymentDate.Year < model.PaymentDate.Year)
//                {
//                    model = CalculateDueAndAdvance(rentSetupModel, model, true);
//                    var calculateModel = CheckAdvance(model, Convert.ToInt32(Advance));
//                    model.Advance = calculateModel.Advance;
//                    model.DueAmount = calculateModel.DueAmount;
//                    model.Status = calculateModel.Status;
//                }
//            }

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

//        public PaymentModel Delete(PaymentModel model)
//        {
//            throw new NotImplementedException();
//        }

//        public PaymentModel Edit(PaymentModel model)
//        {
//            throw new NotImplementedException();
//        }

//        public PaymentModel GetById(int? id)
//        {
//            throw new NotImplementedException();
//        }

//        public List<PaymentModel> GetList()
//        {
//            return (repo.GetList());
//        }


//    }

//}
