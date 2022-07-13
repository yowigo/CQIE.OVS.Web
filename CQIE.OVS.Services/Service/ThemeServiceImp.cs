using CQIE.OVS.DataAccess.Database;
using CQIE.OVS.Models;
using CQIE.OVS.Models.ViewModel;
using CQIE.OVS.Repository.IRepository;
using CQIE.OVS.Services.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.OVS.Services.Service
{
    public class ThemeServiceImp : BaseServiceImp<Theme>, IThemeService
    {
        private readonly OVSDbContext _context;
        public ThemeServiceImp(IBaseRepository<Theme> iBaseRepository, OVSDbContext context)
            : base(iBaseRepository)
        {
            _context = context;
        }

        /// <summary>
        /// 通过主题Id查找主题-歌手信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Theme> GetThemeSinger(int id)
        {
            var value= await _context.Themes.Include(b => b.Theme_Singers).ThenInclude(b => b.Singer)
                        .Where(b=>b.Id==id)
                        .FirstOrDefaultAsync();
            return value;
        }

        public async Task<List<Theme>> GetListSingerByTheme()
        {
            var value = await _context.Themes.Include(b => b.Theme_Singers).ThenInclude(b => b.Singer)
                .ToListAsync();
            return value;
        }

        //新增Theme_Singer关系表
        public async Task<bool> AddThemeSinger(Theme_Singer theme_Singer)
        {
            _context.Add(theme_Singer);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 获取比赛中的歌手的票数
        /// </summary>
        /// <param name="GameId"></param>
        /// <returns></returns>
        public IEnumerable<SingerNumberView> GetVoteNumByTheme(int themeId)
        {
            var result = _context.Theme_Singers.Include(c => c.Theme).Include(c => c.Singer).Where(c => c.Id == themeId);
            //返回歌手与票数
            var list = new List<SingerNumberView>();
            foreach (var item in result)
            {
                list.Add(new SingerNumberView()
                {
                    SingerName = item.Singer.Name,
                    SingerVoteNum = item.VoteNum
                });
            }
            return list;
        }
    }
}
