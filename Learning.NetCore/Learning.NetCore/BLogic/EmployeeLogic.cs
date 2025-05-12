using Learning.NetCore.BLogic.IBLogic;
using Learning.NetCore.Models;
using Learning.NetCore.Repo.IRepo;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Learning.NetCore.BLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeLogic(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        public async Task<List<Employees1>> GetEmployeesAsync()
        {
            return await employeeRepo.GetEmployeesAsync();
        }

        public async Task<Employees1> GetEmployeebyId(long id)
        {
            return await employeeRepo.GetEmployeebyId(id);
        }
    }
}
