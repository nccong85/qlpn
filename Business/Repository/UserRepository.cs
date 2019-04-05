using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class UserRepository
    {
        private readonly Entities _dbcontext;

        public UserRepository(Entities dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<user_mst> GetList()
        {
            return _dbcontext.user_mst.AsNoTracking().ToList();
        }

        public void Add(user_mst addObj)
        {
            _dbcontext.user_mst.Add(addObj);
            this.Save();
        }

        public void Update(user_mst updObj)
        {
            _dbcontext.user_mst.Attach(updObj);
            _dbcontext.Entry(updObj).State = System.Data.Entity.EntityState.Modified;
            this.Save();
        }

        public void Delete(string username)
        {
            var x = this.GetUserByUsername(username);
            _dbcontext.user_mst.Attach(x);
            _dbcontext.user_mst.Remove(x);
            this.Save();
        }

        public user_mst GetUserByUsername(string username)
        {
            user_mst user = (from users in _dbcontext.user_mst
                                 where users.username == username
                                 select users).SingleOrDefault();

            return user;
        }
        public bool IsExist(string username)
        {
            bool isExist = (from user in _dbcontext.user_mst
                            where user.username == username
                            select user).Any();

            return isExist;
        }

        public bool IsAuthenticate(string username, string pass)
        {
            bool isAuthenticate = (from user in _dbcontext.user_mst
                                   where user.username == username
                                   && user.password == pass
                                   select user).Any();
            return isAuthenticate;
        }

        private void Save()
        {
            try
            {
                _dbcontext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = String.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
    }
}
