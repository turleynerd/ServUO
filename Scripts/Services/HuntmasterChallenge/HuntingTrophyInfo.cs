using System;
using Server;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Engines.HuntsmasterChallenge
{
    public enum HuntType
    {
        GrizzlyBear,
        GrayWolf,
        Cougar,
        Turkey,
        Bull,
        Boar,
        Walrus,
        Alligator,
        Eagle,
        MyrmidexLarvae,
        Najasaurus,
        Anchisaur,
        Allosaurus,
        Dimetrosaur,
        Saurosaurus,
        Tiger,
        MyrmidexDrone,
        Triceratops,
        Lion,
        WhiteTiger,
        BlackTiger,
        //Publish 102 added:
        Raptor,
		SeaSerpent,
		Scorpion
    }

    public enum MeasuredBy
    {
        Weight,
        Length,
        Wingspan
    }

    public class HuntingTrophyInfo
    {
        private static List<HuntingTrophyInfo> m_Infos = new List<HuntingTrophyInfo>();
        public static List<HuntingTrophyInfo> Infos { get { return m_Infos; } }

        public static void Initialize()
        {
            m_Infos.Add(new HuntingTrophyInfo(HuntType.GrizzlyBear, typeof(GrizzlyBear),    0x9A26, new TextDefinition(1015242), 400, 800,  MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.GrayWolf,    typeof(GreyWolf),       0x9A28, new TextDefinition(1029681), 70,  190,  MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Cougar,      typeof(Cougar),         0x9A2A, new TextDefinition(1029603), 50,  140,  MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Turkey,      typeof(Turkey),         0x9A2C, new TextDefinition(1155714), 10,  55,   MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Bull,        typeof(Bull),           0x9A2E, new TextDefinition(1072495), 500, 1000, MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Boar,        typeof(Boar),           0x9A30, new TextDefinition(1155715), 100, 400,  MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Walrus,      typeof(Walrus),         0x9A32, new TextDefinition(1155716), 600, 1500, MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Alligator,   typeof(Alligator),      0x9A34, new TextDefinition(1155717), 5,   15,   MeasuredBy.Length));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Eagle,       typeof(Eagle),          0x9A36, new TextDefinition(1072461), 5,   15,   MeasuredBy.Wingspan));
        
            // Pub 91 Additions
            m_Infos.Add(new HuntingTrophyInfo(HuntType.MyrmidexLarvae,  typeof(MyrmidexLarvae), 0x9C00, new TextDefinition(1156276), 200, 400, MeasuredBy.Weight, true));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Najasaurus,      typeof(Najasaurus),     0x9C02, new TextDefinition(1156283), 400, 800, MeasuredBy.Weight, true));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Anchisaur,       typeof(Anchisaur),      0x9C08, new TextDefinition(1156284), 400, 800, MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Allosaurus,      typeof(Allosaurus),     0x9C0A, new TextDefinition(1156280), 400, 800, MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Dimetrosaur,     typeof(Dimetrosaur),    0x9C0C, new TextDefinition(1156279), 400, 800, MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Saurosaurus,     typeof(Saurosaurus),    0x9C0E, new TextDefinition(1156289), 400, 800, MeasuredBy.Weight));

            m_Infos.Add(new HuntingTrophyInfo(HuntType.MyrmidexDrone,   typeof(MyrmidexDrone),  0x9DA6, new TextDefinition(1156134), 300, 600, MeasuredBy.Weight));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Tiger,           typeof(WildTiger),      0x9DA4, new TextDefinition(1156286), 400, 800, MeasuredBy.Weight));

            m_Infos.Add(new HuntingTrophyInfo(HuntType.Triceratops,     typeof(Triceratops),    0x9F2B, new TextDefinition(1124731), 400, 800, MeasuredBy.Weight, flippedids: true));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.Lion,            typeof(Lion),           0x9F2D, new TextDefinition(1124736), 400, 800, MeasuredBy.Weight, flippedids: true));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.WhiteTiger,      typeof(WildWhiteTiger), 0x9F2F, new TextDefinition(1156286), 400, 800, MeasuredBy.Weight, flippedids: true));
            m_Infos.Add(new HuntingTrophyInfo(HuntType.BlackTiger,      typeof(WildBlackTiger), 0x9F31, new TextDefinition(1156286), 400, 800, MeasuredBy.Weight, flippedids: true));
            //Publish 102 added: Please check code 
			m_Infos.Add(new HuntingTrophyInfo(HuntType.Raptor,          typeof(Raptor),         0x2DA, new TextDefinition(1095923),  400, 800, MeasuredBy.Weight, flippedids: true));
			m_Infos.Add(new HuntingTrophyInfo(HuntType.SeaSerpent,      typeof(SeaSerpent),     0x96, new TextDefinition(1018242),   400, 800, MeasuredBy.Weight, flippedids: true));
			m_Infos.Add(new HuntingTrophyInfo(HuntType.Scorpion,        typeof(Scorpion),       0x30, new TextDefinition(1028420),   400, 800, MeasuredBy.Weight, flippedids: true));
        }

        private HuntType m_HuntType;
        private Type m_CreatureType;
        private MeasuredBy m_MeasuredBy;
        private int m_SouthID;
        private TextDefinition m_Species;
        private int m_MinMeasurement;
        private int m_MaxMeasurement;
        private bool m_Complex;
        private bool m_FlippedIDs;

        public HuntType HuntType { get { return m_HuntType; } }
        public Type CreatureType { get { return m_CreatureType; } }
        public MeasuredBy MeasuredBy { get { return m_MeasuredBy; } }
        public int SouthID { get { return m_SouthID; } }
        public TextDefinition Species { get { return m_Species; } }
        public int MinMeasurement { get { return m_MinMeasurement; } }
        public int MaxMeasurement { get { return m_MaxMeasurement; } }
        public bool Complex { get { return m_Complex; } }
        public bool FlippedIDs { get { return m_FlippedIDs; } }

        public HuntingTrophyInfo(HuntType type, Type creatureType, int id, TextDefinition species, int minMeasurement, int maxMeasurement, MeasuredBy measuredBy, bool complex = false, bool flippedids = false)
        {
            m_HuntType = type;
            m_CreatureType = creatureType;
            m_MeasuredBy = measuredBy;
            m_SouthID = id;
            m_Species = species;
            m_MinMeasurement = minMeasurement;
            m_MaxMeasurement = maxMeasurement;
            m_Complex = complex;
            m_FlippedIDs = flippedids;
        }

        public static HuntingTrophyInfo GetInfo(HuntType type)
        {
            foreach (HuntingTrophyInfo info in m_Infos)
            {
                if (info.HuntType == type)
                    return info;
            }

            return null;
        }
    }
}
