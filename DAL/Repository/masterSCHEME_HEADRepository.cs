using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.IRepository;

namespace master.DAL.Repository
{
    public class masterSCHEME_HEADRepository : Repository<SchemeHead, MasterManagementDBContext>, ImasterSCHEME_HEADRepository
    {
        MasterManagementDBContext _mContext;
        public masterSCHEME_HEADRepository(MasterManagementDBContext context) : base(context)
        {
            _mContext = context;
        }

    }
}
