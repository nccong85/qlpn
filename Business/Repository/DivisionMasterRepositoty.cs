using CommonLib.Model.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class DivisionMasterRepositoty
    {
        private readonly Entities _dbcontext;

        public DivisionMasterRepositoty(Entities dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<division_mst> GetList()
        {
            return _dbcontext.division_mst.ToList();
        }

        public List<ListItemEx> GetListWithCode()
        {
            List<ListItemEx> results = new List<ListItemEx>();
            var items = this.GetList();
            foreach (var item in items)
            {
                var cmbItem = new ListItemEx();
                cmbItem.Value = item.ma_trai;
                cmbItem.Text = item.ma_trai + ":" + item.ten_trai;
                results.Add(cmbItem);
            }

            return results;
        }
    }
}
