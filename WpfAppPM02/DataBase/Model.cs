using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace WpfAppPM02.DataBase
{
    #region Специалист
    public partial class Spec
    {
        public string TextStatus
        {
            get
            {
                return (bool)Status ? "Да" : "Нет";
            }
        }
        public override string ToString()
        {
            return Login;
        }

        public string AllOrder
        {
            get
            {
                using (MyModel db = new MyModel())
                {
                   int a= db.Quire.Include(q => q.Spec).Where(q => q.SpecId==this.IdSpec && q.Status==2).Count();
                    return a.ToString();
                }
            }
        }

        public string MounthOrder
        {
            get
            {
                using (MyModel db = new MyModel())
                {
                    DateTime dt = new DateTime();
                    dt = DateTime.Now;
                   dt= dt.AddMonths(-1);

                    int a = db.Quire.Include(q => q.Spec).Where(q => q.SpecId == this.IdSpec && q.Status == 2 && q.Date2 > dt).Count();
                    return a.ToString();

                    
                }
            }
        }

        public int Select { get; set; }

        


    }
    #endregion

    #region Quire

    public partial class Quire
    {
        public string Test { get; set; }
        public string Date2D 
        {
            get { return Date2.Value.ToString("D"); }
        }

        public string Date1D
        {
            get { return Date1.Value.ToString("D"); }
        }
    }

    #endregion

}
