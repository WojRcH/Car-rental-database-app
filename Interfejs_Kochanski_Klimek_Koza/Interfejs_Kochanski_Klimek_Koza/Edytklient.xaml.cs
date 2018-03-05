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
    /// Interaction logic for Edytklient.xaml
    /// </summary>
    public partial class Edytklient : Window
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        public class Klient
        {
            public string nazwisko { get; set; }
            public string imie { get; set; }
            public string telefon { get; set; }
            public string miejscowosc { get; set; }
            public string ulica { get; set; }
            public string kodpoczt { get; set; }
            public int nrdokumentu { get; set; }
            public string dokumwydany { get; set; }
        }
        public Edytklient()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Klient> listaklient = new List<Klient>();
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            string zapytaj = "SELECT * FROM Klienci";            
            cs.DataSource = "W-KOMPUTER\\ASUSSQL";
            cs.InitialCatalog = "wyp_sam";
            cs.IntegratedSecurity = true;
            da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            da.Fill(ds, "Klienci");
            int ile = ds.Tables[0].Rows.Count;
            for (int i = 0; i < ile; i++)
            {
                listaklient.Add(new Klient { nazwisko = ds.Tables["Klienci"].Rows[i][1].ToString(), imie = ds.Tables["Klienci"].Rows[i][2].ToString(), telefon = ds.Tables["Klienci"].Rows[i][3].ToString(), miejscowosc = ds.Tables["Klienci"].Rows[i][4].ToString(), ulica = ds.Tables["Klienci"].Rows[i][5].ToString(), kodpoczt = ds.Tables["Klienci"].Rows[i][6].ToString(), nrdokumentu = Convert.ToInt32(ds.Tables["Klienci"].Rows[i][7]), dokumwydany = ds.Tables["Klienci"].Rows[i][8].ToString() });
            }
            DGklienci.ItemsSource = listaklient;
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
                string zapyt = "insert into Klienci values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
                SqlCommand command = new SqlCommand(zapyt, connection);
                command.Parameters.Add("@p1", SqlDbType.NVarChar).Value = txtnazwisko.Text;
                command.Parameters.Add("@p2", SqlDbType.NVarChar).Value = txtimie.Text;
                command.Parameters.Add("@p3", SqlDbType.NVarChar).Value = txttel.Text;
                command.Parameters.Add("@p4", SqlDbType.NVarChar).Value = txtmiejsco.Text;
                command.Parameters.Add("@p5", SqlDbType.NVarChar).Value = txtulicanr.Text;
                command.Parameters.Add("@p6", SqlDbType.NVarChar).Value = txtkodpoczt.Text;
                command.Parameters.Add("@p7", SqlDbType.Int).Value = txtnrdok.Text;
                command.Parameters.Add("@p8", SqlDbType.NVarChar).Value = txtwydanyprzez.Text;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                connection.Close();
                txtnazwisko.Text = null;
                txtimie.Text = null;
                txttel.Text = null;
                txtmiejsco.Text = null;
                txtulicanr.Text = null;
                txtkodpoczt.Text = null;
                txtnrdok.Text = null;
                txtwydanyprzez.Text = null;
                List<Klient> listaklient = new List<Klient>();
                string zapytaj = "SELECT * FROM Klienci";
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
                da.Fill(ds, "Klienci");
                int ile = ds.Tables[0].Rows.Count;
                for (int i = 0; i < ile; i++)
                {
                    listaklient.Add(new Klient { nazwisko = ds.Tables["Klienci"].Rows[i][1].ToString(), imie = ds.Tables["Klienci"].Rows[i][2].ToString(), telefon = ds.Tables["Klienci"].Rows[i][3].ToString(), miejscowosc = ds.Tables["Klienci"].Rows[i][4].ToString(), ulica = ds.Tables["Klienci"].Rows[i][5].ToString(), kodpoczt = ds.Tables["Klienci"].Rows[i][6].ToString(), nrdokumentu = Convert.ToInt32(ds.Tables["Klienci"].Rows[i][7]), dokumwydany = ds.Tables["Klienci"].Rows[i][8].ToString() });
                }
                DGklienci.ItemsSource = listaklient;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Prawdopodobnie któreś pole jest puste lub posiada niedozwolone znaki. " + ex.Message, "Błąd!");
            }
        }

        private void btnusun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ds.Tables["Klienci"].Rows[DGklienci.SelectedIndex].Delete();
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(ds, "Klienci");
                List<Klient> listaklient = new List<Klient>();
                ds.Clear();
                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                string zapytaj = "SELECT * FROM Klienci";
                cs.DataSource = "W-KOMPUTER\\ASUSSQL";
                cs.InitialCatalog = "wyp_sam";
                cs.IntegratedSecurity = true;
                da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
                da.Fill(ds, "Klienci");
                int ile = ds.Tables[0].Rows.Count;
                for (int i = 0; i < ile; i++)
                {
                    listaklient.Add(new Klient { nazwisko = ds.Tables["Klienci"].Rows[i][1].ToString(), imie = ds.Tables["Klienci"].Rows[i][2].ToString(), telefon = ds.Tables["Klienci"].Rows[i][3].ToString(), miejscowosc = ds.Tables["Klienci"].Rows[i][4].ToString(), ulica = ds.Tables["Klienci"].Rows[i][5].ToString(), kodpoczt = ds.Tables["Klienci"].Rows[i][6].ToString(), nrdokumentu = Convert.ToInt32(ds.Tables["Klienci"].Rows[i][7]), dokumwydany = ds.Tables["Klienci"].Rows[i][8].ToString() });
                }
                DGklienci.ItemsSource = listaklient;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Prawdopodobnie klient ma wypożyczone auto w bazie lub nie został wybrany. "+ex.Message, "Błąd!");
            }
        }

        private void btnodswiez_Click(object sender, RoutedEventArgs e)
        {
            List<Klient> listaklient = new List<Klient>();
            ds.Clear();
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            string zapytaj = "SELECT * FROM Klienci";
            cs.DataSource = "W-KOMPUTER\\ASUSSQL";
            cs.InitialCatalog = "wyp_sam";
            cs.IntegratedSecurity = true;
            da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            da.Fill(ds, "Klienci");
            int ile = ds.Tables[0].Rows.Count;
            for (int i = 0; i < ile; i++)
            {
                listaklient.Add(new Klient { nazwisko = ds.Tables["Klienci"].Rows[i][1].ToString(), imie = ds.Tables["Klienci"].Rows[i][2].ToString(), telefon = ds.Tables["Klienci"].Rows[i][3].ToString(), miejscowosc = ds.Tables["Klienci"].Rows[i][4].ToString(), ulica = ds.Tables["Klienci"].Rows[i][5].ToString(), kodpoczt = ds.Tables["Klienci"].Rows[i][6].ToString(), nrdokumentu = Convert.ToInt32(ds.Tables["Klienci"].Rows[i][7]), dokumwydany = ds.Tables["Klienci"].Rows[i][8].ToString() });
            }
            DGklienci.ItemsSource = listaklient;
        }
    }
}
