using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmpService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmpService.svc or EmpService.svc.cs at the Solution Explorer and start debugging.
    public class EmpService : IEmpService
    {
       
            public List<ClsEmp> DoWork()
            {
                List<ClsEmp> emp = new List<ClsEmp>();
                var con1 = System.Configuration.ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;
                SqlConnection conn = new SqlConnection(con1);
                SqlCommand cmd = new SqlCommand("select * from Stations", conn);

                conn.Open();
                SqlDataReader rea = cmd.ExecuteReader();

                while (rea.Read())
                {
                ClsEmp obj = new ClsEmp();
                    obj.s_id = Convert.ToInt32(rea["Station_Id"]);
                    obj.sname = rea["St_Name"].ToString();
                obj.city = rea["city"].ToString();

                emp.Add(obj);
                }
                rea.Close();
                conn.Close();
                return emp;
            }

        public string InsertKro(string name,string sname)
        {


            try
            {
                var con1 = System.Configuration.ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;
                SqlConnection conn = new SqlConnection(con1);
                SqlCommand cmd = new SqlCommand("insert into Stations values(@sname,@city)", conn);
                cmd.Parameters.AddWithValue("@sname",name);
                cmd.Parameters.AddWithValue("@city", sname);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();

                return "Ho gya is se poch le";
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
