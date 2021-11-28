using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalLaboratoryN20.EF;

namespace MedicalLaboratoryN20.Util
{
    public static class AppData
    {
        public static User LoginUser { get; set; }
        public static DateTime EnableLoginDate { get; set; } = new DateTime(1, 1, 1);
    }
}
