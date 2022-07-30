using Account.Domain.Common;

namespace Account.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
