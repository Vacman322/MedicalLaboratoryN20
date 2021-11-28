using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratoryN20.EF
{
    public static class Db
    {
        public static MedicalLaboratoryN20Entities Context { get; } = new MedicalLaboratoryN20Entities();
    }
}
