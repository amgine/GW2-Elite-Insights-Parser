﻿using LuckParser.Models;
using LuckParser.Models.ParseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Xml.Serialization;

namespace LuckParser.Controllers
{
    public class GW2APIController
    {
        static HttpClient APIClient { get; set; }
        private void GetAPIClient()
        {
            if (APIClient == null)
            {
                APIClient = new HttpClient();
                APIClient.BaseAddress = new Uri("https://api.guildwars2.com");
                APIClient.DefaultRequestHeaders.Accept.Clear();
                APIClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            return;
        }

        private GW2APISkill GetGW2APISKill(string path)
        {
            //System.Threading.Thread.Sleep(100);
            if (APIClient == null) { GetAPIClient(); }
            GW2APISkill skill = null;
            HttpResponseMessage response = APIClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {

                //skill = response.Content.ReadAsAsync<GW2APISkill>().Result;
                GW2APISkillCheck skillCheck = response.Content.ReadAsAsync<GW2APISkillCheck>().Result;
                if (skillCheck.categories != null)
                {
                    int stop = 0;
                }
                if (skillCheck.facts != null)
                {
                    bool block = true;
                    foreach (GW2APIfacts fact in skillCheck.facts)
                    {
                        if (fact.type == "Unblockable" || fact.type == "StunBreak")//Unblockable changeing value from an int to a bool has caused so much chaos
                        {
                            skill = skillCheck;
                            block = false;
                            break;
                        }

                    }
                    if (block)
                    {
                        response = APIClient.GetAsync(path).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            skill = response.Content.ReadAsAsync<GW2APISkillDetailed>().Result;
                        }

                    }
                }
                else
                {
                    skill = skillCheck;
                }
            }
            else
            {//try again after a wait
                System.Threading.Thread.Sleep(1000);
                response = APIClient.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    //skill = response.Content.ReadAsAsync<GW2APISkill>().Result;
                    GW2APISkillCheck skillCheck = response.Content.ReadAsAsync<GW2APISkillCheck>().Result;
                    if (skillCheck.facts != null)
                    {
                        bool block = true;
                        foreach (GW2APIfacts fact in skillCheck.facts)
                        {
                            if (fact.type == "Unblockable" || fact.type == "StunBreak")//Unblockable changeing value from an int to a bool has caused so much chaos
                            {
                                skill = skillCheck;
                                block = false;
                                break;
                            }

                        }
                        if (block == false)
                        {
                            response = APIClient.GetAsync(path).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                skill = response.Content.ReadAsAsync<GW2APISkillDetailed>().Result;
                            }

                        }
                    }
                    else
                    {
                        skill = skillCheck;
                    }

                }
            }
            return skill;
        }
        private SkillList GetSkillList()
        {
            if (ListOfSkills.Items.Count == 0)
            {
                SetSkillList();
            }
            return ListOfSkills;
        }
        public List<int> WriteSkillListToFile()
        {
            //used for wiritng new XMLs
            FileStream fcreate = File.Open(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
            + "/Content/SkillList.txt", FileMode.Create);

            fcreate.Close();


            Console.WriteLine("Getting APi");
            //Get list from API
            GetAPIClient();

            ListOfSkills = new SkillList();
            HttpResponseMessage response = APIClient.GetAsync("/v2/skills").Result;
            int[] idArray;
            List<int> failedList = new List<int>();
            if (response.IsSuccessStatusCode)
            {
                // Get Skill ID list
                idArray = response.Content.ReadAsAsync<int[]>().Result;

                foreach (int id in idArray)
                {
                    GW2APISkill curSkill = new GW2APISkill();
                    curSkill = GetGW2APISKill("/v2/skills/" + id);
                    if (curSkill != null)
                    {

                        ListOfSkills.Items.Add(curSkill);

                    }
                    else
                    {
                        Console.WriteLine("Fail to get response");//fail to retrieve
                        failedList.Add(id);
                    }

                }
                Stream stream = System.IO.File.OpenWrite(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
            + "/Content/SkillList.txt");
                Type[] tyList = { typeof(List<GW2APISkillCheck>), typeof(List<GW2APISkillDetailed>) };

                XmlSerializer xmlSer = new XmlSerializer(typeof(List<GW2APISkill>), tyList);
                xmlSer.Serialize(stream, ListOfSkills.Items);
                stream.Close();

            }
            return failedList;
        }
        public void RetryWriteSkillListtoFile()
        {
            if (new FileInfo(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                + "/Content/SkillList.txt").Length != 0)
            {
                Console.WriteLine("Reading Skilllist");

                //Get list from local XML
                using (var reader = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                + "/Content/SkillList.txt"))
                {
                    Type[] tyList = { typeof(List<GW2APISkillCheck>), typeof(List<GW2APISkillDetailed>) };


                    XmlSerializer deserializer = new XmlSerializer(typeof(SkillList), tyList);
                    ListOfSkills = (SkillList)deserializer.Deserialize(reader);

                    reader.Close();
                }
            }
            Console.WriteLine("Getting APi");
            //Get list from API
            GetAPIClient();

            HttpResponseMessage response = APIClient.GetAsync("/v2/skills").Result;
            int[] idArray;
            if (response.IsSuccessStatusCode)
            {
                // Get Skill ID list
                idArray = response.Content.ReadAsAsync<int[]>().Result;

                foreach (int id in idArray)
                {
                    if (ListOfSkills.Items.FirstOrDefault(x => x.id == id) == null)
                    {
                        GW2APISkill curSkill = new GW2APISkill();
                        curSkill = GetGW2APISKill("/v2/skills/" + id);
                        if (curSkill != null)
                        {

                            ListOfSkills.Items.Add(curSkill);

                        }
                        else
                        {
                            Console.WriteLine("Fail to get response");//fail to retrieve

                        }
                    }
                }
                Stream stream = System.IO.File.OpenWrite(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
            + "/Content/SkillList.txt");
                Type[] tyList = { typeof(List<GW2APISkillCheck>), typeof(List<GW2APISkillDetailed>) };

                XmlSerializer xmlSer = new XmlSerializer(typeof(List<GW2APISkill>), tyList);
                xmlSer.Serialize(stream, ListOfSkills.Items);
                stream.Close();
            }

        }
        private void SetSkillList()
        {

            if (ListOfSkills.Items.Count == 0)
            {

                if (new FileInfo(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                + "/Content/SkillList.txt").Length != 0)
                {
                    Console.WriteLine("Reading Skilllist");

                    //Get list from local XML
                    using (var reader = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                    + "/Content/SkillList.txt"))
                    {
                        Type[] tyList = { typeof(List<GW2APISkillCheck>), typeof(List<GW2APISkillDetailed>) };


                        XmlSerializer deserializer = new XmlSerializer(typeof(SkillList), tyList);
                        ListOfSkills = (SkillList)deserializer.Deserialize(reader);

                        reader.Close();
                    }
                }

            }



            return;
        }
        [XmlRoot("ArrayOfGW2APISkill")]
        public class SkillList
        {
            public SkillList() { Items = new List<GW2APISkill>(); }
            [XmlElement("GW2APISkill")]
            public List<GW2APISkill> Items { get; set; }
        }
        [XmlArray("GW2APISkill")]
        [XmlArrayItem("GW2APISkillCheck", typeof(GW2APISkillCheck))]
        [XmlArrayItem("GW2APISkillDetailed", typeof(GW2APISkillDetailed))]
        static SkillList ListOfSkills = new SkillList();

        public GW2APISkill GetSkill(int id)
        {
            GW2APISkill skill = GetSkillList().Items.FirstOrDefault(x => x.id == id);
            //if (skill == null) {
            //    string path = "/v2/skills/" + id;
            //    skill = GetGW2APISKill(path);
            //}
            return skill;
        }
        //-----------------------------------------------------------------------------
        private GW2APISpec GetGW2APISpec(string path)
        {
            if (APIClient == null) { GetAPIClient(); }
            System.Threading.Thread.Sleep(100);
            GW2APISpec spec = null;
            //path = "/v2/specializations/" + is_elite
            HttpResponseMessage response = APIClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                spec = response.Content.ReadAsAsync<GW2APISpec>().Result;

            }
            return spec;
        }

        private SpecList GetSpecList()
        {
            if (ListofSpecs.Items.Count == 0)
            {
                SetSpecList(); 
            }
            return ListofSpecs;
        }
        public List<int> WriteSpecListToFile()
        {
            //used for wiritng new XMLs
            FileStream fcreate = File.Open(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
            + "/Content/SpecList.txt", FileMode.Create);

            fcreate.Close();


            Console.WriteLine("Getting APi");
            //Get list from API
            GetAPIClient();

            ListofSpecs = new SpecList();
            HttpResponseMessage response = APIClient.GetAsync("/v2/specializations").Result;
            int[] idArray;
            List<int> failedList = new List<int>();
            if (response.IsSuccessStatusCode)
            {
                // Get Skill ID list
                idArray = response.Content.ReadAsAsync<int[]>().Result;

                foreach (int id in idArray)
                {
                    GW2APISpec curSpec = new GW2APISpec();
                    curSpec = GetGW2APISpec("/v2/specializations/" + id);
                    if (curSpec != null)
                    {

                        ListofSpecs.Items.Add(curSpec);

                    }
                    else
                    {
                        Console.WriteLine("Fail to get response");//fail to retrieve
                        failedList.Add(id);
                    }

                }
                Stream stream = System.IO.File.OpenWrite(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
            + "/Content/SpecList.txt");
                Type[] tyList = { typeof(List<GW2APISpec>) };

                XmlSerializer xmlSer = new XmlSerializer(typeof(List<GW2APISpec>), tyList);
                xmlSer.Serialize(stream, ListofSpecs.Items);
                stream.Close();

            }
            return failedList;
        }
        
        private void SetSpecList()
        {

            if (ListofSpecs.Items.Count == 0)
            {

                if (new FileInfo(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                + "/Content/SpecList.txt").Length != 0)
                {
                    Console.WriteLine("Reading SpecList");

                    //Get list from local XML
                    using (var reader = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                    + "/Content/SpecList.txt"))
                    {
                        Type[] tyList = { typeof(List<GW2APISpec>) };


                        XmlSerializer deserializer = new XmlSerializer(typeof(SpecList), tyList);
                        ListofSpecs = (SpecList)deserializer.Deserialize(reader);

                        reader.Close();
                    }
                }
                if (ListofSpecs.Items.Count == 0)//if nothing in file or fail write new file
                {
                    WriteSpecListToFile();
                }

            }



            return;
        }
        [XmlRoot("ArrayOfGW2APISpec")]
        public class SpecList
        {
            public SpecList() { Items = new List<GW2APISpec>(); }
            [XmlElement("GW2APISpec")]
            public List<GW2APISpec> Items { get; set; }
        }
        [XmlArray("GW2APISpec")]
        [XmlArrayItem("GW2APISpec", typeof(GW2APISpec))]
     
        static SpecList ListofSpecs = new SpecList();

        public GW2APISpec GetSpec(int id)
        {
            GW2APISpec spec = GetSpecList().Items.FirstOrDefault(x => x.id == id);
            
            return spec;
        }
    }
}
