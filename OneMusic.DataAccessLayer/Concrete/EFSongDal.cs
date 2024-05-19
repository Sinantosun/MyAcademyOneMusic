using Microsoft.EntityFrameworkCore;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.DataAccessLayer.Context;
using OneMusic.DataAccessLayer.Repositories;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Concrete
{
    public class EFSongDal : GenericRepository<Song>, ISongDal
    {
        public EFSongDal(OneMusicContext context) : base(context)
        {
        }

        public List<Song> getRandomSingerWithRelationShip()
        {
            var context = new OneMusicContext();
            var result = context.Songs.OrderBy(x => Guid.NewGuid()).Include(x => x.Album).Take(5).ToList();
            return result;
        }
    }
}
