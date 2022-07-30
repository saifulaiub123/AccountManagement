using System;

namespace Account.Application.Model
{
    public class Statement
    {
        public int Id { get; set; }

        public int Amount { get; set; }
        public int Balance { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
