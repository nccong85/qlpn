using CommonLib;
using DAL;
using QLPN.DTO;
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
            return _dbcontext.prison_mst.AsNoTracking().ToList();
        }

        public List<prison_mst> GetListForExport(user_mst user)
        {
            var query = (from pm in _dbcontext.prison_mst
                         where String.Equals(user.role, CommonConst.UserRole.ADMIN) || (!String.Equals(user.role, CommonConst.UserRole.ADMIN) && pm.ma_trai_giam == user.dept_cd)
                         select pm);

            return query.ToList();
        }

        public List<PrisonDisplayDto> GetListPrisonToDisplay(user_mst user)
        {
            var query = (from pm in _dbcontext.prison_mst
                          join dm in _dbcontext.division_mst
                          on new { k1 = pm.ma_trai_giam } equals new { k1 = dm.ma_trai }

                          join cm in _dbcontext.code_mst
                          on new { k2 = pm.toi_danh } equals new { k2 = cm.code }
                          where (String.Equals(user.role, CommonConst.UserRole.ADMIN) && cm.category_id == CommonLib.CommonConst.CodeMasterCategoryId.PHAN_LOAI_TOI_DANH)
                          || (!String.Equals(user.role, CommonConst.UserRole.ADMIN) && pm.ma_trai_giam == user.dept_cd && cm.category_id == CommonLib.CommonConst.CodeMasterCategoryId.PHAN_LOAI_TOI_DANH)
                          
                          select new PrisonDisplayDto
                          {
                              id = pm.id,
                              ma_dang_ky = pm.ma_dang_ky,
                              ma_trai_giam = String.Concat(pm.ma_trai_giam, ":", dm.ten_trai),
                              ngay_thang_nam_sinh = pm.ngay_thang_nam_sinh,
                              ho_va_ten = pm.ho_va_ten,
                              ten_goi_khac = pm.ten_goi_khac,
                              gioi_tinh = pm.gioi_tinh == "01" ? "Nam" : "Nữ",
                              que_quan = pm.que_quan,
                              noi_dktt = pm.noi_dktt,
                              toi_danh = cm.value,
                              ngay_bat = pm.ngay_bat,
                              an_phat = pm.an_phat,
                              ngay_nhap_trai = pm.ngay_nhap_trai,
                              ngay_dua_ra = pm.ngay_dua_ra,
                              ly_do_dua_ra = pm.ly_do_dua_ra
                          });

            return query.ToList();
        }

        public List<PrisonDisplayDto> GetListPrisonToDisplay(string divisionCd)
        {
            var initQuery = (from pm in _dbcontext.prison_mst
                             join dm in _dbcontext.division_mst
                             on new { k1 = pm.ma_trai_giam } equals new { k1 = dm.ma_trai }

                             join cm in _dbcontext.code_mst
                             on new { k2 = pm.toi_danh } equals new { k2 = cm.code }

                             where cm.category_id == CommonConst.CodeMasterCategoryId.PHAN_LOAI_TOI_DANH
                             && pm.ma_trai_giam == divisionCd

                             select new PrisonDisplayDto
                             {
                                 id = pm.id,
                                 ma_dang_ky = pm.ma_dang_ky,
                                 ma_trai_giam = String.Concat(pm.ma_trai_giam, ":", dm.ten_trai),
                                 ngay_thang_nam_sinh = pm.ngay_thang_nam_sinh,
                                 ho_va_ten = pm.ho_va_ten,
                                 ten_goi_khac = pm.ten_goi_khac,
                                 gioi_tinh = pm.gioi_tinh == "01" ? "Nam" : "Nữ",
                                 que_quan = pm.que_quan,
                                 noi_dktt = pm.noi_dktt,
                                 toi_danh = cm.value,
                                 ngay_bat = pm.ngay_bat,
                                 an_phat = pm.an_phat,
                                 ngay_nhap_trai = pm.ngay_nhap_trai,
                                 ngay_dua_ra = pm.ngay_dua_ra,
                                 ly_do_dua_ra = pm.ly_do_dua_ra
                             }).ToList();

            return initQuery;
        }

        public void Add(prison_mst addObj)
        {
            _dbcontext.prison_mst.Add(addObj);
            this.Save();
        }

        public void Update(prison_mst updObj)
        {
            _dbcontext.prison_mst.Attach(updObj);
            _dbcontext.Entry(updObj).State = System.Data.Entity.EntityState.Modified;
            this.Save();
        }

        public void Delete(string ma_dang_ky)
        {
            var x = this.GetPrisonById(ma_dang_ky);
            _dbcontext.prison_mst.Attach(x);
            _dbcontext.prison_mst.Remove(x);
            this.Save();
        }

        public prison_mst GetPrisonById(string ma_dang_ky)
        {
            prison_mst prison = (from prisoner in _dbcontext.prison_mst
                                 where prisoner.ma_dang_ky == ma_dang_ky
                                 select prisoner).FirstOrDefault();

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

            string incrementCode = (Int32.Parse(list.ma_dang_ky.Substring(4, 4)) + 1).ToString();
            return incrementCode;
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

        public List<PrisonDisplayDto> SearchPrison(SearchDto search, user_mst user)
        {
            var result = this.GetListPrisonToDisplay(user);

            if (!String.IsNullOrEmpty(search.MaDangKy))
            {
                result = result.Where(p => p.ma_dang_ky.Contains(search.MaDangKy)).ToList();
            }

            if (!String.IsNullOrEmpty(search.TenPhamNhan))
            {
                result = result.Where(p => p.ho_va_ten.Contains(search.TenPhamNhan)).ToList();
            }

            if (!String.IsNullOrEmpty(search.MaTraiGiam))
            {
                result = result.Where(p => p.ma_trai_giam.Contains(search.MaTraiGiam)).ToList();
            }


            return result;
        }
    }
}
