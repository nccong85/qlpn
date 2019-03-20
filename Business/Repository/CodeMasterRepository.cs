using CommonLib.Model.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CodeMasterRepository
    {
        private readonly Entities _dbcontext;

        public CodeMasterRepository(Entities dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<code_mst> GetList()
        {
            return _dbcontext.code_mst.ToList();
        }

        public List<code_mst> GetListByCategoryId(string categoryId)
        {
            return GetList().Where(x => x.category_id == categoryId).ToList();
        }

        public List<ListItemEx> GetListItemExByCategoryId(string categoryId)
        {
            List<ListItemEx> results = new List<ListItemEx>();
            var items = this.GetListByCategoryId(categoryId);
            foreach(var item in items)
            {
                var cmbItem = new ListItemEx();
                cmbItem.Value = item.code;
                cmbItem.Text = item.code + ":" + item.value;
                results.Add(cmbItem);
            }

            return results;
        }

        public List<ListItem> GetListItemByCategoryId(string categoryId)
        {
            List<ListItem> results = new List<ListItem>();
            var items = this.GetListByCategoryId(categoryId);
            foreach (var item in items)
            {
                var cmbItem = new ListItem();
                cmbItem.Value = item.code;
                cmbItem.Text =  item.value;
                results.Add(cmbItem);
            }

            return results;
        }

    }
}
