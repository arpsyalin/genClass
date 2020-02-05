using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenClass
{
    public class JavaJpaGen
    {
        public static bool defalutTrue = true;
        public static string GetExt()
        {
            return "java";
        }

        public static List<string> GetJavaGenData(string tablename, List<NameType> nametypes)
        {
            List<string> reuslt = new List<string>();
            reuslt.AddRange(GetJavaImport());
            reuslt.AddRange(GetJavaHead(tablename));
            reuslt.AddRange(GetJavaDefine(nametypes));
            reuslt.AddRange(GetJavaGetSet(nametypes));
            reuslt.AddRange(GetJavaEnd());
            return reuslt;
        }

        /// <summary>
        /// 拼接第一棒
        /// </summary>
        /// <returns></returns>
        public static List<string> GetJavaImport()
        {
            List<string> import = new List<string>();
            import.Add("package com.ncxm.niuchange.domain;");
            import.Add("import java.io.Serializable;");
            import.Add("import org.hibernate.annotations.GenericGenerator;");
            import.Add("import org.hibernate.annotations.UpdateTimestamp;");
            import.Add("import javax.persistence.*;");
            import.Add("import java.util.Date;");
            return import;
        }

        public static List<string> GetJavaHead(string name)
        {
            List<string> head = new List<string>();
            head.Add("/*** @author 刘亚林   ");
            head.Add(" @time:" + DateTime.Now.ToString());
            head.Add(" @刘亚林类代码生成工具生成");
            head.Add("**/");
            head.Add("@Entity");
            head.Add("@Table(name = \"" + name + "\")");
            head.Add("public class " + name);
            head.Add("{");
            return head;
        }
        public static List<string> GetJavaDefine(List<NameType> nametypes)
        {
            List<string> result = new List<string>();
            foreach (NameType nameType in nametypes)
            {
                string type = GetJavaType(nameType.type);
                string name = nameType.name;
                name = name.Substring(0, 1).ToLower() + name.Substring(1);
                if (!type.Trim().ToUpper().Equals("INT")
                    && name.Trim().ToUpper().Equals("ID"))
                {
                    name="id";
                    result.Add("	@Id");
                    result.Add("	@GeneratedValue(strategy = GenerationType.AUTO, generator = \"" + name + "\")");
                    result.Add("	@GenericGenerator(name = \"" + name + "\", strategy =\"com.ncxm.niuchangel.common.CustomIDGenerator\")");
                    result.Add("	Long " + name + ";");
                    result.Add("");

                }
                else if (!type.Trim().ToUpper().Equals("DATE") && name.Trim().ToUpper().Equals("CREATETIME"))
                {
                    result.Add("	@UpdateTimestamp");
                    result.Add("	@Temporal(TemporalType.TIMESTAMP)");
                    result.Add("	" + type + "" + name + ";");
                    result.Add("");
                }
                else
                {
                    result.Add("	@Column  ");
                    if (type.Equals("boolean") && defalutTrue)
                        result.Add("     " + type + " " + name + " = true;");
                    else
                        result.Add("	 " + type + " " + name + ";");
                    result.Add("");
                }
            }
            return result;
        }

        public static List<string> GetJavaGetSet(List<NameType> nametypes)
        {
            List<string> result = new List<string>();
            foreach (NameType nameType in nametypes)
            {
                string type = GetJavaType(nameType.type);
                string name = nameType.name;
                if (!type.Trim().ToUpper().Equals("INT")
                   && name.Trim().ToUpper().Equals("ID"))
                {
                    name = "id";
                }
                name = name.Substring(0, 1).ToUpper() + name.Substring(1);
                result.Add("	public " + type + " get" + name + "() ");
                result.Add(" 	{");
                result.Add("		return  " + name + " ;");
                result.Add(" 	}");
                result.Add("	 ");
                result.Add("	public void set" + name + "(" + type + " " + name + ")");
                result.Add(" 	{");
                result.Add("		this." + name + " =  " + name + " ;");
                result.Add(" 	}");
                result.Add("	");

            }
            return result;
        }

        public static List<string> GetJavaEnd()
        {
            List<string> end = new List<string>();
            end.Add("}");
            return end;
        }

        public static string GetJavaType(String type)
        {
            if (type.IndexOf("varchar") > -1)
            {
                type = " String ";
                return type;
            }
            if (type.IndexOf("varchar") > -1
                    || type.IndexOf("uniqueidentifier") > -1)
            {
                type = " Long ";
                return type;
            }
            if (type.IndexOf("datetime") > -1)
            {
                 type = " Date ";
                return type;
            }
            if (type.IndexOf("bit") > -1)
            {
                type = " boolean ";
                return type;
            }
            if (type.IndexOf("decimal") > -1)
            {
                type = " double  ";
                return type;
            }

            return type;

        }

    }
}
