using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WpfAppPM02.MyClass;


namespace WpfAppPM02.DataBase
{
   

  public static class Data
    {
        
       private static List<Quire> QuireStatus(List<Quire> c)
        {
            foreach (Quire b in c)
            {
                if (b.Status == 0) b.Test = "Отправлен";
                else if (b.Status == 1) b.Test = "На рассмотрение";
                else b.Test = "Завершен";
            }
            return c;
        }
       
        public static List<MaterialList> SelectMaterialList(Quire q)
        {
            using (MyModel db = new MyModel())
            {
               return db.MaterialList.Include(a => a.Storage).Where(a => a.ReqId == q.IdQuire).ToList();
            }

        }

        #region Quire
        public static void UpdatqQuireTo1(Quire mQuire, Spec mSpec)
        {
            using (MyModel db = new MyModel())
            {
              //  db.Spec.Attach(mSpec);
                db.Quire.Attach(mQuire);
               
               
                mQuire.Status = 1;
                mQuire.SpecId = mSpec.IdSpec;
                db.SaveChanges();
            }
        }
        public static List<Quire> SelectQuireForSpec()
        {
            using (MyModel db = new MyModel())
            {
                var v = db.Quire.Include(a => a.Users.Roli).Where(a => a.SpecId == Session.Id && a.Status == 1).ToList();
                    return v;
            }
        }

        #endregion

        public static List<Storage> SelectStorage()
        {
            using (MyModel db = new MyModel())
            {
               return db.Storage.ToList();
            }
        }
        public static void InsertReq(string mTheme,string mDesc,Users mUser)
        {
            using (MyModel db = new MyModel())
            {
                Quire q = new Quire
                {
                    UserId = mUser.IdUser,
                    Theme = mTheme,
                    Desc = mDesc,
                    Status = 0,
                    Date1 = DateTime.Now
                };
                db.Quire.Add(q);
                db.SaveChanges();

            }

        }
        public static string InsertSpec(string mFio, string mLogin, string mPass, Roli mRoli)
        {
            using (MyModel db = new MyModel())
            {
                Spec u = new Spec
                {
                    Rol_Id = mRoli.IdRoli,
                    FIo = mFio,
                    Login = mLogin,
                    Pass = mPass,
                    Status = false
                };
                db.Spec.Add(u);
                db.SaveChanges();
                return "Запись успешно добавлена";

            }
        }
        public static string InsertUser(string mFio, string mLogin, string mPass, Roli mRoli)
        {
            using (MyModel db = new MyModel())
            {
                Users u = new Users
                {
                    Rol_Id = mRoli.IdRoli,
                    Fio = mFio,
                    Login = mLogin,
                    Pass = mPass,
                };
                db.Users.Add(u);
                db.SaveChanges();
                return "Запись успешно добавлена";
            }
        }

        public static string UpdateUser(string mFio, string mLogin, string mPass,  Roli mRoli, Users mUser)
        {
            using (MyModel db = new MyModel())
            {  
                db.Users.Attach(mUser); 
                mUser.Fio = mFio;
                mUser.Login = mLogin;
                if (mPass != "") mUser.Pass = mPass;
                mUser.Rol_Id = mRoli.IdRoli;
                db.SaveChanges();
                return "Данные успешно обновлены!";
            }
            
        }

        public static string UpdateSpec(string mFio, string mLogin, string mPass, Roli mRoli, Spec mSpec)
        {
            using (MyModel db = new MyModel())
            {
                db.Spec.Attach(mSpec);
                mSpec.FIo = mFio;
                mSpec.Login = mLogin;
                if (mPass != "") mSpec.Pass = mPass;
                mSpec.Rol_Id = mRoli.IdRoli;
                db.SaveChanges();
                return "Данные успешно обновлены!";
            }

        }

        public static void ChangePass(Users mUser,string mPass)
        {
            using (MyModel db = new MyModel())
            {
                db.Users.Attach(mUser);
                mUser.Pass = mPass;
                db.SaveChanges();
            }
        }

        public static void ChangePass(Spec mUser, string mPass)
        {
            using (MyModel db = new MyModel())
            {
                db.Spec.Attach(mUser);
                mUser.Pass = mPass;
                db.SaveChanges();
            }
        }

        public static List<Quire> SelectQuire0()
        {
            using (MyModel db = new MyModel())
            {

                List<Quire> c = db.Database.SqlQuery<Quire>($"Select * from Quire WHERE UserId = {Session.Id}").ToList();

                return QuireStatus(c);
            }
        }

        public static List<Quire> SelectQuire02()
        {
            using (MyModel db = new MyModel())
            {
                var c=  db.Quire.Include(a => a.Spec.Roli).Include(q => q.Users.Roli).Where(a => a.Status == 2).OrderByDescending(a => a.Date2).ToList();
                return QuireStatus(c);
            }
           
        }

        public static List<Quire> SelectQuire01()
        {
            using (MyModel db = new MyModel())
            {


                var c = db.Quire.Include(q => q.Spec.Roli).Include(q =>q.Users.Roli).Where(q => q.Status != 2).OrderByDescending(q=>q.Date1).ToList();
                
                    return QuireStatus(c);
            }
        }

        public static List<Quire> SelectQuire0(int a)
        {
            using (MyModel db = new MyModel())
            {
             
              
                    List<Quire> c = db.Database.SqlQuery<Quire>($"Select * from Quire Where Status={a}").ToList();

                    return QuireStatus(c);
               
            }
        }
        public static List<Roli> SelectRoli0()
        {
            using (MyModel db = new MyModel())
            {
                var c = db.Database.SqlQuery<Roli>("Select * from Roli Where Access=0").ToList();
                return c;                     
            }
        }

        public static List<Roli> SelectRoli1()
        {
            using (MyModel db = new MyModel())
            {
                var c = db.Database.SqlQuery<Roli>("Select * from Roli Where Access!=0").ToList();
                return c;
            }
        }

        public static List<Users> SelectUsers()
        {
            using (MyModel db = new MyModel())
            {
                var a = db.Users.Include(b => b.Roli);

                return a.ToList();

            }
        }

        public static List<Spec> SelectAllSpec()
        {
            using (MyModel db = new MyModel())
            {
                var a = db.Spec.Include(b => b.Roli);
                
                return a.ToList();

            }
        }

        public static List<Spec> SelectOnlySpec()
        {
            using (MyModel db = new MyModel())
            {
               var a = db.Spec.Include(b=>b.Roli).ToList();
               var c = db.Spec.Include(b => b.Roli).ToList();
                foreach (var d in a)
                {
                    if (d.Roli.Access !=1)
                    {
                        c.Remove(d);
                        continue;
                    }

                    if (d.Status == true)
                    {
                        c.Remove(d);
                       
                    }

                }
                return c;

            }
        }

        public static void DeleteUser(Users mUser)
        {
            using (MyModel db = new MyModel())
            {
                db.Users.Attach(mUser);
                db.Users.Remove(mUser);
                db.SaveChanges();
            }
        }
        public static void DeleteSpec(Spec mSpec)
        {
            using (MyModel db = new MyModel())
            {
                db.Spec.Attach(mSpec);
                db.Spec.Remove(mSpec);
                db.SaveChanges();
            }
        }

        
    }
}
