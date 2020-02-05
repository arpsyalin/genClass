using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenClass
{
    public interface QueryInterface
    {   
        /// <summary>
        /// 获取查询表的Sql语句
        /// </summary>
        /// <returns></returns>
          string GetQueryTableSQL();
        /// <summary>
        /// 获取查询字段的Sql语句
        /// </summary>
        /// <returns></returns>
          string GetQueryCoulmnSQL(string tablename);
         
    }
}
