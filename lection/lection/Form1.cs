using System;
using System.Windows.Forms;

namespace lection
{
    public partial class Form1 : Form
    {
        public DB db = new DB();
        public Form1()
        {
            InitializeComponent();
        }
        public int id_emp;
        public void dgwshow(DataGridView a)
        {
            a.Visible = false;
            a.Visible = true;
            a.DataSource = string.Empty;
            a.AutoSize = true;
            a.ReadOnly = true;
            a.MultiSelect = false;
            a.AllowUserToAddRows = false;
            a.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox10.DropDownStyle = ComboBoxStyle.DropDownList;
            show();
            dgwshow(dgw1);
            dgw1.DataSource = db.DataSel("select * from auditory");
        }
        public void show()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            button21.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show();
            dgwshow(dgw1);
            dgw1.DataSource = db.DataSel("select * from auditory");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgwshow(dgw1);
            panel1.Visible = true;
            dgw1.Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                show();
                dgwshow(dgw1);
                dgw1.DataSource = db.DataSel("select * from auditory");
            }
            if (tabControl1.SelectedIndex == 1)
            {
                show();
                dgwshow(dgw2);
                dgw2.DataSource = db.DataSel("select * from lector");
            }
            if (tabControl1.SelectedIndex == 2)
            {
                show();
                dgwshow(dgw3);
                dgw3.DataSource = db.DataSel("select * from group_of");
            }
            if (tabControl1.SelectedIndex == 3)
            {
                show();
                dgwshow(dgw4);
                dgw4.DataSource = db.DataSel("select * from discipline");
            }
            if (tabControl1.SelectedIndex == 4)
            {
                show();
                dgwshow(dgw5);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == false && string.IsNullOrEmpty(comboBox1.Text) == false)
            {
                try
                {
                    db.Insert("INSERT INTO auditory (name,stat) VALUES  ('" + textBox1.Text + "','" + comboBox1.Text + "')");
                    MessageBox.Show("Ok");
                    textBox1.Clear();
                    comboBox1.Text = null;
                }
                catch
                {
                    MessageBox.Show("No");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cl = "";
            try
            {
                int s = dgw1.CurrentRow.Index;
                cl = dgw1.Rows[s].Cells[0].Value.ToString();
                db.Insert("update auditory set stat = '"+comboBox2.Text+"' where id = " + cl);
                comboBox2.Text = null;
                MessageBox.Show("Ok");
            }
            catch {
                MessageBox.Show("No");
            }
            if (string.IsNullOrEmpty(cl) == false)
            {
                dgwshow(dgw1);
                dgw1.DataSource = db.DataSel("select * from auditory");
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            show();
            string cl = "";
            try
            {
                int s = dgw1.CurrentRow.Index;
                cl = dgw1.Rows[s].Cells[0].Value.ToString();
                db.Insert("delete from auditory where id = " + cl);
            }
            catch
            {
                MessageBox.Show("No");
            }
            dgwshow(dgw1);
            dgw1.DataSource = db.DataSel("select * from auditory");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            show();
            dgwshow(dgw2);
            dgw2.DataSource = db.DataSel("select * from lector");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dgwshow(dgw2);
            panel2.Visible = true;
            dgw2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            show();
            string cl = "";
            try
            {
                int s = dgw2.CurrentRow.Index;
                cl = dgw2.Rows[s].Cells[0].Value.ToString();
                db.Insert("delete from lector where id = " + cl);
            }
            catch
            {
                MessageBox.Show("No");
            }
            dgwshow(dgw2);
            dgw2.DataSource = db.DataSel("select * from lector");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == false)
            {
                try
                {

                    db.Insert("INSERT INTO lector (fio) VALUES  ('" + textBox2.Text + "')");
                    MessageBox.Show("Ok");
                    textBox2.Clear();
                }
                catch
                {
                    MessageBox.Show("No");
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            show();
            dgwshow(dgw3);
            dgw3.DataSource = db.DataSel("select * from group_of");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            dgw3.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox5.Text) == false && string.IsNullOrEmpty(comboBox4.Text) == false)
            {
                bool b = false;
                int sem = db.ID("select semester from group_of limit 1");
                if((sem % 2) == 0 && (comboBox4.Text == "1" || comboBox4.Text == "3" || comboBox4.Text == "5" || comboBox4.Text == "7"))
                {
                    b = true;
                }
                if ((sem % 2) == 1 && (comboBox4.Text == "2" || comboBox4.Text == "4" || comboBox4.Text == "6" || comboBox4.Text == "8"))
                {
                    b = true;
                }
                try
                {
                    if (b == true)
                    {
                        db.Insert("INSERT INTO group_of (cpec,semester) VALUES  ('" + comboBox5.Text + "','" + comboBox4.Text + "')");
                        MessageBox.Show("Ok");
                        comboBox5.Text = null;
                        comboBox4.Text = null;
                    }
                    else
                    {

                        MessageBox.Show("Сейчас другой семестр");
                    }
                }
                catch
                {
                    MessageBox.Show("No");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            db.Insert("update group_of set semester = semester+1");
            show();
            dgwshow(dgw3);
            dgw3.DataSource = db.DataSel("select * from group_of");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dgwshow(dgw3);
            show();
            string cl = "";
            try
            {
                int s = dgw3.CurrentRow.Index;
                cl = dgw3.Rows[s].Cells[0].Value.ToString();
                db.Insert("delete from group_of where id = " + cl);
            }
            catch
            {
                MessageBox.Show("No");
            }
            dgwshow(dgw3);
            dgw3.DataSource = db.DataSel("select * from group_of");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            show();
            dgwshow(dgw4);
            dgw4.DataSource = db.DataSel("select * from discipline");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            show();
            string cl = "";
            try
            {
                int s = dgw4.CurrentRow.Index;
                cl = dgw4.Rows[s].Cells[0].Value.ToString();
                db.Insert("delete from discipline where id = " + cl);
            }
            catch
            {
                MessageBox.Show("No");
            }
            dgwshow(dgw4);
            dgw4.DataSource = db.DataSel("select * from discipline");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            dgwshow(dgw4);
            dgw4.DataSource = db.DataSel("select * from LECTOR");
            panel4.Visible = true;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            string cl = "";
            try
            {
                int s = dgw4.CurrentRow.Index;
                cl = dgw4.Rows[s].Cells[0].Value.ToString();

                if (string.IsNullOrEmpty(comboBox3.Text) == false && string.IsNullOrEmpty(comboBox6.Text) == false && string.IsNullOrEmpty(textBox3.Text) == false)
                {


                    bool b = false;
                    int sem = db.ID("select semester from group_of limit 1");
                    if((sem % 2) == 0 && (comboBox6.Text == "1" || comboBox6.Text == "3" || comboBox6.Text == "5" || comboBox6.Text == "7"))
                    {
                        b = true;
                    }
                    if ((sem % 2) == 1 && (comboBox6.Text == "2" || comboBox6.Text == "4" || comboBox6.Text == "6" || comboBox6.Text == "8"))
                    {
                        b = true;
                    }
                    try
                    {
                        if (b == true)
                        {

                            db.Insert("INSERT INTO discipline (name,lector_id,semester,cpec) VALUES  ('" + textBox3.Text + "'," + cl + ",'" + comboBox6.Text + "','" + comboBox3.Text + "')");
                            MessageBox.Show("Ok");
                            comboBox3.Text = null;
                            comboBox6.Text = null;
                            textBox3.Text = null;
                        }
                        else { MessageBox.Show("Сейчас другой семестр"); }
                    }
                    catch
                    {
                        MessageBox.Show("No");
                    }
                }
            }
            catch
            {
                MessageBox.Show("No");
            }
        }
        public string table;
        private void button16_Click(object sender, EventArgs e)
        {
            show();
            panel6.Visible = true;
            dgwshow(dgw5);
            switch(comboBox7.Text)
            {
                case "Группа": dgw5.DataSource = db.DataSel("select * from group_of"); break;
                case "Преподаватель": dgw5.DataSource = db.DataSel("select * from LECTOR");  break;
                case "Аудитория": dgw5.DataSource = db.DataSel("select * from auditory"); break;
                case "Специальность": dgw5.DataSource = db.DataSel("select cpec from group_of group by cpec"); break;
            }
        }
        public int auditory;
        public int group;
        public int disc;
        private void button20_Click(object sender, EventArgs e)
        {
            show();
            auditory = 0;
            group = 0;
            disc = 0;
            panel5.Visible = true;
            button21.Visible = true;
            dgwshow(dgw5);
            dgw5.DataSource = db.DataSel("select * from auditory where stat = 'Open'");
        }
        
        private void button21_Click(object sender, EventArgs e)
        {
            string cl = "";
            string gr = "";
            try
            {
                int s = dgw5.CurrentRow.Index;
                cl = dgw5.Rows[s].Cells[0].Value.ToString();
                gr = dgw5.Rows[s].Cells[1].Value.ToString();
            if(auditory != 0)
            {
                if(group != 0)
                {
                    disc = Convert.ToInt32(cl);
                }
                else
                {
                    group = Convert.ToInt32(cl);
                    dgwshow(dgw5);
                        int sem = (db.ID("select semester from group_of where id = "+group+" limit 1")-1);
                        dgw5.DataSource = db.DataSel("select * from discipline where semester = "+sem+" and cpec = '"+gr+"'");
                }
            }
            else
            {
                auditory = Convert.ToInt32(cl);
                dgwshow(dgw5);
                dgw5.DataSource = db.DataSel("select * from group_of");
            }
            }
            catch { }
            if(auditory != 0 && group != 0 && disc != 0 && string.IsNullOrEmpty(comboBox9.Text) == false && string.IsNullOrEmpty(comboBox10.Text) == false)
            {
                try
                {
                    db.Insert("insert into timetable (classes, weekday, auditory_id, group_id, discipline_id) values ("+comboBox10.Text+",'"+comboBox9.Text+"',"+auditory+","+group+","+disc+")");
                    MessageBox.Show("Ok");
                }
                catch
                {
                    MessageBox.Show("No");
                }
                auditory = 0;
                group = 0;
                disc = 0;
                comboBox10.Text = null;
                comboBox9.Text = null;
                dgwshow(dgw5);
                dgw5.DataSource = db.DataSel("select * from auditory where stat = 'Open'");
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {
            string cl = "";
            try
            {
                int s = dgw5.CurrentRow.Index;
                cl = dgw5.Rows[s].Cells[0].Value.ToString();
            }
            catch { }
            dgwshow(dgw5);
            try
            {
                switch (comboBox7.Text)
                {
                    case "Группа": dgw5.DataSource = db.DataSel("select t.classes,g.id,g.cpec,t.weekday,d.name,l.fio,a.name from auditory a,lector l, timetable t, group_of g, discipline d where t.discipline_id = d.id and g.id = t.group_id and l.id = d.lector_id and a.id = t.auditory_id and t.weekday = '" + comboBox8.Text + "' and g.id = " + cl); break;
                    case "Преподаватель": dgw5.DataSource = db.DataSel("select t.classes,g.id,g.cpec,t.weekday,d.name,l.fio,a.name from auditory a,lector l, timetable t, group_of g, discipline d where t.discipline_id = d.id and g.id = t.group_id and l.id = d.lector_id and a.id = t.auditory_id and t.weekday = '" + comboBox8.Text + "' and l.id = " + cl); break;
                    case "Аудитория": dgw5.DataSource = db.DataSel("select t.classes,g.id,g.cpec,t.weekday,d.name,l.fio,a.name from auditory a,lector l, timetable t, group_of g, discipline d where t.discipline_id = d.id and g.id = t.group_id and l.id = d.lector_id and a.id = t.auditory_id and t.weekday = '" + comboBox8.Text + "' and a.id = " + cl); break;
                    case "Специальность": dgw5.DataSource = db.DataSel("select t.classes,g.id,g.cpec,t.weekday,d.name,l.fio,a.name from auditory a,lector l, timetable t, group_of g, discipline d where t.discipline_id = d.id and g.id = t.group_id and l.id = d.lector_id and a.id = t.auditory_id and t.weekday = '" + comboBox8.Text + "' and g.cpec = '" + cl + "'"); break;
                }
            }
            catch { }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string cl = "";
            try
            {
                int s = dgw5.CurrentRow.Index;
                cl = dgw5.Rows[s].Cells[0].Value.ToString();
            }
            catch { }
            dgwshow(dgw5);
            try
            {
                switch (comboBox7.Text)
                {
                    case "Группа": dgw5.DataSource = db.DataSel("select t.classes,g.id,g.cpec,t.weekday,d.name,l.fio,a.name from auditory a,lector l, timetable t, group_of g, discipline d where t.discipline_id = d.id and g.id = t.group_id and l.id = d.lector_id and a.id = t.auditory_id  and g.id = " + cl); break;
                    case "Преподаватель": dgw5.DataSource = db.DataSel("select t.classes,g.id,g.cpec,t.weekday,d.name,l.fio,a.name from auditory a,lector l, timetable t, group_of g, discipline d where t.discipline_id = d.id and g.id = t.group_id and l.id = d.lector_id and a.id = t.auditory_id and l.id = " + cl); break;
                    case "Аудитория": dgw5.DataSource = db.DataSel("select t.classes,g.id,g.cpec,t.weekday,d.name,l.fio,a.name from auditory a,lector l, timetable t, group_of g, discipline d where t.discipline_id = d.id and g.id = t.group_id and l.id = d.lector_id and a.id = t.auditory_id and a.id = " + cl); break;
                    case "Специальность": dgw5.DataSource = db.DataSel("select t.classes,g.id,g.cpec,t.weekday,d.name,l.fio,a.name from auditory a,lector l, timetable t, group_of g, discipline d where t.discipline_id = d.id and g.id = t.group_id and l.id = d.lector_id and a.id = t.auditory_id and g.cpec = '" + cl + "'"); break;
                }
            }
            catch { }
        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            int pr;
            if (string.IsNullOrEmpty(log.Text) == false && string.IsNullOrEmpty(pass.Text) == false)
            {
                try
                {
                    pr = (db.ID("select priv from user_ where login = '" + log.Text + "' and pass = '" + pass.Text + "'"))-1;
                    if (pr != -1 || (log.Text == "admin" && pass.Text == "1234"))
                    {
                        tabControl1.Visible = true;
                        if (pr == 2)
                        {
                            tabControl1.Controls[0].Enabled = false;
                            tabControl1.Controls[1].Enabled = false;
                            tabControl1.Controls[2].Enabled = false;
                            tabControl1.Controls[3].Enabled = false;
                            tabControl1.Controls[5].Enabled = false;
                            button20.Enabled = false;
                        }
                        panel7.Visible = false;
                    }
                    else { MessageBox.Show("Неверно"); }
                }
                catch { MessageBox.Show("Неверно"); }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            show();
            dgwshow(dgw6);
            dgw6.DataSource = db.DataSel("select id,login,priv from user_");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == false && string.IsNullOrEmpty(textBox5.Text) == false && (radioButton1.Checked || radioButton2.Checked))
            {
                int priv = 0;
                if (radioButton1.Checked)
                {
                    priv = 1;
                }
                if (radioButton2.Checked)
                {
                    priv = 2;
                }
                try
                {

                    db.Insert("INSERT INTO user_ (login,pass,priv) VALUES  ('" + textBox4.Text + "','" + textBox5.Text + "','"+priv+"')");
                    MessageBox.Show("Ok");
                    textBox4.Clear();
                    textBox5.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                }
                catch
                {
                    MessageBox.Show("No");
                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            dgwshow(dgw6);
            panel8.Visible = true;
            dgw6.Visible = false;
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            show();
            string cl = "";
            try
            {
                int s = dgw6.CurrentRow.Index;
                cl = dgw6.Rows[s].Cells[0].Value.ToString();
                db.Insert("delete from user_ where id = " + cl);
            }
            catch
            {
                MessageBox.Show("No");
            }
            dgwshow(dgw6);
            dgw6.DataSource = db.DataSel("select id,login,priv from user_");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
                if (string.IsNullOrEmpty(textBox6.Text) == false && string.IsNullOrEmpty(textBox7.Text) == false)
            {
                    int priv = 2;
                    try
                    {

                        db.Insert("INSERT INTO user_ (login,pass,priv) VALUES  ('" + textBox6.Text + "','" + textBox7.Text + "','" + priv + "')");
                        MessageBox.Show("Ok");
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                    }
                    catch
                    {
                        MessageBox.Show("No");
                    }
                }
            tabControl1.Visible = true;
            MessageBox.Show("Ок, пройдено тут");
            tabControl1.Controls[0].Enabled = false;
                tabControl1.Controls[1].Enabled = false;
                tabControl1.Controls[2].Enabled = false;
                tabControl1.Controls[3].Enabled = false;
                tabControl1.Controls[5].Enabled = false;
                button20.Enabled = false;
            panel7.Visible = false;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
