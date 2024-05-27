﻿using OneMusic.BusinessLayer.Abstract;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Concrete
{
    public class AlbumManager : IAlbumService
    {
        private readonly IAlbumDal _albumDal;

        public AlbumManager(IAlbumDal albumDal)
        {
            _albumDal = albumDal;
        }

        public int TAlbumCount(int id)
        {
           return _albumDal.AlbumCount(id);
        }

        public int TAlbumCountByWaiting(int id)
        {
            return _albumDal.AlbumCountByWaiting(id);
        }

        public void TCreate(Album entity)
        {
            _albumDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _albumDal.Delete(id);
        }

        public string TExpensiveAlbumName(int id)
        {
            return _albumDal.ExpensiveAlbumName(id);
        }

        public List<Album> TgetAlbumByArtist(int id)
        {
            return _albumDal.getAlbumByArtist(id);
        }

        public Album TgetAlbumByIDWithAppUser(int id)
        {
            return _albumDal.getAlbumByIDWithAppUser(id);
        }

        public List<Album> TgetAlbumListWithArtist()
        {
            return _albumDal.getAlbumListWithArtist();
        }

        public List<Album> TgetAlbumWithArtistByStatusFalseList()
        {
            return _albumDal.getAlbumWithArtistByStatusFalseList();
        }

        public List<Album> TgetAlbumWithArtistRejectLists()
        {
            return _albumDal.getAlbumWithArtistRejectLists();
        }

        public Album TGetById(int id)
        {
            return _albumDal.GetById(id);
        }

        public List<Album> TGetList()
        {
            return _albumDal.GetList();
        }

        public List<Album> TgetListAwatingApprovalAlbums()
        {
            return _albumDal.getListAwatingApprovalAlbums();
        }

        public List<Album> TgetRandomAlbumWithArtist()
        {
            return _albumDal.getRandomAlbumWithArtist();
        }

        public void TUpdate(Album entity)
        {
            _albumDal.Update(entity);
        }
    }
}
