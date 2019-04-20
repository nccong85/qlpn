using Business.DTO;
using Business.Model;
using CommonLib;
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
        private const string ADMIN_ROLE = "Quản trị";
        private const string NORMAL_ROLE = "Người dùng thường";
        private const string ENABLE = "Có hiệu lực";
        private const string DISABLE = "Không hiệu lực";

        private readonly Entities _dbcontext;

        public UserRepository(Entities dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<user_mst> GetList()
        {
            return _dbcontext.user_mst.AsNoTracking().ToList();
        }

        public List<UserDisplayModel> GetList(user_mst user)
        {
            var query = (from um in _dbcontext.user_mst
                         where (String.Equals(user.role, CommonConst.UserRole.ADMIN) ||
                         (!String.Equals(user.role, CommonConst.UserRole.ADMIN) && um.dept_cd == user.dept_cd  && um.role != CommonConst.UserRole.ADMIN))
                         select new UserDisplayModel
                         {
                             Id = um.id,
                             Username = um.username,
                             Name = um.name,
                             DepartmentCd = um.dept_cd,
                             DepartmentName = um.dept_name,
                             Role = String.Equals(um.role,CommonConst.UserRole.ADMIN) ? ADMIN_ROLE : NORMAL_ROLE,
                             Status = String.Equals(um.status, CommonConst.UserStatus.ENABLE) ? ENABLE : DISABLE
                         });

            return query.ToList();
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

        public user_mst GetUserById(int id)
        {
            user_mst user = (from users in _dbcontext.user_mst
                             where users.id == id
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
                                   && user.status == CommonConst.UserStatus.ENABLE
                                   select user).Any();
            return isAuthenticate;
        }

        public List<UserDisplayModel> SearchUser(UserSearchDto search, user_mst user)
        {
            var result = this.GetList(user);

            if (!String.IsNullOrEmpty(search.username))
            {
                result = result.Where(p => p.Username.Contains(search.username)).ToList();
            }

            if (!String.IsNullOrEmpty(search.name))
            {
                result = result.Where(p => p.Name.Contains(search.name)).ToList();
            }

            if (!String.IsNullOrEmpty(search.dept_cd))
            {
                result = result.Where(p => p.DepartmentCd.Contains(search.dept_cd)).ToList();
            }

            return result;
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
