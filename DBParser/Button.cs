using System;

namespace Iswenzz.AION.DBParser
{
    public class Link
    {
        public static Button[] button = new Button[1]
        {
            new Button("NPC")
        };

        public static Button.NPC[] npc = new Button.NPC[7]
        {
            new Button.NPC("Elyos", "http://aiondatabase.net/en/npcs/light/", true),
            new Button.NPC("Asmodian", "http://aiondatabase.net/en/npcs/dark/", true),
            new Button.NPC("Shugo", "http://aiondatabase.net/en/npcs/shugo/", true),
            new Button.NPC("Monsters", "http://aiondatabase.net/en/npcs/monsters/", true),
            new Button.NPC("Named monsters", "http://aiondatabase.net/en/npcs/named/", true),
            new Button.NPC("Grade"),
            new Button.NPC("Zone")
        };

        public static Button.NPC.Grade[] grade = new Button.NPC.Grade[4]
        {
            new Button.NPC.Grade("Normal", "http://aiondatabase.net/en/npcs/normal/", true),
            new Button.NPC.Grade("Elite", "http://aiondatabase.net/en/npcs/elite/", true),
            new Button.NPC.Grade("Heroic", "http://aiondatabase.net/en/npcs/heroic/", true),
            new Button.NPC.Grade("Legendary", "http://aiondatabase.net/en/npcs/legendary/", true)
        };

