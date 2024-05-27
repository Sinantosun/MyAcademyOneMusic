using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Abstract
{
    public interface IAlbumService : IGenericService<Album>
    {
        List<Album> TgetAlbumByArtist(int id);
        List<Album> TgetAlbumListWithArtist();
        int TAlbumCount(int id);
        int TAlbumCountByWaiting(int id);
        string TExpensiveAlbumName(int id);

        Album TgetAlbumByIDWithAppUser(int id);

        List<Album> TgetAlbumWithArtistByStatusFalseList();
        List<Album> TgetAlbumWithArtistRejectLists();
        List<Album> TgetListAwatingApprovalAlbums();
        List<Album> TgetRandomAlbumWithArtist();

    }
}
