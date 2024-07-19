using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;

namespace master.DAL.Repository
{
    public class masterDetailHeadRepository : Repository<DetailHead, MasterManagementDBContext>, ImasterDetailHeadRepository
    {
        MasterManagementDBContext _mContext;
        public masterDetailHeadRepository(MasterManagementDBContext context) : base(context)
        {
            _mContext = context;
        }
    }
}
