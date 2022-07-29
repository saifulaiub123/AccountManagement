using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features.AccountActivity.Queries.GetStatement
{
    public class StatementVm
    {
        public  int Id { get; set; }

        public int TransactionAmount { get; set; }
        public int Balance { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
