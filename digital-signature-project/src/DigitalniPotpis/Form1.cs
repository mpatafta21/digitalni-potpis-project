using DigitalniPotpis.Kriptografija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalniPotpis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ProvjeriKljuceve();

            txtUnos.Text = "Unesite svoju poruku ovdje...";
            txtUnos.ForeColor = Color.Gray;

            txtUnos.GotFocus += txtUnos_GotFocus;
            txtUnos.LostFocus += txtUnos_LostFocus;
        }

        private void btnGenerirajSimetricni_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                if (!Directory.Exists(direktorij))
                {
                    Directory.CreateDirectory(direktorij);
                }

                string putDoTajnogKljuca = Path.Combine(direktorij, "tajni_kljuc.txt");
                GeneratorKljuca.GenerirajAESKljuc(putDoTajnogKljuca);

                MessageBox.Show("Simetrični ključ uspješno generiran!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AzurirajTerminal(putDoTajnogKljuca);

                ProvjeriKljuceve();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška: {ex.Message}", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerirajAsimetricni_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                if (!Directory.Exists(direktorij))
                {
                    Directory.CreateDirectory(direktorij);
                }

                string putDoJavnogKljuca = Path.Combine(direktorij, "javni_kljuc.txt");
                string putDoPrivatnogKljuca = Path.Combine(direktorij, "privatni_kljuc.txt");
                GeneratorKljuca.GenerirajRSAKljuceve(putDoJavnogKljuca, putDoPrivatnogKljuca);

                MessageBox.Show("Asimetrični ključevi uspješno generirani!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AzurirajTerminal(putDoJavnogKljuca, putDoPrivatnogKljuca);

                ProvjeriKljuceve();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška: {ex.Message}", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProvjeriKljuceve()
        {
            string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");

            string tajniKljucDatoteka = Path.Combine(direktorij, "tajni_kljuc.txt");
            bool simetricniKljuceviPostoje = File.Exists(tajniKljucDatoteka);

            string javniKljucDatoteka = Path.Combine(direktorij, "javni_kljuc.txt");
            string privatniKljucDatoteka = Path.Combine(direktorij, "privatni_kljuc.txt");
            bool asimetricniKljuceviPostoje = File.Exists(javniKljucDatoteka) && File.Exists(privatniKljucDatoteka);

            btnKriptirajSimetricno.Enabled = simetricniKljuceviPostoje;
            btnDekriptirajSimetricno.Enabled = simetricniKljuceviPostoje;

            btnKriptirajAsimetricno.Enabled = asimetricniKljuceviPostoje;
            btnDekriptirajAsimetricno.Enabled = asimetricniKljuceviPostoje;
        }


        private void btnKriptirajSimetricno_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                string ulaznaDatoteka = Path.Combine(direktorij, "ulazna_poruka.txt");
                string kriptiranaDatoteka = Path.Combine(direktorij, "kriptirano_simetricno.txt");
                string tajniKljucDatoteka = Path.Combine(direktorij, "tajni_kljuc.txt");

                if (!File.Exists(ulaznaDatoteka))
                {
                    MessageBox.Show("Greška: Nije spremljena poruka za kriptiranje. Molimo prvo unesite i spremite poruku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Kriptiranje.KriptirajSimetricno(ulaznaDatoteka, kriptiranaDatoteka, tajniKljucDatoteka);
                MessageBox.Show("Datoteka je uspješno kriptirana (simetrično)!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AzurirajTerminal(kriptiranaDatoteka);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška: {ex.Message}", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKriptirajAsimetricno_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                string ulaznaDatoteka = Path.Combine(direktorij, "ulazna_poruka.txt");
                string kriptiranaDatoteka = Path.Combine(direktorij, "kriptirano_asimetricno.txt");
                string javniKljucDatoteka = Path.Combine(direktorij, "javni_kljuc.txt");

                if (!File.Exists(ulaznaDatoteka))
                {
                    MessageBox.Show("Greška: Nije spremljena poruka za kriptiranje. Molimo prvo unesite i spremite poruku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sadrzaj = File.ReadAllText(ulaznaDatoteka);
                string kriptirano = Kriptiranje.KriptirajAsimetricno(sadrzaj, javniKljucDatoteka);
                File.WriteAllText(kriptiranaDatoteka, kriptirano);

                MessageBox.Show("Datoteka je uspješno kriptirana (asimetrično)!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AzurirajTerminal(kriptiranaDatoteka);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška: {ex.Message}", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDekriptirajSimetricno_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                string ulaznaDatoteka = Path.Combine(direktorij, "ulazna_poruka.txt");
                string kriptiranaDatoteka = Path.Combine(direktorij, "kriptirano_simetricno.txt");
                string dekriptiranaDatoteka = Path.Combine(direktorij, "dekriptirano_simetricno.txt");
                string tajniKljucDatoteka = Path.Combine(direktorij, "tajni_kljuc.txt");

                if (!File.Exists(ulaznaDatoteka))
                {
                    MessageBox.Show("Greška: Nije spremljena poruka za dekriptiranje. Molimo prvo unesite i spremite poruku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(kriptiranaDatoteka))
                {
                    MessageBox.Show("Greška: Nema kriptirane datoteke za dekriptiranje. Molimo prvo kriptirajte poruku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Kriptiranje.DekriptirajSimetricno(kriptiranaDatoteka, dekriptiranaDatoteka, tajniKljucDatoteka);
                MessageBox.Show("Datoteka je uspješno dekriptirana (simetrično)!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AzurirajTerminal(dekriptiranaDatoteka);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška: {ex.Message}", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDekriptirajAsimetricno_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                string ulaznaDatoteka = Path.Combine(direktorij, "ulazna_poruka.txt");
                string kriptiranaDatoteka = Path.Combine(direktorij, "kriptirano_asimetricno.txt");
                string dekriptiranaDatoteka = Path.Combine(direktorij, "dekriptirano_asimetricno.txt");
                string privatniKljucDatoteka = Path.Combine(direktorij, "privatni_kljuc.txt");

                if (!File.Exists(ulaznaDatoteka))
                {
                    MessageBox.Show("Greška: Nije spremljena poruka za dekriptiranje. Molimo prvo unesite i spremite poruku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(kriptiranaDatoteka))
                {
                    MessageBox.Show("Greška: Nema kriptirane datoteke za dekriptiranje. Molimo prvo kriptirajte poruku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string kriptirano = File.ReadAllText(kriptiranaDatoteka);
                string dekriptirano = Kriptiranje.DekriptirajAsimetricno(kriptirano, privatniKljucDatoteka);
                File.WriteAllText(dekriptiranaDatoteka, dekriptirano);

                MessageBox.Show("Datoteka je uspješno dekriptirana (asimetrično)!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AzurirajTerminal(dekriptiranaDatoteka);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška: {ex.Message}", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSpremiTekst_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                if (!Directory.Exists(direktorij))
                {
                    Directory.CreateDirectory(direktorij);
                }

                string ulaznaDatoteka = Path.Combine(direktorij, "ulazna_poruka.txt");

                File.WriteAllText(ulaznaDatoteka, txtUnos.Text);

                MessageBox.Show("Tekst poruke je uspješno spremljen u datoteku!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška: {ex.Message}", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIzracunajSazetak_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                string ulaznaDatoteka = Path.Combine(direktorij, "ulazna_poruka.txt");
                string sazetakDatoteka = Path.Combine(direktorij, "sazetak.txt");

                Kriptiranje.IzracunajSazetak(ulaznaDatoteka, sazetakDatoteka);
                MessageBox.Show("Sažetak uspješno izračunat!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AzurirajTerminal(sazetakDatoteka);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: Prazan sadržaj poruke! \n\n Upišite i spremite sadržaj poruke", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPotpisiSazetak_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                string sazetakDatoteka = Path.Combine(direktorij, "sazetak.txt");
                string potpisDatoteka = Path.Combine(direktorij, "potpis.txt");
                string privatniKljucDatoteka = Path.Combine(direktorij, "privatni_kljuc.txt");

                if (!File.Exists(sazetakDatoteka))
                {
                    MessageBox.Show("Greška: Sažetak nije generiran. Molimo prvo generirajte sažetak.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(privatniKljucDatoteka))
                {
                    MessageBox.Show("Greška: Privatni ključ nije generiran. Molimo prvo generirajte asimetrične ključeve.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Kriptiranje.PotpisiSazetak(sazetakDatoteka, potpisDatoteka, privatniKljucDatoteka);
                MessageBox.Show("Sažetak uspješno potpisan!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AzurirajTerminal(potpisDatoteka);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška: Ne postoji sažetak poruke!", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProvjeriPotpis_Click(object sender, EventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");
                string sazetakDatoteka = Path.Combine(direktorij, "sazetak.txt");
                string potpisDatoteka = Path.Combine(direktorij, "potpis.txt");
                string javniKljucDatoteka = Path.Combine(direktorij, "javni_kljuc.txt");


                if (!File.Exists(javniKljucDatoteka))
                {
                    MessageBox.Show("Greška: Javni ključ nije generiran. Molimo prvo generirajte asimetrične ključeve.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(sazetakDatoteka))
                {
                    MessageBox.Show("Greška: Sažetak poruke nije generiran. Molimo prvo generirajte sažetak.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(potpisDatoteka))
                {
                    MessageBox.Show("Greška: Poruka nije potpisana. Molimo prvo potpišite sažetak.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                bool ispravan = Kriptiranje.ProvjeriPotpis(sazetakDatoteka, potpisDatoteka, javniKljucDatoteka);

                if (ispravan)
                {
                    MessageBox.Show("Potpis je ispravan!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Potpis nije ispravan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška: {ex.Message}", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string direktorij = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kreirane datoteke");

                if (Directory.Exists(direktorij))
                {
                    string[] sveDatoteke = Directory.GetFiles(direktorij, "*.*");

                    foreach (string datoteka in sveDatoteke)
                    {
                        File.Delete(datoteka);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom brisanja datoteka: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AzurirajTerminal(params string[] datoteke)
        {
   
            var sb = new StringBuilder();

            foreach (string datoteka in datoteke)
            {
                if (File.Exists(datoteka))
                {
                    string imeDatoteke = Path.GetFileName(datoteka);
                    string sadrzaj = File.ReadAllText(datoteka);

                    sb.AppendLine($"[Sadržaj datoteke: {imeDatoteke}]");
                    sb.AppendLine();
                    sb.AppendLine(sadrzaj);
                    sb.AppendLine(); 
                }
                else
                {
                    string imeDatoteke = Path.GetFileName(datoteka);
                    sb.AppendLine($"[Datoteka {imeDatoteke} ne postoji!]");
                    sb.AppendLine();
                }
            }

            txtTerminal.Text = sb.ToString();

        }

        private void txtUnos_GotFocus(object sender, EventArgs e)
        {
            if (txtUnos.Text == "Unesite svoju poruku ovdje...")
            {
                txtUnos.Text = ""; 
                txtUnos.ForeColor = Color.Black; 
            }
        }

        private void txtUnos_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnos.Text))
            {
                txtUnos.Text = "Unesite svoju poruku ovdje..."; 
                txtUnos.ForeColor = Color.Gray; 
            }
        }


    }
}
