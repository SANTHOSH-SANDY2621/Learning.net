using Learning.NetCore.Models;

namespace Learning.NetCore.Repo.IRepo
{
    public interface IEmployeeRepo
    {
        public Task<List<Employees1>> GetEmployeesAsync();
        public Task<Employees1> GetEmployeebyId(long id);        
    }
}
