using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace PraktikumStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // Membuat objek mahasiswa
            Mahasiswa mahasiswa = new Mahasiswa(
                24131310056,
                "Iqra Tri Karunia",
                "Teknologi Informasi",
                new List<string>
                {
                    "Pemrograman Jaringan",
                    "Internet of Things",
                    "Integrasi Sistem"
                }
            );

            Console.WriteLine("=== DATA MAHASISWA ASLI ===");
            mahasiswa.TampilkanInfo();

            // SERIALISASI JSON
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(mahasiswa, options);

            // Simpan JSON ke file
            File.WriteAllText("mahasiswa.json", jsonString);

            Console.WriteLine("File mahasiswa.json berhasil disimpan.");

            // Baca kembali file JSON
            string jsonDariFile = File.ReadAllText("mahasiswa.json");

            // Deserialisasi JSON
            Mahasiswa? mahasiswaDariJson =
                JsonSerializer.Deserialize<Mahasiswa>(jsonDariFile);

            Console.WriteLine("\n=== HASIL DESERIALISASI JSON ===");

            if (mahasiswaDariJson != null)
            {
                mahasiswaDariJson.TampilkanInfo();
            }

            // SERIALISASI XML
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(Mahasiswa));

            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, mahasiswa);

                string xmlString = stringWriter.ToString();

                // Simpan XML ke file
                File.WriteAllText("mahasiswa.xml", xmlString);
            }

            Console.WriteLine("File mahasiswa.xml berhasil disimpan.");

            // Baca kembali file XML
            string xmlDariFile = File.ReadAllText("mahasiswa.xml");

            // Deserialisasi XML
            using (StringReader stringReader = new StringReader(xmlDariFile))
            {
                Mahasiswa? mahasiswaDariXml =
                    xmlSerializer.Deserialize(stringReader) as Mahasiswa;

                Console.WriteLine("\n=== HASIL DESERIALISASI XML ===");

                if (mahasiswaDariXml != null)
                {
                    mahasiswaDariXml.TampilkanInfo();
                }
            }

            Console.WriteLine("\nProgram selesai.");
        }
    }
}