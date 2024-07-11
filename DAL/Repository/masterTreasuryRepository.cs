using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;

namespace master.DAL.Repository
{
    public class masterTreasuryRepository : Repository<Treasury, MasterManagementDBContext>, ImasterTreasuryRepository
    {
        MasterManagementDBContext _mContext;
        public masterTreasuryRepository(MasterManagementDBContext context) : base(context)
        {
            _mContext = context;
        }
    }
}
