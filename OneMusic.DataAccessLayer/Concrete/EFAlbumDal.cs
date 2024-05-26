﻿using Microsoft.EntityFrameworkCore;
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
            return _context.Albums.OrderByDescending(x => x.Price).Where(x => x.IsVerify == true && x.AppUserId == id).Select(y => y.AlbumName).FirstOrDefault();
        }

        public List<Album> getAlbumByArtist(int id)
        {
            return _context.Albums.Include(y => y.AppUser).Where(x => x.AppUserId == id && x.IsVerify == true).ToList();
        }


        public List<Album> getAlbumListWithArtist()
        {
            return _context.Albums.Include(x => x.AppUser).Where(x => x.IsVerify == true).ToList();
        }

        public List<Album> getListAwatingApprovalAlbums()
        {
            return _context.Albums.Where(x => x.VerifyDescription != "Onaylandı").ToList();
        }

        public List<Album> getAlbumWithArtistByStatusFalseList()
        {
            return _context.Albums.Include(x => x.AppUser).Where(x => x.IsVerify == false && x.VerifyDescription == "Onay Aşamasında").ToList();
        }
        public List<Album> getAlbumWithArtistRejectLists()
        {
            return _context.Albums.Include(x => x.AppUser).Where(x => x.IsVerify == false && x.VerifyDescription != "Onay Aşamasında" && x.VerifyDescription != "Onaylandı").ToList();
        }

        public List<Album> getRandomAlbumWithArtist()
        {
            return _context.Albums.OrderByDescending(x => Guid.NewGuid()).Include(y => y.AppUser).Where(x => x.IsVerify == true).Take(4).ToList();
        }
    }
}
