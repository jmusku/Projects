

using System.Data.Entity;

namespace EmployeePortal.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("EmployeeDb")
        {
        }
        public DbSet<EmployeeModel> Employees { get; set; }       
    }
}