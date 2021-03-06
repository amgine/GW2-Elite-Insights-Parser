﻿using System.Collections.Generic;
using System.Linq;

namespace LuckParser.Models.ParseModels
{
    public class MechanicData
    {
        private List<MechanicLog> m_Data;
        private List<Mechanic> globalMechList = new List<Mechanic>()
        {
            //VG
            new Mechanic(31860,"Unstable Magic Spike", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'circle',color:'rgb(0,0,255)',", "Green Teleport blue"),
            new Mechanic(31392, "Unstable Magic Spike", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'circle',color:'rgb(0,0,255)',", "Boss Teleport blue"),
            new Mechanic(31340, "Distributed Magic", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'circle',color:'rgb(0,128,0)',", "Green Team"),
            new Mechanic(31391, "Distributed Magic", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'circle',color:'rgb(0,128,0)',", "Green Team"),
            new Mechanic(31529, "Distributed Magic", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'circle',color:'rgb(0,128,0)',", "Green Team"),
            new Mechanic(31750, "Distributed Magic", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'circle',color:'rgb(0,128,0)',", "Green Team"),
            new Mechanic(31886, "Magic Pulse", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'circle',color:'rgb(255,0,0)',", "Hit by Red"),
            new Mechanic(-1, "Pylon Attunement: Red", Mechanic.MechType.PlayerBoon, 15438, "symbol:'square',color:'rgb(255,0,0)',", "Attune:Red"),
            new Mechanic(31317, "Pylon Attunement: Blue", Mechanic.MechType.PlayerBoon, 15438, "symbol:'square',color:'rgb(0,0,255)',", "Attune:Blue"),
            new Mechanic(-1, "Pylon Attunement: Green", Mechanic.MechType.PlayerBoon, 15438, "symbol:'square',color:'rgb(0,128,0)',", "Attune:Green"),
            new Mechanic(31413, "Blue Pylon Power", Mechanic.MechType.EnemyBoonStrip, 15438, "symbol:'square',color:'rgb(0,0,255)',", "Striped Blue Invuln"),
            new Mechanic(31539, "Unstable Pylon", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'hexagram',color:'rgb(255,0,0)',", "Floor Damage"),
            new Mechanic(31828, "Unstable Pylon", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'hexagram',color:'rgb(0,0,255)',", "Floor Damage"),
            new Mechanic(31884, "Unstable Pylon", Mechanic.MechType.SkillOnPlayer, 15438, "symbol:'hexagram',color:'rgb(0,128,0)',", "Floor Damage"),
            //gors         
            new Mechanic(31875, "Spectral Impact", Mechanic.MechType.SkillOnPlayer, 15429, "symbol:'hexagram',color:'rgb(255,0,0)',", "Slam"),
            new Mechanic(31623, "Ghastly Prison", Mechanic.MechType.SkillOnPlayer, 15429, "symbol:'pentagon',color:'rgb(0,0,255)',", "Egg"),
            new Mechanic(31498, "Spectral Darkness", Mechanic.MechType.PlayerBoon, 15429, "symbol:'circle',color:'rgb(0,0,255)',", "Orb Debuff"),

            new Mechanic(31722, "Spirited Fusion", Mechanic.MechType.BossBoon, 15429, "symbol:'square',color:'rgb(0,0,255)',", "Ate Spirit"),
            //sab
            new Mechanic(34108, "Shell-Shocked", Mechanic.MechType.PlayerBoon, 15375, "symbol:'circle',color:'rgb(255,0,0)',", "Canons"),
            new Mechanic(31473, "Sapper Bomb", Mechanic.MechType.PlayerBoon, 15375, "symbol:'circle',color:'rgb(0,128,0)',", "Green Bomb"),
            new Mechanic(31485, "Time Bomb", Mechanic.MechType.PlayerBoon, 15375, "symbol:'circle',color:'rgb(0,0,255)',", "Time Bomb"),//or 3? buff or hits
            new Mechanic(31332, "Firestorm", Mechanic.MechType.SkillOnPlayer, 15375, "symbol:'square',color:'rgb(255,0,0)',", "Flamewall"),
            new Mechanic(31544, "Flak Shot", Mechanic.MechType.SkillOnPlayer, 15375, "symbol:'hexagram',color:'rgb(255,0,0)',", "Flak"),

                //sloth
                new Mechanic(34479, "Tantrum", Mechanic.MechType.SkillOnPlayer, 16123, "symbol:'circle',color:'rgb(255,0,0)',", "Tantrum"),
                new Mechanic(34387, "Volatile Poison", Mechanic.MechType.PlayerBoon, 16123, "symbol:'circle',color:'rgb(0,128,0)',", "Poisin Buff"),
                new Mechanic(34481, "Volatile Poison", Mechanic.MechType.SkillOnPlayer, 16123, "symbol:'hexagram',color:'rgb(0,128,0)',", "Poisin AOE"),
                new Mechanic(34516, "Halitosis", Mechanic.MechType.SkillOnPlayer, 16123, "symbol:'hexagram',color:'rgb(255,0,0)',", "Flame Breathe"),
                new Mechanic(34482, "Spore Release", Mechanic.MechType.SkillOnPlayer, 16123, "symbol:'pentagon',color:'rgb(0,128,0)',", "Shake"),
                new Mechanic(34362, "Magic Transformation", Mechanic.MechType.PlayerBoon, 16123, "symbol:'square',color:'rgb(0,128,0)',", "Slub Transform"),
                new Mechanic(34496, "Nauseated", Mechanic.MechType.PlayerBoon, 16123, "symbol:'square',color:'rgb(0,0,255)',", "Slub CD"),
                new Mechanic(34508, "Fixated", Mechanic.MechType.PlayerBoon, 16123, "symbol:'star',color:'rgb(0,0,255)',", "Fixated"),

                //matt
                new Mechanic(34380, "Oppressive Gaze", Mechanic.MechType.SkillOnPlayer, 16115, "symbol:'hexagram',color:'rgb(0,0,255)',", "Hadouken"),//human
                new Mechanic(34371, "Oppressive Gaze", Mechanic.MechType.SkillOnPlayer, 16115, "symbol:'hexagram',color:'rgb(0,0,255)',", "Hadouken"),//abom
                new Mechanic(34404, "Shards of Rage", Mechanic.MechType.SkillOnPlayer, 16115, "symbol:'hexagram',color:'rgb(255,0,0)',", "Backflip Shards"),//human
                new Mechanic(34411, "Shards of Rage", Mechanic.MechType.SkillOnPlayer, 16115, "symbol:'hexagram',color:'rgb(255,0,0)',", "Backflip Shards"),//abom
                new Mechanic(34450, "Unstable Blood Magic", Mechanic.MechType.PlayerBoon, 16115, "symbol:'diamond',color:'rgb(255,0,0)',", "Bomb"),
                new Mechanic(34416, "Corruption", Mechanic.MechType.PlayerBoon, 16115, "symbol:'circle',color:'rgb(255,0,0)',", "Corruption"),
                new Mechanic(34442, "Sacrifice", Mechanic.MechType.PlayerBoon, 16115, "symbol:'circle',color:'rgb(75,0,130)',", "Sacrifice"),
                new Mechanic(34367, "Unbalanced", Mechanic.MechType.PlayerBoon, 16115, "symbol:'square',color:'rgb(75,30,150)',", "Rain Knockdown"),
                new Mechanic(34422, "Blood Fueled", Mechanic.MechType.BossBoon, 16115, "symbol:'square',color:'rgb(255,0,0)',", "Ate Reflects(Bad)"),
                new Mechanic(34428, "Blood Fueled", Mechanic.MechType.BossBoon, 16115, "symbol:'square',color:'rgb(255,0,0)',", "Ate Reflects(Bad)"),
                new Mechanic(34376, "Blood Shield", Mechanic.MechType.BossBoon, 16115, "symbol:'octagon',color:'rgb(255,0,0)',", "Bubble"),
                new Mechanic(34518, "Blood Shield", Mechanic.MechType.BossBoon, 16115, "symbol:'octagon',color:'rgb(255,0,0)',", "Bubble"),

                //KC
                new Mechanic(34912, "Fixate", Mechanic.MechType.PlayerBoon, 16235, "symbol:'star',color:'rgb(0,0,250)',", "Fixate"),
                new Mechanic(34925, "Fixate", Mechanic.MechType.PlayerBoon, 16235, "symbol:'star',color:'rgb(0,0,250)',", "Fixate"),
                new Mechanic(35077, "Hail of Fury", Mechanic.MechType.SkillOnPlayer, 16235, "symbol:'hexagram',color:'rgb(0,0,250)',", "Debris"),
                new Mechanic(-1, "Insidious Projection", Mechanic.MechType.Spawn, 16235, "symbol:'octagram',color:'rgb(0,0,250)',", "Merge"),//Spawn check
                new Mechanic(35137, "Phantasmal Blades", Mechanic.MechType.SkillOnPlayer, 16235, "symbol:'star',color:'rgb(250,0,0)',", "Bunker and rotate"),
                new Mechanic(35064, "Phantasmal Blades", Mechanic.MechType.SkillOnPlayer, 16235, "symbol:'star',color:'rgb(250,0,0)',", "Bunker and rotate"),
                new Mechanic(35086, "Tower Drop", Mechanic.MechType.SkillOnPlayer, 16235, "symbol:'circle',color:'rgb(250,0,0)',", "Tower Drop"),
                //hit orb

                //Xera
                new Mechanic(35128, "Temporal Shred", Mechanic.MechType.SkillOnPlayer, 16246, "symbol:'circle',color:'rgb(250,0,0)',", "Orb"),
                new Mechanic(34913, "Temporal Shred", Mechanic.MechType.SkillOnPlayer, 16246, "symbol:'square',color:'rgb(250,0,0)',", "Orb Aoe"),
                new Mechanic(35000, "Intervention", Mechanic.MechType.PlayerBoon, 16246, "symbol:'circle',color:'rgb(75,30,150)',", "Bubble"),
                new Mechanic(35168, "Bloodstone Protection", Mechanic.MechType.PlayerBoon, 16246, "symbol:'hourglass',color:'rgb(75,30,150)',", "In Bubble"),
                new Mechanic(34887, "Summon Fragment", Mechanic.MechType.BossCast, 16246, "symbol:'diamond',color:'rgb(75,30,150)',", "CC Too long"),
                new Mechanic(34965, "Derangement", Mechanic.MechType.PlayerBoon, 16246, "symbol:'square',color:'rgb(75,30,150)',", "Stacking buff"),
                new Mechanic(35084, "Bending Chaos", Mechanic.MechType.PlayerBoon, 16246, "symbol:'pentagon',color:'rgb(75,30,150)',", "Button 1"),
                new Mechanic(35162, "Shifting Chaos", Mechanic.MechType.PlayerBoon, 16246, "symbol:'hexagon',color:'rgb(75,30,150)',", "Button 2"),
                new Mechanic(35032, "Twisting Chaos", Mechanic.MechType.PlayerBoon, 16246, "symbol:'octagon',color:'rgb(75,30,150)',", "Button 3"),
                //teleport
                //hit move orb

                //Cairn
                new Mechanic(38113, "Displacement", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'circle',color:'rgb(0,0,250)',", "Blue TP"),
                new Mechanic(37611, "Spatial Manipulation", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'circle',color:'rgb(0,150,0)',", "Green"),
                new Mechanic(37629, "Spatial Manipulation", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'circle',color:'rgb(0,150,0)',", "Green"),
                new Mechanic(37642, "Spatial Manipulation", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'circle',color:'rgb(0,150,0)',", "Green"),
                new Mechanic(37673, "Spatial Manipulation", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'circle',color:'rgb(0,150,0)',", "Green"),
                new Mechanic(38074, "Spatial Manipulation", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'circle',color:'rgb(0,150,0)',", "Green"),
                new Mechanic(38302, "Spatial Manipulation", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'circle',color:'rgb(0,150,0)',", "Green"),
                new Mechanic(38313, "Meteor Swarm", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'diamond',color:'rgb(250,0,0)',", "Knockback crystal"),
                new Mechanic(38049, "Shared Agony", Mechanic.MechType.PlayerBoon, 17194, "symbol:'circle',color:'rgb(250,0,0)',", "Agony Buff"),//could flip
                new Mechanic(38210, "Shared Agony", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'hexagon',color:'rgb(250,0,0)',", "Agony Damage"),//could flip
                new Mechanic(38060, "Energy Surge", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'triangle-left',color:'rgb(250,0,0)',", "Leap"),
                new Mechanic(37631, "Orbital Sweep", Mechanic.MechType.SkillOnPlayer, 17194, "symbol:'circle',color:'rgb(0,0,250)',", "Sweep"),

                //mo
                new Mechanic(37788, "Jade Explosion", Mechanic.MechType.SkillOnPlayer, 17172, "symbol:'circle',color:'rgb(250,0,0)',", "Jade Dieing"),
                new Mechanic(37779, "Claim", Mechanic.MechType.PlayerBoon, 17172, "symbol:'circle',color:'rgb(0,0,250)',", "Claim"),
                new Mechanic(37697, "Dispel", Mechanic.MechType.PlayerBoon, 17172, "symbol:'square',color:'rgb(0,0,250)',", "Dispel"),
                new Mechanic(37813, "Protect", Mechanic.MechType.PlayerBoon, 17172, "symbol:'square',color:'rgb(0,158,0)',", "Protect"),
                new Mechanic(38155, "Mursaat Overseer's Shield", Mechanic.MechType.PlayerBoon, 17172, "symbol:'circle',color:'rgb(0,158,0)',", "Bubble Invuln"),
                new Mechanic(38184, "Enemy Tile", Mechanic.MechType.SkillOnPlayer, 17172, "symbol:'square',color:'rgb(255,0,0)',", "Tile Dmg"),

                //sam
                new Mechanic(37996, "Shockwave", Mechanic.MechType.SkillOnPlayer, 17188, "symbol:'circle',color:'rgb(0,0,255)',", "Knockback"),
                new Mechanic(38168, "Prisoner Sweep", Mechanic.MechType.SkillOnPlayer, 17188, "symbol:'hexagon',color:'rgb(255,0,0)',", "Sweep"),
                new Mechanic(38305, "Bludgeon", Mechanic.MechType.SkillOnPlayer, 17188, "symbol:'square',color:'rgb(255,0,0)',", "Slam"),
                new Mechanic(37868, "Fixate: Samarog", Mechanic.MechType.PlayerBoon, 17188, "symbol:'star',color:'rgb(0,0,255)',", "Fixate: Samarog"),
                new Mechanic(38223, "Fixate: Guldhem", Mechanic.MechType.PlayerBoon, 17188, "symbol:'star',color:'rgb(0,150,0)',", "Fixate: Guldhem"),
                new Mechanic(37693, "Fixate: Rigom", Mechanic.MechType.PlayerBoon, 17188, "symbol:'star',color:'rgb(255,0,0)',", "Fixate: Rigom"),
                new Mechanic(37693, "Fixate: Rigom", Mechanic.MechType.PlayerBoon, 17188, "symbol:'star',color:'rgb(255,0,0)',", "Fixate: Rigom"),
                new Mechanic(37966, "Big Hug", Mechanic.MechType.PlayerBoon, 17188, "symbol:'circle',color:'rgb(0,150,0)',", "Big Green"),
                new Mechanic(38247, "Small Hug", Mechanic.MechType.PlayerBoon, 17188, "symbol:'octagon',color:'rgb(0,150,0)',", "Small Green"),
                new Mechanic(38260, "Inevitable Betrayal", Mechanic.MechType.SkillOnPlayer, 17188, "symbol:'triangle-down',color:'rgb(255,0,0)',", "Failed Kissing"),
                new Mechanic(37851, "Inevitable Betrayal", Mechanic.MechType.SkillOnPlayer, 17188, "symbol:'triangle-down',color:'rgb(255,0,0)',", "Failed Kissing"),
                new Mechanic(37901, "Effigy Pulse", Mechanic.MechType.SkillOnPlayer, 17188, "symbol:'triangle-nw',color:'rgb(255,0,0)',", "Stood in Spear"),
                new Mechanic(37816, "Spear Impact", Mechanic.MechType.SkillOnPlayer, 17188, "symbol:'triangle-sw',color:'rgb(255,0,0)',", "Spear Spawned"),
                //  new Mechanic(37816, "Brutalize", Mechanic.MechType.SkillOnPlayer, 17188, "symbol:'star-square',color:'rgb(255,0,0)',", "CC Target", casted without dmg odd

                //deiimos
                new Mechanic(37716, "Rapid Decay", Mechanic.MechType.SkillOnPlayer, 17154, "symbol:'circle',color:'rgb(0,0,0)',", "Black Oil"),
                new Mechanic(38208, "Annihilate", Mechanic.MechType.SkillOnPlayer, 17154, "symbol:'circle',color:'rgb(255,0,0)',", "Boss Smash"),
                new Mechanic(37929, "Annihilate", Mechanic.MechType.SkillOnPlayer, 17154, "symbol:'circle',color:'rgb(255,0,0)',", "Chain Smash"),
                new Mechanic(37980, "Demonic Shock Wave", Mechanic.MechType.SkillOnPlayer, 17154, "symbol:'circle',color:'rgb(255,0,0)',", "10% Smash"),
                new Mechanic(37982, "Demonic Shock Wave", Mechanic.MechType.SkillOnPlayer, 17154, "symbol:'circle',color:'rgb(255,0,0)',", "10% Smash"),
                new Mechanic(37733, "Tear Instability", Mechanic.MechType.PlayerBoon, 17154, "symbol:'diamond',color:'rgb(0,150,0)',", "Tear"),
                new Mechanic(37613, "Mind Crush", Mechanic.MechType.SkillOnPlayer, 17154, "symbol:'square',color:'rgb(250,0,0)',", "Mind Crush"),
                new Mechanic(38187, "Weak Minded", Mechanic.MechType.PlayerBoon, 17154, "symbol:'square',color:'rgb(0,0,250)',", "Weak Minded"),
                //mlist.Add("Chosen by Eye of Janthir");
                //mlist.Add("");//tp from drunkard
                //mlist.Add("");//bon currupt from thief
                //mlist.Add("Teleport");//to demonic realm

                //horror
                new Mechanic(47327, "Vortex Slash", Mechanic.MechType.SkillOnPlayer, 19767, "symbol:'circle',color:'rgb(250,0,0)',", "Donut Inner"),
                new Mechanic(48432, "Vortex Slash", Mechanic.MechType.SkillOnPlayer, 19767, "symbol:'circle-open',color:'rgb(250,0,0)',", "Donut Outer"),
                new Mechanic(47430, "Soul Rift", Mechanic.MechType.SkillOnPlayer, 19767, "symbol:'circle',color:'rgb(250,140,0)',", "Golem AOE"),
                new Mechanic(48363, "Quad Slash", Mechanic.MechType.SkillOnPlayer, 19767, "symbol:'trianlge-up',color:'rgb(250,140,0)',", "Slices"),
                new Mechanic(47915, "Quad Slash", Mechanic.MechType.SkillOnPlayer, 19767, "symbol:'trianlge-up',color:'rgb(250,140,0)',", "Slices"),
                new Mechanic(47363, "Spinning Slash", Mechanic.MechType.SkillOnPlayer, 19767, "symbol:'trianlge-up',color:'rgb(250,140,0)',", "Sythe"),
                new Mechanic(47434, "Fixated", Mechanic.MechType.PlayerBoon, 19767, "symbol:'circle',color:'rgb(0,0,250)',", "Fixate"),
                new Mechanic(47414, "Necrosis", Mechanic.MechType.PlayerBoon, 19767, "symbol:'square',color:'rgb(0,150,0)',", "Necrosis Debuff"),

                //dhuum
                new Mechanic(48172, "Hateful Ephemera", Mechanic.MechType.SkillOnPlayer, 19450, "symbol:'square',color:'rgb(0,150,0)',", "Golem"),//Buff or dmg?
                new Mechanic(47646, "Arcing Affliction", Mechanic.MechType.PlayerBoon, 19450, "symbol:'hexagon',color:'rgb(250,0,0)',", "Arcing Affliction DMG"),//Buff or dmg?
                new Mechanic(48121, "Arcing Affliction", Mechanic.MechType.SkillOnPlayer, 19450, "symbol:'circle',color:'rgb(250,0,0)',", "Arcing Affliction"),//Buff or dmg?
                new Mechanic(47476, "Residual Affliction", Mechanic.MechType.PlayerBoon, 19450, "symbol:'square',color:'rgb(0,0,250)',", "Bomb CD"),
                new Mechanic(47335, "Soul Shackle", Mechanic.MechType.PlayerOnPlayer, 19450, "symbol:'diamond',color:'rgb(0,0,250)',", "Shackle"),//4 calls probably this one
                new Mechanic(47561, "Slash", Mechanic.MechType.SkillOnPlayer, 19450, "symbol:'triangle',color:'rgb(0,150,0)',", "Cone boon rip"),
                new Mechanic(48752, "Cull", Mechanic.MechType.SkillOnPlayer, 19450, "symbol:'diamond',color:'rgb(0,150,0)',", "Crack"),
                new Mechanic(48760, "Putrid Bomb", Mechanic.MechType.SkillOnPlayer, 19450, "symbol:'circle',color:'rgb(0,75,0)',", "Mark"),
                new Mechanic(48398, "Cataclysmic Cycle", Mechanic.MechType.SkillOnPlayer, 19450, "symbol:'triangle',color:'rgb(250,0,0)',", "Suck Center"),
                new Mechanic(48176, "Death Mark", Mechanic.MechType.SkillOnPlayer, 19450, "symbol:'circle',color:'rgb(250,140,0)',", "Dip Aoe"),
                new Mechanic(48210, "Greater Death Mark", Mechanic.MechType.SkillOnPlayer, 19450, "symbol:'circle-open',color:'rgb(250,140,0)',", "Suck Dmg"),
              //  new Mechanic(48281, "Mortal Coil", Mechanic.MechType.PlayerBoon, 19450, "symbol:'circle',color:'rgb(0,150,0)',", "Green Orbs",
                new Mechanic(46950, "Fractured Spirit", Mechanic.MechType.PlayerBoon, 19450, "symbol:'square',color:'rgb(0,150,0)',", "Green Orbs CD"),

                // Fractals            
                // MAMA   
                new Mechanic(37408, "Blastwave", Mechanic.MechType.SkillOnPlayer, 0x427D, "symbol:'circle',color:'rgb(100,150,0)',", "Blastwave"),
                new Mechanic(37103, "Blastwave", Mechanic.MechType.SkillOnPlayer, 0x427D, "symbol:'circle',color:'rgb(100,150,0)',", "Blastwave"),
                new Mechanic(37391, "Tantrum", Mechanic.MechType.SkillOnPlayer, 0x427D, "symbol:'circle',color:'rgb(50,150,0)',", "Tantrum"),
                new Mechanic(37577, "Leap", Mechanic.MechType.SkillOnPlayer, 0x427D, "symbol:'circle',color:'rgb(150,150,0)',", "Leap"),
                new Mechanic(37437, "Shoot", Mechanic.MechType.SkillOnPlayer, 0x427D, "symbol:'circle',color:'rgb(200,150,0)',", "Shoot"),
                new Mechanic(37185, "Explosive Impact", Mechanic.MechType.SkillOnPlayer, 0x427D, "symbol:'circle',color:'rgb(125,50,0)',", "Explosive Impact"),
                // SIAX
                new Mechanic(37477, "Vile Spit", Mechanic.MechType.SkillOnPlayer, 0x4284, "symbol:'circle',color:'rgb(150,150,0)',", "Vile Spit"),
                // ENSOLYSS
                new Mechanic(37154, "Lunge", Mechanic.MechType.SkillOnPlayer, 0x4234, "symbol:'circle',color:'rgb(50,150,0)',", "Lunge"),
                new Mechanic(37278, "First Smash", Mechanic.MechType.SkillOnPlayer, 0x4234, "symbol:'circle',color:'rgb(100,150,0)',", "First Smash"),
                new Mechanic(36962, "Torment Smash", Mechanic.MechType.SkillOnPlayer, 0x4234, "symbol:'circle',color:'rgb(150,150,0)',", "Torment Smash"),
                // ARKK
                new Mechanic(39685, "Horizon Strike 1", Mechanic.MechType.SkillOnPlayer, 0x455F, "symbol:'circle',color:'rgb(50,0,0)',", "Horizon Strike 1"),
                new Mechanic(39001, "Horizon Strike 2", Mechanic.MechType.SkillOnPlayer, 0x455F, "symbol:'circle',color:'rgb(100,0,0)',", "Horizon Strike 2"),
                new Mechanic(39297, "Horizon Strike Normal", Mechanic.MechType.SkillOnPlayer, 0x455F, "symbol:'circle',color:'rgb(150,0,0)',", "Horizon Strike Normal"),
                new Mechanic(38844, "Overhead Smash", Mechanic.MechType.SkillOnPlayer, 0x455F, "symbol:'circle',color:'rgb(200,0,0)',", "Overhead Smash"),
                new Mechanic(38880, "Corporeal Reassignment", Mechanic.MechType.PlayerBoon, 0x455F, "symbol:'square',color:'rgb(0,150,0)',", "Corporeal Reassignment")
        };

        public MechanicData()
        {
            this.m_Data = new List<MechanicLog>();
        }

        public void AddItem(MechanicLog mLog)
        {
            this.m_Data.Add(mLog);
        }

        public List<MechanicLog> GetMDataLogs()
        {
            return this.m_Data;
        }
        public List<Mechanic> GetMechList(int bossid)
        {
            if (bossid > 0)
            {
                return globalMechList.Where(x => x.GetBossID() == bossid || x.GetBossID() == 0).ToList();
            }
            else
            {
                return globalMechList;
            }

        }
        public Mechanic GetMech(MechanicLog m_log)
        {
            return GetMechList(0).FirstOrDefault(x => x.GetSkill() == m_log.GetSkill());
        }
        public string GetPLoltyShape(string mechName)
        {
            switch (mechName)
            {
                case "DOWN":
                    return "symbol:'cross',color:'rgb(255,0,0)',";
                case "DEAD":
                    return "symbol:'x',color:'rgb(190,190,190)',";
                default:
                    return "";
            }
        }


    }
}