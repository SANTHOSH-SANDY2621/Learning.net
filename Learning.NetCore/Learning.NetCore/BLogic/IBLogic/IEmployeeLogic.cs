using Learning.NetCore.Models;

namespace Learning.NetCore.BLogic.IBLogic
{
    public interface IEmployeeLogic
    {
        public Task<List<Employees1>> GetEmployeesAsync();
        public Task<Employees1> GetEmployeebyId(long id);
    }
}
