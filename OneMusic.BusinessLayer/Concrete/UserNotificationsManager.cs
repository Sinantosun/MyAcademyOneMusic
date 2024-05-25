using OneMusic.BusinessLayer.Abstract;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Concrete
{
    public class UserNotificationsManager : IUserNotificationsService
    {
        private readonly IUserNotificationsDal _userNotifications;

        public UserNotificationsManager(IUserNotificationsDal userNotifications)
        {
            _userNotifications = userNotifications;
        }

        public void TCreate(UserNotifications entity)
        {
            _userNotifications.Create(entity);
        }

        public void TDelete(int id)
        {
            _userNotifications.Delete(id);
        }

        public UserNotifications TGetById(int id)
        {
            return _userNotifications.GetById(id);
        }

        public List<UserNotifications> TGetList()
        {
            return _userNotifications.GetList();
        }

        public void TUpdate(UserNotifications entity)
        {
            _userNotifications.Update(entity);
        }
    }
}
