using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace GenClass
{
    public class SqlServer : QueryInterface
    {
        public string GetQueryTableSQL()
        {
            return "";
        }
        public string GetQueryCoulmnSQL(string tablename)
        {
            return "";
        }

        /// <summary>  
        /// 查询sql中的非系统库  
        /// </summary>  
        /// <param name="connection"></param>  
        /// <returns></returns>  
        public List<string> databaseList(string connection)
        {
            List<string> getCataList = new List<string>();
            string cmdStirng = "select name from sys.databases where database_id > 4";
            SqlConnection connect = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(cmdStirng, connect);
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    IDataReader dr = cmd.ExecuteReader();
                    getCataList.Clear();
                    while (dr.Read())
                    {
                        getCataList.Add(dr["name"].ToString());
                    }
                    dr.Close();
                }

            }
            catch (SqlException e)
            {
                //MessageBox.Show(e.Message);  
            }
            finally
            {
                if (connect != null && connect.State == ConnectionState.Open)
                {
                    connect.Dispose();
                }
            }
            return getCataList;
        }

        /// <summary>  
        /// 获取列名  
        /// </summary>  
        /// <param name="connection"></param>  
        /// <returns></returns>  
        public List<string> GetTables(string connection)
        {
            List<string> tablelist = new List<string>();
            SqlConnection objConnetion = new SqlConnection(connection);
            try
            {
                if (objConnetion.State == ConnectionState.Closed)
                {
                    objConnetion.Open();
                    DataTable objTable = objConnetion.GetSchema("Tables");
                    foreach (DataRow row in objTable.Rows)
                    {
                        tablelist.Add(row[2].ToString());
                    }
                }
            }
            catch
            {

            }
            finally
            {
                if (objConnetion != null && objConnetion.State == ConnectionState.Closed)
                {
                    objConnetion.Dispose();
                }

            }
            return tablelist;
        }

        /// <summary>  
        /// 获取字段  
        /// </summary>  
        /// <param name="connection"></param>  
        /// <param name="TableName"></param>  
        /// <returns></returns>  
        public List<NameType> GetColumnField(string connection, string TableName)
        {
            List<NameType> Columnlist = new List<NameType>();
            SqlConnection objConnetion = new SqlConnection(connection);
            try
            {
                if (objConnetion.State == ConnectionState.Closed)
                {
                    objConnetion.Open();
                }
                //select   b.name colName, c.name colType  
                //from sysobjects a inner join syscolumns b
                //on a.id=b.id and a.xtype='U'
                //inner join systypes c
                //on b.xtype=c.xusertype
                //where a.name='tb_CDealer'
                SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME ,DATA_TYPE FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME='" + TableName + "'", objConnetion);
                SqlDataReader objReader = cmd.ExecuteReader();

                while (objReader.Read())
                {
                    NameType nametype = new NameType();
                    nametype.name = objReader[0].ToString();
                    nametype.type = objReader[1].ToString();
                    Columnlist.Add(nametype);

                }
            }
            catch
            {

            }
            objConnetion.Close();
            return Columnlist;
        }
    }
   
}
