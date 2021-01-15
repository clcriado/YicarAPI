using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Jefe
    {
        public int Id { get; set; }
        public int Idusuario { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
