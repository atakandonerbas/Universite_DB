using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversiteDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source = LAPTOP-MBT9PSM2\SQLEXPRESS; Initial Catalog = UniversiteDB; Integrated Security = True");
            SqlCommand cmd = con.CreateCommand();

            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
            Console.WriteLine($"1) Fakülte İşlemleri\n2) Ders İşlemleri\n3) Bölüm İşlemleri\n4) Öğrenci İşlemleri");
            string secenek = Console.ReadLine();
            Console.Clear();

            con.Open();

            if (secenek == "1")
            {
                Console.WriteLine("Fakülte işlem ekranına hoşgeldiniz.");
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
                Console.WriteLine($"1) Fakülte Listele\n2) Fakülte Güncelle\n3) Fakülte Ekle\n4) Fakülte Sil");
                string secenek1 = Console.ReadLine();
                Console.Clear();

                if (secenek1 == "1")
                {
                    cmd.CommandText = "SELECT ID, Isim, Dekan_ID FROM Fakulte";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        int dekanId = reader.GetInt32(2);
                        Console.WriteLine($"{ID}) {isim} - {dekanId}");
                    }
                    con.Close();

                }
                else if (secenek1 == "2")
                {
                    cmd.CommandText = "SELECT ID, Isim, Dekan_ID FROM Fakulte";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        int dekanId = reader.GetInt32(2);
                        Console.WriteLine($"{ID}) {isim} - {dekanId}");
                    }

                    Console.WriteLine("Güncellemek istediğiniz fakültenin ID numarasını giriniz.");
                    string fakid = Console.ReadLine();

                    Console.WriteLine("Fakülte İsmi = ");
                    string fakisim = Console.ReadLine();

                    Console.WriteLine("Dekan ID = ");
                    int fakdekanid = Convert.ToInt32(Console.ReadLine());

                    cmd.CommandText = "UPDATE Fakulte SET Isim = '" + fakisim + "', Dekan_ID = '" + fakdekanid + "', WHERE ID = " + fakid;


                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Güncelleme işlemi başarılı!");
                        con.Close();
                    }
                    catch
                    {
                        Console.WriteLine("Hata oluştu!");
                        con.Close();
                    }
                }
                else if (secenek1 == "3")
                {

                    Console.WriteLine("Fakülte İsmi = ");
                    string isim = Console.ReadLine();

                    Console.WriteLine("Dekan ID'si = ");
                    string did = Console.ReadLine();

                    try
                    {
                        cmd.CommandText = "INSERT INTO Fakulte(Isim, Dekan_ID) VALUES('" + isim + "', '" + did + "')";

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Ekleme Başarılı!");
                    }
                    catch
                    {
                        Console.WriteLine("Bir Hata Oluştu!");
                    }

                }
                else if (secenek1 == "4")
                {
                    cmd.CommandText = "SELECT ID, Isim, Dekan_ID FROM Fakulte";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        int dekanId = reader.GetInt32(2);
                        Console.WriteLine($"{ID}) {isim} - {dekanId}");
                    }
                    con.Close();
                    con.Open();
                    Console.WriteLine("Silmek istediğiniz fakültenin ID'sini giriniz.");
                    string id = Console.ReadLine();

                    cmd.CommandText = "DELETE FROM Fakulte WHERE ID = " + id;

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Silme İşlemi Başarılı!");
                    con.Close();
                }
                else
                {
                    Console.WriteLine("Sus be");
                }

            }

            else if (secenek == "2")
            {
                Console.WriteLine("Ders işlem ekranına hoşgeldiniz.");
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
                Console.WriteLine($"1) Ders Listele\n2) Ders Güncelle\n3) Ders Ekle\n4) Ders Sil");
                string secenek2 = Console.ReadLine();
                Console.Clear();

                if (secenek2 == "1")
                {
                    cmd.CommandText = "SELECT KOD, Isim, Kredi, Saat, Bolum_ID FROM Ders";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int kod = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        short kredi = reader.GetInt16(2);
                        short saat = reader.GetInt16(3);
                        int bolumId = reader.GetInt32(4);
                        Console.WriteLine($"{kod}) {isim} - {kredi} - {saat} - {bolumId}");
                    }
                }
                else if (secenek2 == "2")
                {
                    cmd.CommandText = "SELECT KOD, Isim, Kredi, Saat, Bolum_ID FROM Ders";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int kod = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        int kredi = reader.GetInt16(2);
                        int saat = reader.GetInt16(3);
                        int bolumId = reader.GetInt32(4);
                        Console.WriteLine($"{kod}) {isim} - {kredi} - {saat} - {bolumId}");
                    }

                    Console.WriteLine("Güncellemek istediğiniz dersin kodunu giriniz.");
                    string derskod = Console.ReadLine();

                    Console.WriteLine("Ders İsmi = ");
                    string dersisim = Console.ReadLine();

                    Console.WriteLine("Kredi = ");
                    int derskredi = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Saat = ");
                    int derssaat = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Bolum ID = ");
                    int dersbolum = Convert.ToInt32(Console.ReadLine());

                    cmd.CommandText = "UPDATE Ders SET Isim = '" + dersisim + "', Kredi = '" + derskredi + "', Saat = '" + derssaat + "', Bolum_ID = '" + dersbolum + "'  WHERE KOD = " + derskod;


                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Güncelleme işlemi başarılı!");
                        con.Close();
                    }
                    catch
                    {
                        Console.WriteLine("Hata oluştu!");
                        con.Close();
                    }
                }
                else if (secenek2 == "3")
                {
                    Console.WriteLine("Ders Kodu = ");
                    int drskod = Console.Read();

                    Console.WriteLine("Ders İsmi = ");
                    string drsisim = Console.ReadLine();

                    Console.WriteLine("Kredi = ");
                    string drskredi = Console.ReadLine();

                    Console.WriteLine("Saat = ");
                    string drssaat = Console.ReadLine();

                    Console.WriteLine("Ders Bölüm Kodu = ");
                    int drsbolum = Console.Read();
                    try
                    {
                        cmd.CommandText = "INSERT INTO Ders(KOD, Isim, Kredi, Saat, Bolum_ID) VALUES('" + drskod + "','" + drsisim + "', '" + drskredi + "', '" + drssaat + "', '" + drsbolum + "')";

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Ekleme Başarılı!");
                    }
                    catch
                    {
                        Console.WriteLine("Bir Hata Oluştu!");
                    }
                }
                else if (secenek2 == "4")
                {
                    cmd.CommandText = "SELECT KOD, Isim, Kredi, Saat, Bolum_ID FROM Ders";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int kod = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        short kredi = reader.GetInt16(2);
                        short saat = reader.GetInt16(3);
                        int bolumId = reader.GetInt32(4);
                        Console.WriteLine($"{kod}) {isim} - {kredi} - {saat} - {bolumId}");
                    }
                    con.Close();
                    con.Open();
                    Console.WriteLine("Silmek istediğiniz dersin kodunu giriniz.");
                    string id = Console.ReadLine();

                    cmd.CommandText = "DELETE FROM Ders WHERE KOD = " + id;

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Silme İşlemi Başarılı!");
                    con.Close();

                }
                else
                {
                    Console.WriteLine("Sus be");
                }
            }

            else if (secenek == "3")
            {
                Console.WriteLine("Bölüm işlem ekranına hoşgeldiniz.");
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
                Console.WriteLine($"1) Bölüm Listele\n2) Bölüm Güncelle\n3) Bölüm Ekle\n4) Bölüm Sil");
                string secenek3 = Console.ReadLine();
                Console.Clear();

                if (secenek3 == "1")
                {
                    cmd.CommandText = "SELECT ID, Isim, Fakulte_ID FROM Bolum";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        int fakulteId = reader.GetInt32(2);
                        Console.WriteLine($"{ID}) {isim} - {fakulteId}");
                    }
                }

                else if (secenek3 == "2")
                {
                    cmd.CommandText = "SELECT ID, Isim, Fakulte_ID FROM Bolum";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        int fakulteId = reader.GetInt32(2);
                        Console.WriteLine($"{ID}) {isim} - {fakulteId}");
                    }

                    Console.WriteLine("Güncellemek istediğiniz bölümün ID numarasını giriniz.");
                    string blmid = Console.ReadLine();

                    Console.WriteLine("Fakülte İsmi = ");
                    string blmisim = Console.ReadLine();

                    Console.WriteLine("Fakülte ID = ");
                    int blmfak = Convert.ToInt32(Console.ReadLine());

                    cmd.CommandText = "UPDATE Bolum SET Isim = '" + blmisim + "', Fakulte_ID = '" + blmfak + "', WHERE ID = " + blmid;


                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Güncelleme işlemi başarılı!");
                        con.Close();
                    }
                    catch
                    {
                        Console.WriteLine("Hata oluştu!");
                        con.Close();
                    }
                }

                else if (secenek3 == "3")
                {
                    Console.WriteLine("Bölüm İsmi = ");
                    int bolumid = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Bölüm İsmi = ");
                    string bolumisim = Console.ReadLine();

                    Console.WriteLine("Fakülte ID'si = ");
                    int bolumfak = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        cmd.CommandText = "INSERT INTO Bolum(ID, Isim, Fakulte_ID) VALUES('" + bolumid + ",''" + bolumisim + "', '" + bolumfak + "')";

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Ekleme Başarılı!");
                    }
                    catch
                    {
                        Console.WriteLine("Bir Hata Oluştu!");
                    }
                }

                else if (secenek3 == "4")
                {
                    cmd.CommandText = "SELECT ID, Isim, Fakulte_ID FROM Bolum";
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        int fakulteId = reader.GetInt32(2);
                        Console.WriteLine($"{ID}) {isim} - {fakulteId}");
                    }

                    con.Close();
                    con.Open();
                    Console.WriteLine("Silmek istediğiniz bölümün ID'sini giriniz.");
                    string id = Console.ReadLine();

                    cmd.CommandText = "DELETE FROM Bolum WHERE ID = " + id;

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Silme İşlemi Başarılı!");
                    con.Close();
                }

                else
                {
                    Console.WriteLine("Sus be");
                }
            }

            else if (secenek == "4")
            {
                Console.WriteLine("Öğrenci işlem ekranına hoşgeldiniz.");
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
                Console.WriteLine($"1) Öğrenci Listele\n2) Öğrenci Güncelle\n3) Öğrenci Ekle\n4) Öğrenci Sil");
                string secenek4 = Console.ReadLine();
                Console.Clear();

                if (secenek4 == "1")
                {
                    cmd.CommandText = "SELECT Okul_No, Isim, SoyIsim, BabaAdi, Bolum_No FROM Ogrenci";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int okul_No = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        string soyIsim = reader.GetString(2);
                        string BabaAdi = reader.GetString(3);
                        int bolumNo = reader.GetInt32(4);
                        Console.WriteLine($"{okul_No}) {isim} - {soyIsim} - {BabaAdi} - {bolumNo}");
                    }

                }
                else if (secenek4 == "2")
                {
                    cmd.CommandText = "SELECT Okul_No, Isim, SoyIsim, BabaAdi, Bolum_No FROM Ogrenci";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int okul_No = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        string soyIsim = reader.GetString(2);
                        string BabaAdi = reader.GetString(3);
                        int bolumNo = reader.GetInt32(4);
                        Console.WriteLine($"{okul_No}) {isim} - {soyIsim} - {BabaAdi} - {bolumNo}");
                    }

                    Console.WriteLine("Güncellemek istediğiniz öğrencinin okul numarasını giriniz.");
                    string ogrid = Console.ReadLine();

                    Console.WriteLine("Fakülte İsmi = ");
                    string ogrisim = Console.ReadLine();

                    Console.WriteLine("Dekan ID = ");
                    string ogrsoyisim = Console.ReadLine();

                    Console.WriteLine("Dekan ID = ");
                    string ogrbaba = Console.ReadLine();

                    Console.WriteLine("Dekan ID = ");
                    string ogrblm = Console.ReadLine();

                    cmd.CommandText = "UPDATE Ogrenci SET Isim = '" + ogrisim + "', SoyIsim = '" + ogrsoyisim + "', BabaAdi = '" + ogrbaba + "', Bolum_NO = '" + ogrblm + "' WHERE Okul_No = " + ogrid;


                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Güncelleme işlemi başarılı!");
                        con.Close();
                    }
                    catch
                    {
                        Console.WriteLine("Hata oluştu!");
                        con.Close();
                    }

                }

                else if (secenek4 == "3")
                {
                    Console.WriteLine("Öğrenci No = ");
                    int ogrenci_no = Console.Read();

                    Console.WriteLine("Öğrenci İsmi = ");
                    string ogrenci_isim = Console.ReadLine();

                    Console.WriteLine("Öğrenci Soyismi = ");
                    string ogrenci_soyisim = Console.ReadLine();

                    Console.WriteLine("Oğrenci Baba İsmi = ");
                    string ogrenci_baba = Console.ReadLine();

                    Console.WriteLine("Ogrencı Bölüm No = ");
                    int ogrenci_bolum = Console.Read();
                    try
                    {
                        cmd.CommandText = "INSERT INTO Öğrenci(Okul_No, Isim, SoyIsim, BabaAdi, Bolum_No) VALUES('" + ogrenci_no + "','" + ogrenci_isim + "', '" + ogrenci_soyisim + "', '" + ogrenci_baba + "', '" + ogrenci_bolum + "')";

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Ekleme Başarılı!");
                    }
                    catch
                    {
                        Console.WriteLine("Bir Hata Oluştu!");
                    }
                }

                else if (secenek4 == "4")
                {
                    cmd.CommandText = "SELECT Okul_No, Isim, SoyIsim, BabaAdi, Bolum_No FROM Ogrenci";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int okul_No = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        string soyIsim = reader.GetString(2);
                        string BabaAdi = reader.GetString(3);
                        int bolumNo = reader.GetInt32(4);
                        Console.WriteLine($"{okul_No}) {isim} - {soyIsim} - {BabaAdi} - {bolumNo}");
                    }
                    con.Close();
                    con.Open();
                    Console.WriteLine("Silmek istediğiniz öğrencinin ID'sini giriniz.");
                    string id = Console.ReadLine();

                    cmd.CommandText = "DELETE FROM Ogrenci WHERE ID = " + id;

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Silme İşlemi Başarılı!");
                    con.Close();
                }

                else
                {
                    Console.WriteLine("Sus be");
                }
            }

            else
            {
                Console.WriteLine("Sus be");
            }

            con.Close();
        }
    }
}
