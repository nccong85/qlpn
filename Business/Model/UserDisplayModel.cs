using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class UserDisplayModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string DepartmentCd { get; set; }
        public string DepartmentName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
}
