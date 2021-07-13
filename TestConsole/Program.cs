using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Plugin1.Clases;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false,
                Mode = CsvMode.NoEscape
            };
            string folderPath = @"Z:\DARBS\2021\PROJEKTI\ARA_2021_L06_BK0_PAMATI_angars_MUIZAS_3_K_BEDRITIS_JF\3_KONSTRUKCIJAS\3_Teklas modeli\GH_FAILI\References\2021.07.21_Ramis_3D_KOPNU_SHEMA\";
            string filepath = folderPath + "1.1 Nodes.csv";
            using(var streamReader = new StreamReader(filepath))
            {
                using (var csvReader = new CsvReader(streamReader, config))
                {
                    var Nodes = csvReader.GetRecords<Node>().ToList();
                }
            }
        }
    }
}
