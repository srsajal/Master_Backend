using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;

namespace master.DAL.Repository
{
    public class masterSubDetailHeadRepository : Repository<SubDetailHead, MasterManagementDBContext>, ImasterSubDetailHeadRepository
    {
        MasterManagementDBContext _mContext;
        public masterSubDetailHeadRepository(MasterManagementDBContext context) : base(context)
        {
            _mContext = context;
        }
    }
}
