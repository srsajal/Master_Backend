using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace master.DAL.Repository
{
    public class masterDepartmentRepository : Repository<Department, MasterManagementDBContext>, ImasterDepartmentRepository
    {
        MasterManagementDBContext _dContext;
        public masterDepartmentRepository(MasterManagementDBContext context) : base(context)
        {
            _dContext = context;
        }
    }
}
