using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;

namespace master.DAL.Repository
{
    public class masterMinorHeadRepository : Repository<MinorHead, MasterManagementDBContext>, ImasterMinorHeadRepository
    {
        MasterManagementDBContext _mContext;
        public masterMinorHeadRepository(MasterManagementDBContext context) : base(context)
        {
            _mContext = context;
        }
    }
}
