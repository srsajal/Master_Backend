using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;
using MasterManegmentSystem.DAL.IRepository;

namespace master.DAL.Repository
{
    public class mastersubmajorheadRepository : Repository<SubMajorHead, MasterManagementDBContext>, ImastersubmajorheadRepository
    {
        MasterManagementDBContext _mContext;
        public mastersubmajorheadRepository(MasterManagementDBContext context) : base(context)
        {
            _mContext = context;
        }

    
    }
}
