using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class PrisonRepository
    {
        private readonly Entities _dbcontext;

        public PrisonRepository(Entities dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<prison_mst> GetList()
        {
            return _dbcontext.prison_mst.ToList();
        }

        public void Add(prison_mst addObj)
        {
            _dbcontext.prison_mst.Add(addObj);
            _dbcontext.SaveChanges();
        }

        public void Update(prison_mst updObj)
        {
            _dbcontext.prison_mst.Attach(updObj);
            _dbcontext.Entry(updObj).State = System.Data.Entity.EntityState.Modified;
            _dbcontext.SaveChanges();
        }

        public void Delete(string ma_dang_ky)
        {
            var x = new prison_mst { ma_dang_ky = ma_dang_ky };
            _dbcontext.prison_mst.Attach(x);
            _dbcontext.prison_mst.Remove(x);
            _dbcontext.SaveChanges();
        }

        public prison_mst GetPrisonById(string ma_dang_ky)
        {
            prison_mst prison = (from prisoner in _dbcontext.prison_mst
                                 where prisoner.ma_dang_ky == ma_dang_ky
                                 select prisoner).SingleOrDefault();

            return prison;
        }
        public bool IsExist(string ma_dang_ky)
        {
            bool isExist = (from prison in _dbcontext.prison_mst
                            where prison.ma_dang_ky == ma_dang_ky
                            select prison).Any();

            return isExist;
        }

        public string GetIcrementCodeForDummy()
        {
            prison_mst list = (from prison in _dbcontext.prison_mst
                                     where prison.ma_trai_giam == "0VLB0002"
                                     orderby prison.ngay_tao descending
                                     select prison).FirstOrDefault();

            string incrementCode = (Int32.Parse(list.ma_dang_ky.Substring(4,4)) + 1).ToString() ;
            return incrementCode;
        }
    }
}
