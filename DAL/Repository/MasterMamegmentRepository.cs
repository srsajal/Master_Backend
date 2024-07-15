
using master.DAL.DBContext;
using master.DAL.Entity;
using master.DAL.Repository;
using MasterManegmentSystem.DAL.IRepository;
using MasterManegmentSystem.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MasterManegmentSystem.DAL.Repository
{
    public class MasterMamegmentRepository  : Repository<MajorHead, MasterManagementDBContext>, IMasterManegmentRepository
    {
        MasterManagementDBContext _mContext;
        public MasterMamegmentRepository(MasterManagementDBContext context) : base(context)
        {
            _mContext = context;
        }

        
    }
}