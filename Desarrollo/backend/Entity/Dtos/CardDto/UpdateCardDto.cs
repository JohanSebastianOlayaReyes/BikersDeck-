using Entity.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Client
{
    public class UpdateCard : BaseDto
    {
        public string Name { get; set; }
        public int Displacement { get; set; }
        public decimal power { get; set; }
        public decimal Torque { get; set; }
        public int speed { get; set; }
        public int model { get; set; }
        public int CylinderNumber { get; set; }
    }
}