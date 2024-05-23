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

        public List<Album> getAlbumByArtist(int id)
        {
            return _context.Albums.Include(y => y.AppUser).Where(x => x.AppUserId == id).ToList();
        }

        public List<Album> getAlbumListWithArtist()
        {
            return _context.Albums.Include(x => x.AppUser).ToList();
        }
    }
}