        public static Button.NPC.Zone[] zone = new Button.NPC.Zone[225]
        {
            new Button.NPC.Zone("PANDAEMONIUM", "http://aiondatabase.net/en/npcs/120010000/", true),
            new Button.NPC.Zone("MARCHUTAN", "http://aiondatabase.net/en/npcs/120020000/", true),
            new Button.NPC.Zone("MARCHUTAN_PRIORY", "http://aiondatabase.net/en/npcs/120080000/", true),
            new Button.NPC.Zone("FATEBOUND_ABBEY", "http://aiondatabase.net/en/npcs/140010000/", true),
            new Button.NPC.Zone("ISHALGEN", "http://aiondatabase.net/en/npcs/220010000/", true),
            new Button.NPC.Zone("MORHEIM", "http://aiondatabase.net/en/npcs/220020000/", true),
            new Button.NPC.Zone("ALTGARD", "http://aiondatabase.net/en/npcs/220030000/", true),
            new Button.NPC.Zone("BELUSLAN", "http://aiondatabase.net/en/npcs/220040000/", true),
            new Button.NPC.Zone("BRUSTHONIN", "http://aiondatabase.net/en/npcs/220050000/", true),
            new Button.NPC.Zone("NOSRA", "http://aiondatabase.net/en/npcs/220110000/", true),
            new Button.NPC.Zone("TOWER_OF_ETERNITY_D", "http://aiondatabase.net/en/npcs/220120000/", true),
            new Button.NPC.Zone("PERNON", "http://aiondatabase.net/en/npcs/710010000/", true),
            new Button.NPC.Zone("SANCTUM", "http://aiondatabase.net/en/npcs/110010000/", true),
            new Button.NPC.Zone("KAISINEL", "http://aiondatabase.net/en/npcs/110020000/", true),
            new Button.NPC.Zone("KAISINEL_ACADEMY", "http://aiondatabase.net/en/npcs/110070000/", true),
            new Button.NPC.Zone("WISPLIGHT_ABBEY", "http://aiondatabase.net/en/npcs/130090000/", true),
            new Button.NPC.Zone("POETA", "http://aiondatabase.net/en/npcs/210010000/", true),
            new Button.NPC.Zone("ELTNEN", "http://aiondatabase.net/en/npcs/210020000/", true),
            new Button.NPC.Zone("VERTERON", "http://aiondatabase.net/en/npcs/210030000/", true),
            new Button.NPC.Zone("HEIRON", "http://aiondatabase.net/en/npcs/210040000/", true),
            new Button.NPC.Zone("THEOBOMOS", "http://aiondatabase.net/en/npcs/210060000/", true),
            new Button.NPC.Zone("ESTERRA", "http://aiondatabase.net/en/npcs/210100000/", true),
            new Button.NPC.Zone("TOWER_OF_ETERNITY_L", "http://aiondatabase.net/en/npcs/210110000/", true),
            new Button.NPC.Zone("LIVE_PARTY_CONCERT_HALL", "http://aiondatabase.net/en/npcs/600080000/", true),
            new Button.NPC.Zone("ORIEL", "http://aiondatabase.net/en/npcs/700010000/", true),
            new Button.NPC.Zone("INGGISON", "http://aiondatabase.net/en/npcs/210050000/", true),
            new Button.NPC.Zone("LF4_M", "http://aiondatabase.net/en/npcs/210130000/", true),
            new Button.NPC.Zone("SIGNIA", "http://aiondatabase.net/en/npcs/210070000/", true),
            new Button.NPC.Zone("GRIFFOEN", "http://aiondatabase.net/en/npcs/210080000/", true),
            new Button.NPC.Zone("IDIAN_DEPTHS_L", "http://aiondatabase.net/en/npcs/210090000/", true),
            new Button.NPC.Zone("GELKMAROS", "http://aiondatabase.net/en/npcs/220070000/", true),
            new Button.NPC.Zone("DF4_M", "http://aiondatabase.net/en/npcs/220140000/", true),
            new Button.NPC.Zone("VENGAR", "http://aiondatabase.net/en/npcs/220080000/", true),
            new Button.NPC.Zone("HABROK", "http://aiondatabase.net/en/npcs/220090000/", true),
            new Button.NPC.Zone("IDIAN_DEPTHS_D", "http://aiondatabase.net/en/npcs/220100000/", true),
            new Button.NPC.Zone("SILENTERA_CANYON", "http://aiondatabase.net/en/npcs/600010000/", true),
            new Button.NPC.Zone("TIAMAT_DOWN", "http://aiondatabase.net/en/npcs/600040000/", true),
            new Button.NPC.Zone("TIAMAT_DOWN_M", "http://aiondatabase.net/en/npcs/600041000/", true),
            new Button.NPC.Zone("KALDOR", "http://aiondatabase.net/en/npcs/600090000/", true),
            new Button.NPC.Zone("AKARON", "http://aiondatabase.net/en/npcs/600100000/", true),
            new Button.NPC.Zone("TIAMARANTA_EYE", "http://aiondatabase.net/en/npcs/300400000/", true),
            new Button.NPC.Zone("SARPAN", "http://aiondatabase.net/en/npcs/600020000/", true),
            new Button.NPC.Zone("SARPAN_SKY", "http://aiondatabase.net/en/npcs/300410000/", true),
            new Button.NPC.Zone("TIAMARANTA", "http://aiondatabase.net/en/npcs/600030000/", true),
            new Button.NPC.Zone("UNDERPASS_M", "http://aiondatabase.net/en/npcs/600110000/", true),
            new Button.NPC.Zone("NORHTERN_KATALAM", "http://aiondatabase.net/en/npcs/600050000/", true),
            new Button.NPC.Zone("SOUTHERN_KATALAM", "http://aiondatabase.net/en/npcs/600060000/", true),
            new Button.NPC.Zone("UNDERGROUND_KATALAM", "http://aiondatabase.net/en/npcs/600070000/", true),
            new Button.NPC.Zone("RESHANTA", "http://aiondatabase.net/en/npcs/400010000/", true),
            new Button.NPC.Zone("BELUS", "http://aiondatabase.net/en/npcs/400020000/", true),
            new Button.NPC.Zone("TRANSIDIUM_ANNEX", "http://aiondatabase.net/en/npcs/400030000/", true),
            new Button.NPC.Zone("ASPIDA", "http://aiondatabase.net/en/npcs/400040000/", true),
            new Button.NPC.Zone("ATANATOS", "http://aiondatabase.net/en/npcs/400050000/", true),
            new Button.NPC.Zone("DISILLON", "http://aiondatabase.net/en/npcs/400060000/", true),
            new Button.NPC.Zone("DE_PRISON", "http://aiondatabase.net/en/npcs/510010000/", true),
            new Button.NPC.Zone("DF_PRISON", "http://aiondatabase.net/en/npcs/520010000/", true),
            new Button.NPC.Zone("ARENA_EVENT_L", "http://aiondatabase.net/en/npcs/210120000/", true),
            new Button.NPC.Zone("ARENA_EVENT_D", "http://aiondatabase.net/en/npcs/220130000/", true),
            new Button.NPC.Zone("IDABPRO", "http://aiondatabase.net/en/npcs/300010000/", true),
            new Button.NPC.Zone("NOCHSANA_TRAINING_CAMP", "http://aiondatabase.net/en/npcs/300030000/", true),
            new Button.NPC.Zone("PROTECTOR_REALM", "http://aiondatabase.net/en/npcs/300330000/", true),
            new Button.NPC.Zone("DARK_POETA", "http://aiondatabase.net/en/npcs/300040000/", true),
            new Button.NPC.Zone("ASTERIA_CHAMBER", "http://aiondatabase.net/en/npcs/300050000/", true),
            new Button.NPC.Zone("SULFUR_TREE_NEST", "http://aiondatabase.net/en/npcs/300060000/", true),
            new Button.NPC.Zone("CHAMBER_OF_ROAH", "http://aiondatabase.net/en/npcs/300070000/", true),
            new Button.NPC.Zone("LEFT_WING_CHAMBER", "http://aiondatabase.net/en/npcs/300080000/", true),
            new Button.NPC.Zone("RIGHT_WING_CHAMBER", "http://aiondatabase.net/en/npcs/300090000/", true),
            new Button.NPC.Zone("STEEL_RAKE", "http://aiondatabase.net/en/npcs/300100000/", true),
            new Button.NPC.Zone("DREDGION", "http://aiondatabase.net/en/npcs/300110000/", true),
            new Button.NPC.Zone("KYSIS_CHAMBER", "http://aiondatabase.net/en/npcs/300120000/", true),
            new Button.NPC.Zone("MIREN_CHAMBER", "http://aiondatabase.net/en/npcs/300130000/", true),
            new Button.NPC.Zone("KROTAN_CHAMBER", "http://aiondatabase.net/en/npcs/300140000/", true),
            new Button.NPC.Zone("UDAS_TEMPLE", "http://aiondatabase.net/en/npcs/300150000/", true),
            new Button.NPC.Zone("UDAS_TEMPLE_LOWER", "http://aiondatabase.net/en/npcs/300160000/", true),
            new Button.NPC.Zone("BESHMUNDIR_TEMPLE", "http://aiondatabase.net/en/npcs/300170000/", true),
            new Button.NPC.Zone("TALOCS_HOLLOW", "http://aiondatabase.net/en/npcs/300190000/", true),
            new Button.NPC.Zone("HARAMEL", "http://aiondatabase.net/en/npcs/300200000/", true),
            new Button.NPC.Zone("MUADA_TRENCHER", "http://aiondatabase.net/en/npcs/300380000/", true),
            new Button.NPC.Zone("DREDGION_OF_CHANTRA", "http://aiondatabase.net/en/npcs/300210000/", true),
            new Button.NPC.Zone("ABYSSAL_SPLINTER", "http://aiondatabase.net/en/npcs/300220000/", true),
            new Button.NPC.Zone("KROMEDE_TRIAL", "http://aiondatabase.net/en/npcs/300230000/", true),
            new Button.NPC.Zone("ATURAM_SKY_FORTRESS", "http://aiondatabase.net/en/npcs/300240000/", true),
            new Button.NPC.Zone("ATURAM_SKY_FORTRESS_BONUS", "http://aiondatabase.net/en/npcs/300241000/", true),
            new Button.NPC.Zone("ESOTERRACE", "http://aiondatabase.net/en/npcs/300250000/", true),
            new Button.NPC.Zone("RENTUS_BASE", "http://aiondatabase.net/en/npcs/300280000/", true),
            new Button.NPC.Zone("EMPYREAN_CRUCIBLE", "http://aiondatabase.net/en/npcs/300300000/", true),
            new Button.NPC.Zone("CRUCIBLE_CHALLENGE", "http://aiondatabase.net/en/npcs/300320000/", true),
            new Button.NPC.Zone("ARENA_OF_CHAOS", "http://aiondatabase.net/en/npcs/300350000/", true),
            new Button.NPC.Zone("ARENA_OF_DISCIPLINE", "http://aiondatabase.net/en/npcs/300360000/", true),
            new Button.NPC.Zone("CHAOS_TRAINING_GROUNDS", "http://aiondatabase.net/en/npcs/300420000/", true),
            new Button.NPC.Zone("DISCIPLINE_TRAINING_GROUNDS", "http://aiondatabase.net/en/npcs/300430000/", true),
            new Button.NPC.Zone("TERATH_DREDGION", "http://aiondatabase.net/en/npcs/300440000/", true),
            new Button.NPC.Zone("ARENA_OF_HARMONY", "http://aiondatabase.net/en/npcs/300450000/", true),
            new Button.NPC.Zone("STEEL_RAKE_CABIN", "http://aiondatabase.net/en/npcs/300460000/", true),
            new Button.NPC.Zone("SEALED_HALL_OF_KNOWLEDGE", "http://aiondatabase.net/en/npcs/300480000/", true),
            new Button.NPC.Zone("TIAMAT_STRONGHOLD", "http://aiondatabase.net/en/npcs/300510000/", true),
            new Button.NPC.Zone("DRAGON_LORD_REFUGE", "http://aiondatabase.net/en/npcs/300520000/", true),
            new Button.NPC.Zone("ETERNAL_BASTION", "http://aiondatabase.net/en/npcs/300540000/", true),
            new Button.NPC.Zone("VOID_CUBE", "http://aiondatabase.net/en/npcs/300580000/", true),
            new Button.NPC.Zone("ARENA_OF_GLORY", "http://aiondatabase.net/en/npcs/300550000/", true),
            new Button.NPC.Zone("SHUGO_IMPERIAL_TOMB", "http://aiondatabase.net/en/npcs/300560000/", true),
            new Button.NPC.Zone("IDLDF5Re_02", "http://aiondatabase.net/en/npcs/300530000/", true),
            new Button.NPC.Zone("HARMONY_TRAINING_GROUND", "http://aiondatabase.net/en/npcs/300570000/", true),
            new Button.NPC.Zone("OPHIDAN_BRIDGE", "http://aiondatabase.net/en/npcs/300590000/", true),
            new Button.NPC.Zone("UNSTABLE_ABYSSAL_SPLINTER", "http://aiondatabase.net/en/npcs/300600000/", true),
            new Button.NPC.Zone("IDTiamat_Israphel", "http://aiondatabase.net/en/npcs/300500000/", true),
            new Button.NPC.Zone("RAKSANG_RUINS", "http://aiondatabase.net/en/npcs/300610000/", true),
            new Button.NPC.Zone("RAKSANG", "http://aiondatabase.net/en/npcs/300310000/", true),
            new Button.NPC.Zone("IDTiamat_Solo", "http://aiondatabase.net/en/npcs/300490000/", true),
            new Button.NPC.Zone("OCCUPIED_RENTUS_BASE", "http://aiondatabase.net/en/npcs/300620000/", true),
            new Button.NPC.Zone("ANGUISHED_DRAGON_LORD_REFUGE", "http://aiondatabase.net/en/npcs/300630000/", true),
            new Button.NPC.Zone("THE_HEXWAY", "http://aiondatabase.net/en/npcs/300700000/", true),
            new Button.NPC.Zone("INFINITY_SHARD", "http://aiondatabase.net/en/npcs/300800000/", true),
            new Button.NPC.Zone("UNITY_TRAINING_GROUNDS", "http://aiondatabase.net/en/npcs/301100000/", true),
            new Button.NPC.Zone("IDRuneweapon_Q", "http://aiondatabase.net/en/npcs/300900000/", true),
            new Button.NPC.Zone("RUNADIUM", "http://aiondatabase.net/en/npcs/301110000/", true),
            new Button.NPC.Zone("IDLDF5RE_solo_Q", "http://aiondatabase.net/en/npcs/301000000/", true),
            new Button.NPC.Zone("IDShulack_Rose_Solo_01", "http://aiondatabase.net/en/npcs/301010000/", true),
            new Button.NPC.Zone("IDShulack_Rose_Solo_02", "http://aiondatabase.net/en/npcs/301020000/", true),
            new Button.NPC.Zone("IDShulack_Rose_01", "http://aiondatabase.net/en/npcs/301030000/", true),
            new Button.NPC.Zone("IDShulack_Rose_02", "http://aiondatabase.net/en/npcs/301040000/", true),
            new Button.NPC.Zone("IDShulack_Rose_03", "http://aiondatabase.net/en/npcs/301050000/", true),
            new Button.NPC.Zone("KAMARS_BATTLEFIELD", "http://aiondatabase.net/en/npcs/301120000/", true),
            new Button.NPC.Zone("SAURO_SUPPLY_BASE", "http://aiondatabase.net/en/npcs/301130000/", true),
            new Button.NPC.Zone("SEIZED_DANUAR_SANCTUARY", "http://aiondatabase.net/en/npcs/301140000/", true),
            new Button.NPC.Zone("ASTERIA_IU_SOLO", "http://aiondatabase.net/en/npcs/301150000/", true),
            new Button.NPC.Zone("NIGHTMARE_CIRCUS", "http://aiondatabase.net/en/npcs/301160000/", true),
            new Button.NPC.Zone("RUKIBUKI_CIRCUS_TROUPE_CAMP", "http://aiondatabase.net/en/npcs/301200000/", true),
            new Button.NPC.Zone("ENGULFED_OPHIDAN_BRIDGE", "http://aiondatabase.net/en/npcs/301210000/", true),
            new Button.NPC.Zone("IRON_WALL_WARFRONT", "http://aiondatabase.net/en/npcs/301220000/", true),
            new Button.NPC.Zone("ILLUMINARY_OBELISK", "http://aiondatabase.net/en/npcs/301230000/", true),
            new Button.NPC.Zone("LEGION_KYSIS_BARRACKS", "http://aiondatabase.net/en/npcs/301240000/", true),
            new Button.NPC.Zone("IDLDF5RE_02_L", "http://aiondatabase.net/en/npcs/301170000/", true),
            new Button.NPC.Zone("IDLDF5RE_03_L", "http://aiondatabase.net/en/npcs/301180000/", true),
            new Button.NPC.Zone("IDLDF5RE_Solo_L", "http://aiondatabase.net/en/npcs/301190000/", true),
            new Button.NPC.Zone("LEGION_MIREN_BARRACKS", "http://aiondatabase.net/en/npcs/301250000/", true),
            new Button.NPC.Zone("LEGION_KROTAN_BARRACKS", "http://aiondatabase.net/en/npcs/301260000/", true),
            new Button.NPC.Zone("LINKGATE_FOUNDRY", "http://aiondatabase.net/en/npcs/301270000/", true),
            new Button.NPC.Zone("KYSIS_BARRACKS", "http://aiondatabase.net/en/npcs/301280000/", true),
            new Button.NPC.Zone("MIREN_BARRACKS", "http://aiondatabase.net/en/npcs/301290000/", true),
            new Button.NPC.Zone("KROTAN_BARRACKS", "http://aiondatabase.net/en/npcs/301300000/", true),
            new Button.NPC.Zone("IDGEL_DOME", "http://aiondatabase.net/en/npcs/301310000/", true),
            new Button.NPC.Zone("LUCKY_OPHIDAN_BRIDGE", "http://aiondatabase.net/en/npcs/301320000/", true),
            new Button.NPC.Zone("RUNADIUM_BONUS", "http://aiondatabase.net/en/npcs/301330000/", true),
            new Button.NPC.Zone("LINKGATE_FOUNDRY_Q", "http://aiondatabase.net/en/npcs/301340000/", true),
            new Button.NPC.Zone("RUNADIUM_HEROIC", "http://aiondatabase.net/en/npcs/301360000/", true),
            new Button.NPC.Zone("INFERNAL_ILLUMINARY_OBELISK", "http://aiondatabase.net/en/npcs/301370000/", true),
            new Button.NPC.Zone("DANUAR_SANCTUARY", "http://aiondatabase.net/en/npcs/301380000/", true),
            new Button.NPC.Zone("DRAKENSPIRE_DEPTHS", "http://aiondatabase.net/en/npcs/301390000/", true),
            new Button.NPC.Zone("THE_SHUGO_EMPEROR_VAULT", "http://aiondatabase.net/en/npcs/301400000/", true),
            new Button.NPC.Zone("STONESPEAR_REACH", "http://aiondatabase.net/en/npcs/301500000/", true),
            new Button.NPC.Zone("SEALED_ARGENT_MANOR", "http://aiondatabase.net/en/npcs/301510000/", true),
            new Button.NPC.Zone("ARGENT_MANOR", "http://aiondatabase.net/en/npcs/300270000/", true),
            new Button.NPC.Zone("DRAKENSPIRE_DEPTHS_Q", "http://aiondatabase.net/en/npcs/301520000/", true),
            new Button.NPC.Zone("LIBRARY_OF_KNOWLEDGE", "http://aiondatabase.net/en/npcs/301540000/", true),
            new Button.NPC.Zone("GARDEN_OF_KNOWLEDGE", "http://aiondatabase.net/en/npcs/301550000/", true),
            new Button.NPC.Zone("MUSEUM_OF_KNOWLEDGE", "http://aiondatabase.net/en/npcs/301560000/", true),
            new Button.NPC.Zone("LIBRARY_OF_KNOWLEDGE_QUEST", "http://aiondatabase.net/en/npcs/301570000/", true),
            new Button.NPC.Zone("SANCTUARY_DUNGEON", "http://aiondatabase.net/en/npcs/301580000/", true),
            new Button.NPC.Zone("SHUGO_EMPEROR_VAULT", "http://aiondatabase.net/en/npcs/301590000/", true),
            new Button.NPC.Zone("ADMA_RUINS", "http://aiondatabase.net/en/npcs/301600000/", true),
            new Button.NPC.Zone("ELEMENTAL_LORDS_LABORATORY", "http://aiondatabase.net/en/npcs/301610000/", true),
            new Button.NPC.Zone("ELEMENTIS_FOREST", "http://aiondatabase.net/en/npcs/300260000/", true),
            new Button.NPC.Zone("ARKHALS_HIDDEN_SPACE", "http://aiondatabase.net/en/npcs/301620000/", true),
            new Button.NPC.Zone("HELL_PASS", "http://aiondatabase.net/en/npcs/301630000/", true),
            new Button.NPC.Zone("IDEVENT_DEF", "http://aiondatabase.net/en/npcs/301631000/", true),
            new Button.NPC.Zone("MECHANERKS_WEAPONS_FACTORY", "http://aiondatabase.net/en/npcs/301640000/", true),
            new Button.NPC.Zone("ASHUNATAL_DREDGION", "http://aiondatabase.net/en/npcs/301650000/", true),
            new Button.NPC.Zone("KROBAN_BASE", "http://aiondatabase.net/en/npcs/301660000/", true),
            new Button.NPC.Zone("BALAUR_MARCHING_ROUTE", "http://aiondatabase.net/en/npcs/301670000/", true),
            new Button.NPC.Zone("RUNATORIUM_RUINS", "http://aiondatabase.net/en/npcs/301680000/", true),
            new Button.NPC.Zone("AETHER_MINE", "http://aiondatabase.net/en/npcs/301690000/", true),
            new Button.NPC.Zone("TREASURE_ISLAND_OF_COURAGE", "http://aiondatabase.net/en/npcs/301700000/", true),
            new Button.NPC.Zone("MIRASH_REFUGE", "http://aiondatabase.net/en/npcs/301720000/", true),
            new Button.NPC.Zone("FIRE_TEMPLE_OF_MEMORY", "http://aiondatabase.net/en/npcs/302000000/", true),
            new Button.NPC.Zone("RIFT_OF_OBLIVION", "http://aiondatabase.net/en/npcs/302100000/", true),
            new Button.NPC.Zone("RIFT_OF_OBLIVION_BONUS", "http://aiondatabase.net/en/npcs/302100000/", true),
            new Button.NPC.Zone("SANCTUM_BATTLEFIELD", "http://aiondatabase.net/en/npcs/302200000/", true),
            new Button.NPC.Zone("PANDAEMONIUM_BATTLEFIELD", "http://aiondatabase.net/en/npcs/302300000/", true),
            new Button.NPC.Zone("GOLD_ARENA", "http://aiondatabase.net/en/npcs/302310000/", true),
            new Button.NPC.Zone("GOLDEN_CRUCIBLE", "http://aiondatabase.net/en/npcs/302320000/", true),
            new Button.NPC.Zone("KUMUKI_HIDEOUT", "http://aiondatabase.net/en/npcs/302330000/", true),
            new Button.NPC.Zone("SATRA_TREASURE_HOARD", "http://aiondatabase.net/en/npcs/300470000/", true),
            new Button.NPC.Zone("NARAKKALLI", "http://aiondatabase.net/en/npcs/302340000/", true),
            new Button.NPC.Zone("NEVIWIND_CANYON", "http://aiondatabase.net/en/npcs/302350000/", true),
            new Button.NPC.Zone("GOLD_ARENA_LONE_FIGHTER", "http://aiondatabase.net/en/npcs/302360000/", true),
            new Button.NPC.Zone("GOLDEN_CRUCIBLE_GROUP_BATTLE", "http://aiondatabase.net/en/npcs/302370000/", true),
            new Button.NPC.Zone("GOLD_ARENA_GROUP_BATTLES_L", "http://aiondatabase.net/en/npcs/302380000/", true),
            new Button.NPC.Zone("GOLDEN_CRUCIBLE_GROUP_BATTLES_L", "http://aiondatabase.net/en/npcs/302390000/", true),
            new Button.NPC.Zone("TOWER_OF_CHALLENGE", "http://aiondatabase.net/en/npcs/302400000/", true),
            new Button.NPC.Zone("GOLD_ARENA_GROUP_BATTLES_D", "http://aiondatabase.net/en/npcs/302410000/", true),
            new Button.NPC.Zone("GOLDEN_CRUCIBLE_GROUP_BATTLES_D", "http://aiondatabase.net/en/npcs/302420000/", true),
            new Button.NPC.Zone("KARAMATIS_A", "http://aiondatabase.net/en/npcs/310010000/", true),
            new Button.NPC.Zone("KARAMATIS_B", "http://aiondatabase.net/en/npcs/310020000/", true),
            new Button.NPC.Zone("AERDINA", "http://aiondatabase.net/en/npcs/310030000/", true),
            new Button.NPC.Zone("GERANAIA", "http://aiondatabase.net/en/npcs/310040000/", true),
            new Button.NPC.Zone("AETHEROGENETICS_LAB", "http://aiondatabase.net/en/npcs/310050000/", true),
            new Button.NPC.Zone("FRAGMENT_OF_DARKNESS", "http://aiondatabase.net/en/npcs/310060000/", true),
            new Button.NPC.Zone("SLIVER_OF_DARKNESS", "http://aiondatabase.net/en/npcs/310070000/", true),
            new Button.NPC.Zone("SANCTUM_UNDERGROUND_ARENA", "http://aiondatabase.net/en/npcs/310080000/", true),
            new Button.NPC.Zone("INDRATU_FORTRESS", "http://aiondatabase.net/en/npcs/310090000/", true),
            new Button.NPC.Zone("AZOTURAN_FORTRESS", "http://aiondatabase.net/en/npcs/310100000/", true),
            new Button.NPC.Zone("THEOBOMOS_LAB", "http://aiondatabase.net/en/npcs/310110000/", true),
            new Button.NPC.Zone("ATAXIAR_A", "http://aiondatabase.net/en/npcs/310120000/", true),
            new Button.NPC.Zone("ATAXIAR_B", "http://aiondatabase.net/en/npcs/320010000/", true),
            new Button.NPC.Zone("ATAXIAR_C", "http://aiondatabase.net/en/npcs/320020000/", true),
            new Button.NPC.Zone("BREGIRUN", "http://aiondatabase.net/en/npcs/320030000/", true),
            new Button.NPC.Zone("NIDALBER", "http://aiondatabase.net/en/npcs/320040000/", true),
            new Button.NPC.Zone("ARKANIS_TEMPLE", "http://aiondatabase.net/en/npcs/320050000/", true),
            new Button.NPC.Zone("SPACE_OF_OBLIVION", "http://aiondatabase.net/en/npcs/320060000/", true),
            new Button.NPC.Zone("SPACE_OF_DESTINY", "http://aiondatabase.net/en/npcs/320070000/", true),
            new Button.NPC.Zone("DRAUPNIR_CAVE", "http://aiondatabase.net/en/npcs/320080000/", true),
            new Button.NPC.Zone("TRINIEL_UNDERGROUND_ARENA", "http://aiondatabase.net/en/npcs/320090000/", true),
            new Button.NPC.Zone("FIRE_TEMPLE", "http://aiondatabase.net/en/npcs/320100000/", true),
            new Button.NPC.Zone("ALQUIMIA_RESEARCH_CENTER", "http://aiondatabase.net/en/npcs/320110000/", true),
            new Button.NPC.Zone("SHADOW_COURT_DUNGEON", "http://aiondatabase.net/en/npcs/320120000/", true),
            new Button.NPC.Zone("ADMA_STRONGHOLD", "http://aiondatabase.net/en/npcs/320130000/", true),
            new Button.NPC.Zone("ATAXIAR_D", "http://aiondatabase.net/en/npcs/320140000/", true),
            new Button.NPC.Zone("PADMARASHKA_CAVE", "http://aiondatabase.net/en/npcs/320150000/", true),
            new Button.NPC.Zone("HOLY_TOWER_L", "http://aiondatabase.net/en/npcs/310160000/", true),
            new Button.NPC.Zone("HOLY_TOWER_D", "http://aiondatabase.net/en/npcs/320160000/", true),
            new Button.NPC.Zone("HOUSING_LC_LEGION", "http://aiondatabase.net/en/npcs/700020000/", true),
            new Button.NPC.Zone("HOUSING_DC_LEGION", "http://aiondatabase.net/en/npcs/710020000/", true),
            new Button.NPC.Zone("ORIEL_STUDIO", "http://aiondatabase.net/en/npcs/720010000/", true),
            new Button.NPC.Zone("PERNON_STUDIO", "http://aiondatabase.net/en/npcs/730010000/", true)
        };
    }

    public class Button
    {
        public string Name;
        public string Url;
        public bool Stop;

        public Button(string name, string url = "", bool stop = false)
        {
            this.Name = name;
            this.Url = url;
            this.Stop = stop;
        }

        public class NPC : Button
        {
            public NPC(string name, string url = "", bool stop = false) : base(name, url, stop)
            {
                Name = name;
                Url = url;
                Stop = stop;
            }

            public void Parse()
            {
                NPC_Parser parser = new NPC_Parser(base.Name, base.Url);
            }

            public class Grade : NPC
            {
                public Grade(string name, string url = "", bool stop = false) : base(name, url, stop)
                {
                    Name = name;
                    Url = url;
                    Stop = stop;
                }
            }

            public class Zone : NPC
            {
                public Zone(string name, string url = "", bool stop = false) : base(name, url, stop)
                {
                    Name = name;
                    Url = url;
                    Stop = stop;
                }
            }
        }
    }
}
