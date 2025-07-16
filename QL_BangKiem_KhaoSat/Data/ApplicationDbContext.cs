using Microsoft.EntityFrameworkCore;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
     
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<VaiTroEntity> VaiTros { get; set; }
        public DbSet<LichSuDuyetEntity> LichSuDuyets { get; set; }
        public DbSet<BangKiemEntity> BangKiemEntities { get; set; }
        public DbSet<BangKiemStepResult> BangKiemStepResults { get; set; }
        public DbSet<BangKiemSubStepResult> BangKiemSubStepResults { get; set; }
        public DbSet<StepEntity> StepEntities { get; set; }
        public DbSet<KhoaEntity> Khoas { get; set; }
        public DbSet<BangKiemDanhGia> BangKiemDanhGias { get; set; }

    }
}
