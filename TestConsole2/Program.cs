using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Data;
using System.Collections.Generic;

namespace TestConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> Members = new List<Member>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false,
                Mode = CsvMode.NoEscape
            };
            string folderPath = @"Z:\DARBS\2021\PROJEKTI\ARA_2021_L06_BK0_PAMATI_angars_MUIZAS_3_K_BEDRITIS_JF\3_KONSTRUKCIJAS\3_Teklas modeli\GH_FAILI\References\2021.07.21_Ramis_3D_KOPNU_SHEMA\";
            string filepath = folderPath + "1.17 Members.csv";
            using (var streamReader = new StreamReader(filepath))
            {
                using (var csvReader = new CsvReader(streamReader, config))
                {
                    csvReader.Context.RegisterClassMap<MemberMap>();
                    Members = csvReader.GetRecords<Member>().ToList();
                }
            }
            
            
        }
    }
}
