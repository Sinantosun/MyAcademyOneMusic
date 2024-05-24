using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Abstract
{
    public interface IAlbumDal:IGenericDal<Album>
    {
        List<Album> getAlbumByArtist(int id);

        List<Album> getAlbumListWithArtist();

        int AlbumCount(int id);
        int AlbumCountByWaiting(int id);
        string ExpensiveAlbumName(int id);

    }
}
