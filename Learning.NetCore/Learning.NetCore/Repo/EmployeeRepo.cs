using Learning.NetCore.Models;
using Learning.NetCore.Repo.IRepo;
using Microsoft.EntityFrameworkCore;
namespace Learning.NetCore.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext dbContext;

        public EmployeeRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Employees1>> GetEmployeesAsync()
        {            
            try
            {
                List<Employees1> employees = dbContext.Employee.ToList();                  
                return employees;                           
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.InnerException?.ToString());
            }            
        }

        public async Task<Employees1> GetEmployeebyId(long id)
        {
            try
            {
               Employees1 employees = dbContext.Employee.Where(x=>x.Id == id).FirstOrDefault();
               return employees;
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.InnerException?.ToString());
            }
        }
    }
}
