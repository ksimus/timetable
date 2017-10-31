using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace lection
{
    public partial class DB
    {

        public List<string> lis = new List<string>();
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        public string[] sa;
        public List<int> lisint = new List<int>();
        public int[] si;

        public int id;



        public NpgsqlDataReader SingInt(string sel, int num)
        {
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User=postgres;Password=1;Database=lection;");
            NpgsqlCommand com = new NpgsqlCommand(sel, con);

            NpgsqlDataReader reader;

            try
            {
                con.Open();
                reader = com.ExecuteReader();
                return reader;
            }
            catch { throw new Exception(); }
            finally
            {
                con.Close();
            }
        }
        public int ID(string sel)
        {
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User=postgres;Password=1;Database=lection;");
            NpgsqlCommand com = new NpgsqlCommand(sel, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader.GetInt32(0)) + 1; //Получаем значение из второго столбца! Первый это (0)!
            }
            con.Close();
            return id;
        }
        public float d;
        public float SelDouble(string sel)
        {
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User=postgres;Password=1;Database=lection;");
            NpgsqlCommand com = new NpgsqlCommand(sel, con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                d = reader.GetFloat(0); //Получаем значение из второго столбца! Первый это (0)!
            }
            con.Close();
            return d;
        }
        public string st;

        public DataTable DataSel(string sel)
        {
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User=postgres;Password=1;Database=postgres;");
            int a;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sel, con);
            con.Open();
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            con.Close();
            return dt;
        }

        public void Insert(string queryString)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User=postgres;Password=1;Database=lection;");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(queryString, conn);
            Int32 rowsaffected;
            try
            {
                rowsaffected = command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("NO!");
            }
            conn.Close();
        }

        public string[] SelStr(string sel)
        {
            lis.Clear();
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User=postgres;Password=1;Database=lection;");
            NpgsqlCommand com = new NpgsqlCommand(sel, con);
            con.Open();
            NpgsqlDataReader reader;
            try
            {
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    lis.Add(reader.GetString(0));

                }
            }
            catch { throw new Exception(); }
            finally
            {
                con.Close();
            }
            sa = lis.ToArray();
            return sa;

        }
        public int[] SelInt(string sel)
        {
            lisint.Clear();
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User=postgres;Password=1;Database=lection;");
            NpgsqlCommand com = new NpgsqlCommand(sel, con);
            con.Open();
            NpgsqlDataReader reader;
            try
            {
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    lisint.Add(reader.GetInt32(0));
                }
            }
            catch { throw new Exception(); }
            finally
            {
                con.Close();
            }
            si = lisint.ToArray();
            return si;

        }

        private void DB_Load(object sender, EventArgs e)
        {

        }

    }
}