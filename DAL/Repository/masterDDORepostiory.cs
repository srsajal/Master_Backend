using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;

namespace master.DAL.Repository
{
    public class masterDDORepostiory : Repository<Ddo, MasterManagementDBContext>, ImasterDDORepository
    {
        MasterManagementDBContext _mContext;
        public masterDDORepostiory(MasterManagementDBContext context) : base(context)
        {
            _mContext = context;
        }
    }
}
