using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

public partial class _Default : System.Web.UI.Page
{
    public string json;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = MySQL("select * from treeview");

            JArray array = new JArray();
            foreach (DataRow dr_a in dt.Select("a <> '' and b = ''"))
            {
                JObject o_a = new JObject();
                o_a["text"] = dr_a["text"].ToString();
                o_a["href"] = dr_a["href"].ToString();

                JArray nodes_a = new JArray();
                foreach (DataRow dr_b in dt.Select("a = '" + dr_a["a"] + "' and b <> '' and c = ''"))
                {
                    JObject o_b = new JObject();
                    o_b["text"] = dr_b["text"].ToString();
                    o_b["href"] = dr_b["href"].ToString();

                    JArray nodes_b = new JArray();
                    foreach (DataRow dr_c in dt.Select("b = '" + dr_b["b"] + "' and c <> '' and d = ''"))
                    {
                        JObject o_c = new JObject();
                        o_c["text"] = dr_c["text"].ToString();
                        o_c["href"] = dr_c["href"].ToString();

                        JArray nodes_c = new JArray();
                        foreach (DataRow dr_d in dt.Select("c = '" + dr_c["c"] + "' and d <> '' and e = ''"))
                        {
                            JObject o_d = new JObject();
                            o_d["text"] = dr_d["text"].ToString();
                            o_d["href"] = dr_d["href"].ToString();

                            nodes_c.Add(o_d);
                        }
                        if (nodes_c.Count > 0)
                            o_c["nodes"] = nodes_c;

                        nodes_b.Add(o_c);
                    }
                    if (nodes_b.Count > 0)
                        o_b["nodes"] = nodes_b;


                    nodes_a.Add(o_b);
                }

                if (nodes_a.Count > 0)
                    o_a["nodes"] = nodes_a;


                array.Add(o_a);
            }


            json = array.ToString();
        }
    }

    private DataTable MySQL(string cmd)
    {
        DataTable dt = new DataTable();
        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, "server=localhost;uid=root;database=project"))
        {
            adapter.Fill(dt);
        }
        return dt;
    }
}