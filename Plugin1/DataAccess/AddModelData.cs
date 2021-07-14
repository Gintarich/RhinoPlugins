using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Plugin1.Clases;
using Rhino.Geometry;
using MemberMap = Plugin1.Clases.MemberMap;

namespace Plugin1.DataAccess
{
    class AddModelData
    {
        /// <summary>
        /// Gets Members from suplied csv path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<MemberSet> GetModel(string folderPath)
        {
            List<MemberSet> setsOfMembers = new List<MemberSet>();
            Dictionary<int, Node> Nodes = new Dictionary<int, Node>();
            List<Point3d> rPoints = new List<Point3d>();

            //Populate nodes
            var nodes = GetNodes(folderPath);
            //populate lines
            var lines = GetLines(folderPath);
            //populate members
            var members = GetMembers(folderPath);
            //populate sets of members
            setsOfMembers = GetSetsOfMembers(folderPath);
            //Populate profiles 
            var profiles = GetProfiles(folderPath);

            //Set Profile Values
            foreach (var profile in profiles)
            {
                profile.SetValue();
            }

            //Convert model from meters to milimeters, flip it and get rhino Points out of it
            foreach (Node node in nodes)
            {
                node.Magnify();
                node.Flip();
                rPoints.Add(node.GetRhinoPoint());
            }
            
            //Add Node objec to line object
            foreach (var line in lines)
            {
                line.PopulateNodes(nodes);
            }

            //Add Line object to Member object
            foreach (var member in members)
            {
                member.PopulateLines(lines);
            }

            //Add Member object to Memberset object
            foreach (var set in setsOfMembers)
            {
                set.PopulateMembers(members);
            }
            

            return setsOfMembers;
        }
        public static List<Node> GetNodes(string folderPath)
        {
            List<Node> Nodes = new List<Node>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false,
                Mode = CsvMode.NoEscape
            };
            
            string filepath = folderPath + "1.1 Nodes.csv";
            using (var streamReader = new StreamReader(filepath))
            {
                using (var csvReader = new CsvReader(streamReader, config))
                {
                    csvReader.Context.RegisterClassMap<NodeMap>();
                    Nodes = csvReader.GetRecords<Node>().ToList();
                }
            }
            return Nodes;
        }
        public static List<Clases.Line> GetLines(string folderPath)
        {
            List<Clases.Line> Lines = new List<Clases.Line>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false,
                Mode = CsvMode.NoEscape
            };
            string filepath = folderPath + "1.2 Lines.csv";
            using (var streamReader = new StreamReader(filepath))
            {
                using (var csvReader = new CsvReader(streamReader, config))
                {
                    csvReader.Context.RegisterClassMap<LineMap>();
                    Lines = csvReader.GetRecords<Clases.Line>().ToList();
                }
            }
            return Lines;
        }
        public static List<Member> GetMembers(string folderPath)
        {
            List<Member> Members = new List<Member>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false,
                Mode = CsvMode.NoEscape
            };
            string filepath = folderPath + "1.17 Members.csv";
            using (var streamReader = new StreamReader(filepath))
            {
                using (var csvReader = new CsvReader(streamReader, config))
                {
                    csvReader.Context.RegisterClassMap<Plugin1.Clases.MemberMap>();
                    Members = csvReader.GetRecords<Member>().ToList();
                }
            }
            return Members;
        }
        public static List<MemberSet> GetSetsOfMembers(string folderPath)
        {
            List<MemberSet> setsOfMembers = new List<MemberSet>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false,
                Mode = CsvMode.NoEscape
            };
            string filepath = folderPath + "1.21 Sets of Members.csv";
            using (var streamReader = new StreamReader(filepath))
            {
                using (var csvReader = new CsvReader(streamReader, config))
                {
                    csvReader.Context.RegisterClassMap<Plugin1.Clases.MemberSetMap>();
                    setsOfMembers = csvReader.GetRecords<MemberSet>().ToList();
                }
            }
            return setsOfMembers;
        }
        public static List<Profile> GetProfiles(string folderPath)
        {
            List<Profile> profiles = new List<Profile>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false,
                Mode = CsvMode.NoEscape
            };
            string filepath = folderPath + "1.13 Cross-Sections .csv";
            using (var streamReader = new StreamReader(filepath))
            {
                using (var csvReader = new CsvReader(streamReader, config))
                {
                    csvReader.Context.RegisterClassMap<Plugin1.Clases.ProfileMap>();
                    profiles = csvReader.GetRecords<Profile>().ToList();
                }
            }

            return profiles;
        }
    }
}
