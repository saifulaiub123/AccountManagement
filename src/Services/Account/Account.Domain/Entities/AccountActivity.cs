using Account.Domain.Common;

namespace Account.Domain.Entities
{
    public class AccountActivity : BaseEntity
    {
        public int TransactionAmount { get; set; }
        public int Balance { get; set; }
        public int UserId { get; set; }
    }
}
