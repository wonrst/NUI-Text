using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        string VS15 = "\ufe0e";
        string VS16 = "\ufe0f";
        string ZWJ  = "\u200d";

        string MALE_SIGN   = "\U00002642";
        string FEMALE_SIGN = "\U00002640";

        string HAND_SHAKE = "\U0001F91D";
        
        string HEAVY_BLACK_HEART = "\U00002764";
        string KISS = "\U0001F48B";

        string[] PEOPLE = {
            "\U0001F9D1", // Person
            "\U0001F468", // Man
            "\U0001F469", // Woman
        };

        string[] WORKS = {
            // PEOPLE + SKINS + ZWJ + WORKS
            "\U00002695", "\U0001F3EB", "\U00002696", "\U0001F33E", "\U0001F373", "\U0001F527", "\U0001F3ED", "\U0001F4BC",
            "\U0001F52C", "\U0001F4BB", "\U0001F3A4", "\U0001F3A8", "\U00002708", "\U0001F680", "\U0001F692", "\U0001F37C",
            // PEOPLE + SKINS + ZWJ + OBJECTS
            "\U0001F9AF", "\U0001F9BC", "\U0001F9BD",
            // STYLE
            "\U0001F9B0", "\U0001F9B3", "\U0001F9B2", "\U0001F9B1",

        };

        string[] WORKS2 = {
            // WORKS2 + SKIN + (ZWJ + SIGN + VS16)
            "\U0001F46E", "\U0001F575", "\U0001F482", "\U0001F477", "\U0001F473", "\U0001F935", "\U0001F470", "\U0001F9D9", "\U0001F9DA",
            "\U0001F9B8", "\U0001F9B9", "\U0001F9DB", "\U0001F9DC", "\U0001F9DD", "\U0001F486", "\U0001F487", "\U0001F6B6", "\U0001F9CD", "\U0001F9CE",
            // OBJECTS2 + SKIN + (ZWJ + SIGN + VS16)
            "\U0001F3C3", "\U0001F9D6", "\U0001F9D7", "\U0001F3CC", "\U0001F3C4", "\U0001F6A3", "\U0001F3CA", "\U000026F9", "\U0001F3CB",
            "\U0001F6B4", "\U0001F6B5", "\U0001F938", "\U0001F93D", "\U0001F93E", "\U0001F939", "\U0001F9D8", 
            // STYLE
            "\U0001F9D4", "\U0001F471", "\U0001F64D", "\U0001F64E", "\U0001F645", "\U0001F646", "\U0001F481", "\U0001F64B", "\U0001F9CF", "\U0001F647",
            "\U0001F926", "\U0001F937", 
        };

        // U+1F469 U+1F3FB U+200D U+1F91D U+200D U+1F469 U+1F3FC
        // U+1F9D1 U+1F3FF U+200D U+1F91D U+200D U+1F9D1 U+1F3FF
        // U+1F9D1 U+1F3FB U+200D U+2764 U+FE0F U+200D U+1F48B U+200D U+1F9D1 U+1F3FC
        // U+1F9D1 U+1F3FB U+200D U+2764 U+FE0F U+200D U+1F9D1 U+1F3FC

        string[] SKINS = {
            "\U0001F3FB", // Dark skin tone
            "\U0001F3FC", // Medium Dark skin tone
            "\U0001F3FD", // Medium skin tone
            "\U0001F3FE", // Medium Light skin tone
            "\U0001F3FF", // Light skin tone
        };

        string[] EMOJIS = {
            "☝", "⛹", "✊", "✋", "✌", "✍", "🎅", "🏂", "🏃", "🏄", "🏇", "🏊", "🏋", "🏌", "👂", "👃", "👆", "👇",
            "👈", "👉", "👊", "👋", "👌", "👍", "👎", "👏", "👐", "👦", "👧", "👨", "👩", "👮", "👰", "👱", "👲", "👳",
            "👴", "👵", "👶", "👷", "👸", "👼", "💁", "💂", "💃", "💅", "💆", "💇", "💪", "🕴", "🕵", "🕺", "🖐", "🖕",
            "🖖", "🙅", "🙆", "🙇", "🙋", "🙌", "🙍", "🙎", "🙏", "🚣", "🚴", "🚵", "🚶", "🛀", "🛌", "🤘", "🤙", "🤚",
            "🤛", "🤜", "🤝", "🤞", "🤟", "🤦", "🤰", "🤱", "🤲", "🤳", "🤴", "🤵", "🤶", "🤷", "🤸",
            "\U0001F977", "\U0001F934", "\U0001F478", "\U0001F472", "\U0001F9D5", "\U0001F47C", "\U0001F385", "\U0001F936", 
        };

        string[] VARIATIONS = {
            "\U00000023",	// # (1.1) NUMBER SIGN
            "\U0000002A",	// # (1.1) ASTERISK
            "\U00000030",	// # (1.1) DIGIT ZERO
            "\U00000031",	// # (1.1) DIGIT ONE
            "\U00000032",	// # (1.1) DIGIT TWO
            "\U00000033",	// # (1.1) DIGIT THREE
            "\U00000034",	// # (1.1) DIGIT FOUR
            "\U00000035",	// # (1.1) DIGIT FIVE
            "\U00000036",	// # (1.1) DIGIT SIX
            "\U00000037",	// # (1.1) DIGIT SEVEN
            "\U00000038",	// # (1.1) DIGIT EIGHT
            "\U00000039",	// # (1.1) DIGIT NINE
            "\U000000A9",	// # (1.1) COPYRIGHT SIGN
            "\U000000AE",	// # (1.1) REGISTERED SIGN
            "\U0000203C",	// # (1.1) DOUBLE EXCLAMATION MARK
            "\U00002049",	// # (3.0) EXCLAMATION QUESTION MARK
            "\U00002122",	// # (1.1) TRADE MARK SIGN
            "\U00002139",	// # (3.0) INFORMATION SOURCE
            "\U00002194",	// # (1.1) LEFT RIGHT ARROW
            "\U00002195",	// # (1.1) UP DOWN ARROW
            "\U00002196",	// # (1.1) NORTH WEST ARROW
            "\U00002197",	// # (1.1) NORTH EAST ARROW
            "\U00002198",	// # (1.1) SOUTH EAST ARROW
            "\U00002199",	// # (1.1) SOUTH WEST ARROW
            "\U000021A9",	// # (1.1) LEFTWARDS ARROW WITH HOOK
            "\U000021AA",	// # (1.1) RIGHTWARDS ARROW WITH HOOK
            "\U0000231A",	// # (1.1) WATCH
            "\U0000231B",	// # (1.1) HOURGLASS
            "\U00002328",	// # (1.1) KEYBOARD
            "\U000023CF",	// # (4.0) EJECT SYMBOL
            "\U000023E9",	// # (6.0) BLACK RIGHT-POINTING DOUBLE TRIANGLE
            "\U000023EA",	// # (6.0) BLACK LEFT-POINTING DOUBLE TRIANGLE
            "\U000023EB",	// # (6.0) BLACK UP-POINTING DOUBLE TRIANGLE
            "\U000023EC",	// # (6.0) BLACK DOWN-POINTING DOUBLE TRIANGLE
            "\U000023ED",	// # (6.0) BLACK RIGHT-POINTING DOUBLE TRIANGLE WITH VERTICAL BAR
            "\U000023EE",	// # (6.0) BLACK LEFT-POINTING DOUBLE TRIANGLE WITH VERTICAL BAR
            "\U000023EF",	// # (6.0) BLACK RIGHT-POINTING TRIANGLE WITH DOUBLE VERTICAL BAR
            "\U000023F0",	// # (6.0) ALARM CLOCK
            "\U000023F1",	// # (6.0) STOPWATCH
            "\U000023F2",	// # (6.0) TIMER CLOCK
            "\U000023F3",	// # (6.0) HOURGLASS WITH FLOWING SAND
            "\U000023F8",	// # (7.0) DOUBLE VERTICAL BAR
            "\U000023F9",	// # (7.0) BLACK SQUARE FOR STOP
            "\U000023FA",	// # (7.0) BLACK CIRCLE FOR RECORD
            "\U000024C2",	// # (1.1) CIRCLED LATIN CAPITAL LETTER M
            "\U000025AA",	// # (1.1) BLACK SMALL SQUARE
            "\U000025AB",	// # (1.1) WHITE SMALL SQUARE
            "\U000025B6",	// # (1.1) BLACK RIGHT-POINTING TRIANGLE
            "\U000025C0",	// # (1.1) BLACK LEFT-POINTING TRIANGLE
            "\U000025FB",	// # (3.2) WHITE MEDIUM SQUARE
            "\U000025FC",	// # (3.2) BLACK MEDIUM SQUARE
            "\U000025FD",	// # (3.2) WHITE MEDIUM SMALL SQUARE
            "\U000025FE",	// # (3.2) BLACK MEDIUM SMALL SQUARE
            "\U00002600",	// # (1.1) BLACK SUN WITH RAYS
            "\U00002601",	// # (1.1) CLOUD
            "\U00002602",	// # (1.1) UMBRELLA
            "\U00002603",	// # (1.1) SNOWMAN
            "\U00002604",	// # (1.1) COMET
            "\U0000260E",	// # (1.1) BLACK TELEPHONE
            "\U00002611",	// # (1.1) BALLOT BOX WITH CHECK
            "\U00002614",	// # (4.0) UMBRELLA WITH RAIN DROPS
            "\U00002615",	// # (4.0) HOT BEVERAGE
            "\U00002618",	// # (4.1) SHAMROCK
            "\U0000261D",	// # (1.1) WHITE UP POINTING INDEX
            "\U00002620",	// # (1.1) SKULL AND CROSSBONES
            "\U00002622",	// # (1.1) RADIOACTIVE SIGN
            "\U00002623",	// # (1.1) BIOHAZARD SIGN
            "\U00002626",	// # (1.1) ORTHODOX CROSS
            "\U0000262A",	// # (1.1) STAR AND CRESCENT
            "\U0000262E",	// # (1.1) PEACE SYMBOL
            "\U0000262F",	// # (1.1) YIN YANG
            "\U00002638",	// # (1.1) WHEEL OF DHARMA
            "\U00002639",	// # (1.1) WHITE FROWNING FACE
            "\U0000263A",	// # (1.1) WHITE SMILING FACE
            "\U00002640",	// # (1.1) FEMALE SIGN
            "\U00002642",	// # (1.1) MALE SIGN
            "\U00002648",	// # (1.1) ARIES
            "\U00002649",	// # (1.1) TAURUS
            "\U0000264A",	// # (1.1) GEMINI
            "\U0000264B",	// # (1.1) CANCER
            "\U0000264C",	// # (1.1) LEO
            "\U0000264D",	// # (1.1) VIRGO
            "\U0000264E",	// # (1.1) LIBRA
            "\U0000264F",	// # (1.1) SCORPIUS
            "\U00002650",	// # (1.1) SAGITTARIUS
            "\U00002651",	// # (1.1) CAPRICORN
            "\U00002652",	// # (1.1) AQUARIUS
            "\U00002653",	// # (1.1) PISCES
            "\U0000265F",	// # (1.1) BLACK CHESS PAWN
            "\U00002660",	// # (1.1) BLACK SPADE SUIT
            "\U00002663",	// # (1.1) BLACK CLUB SUIT
            "\U00002665",	// # (1.1) BLACK HEART SUIT
            "\U00002666",	// # (1.1) BLACK DIAMOND SUIT
            "\U00002668",	// # (1.1) HOT SPRINGS
            "\U0000267B",	// # (3.2) BLACK UNIVERSAL RECYCLING SYMBOL
            "\U0000267E",	// # (4.1) PERMANENT PAPER SIGN
            "\U0000267F",	// # (4.1) WHEELCHAIR SYMBOL
            "\U00002692",	// # (4.1) HAMMER AND PICK
            "\U00002693",	// # (4.1) ANCHOR
            "\U00002694",	// # (4.1) CROSSED SWORDS
            "\U00002695",	// # (4.1) STAFF OF AESCULAPIUS
            "\U00002696",	// # (4.1) SCALES
            "\U00002697",	// # (4.1) ALEMBIC
            "\U00002699",	// # (4.1) GEAR
            "\U0000269B",	// # (4.1) ATOM SYMBOL
            "\U0000269C",	// # (4.1) FLEUR-DE-LIS
            "\U000026A0",	// # (4.0) WARNING SIGN
            "\U000026A1",	// # (4.0) HIGH VOLTAGE SIGN
            "\U000026A7",	// # (4.1) MALE WITH STROKE AND MALE AND FEMALE SIGN
            "\U000026AA",	// # (4.1) MEDIUM WHITE CIRCLE
            "\U000026AB",	// # (4.1) MEDIUM BLACK CIRCLE
            "\U000026B0",	// # (4.1) COFFIN
            "\U000026B1",	// # (4.1) FUNERAL URN
            "\U000026BD",	// # (5.2) SOCCER BALL
            "\U000026BE",	// # (5.2) BASEBALL
            "\U000026C4",	// # (5.2) SNOWMAN WITHOUT SNOW
            "\U000026C5",	// # (5.2) SUN BEHIND CLOUD
            "\U000026C8",	// # (5.2) THUNDER CLOUD AND RAIN
            "\U000026CE",	// # (6.0) OPHIUCHUS
            "\U000026CF",	// # (5.2) PICK
            "\U000026D1",	// # (5.2) HELMET WITH WHITE CROSS
            "\U000026D3",	// # (5.2) CHAINS
            "\U000026D4",	// # (5.2) NO ENTRY
            "\U000026E9",	// # (5.2) SHINTO SHRINE
            "\U000026EA",	// # (5.2) CHURCH
            "\U000026F0",	// # (5.2) MOUNTAIN
            "\U000026F1",	// # (5.2) UMBRELLA ON GROUND
            "\U000026F2",	// # (5.2) FOUNTAIN
            "\U000026F3",	// # (5.2) FLAG IN HOLE
            "\U000026F4",	// # (5.2) FERRY
            "\U000026F5",	// # (5.2) SAILBOAT
            "\U000026F7",	// # (5.2) SKIER
            "\U000026F8",	// # (5.2) ICE SKATE
            "\U000026F9",	// # (5.2) PERSON WITH BALL
            "\U000026FA",	// # (5.2) TENT
            "\U000026FD",	// # (5.2) FUEL PUMP
            "\U00002702",	// # (1.1) BLACK SCISSORS
            "\U00002705",	// # (6.0) WHITE HEAVY CHECK MARK
            "\U00002708",	// # (1.1) AIRPLANE
            "\U00002709",	// # (1.1) ENVELOPE
            "\U0000270A",	// # (6.0) RAISED FIST
            "\U0000270B",	// # (6.0) RAISED HAND
            "\U0000270C",	// # (1.1) VICTORY HAND
            "\U0000270D",	// # (1.1) WRITING HAND
            "\U0000270F",	// # (1.1) PENCIL
            "\U00002712",	// # (1.1) BLACK NIB
            "\U00002714",	// # (1.1) HEAVY CHECK MARK
            "\U00002716",	// # (1.1) HEAVY MULTIPLICATION X
            "\U0000271D",	// # (1.1) LATIN CROSS
            "\U00002721",	// # (1.1) STAR OF DAVID
            "\U00002728",	// # (6.0) SPARKLES
            "\U00002733",	// # (1.1) EIGHT SPOKED ASTERISK
            "\U00002734",	// # (1.1) EIGHT POINTED BLACK STAR
            "\U00002744",	// # (1.1) SNOWFLAKE
            "\U00002747",	// # (1.1) SPARKLE
            "\U0000274C",	// # (6.0) CROSS MARK
            "\U0000274E",	// # (6.0) NEGATIVE SQUARED CROSS MARK
            "\U00002753",	// # (6.0) BLACK QUESTION MARK ORNAMENT
            "\U00002754",	// # (6.0) WHITE QUESTION MARK ORNAMENT
            "\U00002755",	// # (6.0) WHITE EXCLAMATION MARK ORNAMENT
            "\U00002757",	// # (5.2) HEAVY EXCLAMATION MARK SYMBOL
            "\U00002763",	// # (1.1) HEAVY HEART EXCLAMATION MARK ORNAMENT
            "\U00002764",	// # (1.1) HEAVY BLACK HEART
            "\U00002795",	// # (6.0) HEAVY PLUS SIGN
            "\U00002796",	// # (6.0) HEAVY MINUS SIGN
            "\U00002797",	// # (6.0) HEAVY DIVISION SIGN
            "\U000027A1",	// # (1.1) BLACK RIGHTWARDS ARROW
            "\U000027B0",	// # (6.0) CURLY LOOP
            "\U000027BF",	// # (6.0) DOUBLE CURLY LOOP
            "\U00002934",	// # (3.2) ARROW POINTING RIGHTWARDS THEN CURVING UPWARDS
            "\U00002935",	// # (3.2) ARROW POINTING RIGHTWARDS THEN CURVING DOWNWARDS
            "\U00002B05",	// # (4.0) LEFTWARDS BLACK ARROW
            "\U00002B06",	// # (4.0) UPWARDS BLACK ARROW
            "\U00002B07",	// # (4.0) DOWNWARDS BLACK ARROW
            "\U00002B1B",	// # (5.1) BLACK LARGE SQUARE
            "\U00002B1C",	// # (5.1) WHITE LARGE SQUARE
            "\U00002B50",	// # (5.1) WHITE MEDIUM STAR
            "\U00002B55",	// # (5.2) HEAVY LARGE CIRCLE
            "\U00003030",	// # (1.1) WAVY DASH
            "\U0000303D",	// # (3.2) PART ALTERNATION MARK
            "\U00003297",	// # (1.1) CIRCLED IDEOGRAPH CONGRATULATION
            "\U00003299",	// # (1.1) CIRCLED IDEOGRAPH SECRET
            "\U0001F004",	// # (5.1) MAHJONG TILE RED DRAGON
            "\U0001F170",	// # (6.0) NEGATIVE SQUARED LATIN CAPITAL LETTER A
            "\U0001F171",	// # (6.0) NEGATIVE SQUARED LATIN CAPITAL LETTER B
            "\U0001F17E",	// # (6.0) NEGATIVE SQUARED LATIN CAPITAL LETTER O
            "\U0001F17F",	// # (5.2) NEGATIVE SQUARED LATIN CAPITAL LETTER P
            "\U0001F202",	// # (6.0) SQUARED KATAKANA SA
            "\U0001F21A",	// # (5.2) SQUARED CJK UNIFIED IDEOGRAPH-7121
            "\U0001F22F",	// # (5.2) SQUARED CJK UNIFIED IDEOGRAPH-6307
            "\U0001F237",	// # (6.0) SQUARED CJK UNIFIED IDEOGRAPH-6708
            "\U0001F30D",	// # (6.0) EARTH GLOBE EUROPE-AFRICA
            "\U0001F30E",	// # (6.0) EARTH GLOBE AMERICAS
            "\U0001F30F",	// # (6.0) EARTH GLOBE ASIA-AUSTRALIA
            "\U0001F315",	// # (6.0) FULL MOON SYMBOL
            "\U0001F31C",	// # (6.0) LAST QUARTER MOON WITH FACE
            "\U0001F321",	// # (7.0) THERMOMETER
            "\U0001F324",	// # (7.0) WHITE SUN WITH SMALL CLOUD
            "\U0001F325",	// # (7.0) WHITE SUN BEHIND CLOUD
            "\U0001F326",	// # (7.0) WHITE SUN BEHIND CLOUD WITH RAIN
            "\U0001F327",	// # (7.0) CLOUD WITH RAIN
            "\U0001F328",	// # (7.0) CLOUD WITH SNOW
            "\U0001F329",	// # (7.0) CLOUD WITH LIGHTNING
            "\U0001F32A",	// # (7.0) CLOUD WITH TORNADO
            "\U0001F32B",	// # (7.0) FOG
            "\U0001F32C",	// # (7.0) WIND BLOWING FACE
            "\U0001F336",	// # (7.0) HOT PEPPER
            "\U0001F378",	// # (6.0) COCKTAIL GLASS
            "\U0001F37D",	// # (7.0) FORK AND KNIFE WITH PLATE
            "\U0001F393",	// # (6.0) GRADUATION CAP
            "\U0001F396",	// # (7.0) MILITARY MEDAL
            "\U0001F397",	// # (7.0) REMINDER RIBBON
            "\U0001F399",	// # (7.0) STUDIO MICROPHONE
            "\U0001F39A",	// # (7.0) LEVEL SLIDER
            "\U0001F39B",	// # (7.0) CONTROL KNOBS
            "\U0001F39E",	// # (7.0) FILM FRAMES
            "\U0001F39F",	// # (7.0) ADMISSION TICKETS
            "\U0001F3A7",	// # (6.0) HEADPHONE
            "\U0001F3AC",	// # (6.0) CLAPPER BOARD
            "\U0001F3AD",	// # (6.0) PERFORMING ARTS
            "\U0001F3AE",	// # (6.0) VIDEO GAME
            "\U0001F3C2",	// # (6.0) SNOWBOARDER
            "\U0001F3C4",	// # (6.0) SURFER
            "\U0001F3C6",	// # (6.0) TROPHY
            "\U0001F3CA",	// # (6.0) SWIMMER
            "\U0001F3CB",	// # (7.0) WEIGHT LIFTER
            "\U0001F3CC",	// # (7.0) GOLFER
            "\U0001F3CD",	// # (7.0) RACING MOTORCYCLE
            "\U0001F3CE",	// # (7.0) RACING CAR
            "\U0001F3D4",	// # (7.0) SNOW CAPPED MOUNTAIN
            "\U0001F3D5",	// # (7.0) CAMPING
            "\U0001F3D6",	// # (7.0) BEACH WITH UMBRELLA
            "\U0001F3D7",	// # (7.0) BUILDING CONSTRUCTION
            "\U0001F3D8",	// # (7.0) HOUSE BUILDINGS
            "\U0001F3D9",	// # (7.0) CITYSCAPE
            "\U0001F3DA",	// # (7.0) DERELICT HOUSE BUILDING
            "\U0001F3DB",	// # (7.0) CLASSICAL BUILDING
            "\U0001F3DC",	// # (7.0) DESERT
            "\U0001F3DD",	// # (7.0) DESERT ISLAND
            "\U0001F3DE",	// # (7.0) NATIONAL PARK
            "\U0001F3DF",	// # (7.0) STADIUM
            "\U0001F3E0",	// # (6.0) HOUSE BUILDING
            "\U0001F3ED",	// # (6.0) FACTORY
            "\U0001F3F3",	// # (7.0) WAVING WHITE FLAG
            "\U0001F3F5",	// # (7.0) ROSETTE
            "\U0001F3F7",	// # (7.0) LABEL
            "\U0001F408",	// # (6.0) CAT
            "\U0001F415",	// # (6.0) DOG
            "\U0001F41F",	// # (6.0) FISH
            "\U0001F426",	// # (6.0) BIRD
            "\U0001F43F",	// # (7.0) CHIPMUNK
            "\U0001F441",	// # (7.0) EYE
            "\U0001F442",	// # (6.0) EAR
            "\U0001F446",	// # (6.0) WHITE UP POINTING BACKHAND INDEX
            "\U0001F447",	// # (6.0) WHITE DOWN POINTING BACKHAND INDEX
            "\U0001F448",	// # (6.0) WHITE LEFT POINTING BACKHAND INDEX
            "\U0001F449",	// # (6.0) WHITE RIGHT POINTING BACKHAND INDEX
            "\U0001F44D",	// # (6.0) THUMBS UP SIGN
            "\U0001F44E",	// # (6.0) THUMBS DOWN SIGN
            "\U0001F453",	// # (6.0) EYEGLASSES
            "\U0001F46A",	// # (6.0) FAMILY
            "\U0001F47D",	// # (6.0) EXTRATERRESTRIAL ALIEN
            "\U0001F4A3",	// # (6.0) BOMB
            "\U0001F4B0",	// # (6.0) MONEY BAG
            "\U0001F4B3",	// # (6.0) CREDIT CARD
            "\U0001F4BB",	// # (6.0) PERSONAL COMPUTER
            "\U0001F4BF",	// # (6.0) OPTICAL DISC
            "\U0001F4CB",	// # (6.0) CLIPBOARD
            "\U0001F4DA",	// # (6.0) BOOKS
            "\U0001F4DF",	// # (6.0) PAGER
            "\U0001F4E4",	// # (6.0) OUTBOX TRAY
            "\U0001F4E5",	// # (6.0) INBOX TRAY
            "\U0001F4E6",	// # (6.0) PACKAGE
            "\U0001F4EA",	// # (6.0) CLOSED MAILBOX WITH LOWERED FLAG
            "\U0001F4EB",	// # (6.0) CLOSED MAILBOX WITH RAISED FLAG
            "\U0001F4EC",	// # (6.0) OPEN MAILBOX WITH RAISED FLAG
            "\U0001F4ED",	// # (6.0) OPEN MAILBOX WITH LOWERED FLAG
            "\U0001F4F7",	// # (6.0) CAMERA
            "\U0001F4F9",	// # (6.0) VIDEO CAMERA
            "\U0001F4FA",	// # (6.0) TELEVISION
            "\U0001F4FB",	// # (6.0) RADIO
            "\U0001F4FD",	// # (7.0) FILM PROJECTOR
            "\U0001F508",	// # (6.0) SPEAKER
            "\U0001F50D",	// # (6.0) LEFT-POINTING MAGNIFYING GLASS
            "\U0001F512",	// # (6.0) LOCK
            "\U0001F513",	// # (6.0) OPEN LOCK
            "\U0001F549",	// # (7.0) OM SYMBOL
            "\U0001F54A",	// # (7.0) DOVE OF PEACE
            "\U0001F550",	// # (6.0) CLOCK FACE ONE OCLOCK
            "\U0001F551",	// # (6.0) CLOCK FACE TWO OCLOCK
            "\U0001F552",	// # (6.0) CLOCK FACE THREE OCLOCK
            "\U0001F553",	// # (6.0) CLOCK FACE FOUR OCLOCK
            "\U0001F554",	// # (6.0) CLOCK FACE FIVE OCLOCK
            "\U0001F555",	// # (6.0) CLOCK FACE SIX OCLOCK
            "\U0001F556",	// # (6.0) CLOCK FACE SEVEN OCLOCK
            "\U0001F557",	// # (6.0) CLOCK FACE EIGHT OCLOCK
            "\U0001F558",	// # (6.0) CLOCK FACE NINE OCLOCK
            "\U0001F559",	// # (6.0) CLOCK FACE TEN OCLOCK
            "\U0001F55A",	// # (6.0) CLOCK FACE ELEVEN OCLOCK
            "\U0001F55B",	// # (6.0) CLOCK FACE TWELVE OCLOCK
            "\U0001F55C",	// # (6.0) CLOCK FACE ONE-THIRTY
            "\U0001F55D",	// # (6.0) CLOCK FACE TWO-THIRTY
            "\U0001F55E",	// # (6.0) CLOCK FACE THREE-THIRTY
            "\U0001F55F",	// # (6.0) CLOCK FACE FOUR-THIRTY
            "\U0001F560",	// # (6.0) CLOCK FACE FIVE-THIRTY
            "\U0001F561",	// # (6.0) CLOCK FACE SIX-THIRTY
            "\U0001F562",	// # (6.0) CLOCK FACE SEVEN-THIRTY
            "\U0001F563",	// # (6.0) CLOCK FACE EIGHT-THIRTY
            "\U0001F564",	// # (6.0) CLOCK FACE NINE-THIRTY
            "\U0001F565",	// # (6.0) CLOCK FACE TEN-THIRTY
            "\U0001F566",	// # (6.0) CLOCK FACE ELEVEN-THIRTY
            "\U0001F567",	// # (6.0) CLOCK FACE TWELVE-THIRTY
            "\U0001F56F",	// # (7.0) CANDLE
            "\U0001F570",	// # (7.0) MANTELPIECE CLOCK
            "\U0001F573",	// # (7.0) HOLE
            "\U0001F574",	// # (7.0) MAN IN BUSINESS SUIT LEVITATING
            "\U0001F575",	// # (7.0) SLEUTH OR SPY
            "\U0001F576",	// # (7.0) DARK SUNGLASSES
            "\U0001F577",	// # (7.0) SPIDER
            "\U0001F578",	// # (7.0) SPIDER WEB
            "\U0001F579",	// # (7.0) JOYSTICK
            "\U0001F587",	// # (7.0) LINKED PAPERCLIPS
            "\U0001F58A",	// # (7.0) LOWER LEFT BALLPOINT PEN
            "\U0001F58B",	// # (7.0) LOWER LEFT FOUNTAIN PEN
            "\U0001F58C",	// # (7.0) LOWER LEFT PAINTBRUSH
            "\U0001F58D",	// # (7.0) LOWER LEFT CRAYON
            "\U0001F590",	// # (7.0) RAISED HAND WITH FINGERS SPLAYED
            "\U0001F5A5",	// # (7.0) DESKTOP COMPUTER
            "\U0001F5A8",	// # (7.0) PRINTER
            "\U0001F5B1",	// # (7.0) THREE BUTTON MOUSE
            "\U0001F5B2",	// # (7.0) TRACKBALL
            "\U0001F5BC",	// # (7.0) FRAME WITH PICTURE
            "\U0001F5C2",	// # (7.0) CARD INDEX DIVIDERS
            "\U0001F5C3",	// # (7.0) CARD FILE BOX
            "\U0001F5C4",	// # (7.0) FILE CABINET
            "\U0001F5D1",	// # (7.0) WASTEBASKET
            "\U0001F5D2",	// # (7.0) SPIRAL NOTE PAD
            "\U0001F5D3",	// # (7.0) SPIRAL CALENDAR PAD
            "\U0001F5DC",	// # (7.0) COMPRESSION
            "\U0001F5DD",	// # (7.0) OLD KEY
            "\U0001F5DE",	// # (7.0) ROLLED-UP NEWSPAPER
            "\U0001F5E1",	// # (7.0) DAGGER KNIFE
            "\U0001F5E3",	// # (7.0) SPEAKING HEAD IN SILHOUETTE
            "\U0001F5E8",	// # (7.0) LEFT SPEECH BUBBLE
            "\U0001F5EF",	// # (7.0) RIGHT ANGER BUBBLE
            "\U0001F5F3",	// # (7.0) BALLOT BOX WITH BALLOT
            "\U0001F5FA",	// # (7.0) WORLD MAP
            "\U0001F610",	// # (6.0) NEUTRAL FACE
            "\U0001F687",	// # (6.0) METRO
            "\U0001F68D",	// # (6.0) ONCOMING BUS
            "\U0001F691",	// # (6.0) AMBULANCE
            "\U0001F694",	// # (6.0) ONCOMING POLICE CAR
            "\U0001F698",	// # (6.0) ONCOMING AUTOMOBILE
            "\U0001F6AD",	// # (6.0) NO SMOKING SYMBOL
            "\U0001F6B2",	// # (6.0) BICYCLE
            "\U0001F6B9",	// # (6.0) MENS SYMBOL
            "\U0001F6BA",	// # (6.0) WOMENS SYMBOL
            "\U0001F6BC",	// # (6.0) BABY SYMBOL
            "\U0001F6CB",	// # (7.0) COUCH AND LAMP
            "\U0001F6CD",	// # (7.0) SHOPPING BAGS
            "\U0001F6CE",	// # (7.0) BELLHOP BELL
            "\U0001F6CF",	// # (7.0) BED
            "\U0001F6E0",	// # (7.0) HAMMER AND WRENCH
            "\U0001F6E1",	// # (7.0) SHIELD
            "\U0001F6E2",	// # (7.0) OIL DRUM
            "\U0001F6E3",	// # (7.0) MOTORWAY
            "\U0001F6E4",	// # (7.0) RAILWAY TRACK
            "\U0001F6E5",	// # (7.0) MOTOR BOAT
            "\U0001F6E9",	// # (7.0) SMALL AIRPLANE
            "\U0001F6F0",	// # (7.0) SATELLITE
            "\U0001F6F3"	// # (7.0) PASSENGER SHIP
        };

        const bool HORIZONTAL = true;
        const bool VERITCAL = false;
        const int  MATCH_PARENT = LayoutParamPolicies.MatchParent;
        const int  WRAP_CONTENT = LayoutParamPolicies.WrapContent;

        // View EMOJI_VIEW;
        ScrollableBase EMOJI_VIEW;

        // config
        const int ROW = 25;
        const int WIDTH = 40;
        const int HEIGHT = 40;
        const string FONT = "SamsungOneUI_600";
        const float FONT_SIZE = 30;
        const int SKIN_VIEW_WIDTH = (WIDTH + 1) * (6) - 1;
        const int SKINWORK_VIEW_WIDTH = (WIDTH + 1) * (18) - 1;
        const int VARIATION_VIEW_WIDTH = (WIDTH + 1) * (3) - 1;
        const int VERT_VIEW_HEIGHT = (HEIGHT + 1) * 25;
        const int BUTTON_WIDTH = (WIDTH + 1) * 6 - 1;
        
        const int COMPLEX_VIEW_WIDTH = (WIDTH + 1) * (25) - 1;

        const int TEST_VIEW_WIDTH = 1920;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(1920, 1080));
        }

        public void GenerateUI(Size windowSize)
        {
            Window window = Window.Instance;
            window.WindowSize = windowSize;

            var view = NewView(VERITCAL, MATCH_PARENT, MATCH_PARENT);
            window.Add(view);

            var menuView = NewView(HORIZONTAL, MATCH_PARENT, WRAP_CONTENT);
            view.Add(menuView);

            EMOJI_VIEW = new ScrollableBase()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            view.Add(EMOJI_VIEW);

            // EMOJI_VIEW = NewView(HORIZONTAL, MATCH_PARENT, MATCH_PARENT);
            // view.Add(EMOJI_VIEW);

            var skinButton = NewButton("SKINTONE");
            menuView.Add(skinButton);
            skinButton.Clicked += (s, e) =>
            {
                ClearEmojiView();
                AddSkinTest();
            };

            var skinWorkButton = NewButton("SKINTONE VARIATION");
            menuView.Add(skinWorkButton);
            skinWorkButton.Clicked += (s, e) =>
            {
                ClearEmojiView();
                AddSkinWorkTest();
            };

            var complexButton = NewButton("COMPLEX VARIATION");
            menuView.Add(complexButton);
            complexButton.Clicked += (s, e) =>
            {
                ClearEmojiView();
                AddComplexTest();
            };

            var variationButton = NewButton("VARIATION");
            menuView.Add(variationButton);
            variationButton.Clicked += (s, e) =>
            {
                ClearEmojiView();
                AddVariationTest();
            };

            int fontIndex = -1;
            string[] fonts = {"SamsungColorEmoji", "SamsungOneUI_300", "SamsungOneUI_600"};

            var variationFontButton = NewButton("VARIATION FONT");
            menuView.Add(variationFontButton);
            variationFontButton.Clicked += (s, e) =>
            {
                ClearEmojiView();
                fontIndex ++;
                if (fontIndex % fonts.Length == 0)
                {
                    fontIndex = 0;
                }
                string fontFamily = fonts[fontIndex];
                variationFontButton.Text = fontFamily;
                AddVariationFontTest(fontFamily);
            };







            int fontCount = 0;

            var testButton = NewButton("TEST");
            testButton.WidthSpecification = LayoutParamPolicies.MatchParent;
            menuView.Add(testButton);
            testButton.Clicked += (s, e) =>
            {
                ClearEmojiView();

                string[] array = {
                    //"✨✨\ufe0e✨\ufe0f",

                    "🥵🥵😶‍🌫️😶‍🌫️🤕🤕✨✨✨🥳🥳✨✨✨✨✨✨🥳🥳✨✨✨✨✨🥵🥵🥵",
                    "✨✨✨✨✨",
                    "✨✨✨✨✨✨🥵🥵😶‍🌫️😶‍🌫️🤕🤕",
                    "🥵🥵🥵🤕✨✨✨✨🥳🥳",

                    "Hello World✨✨✨🥳🥳✨✨✨Hell✨✨✨🥳🥳✨✨✨✨✨🥵🥵🥵world",
                    "✨H✨E✨L✨L✨O",
                    "H✨E✨\ufe0fL✨\ufe0eL✨O✨✨🥵🥵😶‍🌫️😶‍🌫️🤕🤕",
                    "😶‍🌫️EMOJI🥵🥵🥵🤕✨\ufe0e✨✨\ufe0f✨🥳🥳",

                    "🥵🥵😶‍🌫️😶‍🌫️🤕🤕✨\ufe0e✨\ufe0e✨\ufe0e🥳🥳✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e🥳🥳✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e🥵🥵🥵",
                    "✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e",
                    "✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e🥵🥵😶‍🌫️😶‍🌫️🤕🤕",
                    "🥵🥵🥵🤕✨\ufe0e✨\ufe0e✨\ufe0e✨\ufe0e🥳🥳",

                    "🥵🥵😶‍🌫️😶‍🌫️🤕🤕✨\ufe0f✨\ufe0f✨\ufe0f🥳🥳✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f🥳🥳✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f🥵🥵🥵",
                    "✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f",
                    "✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f🥵🥵😶‍🌫️😶‍🌫️🤕🤕",
                    "🥵🥵🥵🤕✨\ufe0f✨\ufe0f✨\ufe0f✨\ufe0f🥳🥳",

                    "🥵🥵😶‍🌫️😶‍🌫️🤕🤕✨\ufe0f✨\ufe0e✨\ufe0f🥳🥳✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f🥳🥳✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0e🥵🥵🥵",
                    "✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0e",
                    "✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0e🥵🥵😶‍🌫️😶‍🌫️🤕🤕",
                    "🥵🥵🥵🤕✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0e🥳🥳",

                    "Hello world✨\ufe0f✨\ufe0e✨\ufe0f🥳🥳✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f🥳🥳✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0e🥵🥵🥵",
                    "✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0eworld",
                    "Hello world✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0e✨\ufe0f✨\ufe0eworld🥵🥵😶‍🌫️😶‍🌫️🤕🤕",
                    "Hell✨\ufe0fo✨\ufe0eW✨\ufe0f✨\ufe0eorld🥳🥳"
                };

                View vertView = NewVertView(TEST_VIEW_WIDTH);
                EMOJI_VIEW.Add(vertView);

                fontCount ++;
                string fontfamily = "SamsungOneUI_600";
                if (fontCount % 3 == 0)
                {
                    fontfamily = "SamsungOneUI_600";
                    testButton.Text = "TEST 600";
                }
                else if (fontCount % 3 == 1)
                {
                    fontfamily = "SamsungColorEmoji";
                    testButton.Text = "TEST COLOR";
                }
                else
                {
                    fontfamily = "SamsungOneUI_300";
                    testButton.Text = "TEST 300";
                }

                for (int i = 0 ; i < array.Length ; i ++)
                {
                    var label = NewTextLabel(array[i]);
                    label.PixelSize = 20;
                    label.FontFamily = fontfamily;
                    label.WidthSpecification = LayoutParamPolicies.MatchParent;
                    label.HorizontalAlignment = HorizontalAlignment.Begin;
                    vertView.Add(label);
                }
            };


            // U+1F9D1 U+1F3FB U+200D U+1F91D U+200D U+1F9D1 U+1F3FB
            View vertView = NewVertView(SKIN_VIEW_WIDTH);
            EMOJI_VIEW.Add(vertView);
            var test = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = SKIN_VIEW_WIDTH,
                HeightSpecification = HEIGHT,
                BackgroundColor = Color.Black,
            };
            vertView.Add(test);

            // View vertView = NewVertView(SKIN_VIEW_WIDTH);
            // EMOJI_VIEW.Add(vertView);
            // for (int i = 0 ; i < EMOJIS.Length ; i ++)
            // {
            //     if (i != 0 && i % ROW == 0)
            //     {
            //         vertView = NewVertView(SKIN_VIEW_WIDTH);
            //         EMOJI_VIEW.Add(vertView);
            //     }
            //     vertView.Add(NewSkinView(i));
            // }
        }

        public void ClearEmojiView()
        {
            int count = (int)EMOJI_VIEW.GetChildCount();
            Tizen.Log.Error(TAG, $"count : {count}\n");
            for (int i = 0 ; i < count ; i ++)
            {
                var item = EMOJI_VIEW.GetChildAt(0);
                EMOJI_VIEW.Remove(item);
                if (item is View)
                {
                    int horViewCount = (int)item.GetChildCount();
                    for (int j = 0 ; j < horViewCount ; j ++)
                    {
                        var horView = item.GetChildAt(0);
                        item.Remove(horView);
                    }
                }
            }
        }

        public void AddSkinTest()
        {
            var view = NewView(VERITCAL, SKIN_VIEW_WIDTH, VERT_VIEW_HEIGHT);
            EMOJI_VIEW.Add(view);
            for (int i = 0 ; i < EMOJIS.Length ; i ++)
            {
                if (i != 0 && i % ROW == 0)
                {
                    view = NewView(VERITCAL, SKIN_VIEW_WIDTH, VERT_VIEW_HEIGHT);
                    EMOJI_VIEW.Add(view);
                }
                view.Add(NewSkinView(i));
            }
        }

        public void AddSkinWorkTest()
        {
            var view = NewView(VERITCAL, SKINWORK_VIEW_WIDTH, VERT_VIEW_HEIGHT);
            EMOJI_VIEW.Add(view);
            int worksIndex = 0;
            for (int i = 0 ; i < WORKS.Length ; i ++)
            {
                if (i != 0 && i % ROW == 0)
                {
                    view = NewView(VERITCAL, SKINWORK_VIEW_WIDTH, VERT_VIEW_HEIGHT);
                    EMOJI_VIEW.Add(view);
                }
                view.Add(NewSkinWorkView(i));
                worksIndex = i;
            }
            worksIndex ++;
            for (int i = 0 ; i < WORKS2.Length ; i ++)
            {
                if (i + worksIndex != 0 && (i + worksIndex) % ROW == 0)
                {
                    view = NewView(VERITCAL, SKINWORK_VIEW_WIDTH, VERT_VIEW_HEIGHT);
                    EMOJI_VIEW.Add(view);
                }
                view.Add(NewSkinWork2View(i));
            }
        }

        public void AddComplexTest()
        {
            var view = NewView(VERITCAL, COMPLEX_VIEW_WIDTH, VERT_VIEW_HEIGHT);
            EMOJI_VIEW.Add(view);
            // people, men, women, woman and man
            for (int i = 0 ; i < 4 ; i ++)
            {
                view.Add(NewHandShakeView(i));
            }
            for (int i = 0 ; i < 4 ; i ++)
            {
                view.Add(NewKissView(i));
            }
            for (int i = 0 ; i < 4 ; i ++)
            {
                view.Add(NewCoupleView(i));
            }
        }

        public void AddVariationTest()
        {
            var view = NewView(VERITCAL, VARIATION_VIEW_WIDTH, VERT_VIEW_HEIGHT);
            EMOJI_VIEW.Add(view);
            for (int i = 0 ; i < VARIATIONS.Length ; i ++)
            {
                if (i != 0 && i % ROW == 0)
                {
                    view = NewView(VERITCAL, VARIATION_VIEW_WIDTH, VERT_VIEW_HEIGHT);
                    EMOJI_VIEW.Add(view);
                }
                view.Add(NewVariationView(i));
            }
        }

        public void AddVariationFontTest(string fontFamily)
        {
            var view = NewView(VERITCAL, VARIATION_VIEW_WIDTH, VERT_VIEW_HEIGHT);
            EMOJI_VIEW.Add(view);
            for (int i = 0 ; i < VARIATIONS.Length ; i ++)
            {
                if (i != 0 && i % ROW == 0)
                {
                    view = NewView(VERITCAL, VARIATION_VIEW_WIDTH, VERT_VIEW_HEIGHT);
                    EMOJI_VIEW.Add(view);
                }
                view.Add(NewVariationFont(i, fontFamily));
            }
        }

        public View NewSkinView(int emojiIndex)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = SKIN_VIEW_WIDTH,
                HeightSpecification = HEIGHT,
                BackgroundColor = Color.Black,
            };

            view.Add(NewTextLabel(EMOJIS[emojiIndex]));
            view.Add(NewTextLabel(EMOJIS[emojiIndex] + VS15));
            view.Add(NewTextLabel(EMOJIS[emojiIndex] + VS16));

            for (int i = 0 ; i < SKINS.Length ; i ++)
            {
                view.Add(NewTextLabel(EMOJIS[emojiIndex] + SKINS[i]));
            }
            return view;
        }

        public View NewSkinWorkView(int emojiIndex)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = SKINWORK_VIEW_WIDTH,
                HeightSpecification = HEIGHT,
                BackgroundColor = Color.Black,
            };

            // PEOPLE + SKINS + ZWJ + WORKS
            for (int peopleIndex = 0 ; peopleIndex < PEOPLE.Length ; peopleIndex ++)
            {
                view.Add(NewTextLabel(PEOPLE[peopleIndex] + ZWJ + WORKS[emojiIndex]));

                for (int i = 0 ; i < SKINS.Length ; i ++)
                {
                    view.Add(NewTextLabel(PEOPLE[peopleIndex] + SKINS[i] + ZWJ + WORKS[emojiIndex]));
                }
            }

            return view;
        }

        public View NewSkinWork2View(int emojiIndex)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = SKINWORK_VIEW_WIDTH,
                HeightSpecification = HEIGHT,
                BackgroundColor = Color.Black,
            };

            // WORKS2 + SKIN + (ZWJ + SIGN + VS16)
            view.Add(NewTextLabel(WORKS2[emojiIndex]));
            for (int i = 0 ; i < SKINS.Length ; i ++)
            {
                view.Add(NewTextLabel(WORKS2[emojiIndex] + SKINS[i]));
            }
            view.Add(NewTextLabel(WORKS2[emojiIndex] + ZWJ + MALE_SIGN + VS16));
            for (int i = 0 ; i < SKINS.Length ; i ++)
            {
                view.Add(NewTextLabel(WORKS2[emojiIndex] + SKINS[i] + ZWJ + MALE_SIGN + VS16));
            }
            view.Add(NewTextLabel(WORKS2[emojiIndex] + ZWJ + FEMALE_SIGN + VS16));
            for (int i = 0 ; i < SKINS.Length ; i ++)
            {
                view.Add(NewTextLabel(WORKS2[emojiIndex] + SKINS[i] + ZWJ + FEMALE_SIGN + VS16));
            }

            return view;
        }

        public View NewHandShakeView(int emojiIndex)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = COMPLEX_VIEW_WIDTH,
                HeightSpecification = HEIGHT,
                BackgroundColor = Color.Black,
            };

            // PERSON + SKIN + ZWJ + HAND_SHAKE + ZWJ + PERSON + SKIN
            string PERSON  = emojiIndex > 2 ? PEOPLE[2] : PEOPLE[emojiIndex];
            string PERSON2 = emojiIndex > 2 ? PEOPLE[1] : PEOPLE[emojiIndex];

            string[] PERSON_AND_PERSON = {
                "",
                "\U0001F46C", // MEN
                "\U0001F46D", // WOMEN
                "\U0001F46B"  // WOMAN AND MAN
            };

            string MAN_AND_MAN = PERSON_AND_PERSON[emojiIndex];

            if (emojiIndex == 0) // person
            {
                view.Add(NewTextLabel(PERSON + ZWJ + HAND_SHAKE + ZWJ + PERSON2));
            }
            else
            {
                view.Add(NewTextLabel(MAN_AND_MAN));
            }

            for (int i = 0 ; i < SKINS.Length ; i ++)
            for (int j = 0 ; j < SKINS.Length ; j ++)
            {
                if (emojiIndex > 0 && i == j)
                {
                    view.Add(NewTextLabel(MAN_AND_MAN + SKINS[i]));
                }
                else
                {
                    view.Add(NewTextLabel(PERSON + SKINS[i] + ZWJ + HAND_SHAKE + ZWJ + PERSON2 + SKINS[j]));
                }
            }

            return view;
        }

        public View NewKissView(int emojiIndex)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = COMPLEX_VIEW_WIDTH,
                HeightSpecification = HEIGHT,
                BackgroundColor = Color.Black,
            };

            // U+1F9D1 U+1F3FB U+200D U+2764 U+FE0F U+200D U+1F48B U+200D U+1F9D1 U+1F3FC
            // PERSON + SKIN + ZWJ + HEART + VS16 + ZWJ + KISS + ZWJ + PERSON + SKIN

            // PEOPLE, MEN, WOMEN, WOMAN AND MAN

            string PERSON  = emojiIndex > 2 ? PEOPLE[2] : PEOPLE[emojiIndex];
            string PERSON2 = emojiIndex > 2 ? PEOPLE[1] : PEOPLE[emojiIndex];

            string MAN_AND_MAN = "\U0001F48F";

            if (emojiIndex == 0) // person
            {
                view.Add(NewTextLabel(MAN_AND_MAN));
            }
            else
            {
                view.Add(NewTextLabel(PERSON + ZWJ + HEAVY_BLACK_HEART + VS16 + ZWJ + KISS + ZWJ + PERSON2));
            }

            for (int i = 0 ; i < SKINS.Length ; i ++)
            for (int j = 0 ; j < SKINS.Length ; j ++)
            {
                if (emojiIndex == 0 && i == j) // person
                {
                    view.Add(NewTextLabel(MAN_AND_MAN + SKINS[i]));
                }
                else
                {
                   view.Add(NewTextLabel(PERSON + SKINS[i] + ZWJ + HEAVY_BLACK_HEART + VS16 + ZWJ + KISS + ZWJ + PERSON2 + SKINS[j]));
                }
            }

            return view;
        }

        public View NewCoupleView(int emojiIndex)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = COMPLEX_VIEW_WIDTH,
                HeightSpecification = HEIGHT,
                BackgroundColor = Color.Black,
            };

            // U+1F9D1 U+1F3FB U+200D U+2764 U+FE0F U+200D U+1F9D1 U+1F3FC
            // PERSON + SKIN + ZWJ + HEART + VS16 + ZWJ + PERSON + SKIN

            // PEOPLE, MEN, WOMEN, WOMAN AND MAN
            string PERSON  = emojiIndex > 2 ? PEOPLE[2] : PEOPLE[emojiIndex];
            string PERSON2 = emojiIndex > 2 ? PEOPLE[1] : PEOPLE[emojiIndex];

            string COUPLE = "\U0001F491";

            if (emojiIndex == 0) // person
            {
                view.Add(NewTextLabel(COUPLE));
            }
            else
            {
                view.Add(NewTextLabel(PERSON + ZWJ + HEAVY_BLACK_HEART + VS16 + ZWJ + PERSON2));
            }

            for (int i = 0 ; i < SKINS.Length ; i ++)
            for (int j = 0 ; j < SKINS.Length ; j ++)
            {
                if (emojiIndex == 0 && i == j) // person
                {
                    view.Add(NewTextLabel(COUPLE + SKINS[i]));
                }
                else
                {
                   view.Add(NewTextLabel(PERSON + SKINS[i] + ZWJ + HEAVY_BLACK_HEART + VS16 + ZWJ + PERSON2 + SKINS[j]));
                }
            }

            return view;
        }

        public View NewVariationView(int variationIndex)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = VARIATION_VIEW_WIDTH,
                HeightSpecification = HEIGHT,
                BackgroundColor = Color.Black,
            };

            view.Add(NewTextLabel(VARIATIONS[variationIndex]));
            view.Add(NewTextLabel(VARIATIONS[variationIndex] + VS15));
            view.Add(NewTextLabel(VARIATIONS[variationIndex] + VS16));

            return view;
        }

        public TextLabel NewVariationFont(int variationIndex, string fontFamily)
        {
            string variation = VARIATIONS[variationIndex] + VARIATIONS[variationIndex] + VS15 + VARIATIONS[variationIndex] + VS16;
            var label = NewTextLabel(variation);
            label.WidthSpecification = VARIATION_VIEW_WIDTH;
            label.FontFamily = fontFamily;
            return label;
        }

        public View NewView(bool horizontal, int width, int height)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = horizontal ? LinearLayout.Orientation.Horizontal : LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = width,
                HeightSpecification = height,
                BackgroundColor = Color.Black,
                Margin = new Extents(0, 1, 0, 0),
            };
            return view;
        }

        public View NewVertView(int width)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = width,
                HeightSpecification = VERT_VIEW_HEIGHT,
                BackgroundColor = Color.Black,
            };
            return view;
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                Ellipsis = false,
                WidthSpecification = WIDTH,
                HeightSpecification = WIDTH,
                BackgroundColor = Color.White,
                FontFamily = FONT,
                PixelSize = FONT_SIZE,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                RenderMode = TextRenderMode.AsyncAuto,
            };
            return label;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                WidthSpecification = BUTTON_WIDTH,
                HeightSpecification = HEIGHT,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
            };
            button.TextLabel.PixelSize = 16.0f;
            return button;
        }

        public ButtonStyle NewButtonStyle()
        {
            var style = new ButtonStyle
            {
                CornerRadius = 0.0f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.0f, 0.0f, 0.0f, 1.0f),
                    Pressed = new Color(0.25f, 0.0f, 0.0f, 0.3f),
                },
                Overlay = new ImageViewStyle()
                {
                    BackgroundColor = new Selector<Color>()
                    {
                        Pressed = new Color(0, 0, 0, 0.1f),
                        Other = new Color(1, 1, 1, 0.1f),
                    },
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                }
            };
            return style;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
