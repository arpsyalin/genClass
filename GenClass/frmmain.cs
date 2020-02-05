using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace GenClass
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
        }

        private void btng_Click(object sender, EventArgs e)
        {
            string connectStr = txbconstr.Text;
            SqlServer sql = new SqlServer();
            List<string> tablenames = sql.GetTables(connectStr);
            foreach (string tablename in tablenames)
            {
                List<NameType> nameTypes = sql.GetColumnField(connectStr, tablename);
                genAndroidClassData(tablename, nameTypes);

            }
        }

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="nameTypes"></param>
        public void genAndroidClassData(string table, List<NameType> nameTypes)
        {
            table = table.Substring(0, 1).ToUpper() + table.Substring(1);
            string filePath = GetAppDBTextPath("android",table, AndroidGen.GetExt());
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    List<string> writedatas = AndroidGen.GetJavaGenData(table, nameTypes);
                    foreach (string data in writedatas)
                    {
                        sw.WriteLine(data);
                    }
                }
            }

        }

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="nameTypes"></param>
        public void genJpaClassData(string table, List<NameType> nameTypes)
        {
            table = table.Substring(0, 1).ToUpper() + table.Substring(1);
            string filePath = GetAppDBTextPath("jpa",table, JavaJpaGen.GetExt());
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    List<string> writedatas = JavaJpaGen.GetJavaGenData(table, nameTypes);
                    foreach (string data in writedatas)
                    {
                        sw.WriteLine(data);
                    }
                }
            }

        }

        /// <summary>
        /// 保存文件的地址
        /// 
        /// type不用带.
        /// </summary>
        /// <returns></returns>
        public string GetAppDBTextPath(string dir,string filename, string type)
        {
            string fullName = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\"));
            fullName = fullName.Substring(0, fullName.LastIndexOf("\\")) + "\\" +dir+"\\"+ filename + "." + type;
            string s = fullName.Substring(0, fullName.LastIndexOf('\\'));
            Directory.CreateDirectory(s);//如果文件夹不存在就创建它
            return fullName;

        }

        private void btnJpa_Click(object sender, EventArgs e)
        {
            string connectStr = txbconstr.Text;
            SqlServer sql = new SqlServer();
            List<string> tablenames = sql.GetTables(connectStr);
            foreach (string tablename in tablenames)
            {
                List<NameType> nameTypes = sql.GetColumnField(connectStr, tablename);
                genJpaClassData(tablename, nameTypes);

            }
        }
    }
}
