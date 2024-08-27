using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class TransactionRepositoryImp : GenericRepositoryImp<Transactions>, ITransactionRepository
    {
        public TransactionRepositoryImp(AppDBContext context) : base(context)
        {
        }
    }
}
