using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Interfejs_Kochanski_Klimek_Koza
{
    /// <summary>
    /// Interaction logic for Edytsamochod.xaml
    /// </summary>
    public partial class Edytsamochod : Window
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        
        public class Samochod
        {
            public string marka { get; set; }
            public string model { get; set; }
            public string silnik { get; set; }
            public int pojemnosc { get; set; }
            public string numer_rejestracyjny { get; set; }
            public bool statuswypoz { get; set; }
            public int cenawyp { get; set; }
            public string stantechniczny { get; set; }
            public DateTime OC { get; set; }
            public DateTime AC { get; set; }
            public DateTime przeglad_techniczny { get; set; }
            public int ID_samochodu { get; set; }
        }

        public Edytsamochod()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Samochod> listasamoch = new List<Samochod>();
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            string zapytaj = "SELECT * FROM Samochody";
            
            
            cs.DataSource = "W-KOMPUTER\\ASUSSQL";
            cs.InitialCatalog = "wyp_sam";
            cs.IntegratedSecurity = true;
            da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            da.Fill(ds, "Samochody");
            int ile = ds.Tables[0].Rows.Count;
            //DGwypoz.ItemsSource = ds.Tables["Samochody"].DefaultView;//cala tablea wypisana do gridview autocolumns
            for (int i = 0; i < ile; i++)
            {
                listasamoch.Add(new Samochod { marka = ds.Tables["Samochody"].Rows[i][1].ToString(), model = ds.Tables["Samochody"].Rows[i][2].ToString(), silnik = ds.Tables["Samochody"].Rows[i][3].ToString(), pojemnosc = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][4].ToString()), numer_rejestracyjny = ds.Tables["Samochody"].Rows[i][5].ToString(), cenawyp = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][7].ToString()), stantechniczny = ds.Tables["Samochody"].Rows[i][8].ToString(), statuswypoz = Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6].ToString()), przeglad_techniczny = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][11]), OC = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][9]), AC = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][10]) });
            }
            DGsamo.ItemsSource = listasamoch;
        }

        private void btndodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                cs.DataSource = "W-KOMPUTER\\ASUSSQL";
                cs.InitialCatalog = "wyp_sam";
                cs.IntegratedSecurity = true;
                SqlConnection connection = new SqlConnection(cs.ToString());
                connection.Open();
                string zapyt = "insert into Samochody values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";
                SqlCommand command = new SqlCommand(zapyt, connection);
                command.Parameters.Add("@p1", SqlDbType.NVarChar).Value = txtmarka.Text;
                command.Parameters.Add("@p2", SqlDbType.NVarChar).Value = txtmodel.Text;
                command.Parameters.Add("@p3", SqlDbType.NVarChar).Value = txtsilnik.Text;
                command.Parameters.Add("@p4", SqlDbType.Int).Value = txtpoje.Text;
                command.Parameters.Add("@p5", SqlDbType.NVarChar).Value = txtnrreje.Text;
                command.Parameters.Add("@p6", SqlDbType.Bit).Value = false;
                command.Parameters.Add("@p7", SqlDbType.Int).Value = txtcena.Text;
                command.Parameters.Add("@p8", SqlDbType.NVarChar).Value = txtstan.Text;
                command.Parameters.Add("@p9", SqlDbType.Date).Value = Convert.ToDateTime(DPOC.ToString());
                command.Parameters.Add("@p10", SqlDbType.Date).Value = Convert.ToDateTime(DPAC.ToString());
                command.Parameters.Add("@p11", SqlDbType.Date).Value = Convert.ToDateTime(DPtech.ToString());
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                connection.Close();
                txtmarka.Text = null;
                txtmodel.Text = null;
                txtsilnik.Text = null;
                txtpoje.Text = null;
                txtnrreje.Text = null;
                txtcena.Text = null;
                txtstan.Text = null;
                DPOC.SelectedDate = null;
                DPAC.SelectedDate = null;
                DPtech.SelectedDate = null;
                List<Samochod> listasamoch = new List<Samochod>();
                string zapytaj = "SELECT * FROM Samochody";
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
                da.Fill(ds, "Samochody");
                int ile = ds.Tables[0].Rows.Count;
                //DGwypoz.ItemsSource = ds.Tables["Samochody"].DefaultView;//cala tablea wypisana do gridview autocolumns
                for (int i = 0; i < ile; i++)
                {
                    listasamoch.Add(new Samochod { marka = ds.Tables["Samochody"].Rows[i][1].ToString(), model = ds.Tables["Samochody"].Rows[i][2].ToString(), silnik = ds.Tables["Samochody"].Rows[i][3].ToString(), pojemnosc = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][4].ToString()), numer_rejestracyjny = ds.Tables["Samochody"].Rows[i][5].ToString(), cenawyp = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][7].ToString()), stantechniczny = ds.Tables["Samochody"].Rows[i][8].ToString(), statuswypoz = Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6].ToString()), przeglad_techniczny = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][11]), OC = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][9]), AC = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][10]) });
                }
                DGsamo.ItemsSource = listasamoch;
            }
            catch(Exception ex)
            { MessageBox.Show("Prawdopodobnie któreś pole jest puste lub posiada niedozwolone znaki. "+ ex.Message, "Błąd!"); }
        }

        private void btnusun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ds.Tables["Samochody"].Rows[DGsamo.SelectedIndex].Delete();
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(ds, "Samochody");
                List<Samochod> listasamoch = new List<Samochod>();
                ds.Clear();
                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                string zapytaj = "SELECT * FROM Samochody";
                cs.DataSource = "W-KOMPUTER\\ASUSSQL";
                cs.InitialCatalog = "wyp_sam";
                cs.IntegratedSecurity = true;
                da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
                da.Fill(ds, "Samochody");
                int ile = ds.Tables[0].Rows.Count;
                //DGwypoz.ItemsSource = ds.Tables["Samochody"].DefaultView;//cala tablea wypisana do gridview autocolumns
                for (int i = 0; i < ile; i++)
                {
                    listasamoch.Add(new Samochod { marka = ds.Tables["Samochody"].Rows[i][1].ToString(), model = ds.Tables["Samochody"].Rows[i][2].ToString(), silnik = ds.Tables["Samochody"].Rows[i][3].ToString(), pojemnosc = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][4].ToString()), numer_rejestracyjny = ds.Tables["Samochody"].Rows[i][5].ToString(), cenawyp = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][7].ToString()), stantechniczny = ds.Tables["Samochody"].Rows[i][8].ToString(), statuswypoz = Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6].ToString()), przeglad_techniczny = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][11]), OC = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][9]), AC = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][10]) });
                }
                DGsamo.ItemsSource = listasamoch;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Prawdopodobnie auto jest wypożyczone lub rekord nie został wybrany. "+ex.Message, "Błąd!");
            }
        }

        private void btnodswiez_Click(object sender, RoutedEventArgs e)
        {
            List<Samochod> listasamoch = new List<Samochod>();
            ds.Clear();
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            string zapytaj = "SELECT * FROM Samochody";
            cs.DataSource = "W-KOMPUTER\\ASUSSQL";
            cs.InitialCatalog = "wyp_sam";
            cs.IntegratedSecurity = true;
            da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            da.Fill(ds, "Samochody");
            int ile = ds.Tables[0].Rows.Count;
            //DGwypoz.ItemsSource = ds.Tables["Samochody"].DefaultView;//cala tablea wypisana do gridview autocolumns
            for (int i = 0; i < ile; i++)
            {
                listasamoch.Add(new Samochod { marka = ds.Tables["Samochody"].Rows[i][1].ToString(), model = ds.Tables["Samochody"].Rows[i][2].ToString(), silnik = ds.Tables["Samochody"].Rows[i][3].ToString(), pojemnosc = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][4].ToString()), numer_rejestracyjny = ds.Tables["Samochody"].Rows[i][5].ToString(), cenawyp = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][7].ToString()), stantechniczny = ds.Tables["Samochody"].Rows[i][8].ToString(), statuswypoz = Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6].ToString()), przeglad_techniczny = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][11]), OC = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][9]), AC = Convert.ToDateTime(ds.Tables["Samochody"].Rows[i][10]) });
            }
            DGsamo.ItemsSource = listasamoch;

        }
    }
}
