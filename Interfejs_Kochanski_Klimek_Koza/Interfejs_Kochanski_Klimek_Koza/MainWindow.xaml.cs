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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Interfejs_Kochanski_Klimek_Koza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlDataAdapter da;
        SqlDataAdapter dawyp;
        SqlDataAdapter dakli;
        DataSet ds = new DataSet();
        DataSet dswyp = new DataSet();
        DataSet dskli = new DataSet();       

        public MainWindow()
        {
            InitializeComponent();
           
            //DataContext = new ViewModel();

        }
        //public class ViewModel
        //{
        //    public ObservableCollection<string> CmbContent { get; private set; }

        //    public ViewModel()
        //    {
        //        CmbContent = new ObservableCollection<string>
        //        {
        //        "test 1",
        //        "test 2"
        //        };
        //    }
        //}
        public class Rezerwuj
        {
            public string stan_rezerwacji { get; set; }
            public DateTime OD { get; set; }
            public DateTime DO { get; set; }
            public int ID_klient { get; set; }
            public int ID_samochod { get; set; }
        }
        public class Wypozyczenie
        {
            public int ID_rezer { get; set; }
            public string marka { get; set; }
            public string model { get; set; }
            public string numer_rejestracyjny { get; set; }
            public string stan_rezerwacji { get; set; }
            public DateTime OD { get; set; }
            public DateTime DO { get; set; }
            public string nazwisko { get; set; }
            public string imie { get; set; }
            public string telefon { get; set; }
            public int nrdokumentu { get; set; }
            public bool czywyp { get; set; }
        }
        public class Klient
        {
            public int ID_klient { get; set; }
            public string klient { get; set; }            
        }
        public class Samochod
        {
            public int ID_samochod { get; set; }
            public string marka { get; set; }
            public string model { get; set; }
            public string silnik { get; set; }
            public int pojemnosc { get; set; }
            public string numer_rejestracyjny { get; set; }
            public int cena { get; set; }
            public string stantechniczny { get; set; }
            public bool statuswypoz { get; set; }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DPdzis.SelectedDate = DateTime.Now.Date;
            DPdzis2.SelectedDate = DateTime.Now.Date;
            DPdzis3.SelectedDate = DateTime.Now.Date;
            int ilesam, ilewyp, ilekli;
            List<Klient> listaklientow = new List<Klient>();
            List<Samochod> listasamochwyp = new List<Samochod>();
            List<Samochod> listasamochodd = new List<Samochod>();
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            
            string zapytaj = "SELECT * FROM Samochody";
            cs.DataSource = "W-KOMPUTER\\ASUSSQL";
            cs.InitialCatalog = "wyp_sam";
            cs.IntegratedSecurity = true;
            da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            da.Fill(ds, "Samochody");
            ilesam = ds.Tables[0].Rows.Count;
            //DGwypoz.ItemsSource = ds.Tables["Samochody"].DefaultView;//cala tablea wypisana do gridview autocolumns
            for (int i = 0; i < ilesam; i++)
            {
                if (Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6]) == false)//niewypozyczone
                {
                    listasamochwyp.Add(new Samochod() { ID_samochod= Convert.ToInt32(ds.Tables["Samochody"].Rows[i][0].ToString()), marka = ds.Tables["Samochody"].Rows[i][1].ToString(), model = ds.Tables["Samochody"].Rows[i][2].ToString(), silnik = ds.Tables["Samochody"].Rows[i][3].ToString(), pojemnosc = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][4].ToString()), numer_rejestracyjny = ds.Tables["Samochody"].Rows[i][5].ToString(), cena = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][7].ToString()), stantechniczny = ds.Tables["Samochody"].Rows[i][8].ToString(), statuswypoz = Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6].ToString()) });
                }
                else
                { listasamochodd.Add(new Samochod() { ID_samochod = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][0].ToString()), marka = ds.Tables["Samochody"].Rows[i][1].ToString(), model = ds.Tables["Samochody"].Rows[i][2].ToString(), silnik = ds.Tables["Samochody"].Rows[i][3].ToString(), pojemnosc = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][4].ToString()), numer_rejestracyjny = ds.Tables["Samochody"].Rows[i][5].ToString(), cena = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][7].ToString()), stantechniczny = ds.Tables["Samochody"].Rows[i][8].ToString(), statuswypoz = Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6].ToString()) }); }
            }
            DGwypo.ItemsSource = listasamochwyp;
            DGzwrot.ItemsSource = listasamochodd;

            List<Wypozyczenie> listawypozyczen = new List<Wypozyczenie>();
            zapytaj = "select ID_Rezerwacji,Marka,Model,Numer_rejestracyjny,Stan_rezerwacji,Rezerwuj_od,Rezerwuj_do,Nazwisko,Imie,Tel_kontaktowy,Nr_dokumentu,Status_wypozyczenia from Rezerwacje r inner join Samochody s on r.ID_Samochod=s.ID_Samochodu inner join Klienci k on r.ID_Klienta=k.ID_Klienta";
            dawyp = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            dawyp.Fill(dswyp, "Wypozyczenia");
            ilewyp = dswyp.Tables[0].Rows.Count;
            for (int i = 0; i < ilewyp; i++)
            {
                if (Convert.ToBoolean(dswyp.Tables["Wypozyczenia"].Rows[i][11]) == true) {
                    listawypozyczen.Add(new Wypozyczenie() { marka = dswyp.Tables["Wypozyczenia"].Rows[i][1].ToString(), model = dswyp.Tables["Wypozyczenia"].Rows[i][2].ToString(), numer_rejestracyjny = dswyp.Tables["Wypozyczenia"].Rows[i][3].ToString(),stan_rezerwacji= dswyp.Tables["Wypozyczenia"].Rows[i][4].ToString(),OD= Convert.ToDateTime(dswyp.Tables["Wypozyczenia"].Rows[i][5].ToString()),DO= Convert.ToDateTime(dswyp.Tables["Wypozyczenia"].Rows[i][6].ToString()),nazwisko= dswyp.Tables["Wypozyczenia"].Rows[i][7].ToString(),imie= dswyp.Tables["Wypozyczenia"].Rows[i][8].ToString(),telefon= dswyp.Tables["Wypozyczenia"].Rows[i][9].ToString(),nrdokumentu= Convert.ToInt32(dswyp.Tables["Wypozyczenia"].Rows[i][10].ToString()) });
                    }
            }
            DGprzeg.ItemsSource = listawypozyczen;

            zapytaj = "Select CONCAT (nazwisko,' ',imie,' nr dokumentu: ',Nr_dokumentu), ID_Klienta from Klienci";
            dakli = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            dakli.Fill(dskli, "Klienci");
            ilekli = dskli.Tables[0].Rows.Count;
            for (int i = ilekli; i > 0; i--)
            {
                listaklientow.Add(new Klient() { klient = dskli.Tables["Klienci"].Rows[i - 1][0].ToString(),ID_klient=Convert.ToInt32(dskli.Tables["Klienci"].Rows[i - 1][1].ToString()) });
            }
            CBklient.ItemsSource = listaklientow;
        }

        private void MIklient_Click(object sender, RoutedEventArgs e)
        {
            Edytklient edytklient = new Edytklient();
            edytklient.ShowDialog();
        }

        private void MIsamochod_Click(object sender, RoutedEventArgs e)
        {
            Edytsamochod edytsamochod = new Edytsamochod();
            edytsamochod.ShowDialog();
        }                

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                cs.DataSource = "W-KOMPUTER\\ASUSSQL";
                cs.InitialCatalog = "wyp_sam";
                cs.IntegratedSecurity = true;
                SqlConnection connection = new SqlConnection(cs.ToString());
                connection.Open();
                string zapyt = "insert into Rezerwacje values (@p1,@p2,@p3,@p4,@p5)";
                SqlCommand command = new SqlCommand(zapyt, connection);
                command.Parameters.Add("@p1", SqlDbType.NVarChar).Value = TBuwagi.Text.ToString();
                command.Parameters.Add("@p2", SqlDbType.Date).Value = Convert.ToDateTime(DPdzis.ToString());
                command.Parameters.Add("@p3", SqlDbType.Date).Value = Convert.ToDateTime(DPdokiedy.ToString());
                command.Parameters.Add("@p4", SqlDbType.Int).Value = CBklient.SelectedIndex + 1;
                command.Parameters.Add("@p5", SqlDbType.Int).Value = DGwypo.SelectedIndex + 1;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                connection.Close();                
                int ileDGzwro = DGzwrot.Items.Count;
                ds.Tables["Samochody"].Rows[DGwypo.SelectedIndex + ileDGzwro][6] = true;
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(ds, "Samochody");
                MessageBox.Show("Samochód o ID: " + (DGwypo.SelectedIndex).ToString() + " został wypożyczony pomyślnie.", "Samochód wypożyczony!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Prawdopodobnie wkradł się błąd. " + ex.Message, "Błąd!");
            }


            //Rezerwuj rezerwuj = new Rezerwuj();
            
            //rezerwuj.OD = Convert.ToDateTime(DPdzis.ToString());
            //rezerwuj.DO = Convert.ToDateTime(DPdokiedy.ToString());
            //rezerwuj.ID_klient = CBklient.SelectedIndex;
            //rezerwuj.ID_samochod = DGwypo.SelectedIndex;
                             
        }

        private void btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            ds.Clear();
            dswyp.Clear();            
            DPdzis.SelectedDate = DateTime.Now.Date;
            DPdzis2.SelectedDate = DateTime.Now.Date;
            DPdzis3.SelectedDate = DateTime.Now.Date;
            int ilesam, ilewyp;            
            List<Samochod> listasamochwyp = new List<Samochod>();
            List<Samochod> listasamochodd = new List<Samochod>();
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();

            string zapytaj = "SELECT * FROM Samochody";
            cs.DataSource = "W-KOMPUTER\\ASUSSQL";
            cs.InitialCatalog = "wyp_sam";
            cs.IntegratedSecurity = true;
            da = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            da.Fill(ds, "Samochody");
            ilesam = ds.Tables[0].Rows.Count;
            //DGwypoz.ItemsSource = ds.Tables["Samochody"].DefaultView;//cala tablea wypisana do gridview autocolumns
            for (int i = 0; i < ilesam; i++)
            {
                if (Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6]) == false)//niewypozyczone
                {
                    listasamochwyp.Add(new Samochod() { ID_samochod= Convert.ToInt32(ds.Tables["Samochody"].Rows[i][0].ToString()), marka = ds.Tables["Samochody"].Rows[i][1].ToString(), model = ds.Tables["Samochody"].Rows[i][2].ToString(), silnik = ds.Tables["Samochody"].Rows[i][3].ToString(), pojemnosc = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][4].ToString()), numer_rejestracyjny = ds.Tables["Samochody"].Rows[i][5].ToString(), cena = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][7].ToString()), stantechniczny = ds.Tables["Samochody"].Rows[i][8].ToString(), statuswypoz = Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6].ToString()) });
                }
                else
                { listasamochodd.Add(new Samochod() { ID_samochod = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][0].ToString()), marka = ds.Tables["Samochody"].Rows[i][1].ToString(), model = ds.Tables["Samochody"].Rows[i][2].ToString(), silnik = ds.Tables["Samochody"].Rows[i][3].ToString(), pojemnosc = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][4].ToString()), numer_rejestracyjny = ds.Tables["Samochody"].Rows[i][5].ToString(), cena = Convert.ToInt32(ds.Tables["Samochody"].Rows[i][7].ToString()), stantechniczny = ds.Tables["Samochody"].Rows[i][8].ToString(), statuswypoz = Convert.ToBoolean(ds.Tables["Samochody"].Rows[i][6].ToString()) }); }
            }
            DGwypo.ItemsSource = listasamochwyp;
            DGzwrot.ItemsSource = listasamochodd;

            List<Wypozyczenie> listawypozyczen = new List<Wypozyczenie>();
            zapytaj = "select ID_Rezerwacji,Marka,Model,Numer_rejestracyjny,Stan_rezerwacji,Rezerwuj_od,Rezerwuj_do,Nazwisko,Imie,Tel_kontaktowy,Nr_dokumentu,Status_wypozyczenia from Rezerwacje r inner join Samochody s on r.ID_Samochod=s.ID_Samochodu inner join Klienci k on r.ID_Klienta=k.ID_Klienta";
            dawyp = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            dawyp.Fill(dswyp, "Wypozyczenia");
            ilewyp = dswyp.Tables[0].Rows.Count;
            for (int i = ilewyp; i > 0; i--)
            {
                if (Convert.ToBoolean(dswyp.Tables["Wypozyczenia"].Rows[i - 1][11]) == true)
                {
                    listawypozyczen.Add(new Wypozyczenie() { marka = dswyp.Tables["Wypozyczenia"].Rows[i - 1][1].ToString(), model = dswyp.Tables["Wypozyczenia"].Rows[i - 1][2].ToString(), numer_rejestracyjny = dswyp.Tables["Wypozyczenia"].Rows[i - 1][3].ToString(), stan_rezerwacji = dswyp.Tables["Wypozyczenia"].Rows[i - 1][4].ToString(), OD = Convert.ToDateTime(dswyp.Tables["Wypozyczenia"].Rows[i - 1][5].ToString()), DO = Convert.ToDateTime(dswyp.Tables["Wypozyczenia"].Rows[i - 1][6].ToString()), nazwisko = dswyp.Tables["Wypozyczenia"].Rows[i - 1][7].ToString(), imie = dswyp.Tables["Wypozyczenia"].Rows[i - 1][8].ToString(), telefon = dswyp.Tables["Wypozyczenia"].Rows[i - 1][9].ToString(), nrdokumentu = Convert.ToInt32(dswyp.Tables["Wypozyczenia"].Rows[i - 1][10].ToString()) });
                }
            }
            DGprzeg.ItemsSource = listawypozyczen;
            List<Klient> listaklientow = new List<Klient>();
            zapytaj = "Select CONCAT (nazwisko,' ',imie,' nr dokumentu: ',Nr_dokumentu), ID_Klienta from Klienci";
            dskli.Clear();
            dakli = new SqlDataAdapter(zapytaj, cs.ConnectionString);
            dakli.Fill(dskli, "Klienci");
            int ilekli = dskli.Tables[0].Rows.Count;
            for (int i = ilekli; i > 0; i--)
            {
                listaklientow.Add(new Klient() { klient = dskli.Tables["Klienci"].Rows[i - 1][0].ToString(), ID_klient = Convert.ToInt32(dskli.Tables["Klienci"].Rows[i - 1][1].ToString()) });
            }
            CBklient.ItemsSource = listaklientow;


        }

        private void btnoddaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                List<Rezerwuj> rezerwacje = new List<Rezerwuj>();
                string zapytaj = "Select * from Rezerwacje";
                cs.DataSource = "W-KOMPUTER\\ASUSSQL";
                cs.InitialCatalog = "wyp_sam";
                cs.IntegratedSecurity = true;
                SqlDataAdapter darez = new SqlDataAdapter(zapytaj, cs.ConnectionString);
                DataSet dsrez = new DataSet();
                darez.Fill(dsrez, "Rezerwuj");
                int ilerez = dsrez.Tables[0].Rows.Count;


                for (int i = 0; i < ilerez; i++)
                {
                    rezerwacje.Add(new Rezerwuj() { stan_rezerwacji = dsrez.Tables["Rezerwuj"].Rows[i][1].ToString(),OD= Convert.ToDateTime(dsrez.Tables["Rezerwuj"].Rows[i][2].ToString()), DO = Convert.ToDateTime(dsrez.Tables["Rezerwuj"].Rows[i][3].ToString()),ID_klient = Convert.ToInt32(dsrez.Tables["Rezerwuj"].Rows[i][4].ToString()),ID_samochod= Convert.ToInt32(dsrez.Tables["Rezerwuj"].Rows[i][5].ToString()) });
                }
                int ileDGwyp = DGwypo.Items.Count;
                ds.Tables["Samochody"].Rows[DGzwrot.SelectedIndex][6] = false;
                dsrez.Tables["Rezerwuj"].Rows[DGzwrot.SelectedIndex].Delete();
                SqlCommandBuilder builder = new SqlCommandBuilder(darez);
                darez.Update(dsrez, "Rezerwuj");
                SqlCommandBuilder builder2 = new SqlCommandBuilder(da);
                da.Update(ds, "Samochody");
                MessageBox.Show("Samochód o ID: " + (DGzwrot.SelectedIndex).ToString() + " został zwrócony pomyślnie.", "Samochód zwrócony!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Prawdopodobnie wkradł się błąd. " + ex.Message, "Błąd!");
            }
        }
    }
}