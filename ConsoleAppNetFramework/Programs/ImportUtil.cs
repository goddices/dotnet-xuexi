using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleAppNetFramework.Programs
{
    public class ImportUtil
    {
        public void Import()
        {
            var lines = File.ReadAllLines(@"C:\Users\goddi\myspace\develop\projects\ygpt-tool\doc\新建文件夹\HOSDEAL.txt");
            SqlConnection conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=testgy");
            conn.Open();
            for (var i = 0; i < lines.Length; i += 2)
            {
                string dataStr = $"{lines[i].Replace("\t", "  ")} {lines[i + 1]}";
                string[] dataItems = dataStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                var cmd = conn.CreateCommand();
                cmd.CommandText = $"insert into HOSREALV1(Code1,Code2,Code3) values('{dataItems[0]}','{dataItems[2]}',N'{dataItems[1]}')";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}


/*
 * USE [testgy]
GO
 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HOSREALV1](

[Code1][nvarchar](1000) NULL,
	[Code2] [nvarchar](1000) NULL,
	[Code3] [nvarchar](1000) NULL
) ON[PRIMARY]
GO
 * 
 */