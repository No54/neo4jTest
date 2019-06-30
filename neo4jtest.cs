using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace neo4jTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //链接，用户名，密码
            string uri = "bolt://localhost:7687";
            string user = "neo4j";
            string password = "test";

            //创建链接接口类
            IDriver _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));

            //给个参数
            string message = "neo4j new boy!";

            //查询语句
            string cql = "CREATE (a:Greeting) " +
                         "SET a.message = '" + message + "'" +
                         "RETURN a.message + ', from node ' + id(a)";

            //开启链接会话
            var session = _driver.Session();

            //通过会话执行查询语句
            var greeting = session.Run(cql);

            //返回的是一串结构化数据
            var res = greeting.ToList();

            //找到想要的
            Interaction.MsgBox(res[0][0].ToString());
            session.Dispose();
            _driver.Dispose();

        }
    }

}
