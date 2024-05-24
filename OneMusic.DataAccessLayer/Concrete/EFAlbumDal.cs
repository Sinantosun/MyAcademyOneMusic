using Microsoft.EntityFrameworkCore;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.DataAccessLayer.Context;
using OneMusic.DataAccessLayer.Repositories;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.DataAccessLayer.Concrete
{
    public class EFAlbumDal : GenericRepository<Album>, IAlbumDal
    {
        private readonly OneMusicContext _context;
        public EFAlbumDal(OneMusicContext context) : base(context)
        {
            _context = context;
        }

        public int AlbumCount(int id)
        {
            return _context.Albums.Where(x => x.IsVerify == true && x.AppUserId == id).Count();
        }

        public int AlbumCountByWaiting(int id)
        {
            return _context.Albums.Where(x => x.VerifyDescription == "Onay Aşamasında" && x.AppUserId == id).Count();
        }

        public string ExpensiveAlbumName(int id)
        {
            return _context.Albums.Where(x => x.AppUserId == id && x.Price == _context.Albums.Max(y => y.Price)).Select(t => t.AlbumName).FirstOrDefault();
        }

        public List<Album> getAlbumByArtist(int id)
        {
            return _context.Albums.Include(y => y.AppUser).Where(x => x.AppUserId == id && x.IsVerify == true).ToList();
        }

        public List<Album> getAlbumListWithArtist()
        {
            return _context.Albums.Include(x => x.AppUser).ToList();
        }
    }
}
