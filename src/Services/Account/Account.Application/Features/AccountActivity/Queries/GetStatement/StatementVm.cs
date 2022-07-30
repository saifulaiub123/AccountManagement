using System;

namespace Account.Application.Features.AccountActivity.Queries.GetStatement
{
    public class StatementVm
    {
        public  int Id { get; set; }

        public int Amount { get; set; }
        public int Balance { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
