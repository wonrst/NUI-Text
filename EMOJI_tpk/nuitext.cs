using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        public const string TAG = "EMOJI";

        public TapGestureDetector TapDetector;
        public TapGestureDetector ClearDetector;
        public TapGestureDetector ClearLogDetector;
        public TapGestureDetector ScaleDetector;
        public TapGestureDetector HelpDetector;

        public View VIEW;
        public View MAIN_VIEW;
        public View LOG_VIEW;
        public TextLabel WORK_BENCH;
        public Dictionary<string, string> EMOJI_DICTIONARY = new Dictionary<string, string>();
        public List<string> HISTORY = new List<string>();

        public Timer TIMER;

        // CONFIG
        public static float SCALE = 1.2f;
        public static float SCALE_STEP = 0.2f;

        public static bool ASYNC = true;

        public static int ROW = 18;
        public static int COL = 19;

        public static float PIXEL_SIZE = 29.0f;
        public static int CELL = 1;
        public static int WIDTH = 30;
        public static int HEIGHT = 29;
        public static int LOG_WIDTH = 300;

        public static int LOG_HEIGHT = (HEIGHT + CELL) * (COL - 1) - 1;
        public static int NUM_OF_BUTTON = 3;
        public static string FONT = "NotoColorEmoji";

        public static int MATCH_PARENT = -1;
        public static int WRAP_CONTENT = -2;
        public static bool HORIZONTAL = true;

        public static string EMPTY = "";
        public static string EMPTY_UNICODE = "";
        public static string EMPTY_LABEL = "";
        public static string EMPTY_DESCRIPTION = "";

        protected override void OnCreate()
        {
            base.OnCreate();

            Initialize();

            TIMER = new Timer(500);
            TIMER.Tick += (s, e) =>
            {
                ClearAll();
                SCALE += SCALE_STEP;
                SCALE = SCALE > 2.6f ? 0.6f : SCALE;
                ScaleUpdate();

                return true;
            };

            Window.Instance.KeyEvent += OnKeyEvent;
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                return;                    
            }

            if (e.Key.KeyPressedName == "F1")
            {
                PrintShortcut();
            }
            else if (e.Key.KeyPressedName == "F2")
            {
                ASYNC = false;
                Tizen.Log.Info(TAG, "Sync rendering \n");
            }
            else if (e.Key.KeyPressedName == "F3")
            {
                ASYNC = true;
                Tizen.Log.Info(TAG, "Async rendering \n");
            }
            else if (e.Key.KeyPressedName == "F5")
            {
                ClearAll();
                ScaleUpdate();
                Tizen.Log.Info(TAG, "Refresh \n");
            }
            else if (e.Key.KeyPressedName == "Escape")
            {
                if (TIMER.IsRunning())
                {
                    TIMER.Stop();
                    Tizen.Log.Info(TAG, "Scale Test Stop \n");
                }
                else
                {
                    TIMER.Start();
                    Tizen.Log.Info(TAG, "Scale Test Start \n");
                }
            }
            else if (e.Key.KeyPressedName == "1")
            {
                ClearAll();
                SCALE = 1.0f;
                ScaleUpdate();
                Tizen.Log.Info(TAG, "Scale set : 1.0 \n");
            }
            else if (e.Key.KeyPressedName == "2")
            {
                ClearAll();
                SCALE = 2.0f;
                ScaleUpdate();
                Tizen.Log.Info(TAG, "Scale set : 2.0 \n");
            }
            else if (e.Key.KeyPressedName == "3")
            {
                ClearAll();
                SCALE -= SCALE_STEP;
                SCALE = SCALE < 0.59f ? 2.4f : SCALE;
                ScaleUpdate();
                Tizen.Log.Info(TAG, $"Scale down : {SCALE} \n");
            }
            else if (e.Key.KeyPressedName == "4")
            {
                ClearAll();
                SCALE += SCALE_STEP;
                SCALE = SCALE > 2.6f ? 0.6f : SCALE;
                ScaleUpdate();
                Tizen.Log.Info(TAG, $"Scale up : {SCALE} \n");
            }
            else if (e.Key.KeyPressedName == "9")
            {
                bool isRunning = TIMER.IsRunning();
                TIMER.Interval -= 100;
                if (!isRunning) TIMER.Stop();
                Tizen.Log.Info(TAG, $"Scale Test Interval Down : {TIMER.Interval} \n");
            }
            else if (e.Key.KeyPressedName == "0")
            {
                bool isRunning = TIMER.IsRunning();
                TIMER.Interval += 100;
                if (!isRunning) TIMER.Stop();
                Tizen.Log.Info(TAG, $"Scale Test Interval Up : {TIMER.Interval} \n");
            }
        }

        public void PrintShortcut()
        {
            Tizen.Log.Error(TAG, "EMOJI TEST HELP                  \n");
            Tizen.Log.Info (TAG, "F1    : Help                     \n");
            Tizen.Log.Info (TAG, "F2    : Sync  rendering          \n");
            Tizen.Log.Info (TAG, "F3    : Async rendering          \n");
            Tizen.Log.Info (TAG, "F5    : Refresh                  \n");
            Tizen.Log.Info (TAG, "ESC   : Scale Test Start/Stop    \n");
            Tizen.Log.Info (TAG, "Num 1 : Scale 1.0                \n");
            Tizen.Log.Info (TAG, "Num 2 : Scale 2.0                \n");
            Tizen.Log.Info (TAG, "Num 3 : Scale Down               \n");
            Tizen.Log.Info (TAG, "Num 4 : Scale Up                 \n");

            Tizen.Log.Info (TAG, "Num 9 : Scale Test Interval Down \n");
            Tizen.Log.Info (TAG, "Num 0 : Scale Test Interval Up   \n");
        }

        public void Initialize()
        {
            SetConfig();
            GenerateUI();
            GenerateEmoji();
        }

        public void GenerateEmoji()
        {
            // COMMON
            string ZWJ = "\u200d";
            string ZWNJ = "\u200c";
            string VS15 = "\ufe0e";
            string VS16 = "\ufe0f";


            // * 1 *
            View EMOJI_VIEW_1 = AddView(MAIN_VIEW);

            string[] FACE_ARY = {"\U0001F600", "\U0001F970", "\U0001F60B", "\U0001F917",
                                 "\U0001F910", "\U0001F60C", "\U0001F637", "\U0001F631",
                                 "\U0001F97A", "\U0001F615", "\U0001F923", "\U0001FAE0",
                                 "\U0001F607", "\U0001F970", "\U0001F911", "\U0001F914", "\U0001F976", "\U0001F92F"};

            AddEmoji(EMOJI_VIEW_1, FACE_ARY);


            // * 2 *
            string FACE_WITHOUT_MOUSE = "\U0001F636";
            string CLOUD = "\U0001F32B";
            string FACE_IN_CLOUD = FACE_WITHOUT_MOUSE + ZWJ + CLOUD + VS16;

            string FACE_SMILE = "\U0001F62E";
            string DASH = "\U0001F4A8";
            string FACE_EXHALING = FACE_SMILE + ZWJ + DASH;

            string FACE_X_EYE = "\U0001F635";
            string DIZZY = "\U0001F4AB";
            string FACE_SPIRAL = FACE_X_EYE + ZWJ + DIZZY;

            View EMOJI_VIEW_2 = AddView(MAIN_VIEW);

            string[] FACE_COMB_ARY = {FACE_WITHOUT_MOUSE, CLOUD, FACE_IN_CLOUD,
                                      FACE_SMILE, DASH, FACE_EXHALING,
                                      FACE_X_EYE, DIZZY, FACE_SPIRAL};

            string[] FACE_COMB_DESC_ARY = {"FACE_WITHOUT_MOUSE", "CLOUD", "FACE_IN_CLOUD = FACE_WITHOUT_MOUSE + ZWJ + CLOUD + VS16",
                                           "FACE_SMILE", "DASH", "FACE_EXHALING = FACE_SMILE + ZWJ + DASH",
                                           "FACE_X_EYE", "DIZZY", "FACE_SPIRAL = FACE_X_EYE + ZWJ + DIZZY"};

            AddEmoji(EMOJI_VIEW_2, FACE_COMB_ARY, FACE_COMB_DESC_ARY);

            string COWBOY = "\U0001F920";
            string PARTY = "\U0001F973";
            string DISGUISED = "\U0001F978";

            string SUNGLASS = "\U0001F60E";
            string NERD = "\U0001F913";
            string MONOCLE = "\U0001F9D0";

            string MOUTH = "\U0001F92C";
            string DEVIL = "\U0001F608";
            string SKULL = "\U0001F480";

            string[] FACE_MORE_ARY = {COWBOY, PARTY, DISGUISED, SUNGLASS, NERD, MONOCLE, MOUTH, DEVIL, SKULL};
            string[] FACE_MORE_DESC_ARY = {"COWBOY", "PARTY", "DISGUISED", "SUNGLASS", "NERD", "MONOCLE", "MOUTH", "DEVIL", "SKULL"};

            AddEmoji(EMOJI_VIEW_2, FACE_MORE_ARY, FACE_MORE_DESC_ARY);


            // * 3 *
            string RED_HEART = "\u2764";
            string FIRE = "\U0001F525";
            string HEART_ON_FIRE = RED_HEART + VS16 + ZWJ + FIRE;

            string EYE = "\U0001F441";
            string SPEECH_BUBBLE = "\U0001F5E8";
            string EYE_IN_SPEECH_BUBBLE = EYE + VS16 + ZWJ + SPEECH_BUBBLE + VS16;

            string NINJA = "\U0001F977";
            string PRINCE = "\U0001F934";
            string BABY = "\U0001F47C";

            View EMOJI_VIEW_3 = AddView(MAIN_VIEW);

            string[] EMOTION_ARY = {"\U0001F48B", "\U0001F4AF", "\U0001F4A2", "\U0001F4A5",
                                    "\U0001F4A6", "\U0001F573", "\U0001F4AC", "\U0001F4A4", "\U0001F4AD"};

            AddEmoji(EMOJI_VIEW_3, EMOTION_ARY);

            string[] EMOTION_COMB_ARY = {RED_HEART, FIRE, HEART_ON_FIRE,
                                         EYE, SPEECH_BUBBLE, EYE_IN_SPEECH_BUBBLE,
                                         NINJA, PRINCE, BABY};

            string[] EMOTION_COMB_DESC_ARY = {"RED_HEART", "FIRE", "HEART_ON_FIRE = RED_HEART + VS16 + ZWJ + FIRE",
                                              "EYE", "SPEECH_BUBBLE", "EYE_IN_SPEECH_BUBBLE = EYE + VS16 + ZWJ + SPEECH_BUBBLE + VS16",
                                              "NINJA", "PRINCE", "BABY"};

            AddEmoji(EMOJI_VIEW_3, EMOTION_COMB_ARY, EMOTION_COMB_DESC_ARY);


            // * 4 *
            // PERSON
            string MALE_SIGN = "\u2642";
            string FEMALE_SIGN = "\u2640";
            string TRANSGENDER_SIGN = "\u26A7";

            string BEARD = "\U0001F9D4";
            string BEARD_MAN = BEARD + ZWJ + MALE_SIGN + VS16;
            string BEARD_WOMAN = BEARD + ZWJ + FEMALE_SIGN + VS16;

            string BLOND = "\U0001F471";
            string BLOND_MAN = BLOND + ZWJ + MALE_SIGN + VS16;
            string BLOND_WOMAN = BLOND + ZWJ + FEMALE_SIGN + VS16;

            string DEAF = "\U0001F9CF";
            string DEAF_MAN = DEAF + ZWJ + MALE_SIGN + VS16;
            string DEAF_WOMAN = DEAF + ZWJ + FEMALE_SIGN + VS16;

            string OLDER_PERSON = "\U0001F9D3";
            string OLDER_MAN = "\U0001F474";
            string OLDER_WOMAN = "\U0001F475";

            string PERSON = "\U0001F9D1";
            string MAN = "\U0001F468";
            string WOMAN = "\U0001F469";

            View EMOJI_VIEW_4 = AddView(MAIN_VIEW);

            string[] PERSON_ARY = {MALE_SIGN, FEMALE_SIGN, TRANSGENDER_SIGN,
                                   BEARD, BEARD_MAN, BEARD_WOMAN,
                                   BLOND, BLOND_MAN, BLOND_WOMAN,
                                   DEAF, DEAF_MAN, DEAF_WOMAN,
                                   OLDER_PERSON, OLDER_MAN, OLDER_WOMAN,
                                   PERSON, MAN, WOMAN};

            string[] PERSON_DESC_ARY = {"MALE_SIGN", "FEMALE_SIGN", "TRANSGENDER_SIGN",
                                        "BEARD", "BEARD_MAN = BEARD + ZWJ + MALE_SIGN + VS16", "BEARD_WOMAN = BEARD + ZWJ + FEMALE_SIGN + VS16",
                                        "BLOND", "BLOND_MAN = BLOND + ZWJ + MALE_SIGN + VS16", "BLOND_WOMAN = BLOND + ZWJ + FEMALE_SIGN + VS16",
                                        "DEAF", "DEAF_MAN = DEAF + ZWJ + MALE_SIGN + VS16", "DEAF_WOMAN = DEAF + ZWJ + FEMALE_SIGN + VS16",
                                        "OLDER_PERSON", "OLDER_MAN", "OLDER_WOMAN",
                                        "PERSON", "MAN", "WOMAN"};

            AddEmoji(EMOJI_VIEW_4, PERSON_ARY, PERSON_DESC_ARY);


            // * 5 *
            string RED_HAIR = "\U0001F9B0";
            string CURLY_HAIR = "\U0001F9B1";
            string WHITE_HAIR = "\U0001F9B3";
            string BALD_HAIR = "\U0001F9B2";

            string PERSON_HAIR1 = PERSON + ZWJ + RED_HAIR;
            string PERSON_HAIR2 = PERSON + ZWJ + CURLY_HAIR;
            string PERSON_HAIR3 = PERSON + ZWJ + WHITE_HAIR;
            string PERSON_HAIR4 = PERSON + ZWJ + BALD_HAIR;

            string MAN_HAIR1 = MAN + ZWJ + RED_HAIR;
            string MAN_HAIR2 = MAN + ZWJ + CURLY_HAIR;
            string MAN_HAIR3 = MAN + ZWJ + WHITE_HAIR;
            string MAN_HAIR4 = MAN + ZWJ + BALD_HAIR;

            string WOMAN_HAIR1 = WOMAN + ZWJ + RED_HAIR;
            string WOMAN_HAIR2 = WOMAN + ZWJ + CURLY_HAIR;
            string WOMAN_HAIR3 = WOMAN + ZWJ + WHITE_HAIR;
            string WOMAN_HAIR4 = WOMAN + ZWJ + BALD_HAIR;

            string BOY = "\U0001F466";
            string GIRL = "\U0001F467";

            View EMOJI_VIEW_5 = AddView(MAIN_VIEW);

            string[] HAIR_ARY = {RED_HAIR, CURLY_HAIR, WHITE_HAIR, BALD_HAIR,
                                 PERSON_HAIR1, PERSON_HAIR2, PERSON_HAIR3, PERSON_HAIR4,
                                 MAN_HAIR1, MAN_HAIR2, MAN_HAIR3, MAN_HAIR4,
                                 WOMAN_HAIR1, WOMAN_HAIR2, WOMAN_HAIR3, WOMAN_HAIR4,
                                 BOY, GIRL};

            string[] HAIR_DESC_ARY = {"RED_HAIR", "CURLY_HAIR", "WHITE_HAIR", "BALD_HAIR",
                                      "PERSON_HAIR1 = PERSON + ZWJ + RED_HAIR",
                                      "PERSON_HAIR2 = PERSON + ZWJ + CURLY_HAIR",
                                      "PERSON_HAIR3 = PERSON + ZWJ + WHITE_HAIR",
                                      "PERSON_HAIR4 = PERSON + ZWJ + BALD_HAIR",
                                      "MAN_HAIR1 = MAN + ZWJ + RED_HAIR",
                                      "MAN_HAIR2 = MAN + ZWJ + CURLY_HAIR",
                                      "MAN_HAIR3 = MAN + ZWJ + WHITE_HAIR",
                                      "MAN_HAIR4 = MAN + ZWJ + BALD_HAIR",
                                      "WOMAN_HAIR1 = WOMAN + ZWJ + RED_HAIR",
                                      "WOMAN_HAIR2 = WOMAN + ZWJ + CURLY_HAIR",
                                      "WOMAN_HAIR3 = WOMAN + ZWJ + WHITE_HAIR",
                                      "WOMAN_HAIR4 = WOMAN + ZWJ + BALD_HAIR",
                                      "BOY", "GIRL"};

            AddEmoji(EMOJI_VIEW_5, HAIR_ARY, HAIR_DESC_ARY);


            // * 6 *
            string MEDICAL_SYMBOL = "\u2695";
            string BALANCE_SCALE = "\u2696";
            string AIR_PLANE = "\u2708";
            string GRADUATION_CAP = "\U0001F393";
            string SCHOOL = "\U0001F3EB";
            string RICE = "\U0001F33E";
            string COOKING = "\U0001F373";
            string WRENCH = "\U0001F527";
            string MICRO_SCOPE = "\U0001F52C";
            string LAPTOP = "\U0001F4BB";
            string ROCKET = "\U0001F680";
            string PALETTE = "\U0001F3A8";

            View EMOJI_VIEW_6 = AddView(MAIN_VIEW);

            string[] WORK_ARY = {MEDICAL_SYMBOL, BALANCE_SCALE, AIR_PLANE, GRADUATION_CAP,
                                 SCHOOL, RICE, COOKING, WRENCH,
                                 MICRO_SCOPE, LAPTOP, ROCKET, PALETTE};

            string[] WORK_DESC_ARY = {"MEDICAL_SYMBOL", "BALANCE_SCALE", "AIR_PLANE", "GRADUATION_CAP",
                                      "SCHOOL", "RICE", "COOKING", "WRENCH",
                                      "MICRO_SCOPE", "LAPTOP", "ROCKET", "PALETTE"};

            AddEmoji(EMOJI_VIEW_6, WORK_ARY, WORK_DESC_ARY);

            string DETECTIVE = "\U0001F575";
            string DETECTIVE_MAN = DETECTIVE + VS16 + ZWJ + MALE_SIGN + VS16;
            string DETECTIVE_WOMAN = DETECTIVE + VS16 + ZWJ + FEMALE_SIGN + VS16;

            string GUARD = "\U0001F482";
            string GUARD_MAN = GUARD + ZWJ + MALE_SIGN + VS16;
            string GUARD_WOMAN = GUARD + ZWJ + FEMALE_SIGN + VS16;

            string[] WORK_COMB_ARY = {DETECTIVE, DETECTIVE_MAN, DETECTIVE_WOMAN,
                                      GUARD, GUARD_MAN, GUARD_WOMAN};

            string[] WORK_COMB_DESC_ARY = {"DETECTIVE",
                                           "DETECTIVE_MAN = DETECTIVE + VS16 + ZWJ + MALE_SIGN + VS16",
                                           "DETECTIVE_WOMAN = DETECTIVE + VS16 + ZWJ + FEMALE_SIGN + VS16",
                                           "GUARD",
                                           "GUARD_MAN = GUARD + ZWJ + MALE_SIGN + VS16",
                                           "GUARD_WOMAN = GUARD + ZWJ + FEMALE_SIGN + VS16"};

            AddEmoji(EMOJI_VIEW_6, WORK_COMB_ARY, WORK_COMB_DESC_ARY);


            // * 7 *
            string PERSON_DOCTOR = PERSON + ZWJ + MEDICAL_SYMBOL + VS16;
            string MAN_DOCTOR = MAN + ZWJ + MEDICAL_SYMBOL + VS16;
            string WOMAN_DOCTOR = WOMAN + ZWJ + MEDICAL_SYMBOL + VS16;

            string PERSON_JUDGE = PERSON + ZWJ + BALANCE_SCALE + VS16;
            string MAN_JUDGE = MAN + ZWJ + BALANCE_SCALE + VS16;
            string WOMAN_JUDGE = WOMAN + ZWJ + BALANCE_SCALE + VS16;

            string PERSON_PILOT = PERSON + ZWJ + AIR_PLANE + VS16;
            string MAN_PILOT = MAN + ZWJ + AIR_PLANE + VS16;
            string WOMAN_PILOT = WOMAN + ZWJ + AIR_PLANE + VS16;

            string PERSON_STUDENT = PERSON + ZWJ + GRADUATION_CAP;
            string MAN_STUDENT = MAN + ZWJ + GRADUATION_CAP;
            string WOMAN_STUDENT = WOMAN + ZWJ + GRADUATION_CAP;

            string PERSON_TEACHER = PERSON + ZWJ + SCHOOL;
            string MAN_TEACHER = MAN + ZWJ + SCHOOL;
            string WOMAN_TEACHER = WOMAN + ZWJ + SCHOOL;

            string PERSON_FARMER = PERSON + ZWJ + RICE;
            string MAN_FARMER = MAN + ZWJ + RICE;
            string WOMAN_FARMER = WOMAN + ZWJ + RICE;

            View EMOJI_VIEW_7 = AddView(MAIN_VIEW);

            string[] WORK_COMB2_ARY = {PERSON_DOCTOR, MAN_DOCTOR, WOMAN_DOCTOR,
                                       PERSON_JUDGE, MAN_JUDGE, WOMAN_JUDGE,
                                       PERSON_PILOT, MAN_PILOT, WOMAN_PILOT,
                                       PERSON_STUDENT, MAN_STUDENT, WOMAN_STUDENT,
                                       PERSON_TEACHER, MAN_TEACHER, WOMAN_TEACHER,
                                       PERSON_FARMER, MAN_FARMER, WOMAN_FARMER};

            string[] WORK_COMB2_DESC_ARY = {"PERSON_DOCTOR = PERSON + ZWJ + MEDICAL_SYMBOL + VS16",
                                            "MAN_DOCTOR = MAN + ZWJ + MEDICAL_SYMBOL + VS16",
                                            "WOMAN_DOCTOR = WOMAN + ZWJ + MEDICAL_SYMBOL + VS16",
                                            "PERSON_JUDGE = PERSON + ZWJ + BALANCE_SCALE + VS16",
                                            "MAN_JUDGE = MAN + ZWJ + BALANCE_SCALE + VS16",
                                            "WOMAN_JUDGE = WOMAN + ZWJ + BALANCE_SCALE + VS16",
                                            "PERSON_PILOT = PERSON + ZWJ + AIR_PLANE + VS16",
                                            "MAN_PILOT = MAN + ZWJ + AIR_PLANE + VS16",
                                            "WOMAN_PILOT = WOMAN + ZWJ + AIR_PLANE + VS16",
                                            "PERSON_STUDENT = PERSON + ZWJ + GRADUATION_CAP",
                                            "MAN_STUDENT = MAN + ZWJ + GRADUATION_CAP",
                                            "WOMAN_STUDENT = WOMAN + ZWJ + GRADUATION_CAP",
                                            "PERSON_TEACHER = PERSON + ZWJ + SCHOOL",
                                            "MAN_TEACHER = MAN + ZWJ + SCHOOL",
                                            "WOMAN_TEACHER = WOMAN + ZWJ + SCHOOL",
                                            "PERSON_FARMER = PERSON + ZWJ + RICE",
                                            "MAN_FARMER = MAN + ZWJ + RICE",
                                            "WOMAN_FARMER = WOMAN + ZWJ + RICE"};

            AddEmoji(EMOJI_VIEW_7, WORK_COMB2_ARY, WORK_COMB2_DESC_ARY);


            // * 8 *
            string PERSON_COOK = PERSON + ZWJ + COOKING;
            string MAN_COOK = MAN + ZWJ + COOKING;
            string WOMAN_COOK = WOMAN + ZWJ + COOKING;

            string PERSON_MECHANIC = PERSON + ZWJ + WRENCH;
            string MAN_MECHANIC = MAN + ZWJ + WRENCH;
            string WOMAN_MECHANIC = WOMAN + ZWJ + WRENCH;

            string PERSON_SCIENTIST = PERSON + ZWJ + MICRO_SCOPE;
            string MAN_SCIENTIST = MAN + ZWJ + MICRO_SCOPE;
            string WOMAN_SCIENTIST = WOMAN + ZWJ + MICRO_SCOPE;

            string PERSON_TECHNOLOGIST = PERSON + ZWJ + LAPTOP;
            string MAN_TECHNOLOGIST = MAN + ZWJ + LAPTOP;
            string WOMAN_TECHNOLOGIST = WOMAN + ZWJ + LAPTOP;

            string PERSON_ASTRONAUT = PERSON + ZWJ + ROCKET;
            string MAN_ASTRONAUT = MAN + ZWJ + ROCKET;
            string WOMAN_ASTRONAUT = WOMAN + ZWJ + ROCKET;

            string PERSON_ARTIST = PERSON + ZWJ + PALETTE;
            string MAN_ARTIST = MAN + ZWJ + PALETTE;
            string WOMAN_ARTIST = WOMAN + ZWJ + PALETTE;

            View EMOJI_VIEW_8 = AddView(MAIN_VIEW);

            string[] WORK_COMB3_ARY = {PERSON_COOK, MAN_COOK, WOMAN_COOK,
                                       PERSON_MECHANIC, MAN_MECHANIC, WOMAN_MECHANIC,
                                       PERSON_SCIENTIST, MAN_SCIENTIST, WOMAN_SCIENTIST,
                                       PERSON_TECHNOLOGIST, MAN_TECHNOLOGIST, WOMAN_TECHNOLOGIST,
                                       PERSON_ASTRONAUT, MAN_ASTRONAUT, WOMAN_ASTRONAUT,
                                       PERSON_ARTIST, MAN_ARTIST, WOMAN_ARTIST};

            string[] WORK_COMB3_DESC_ARY = {"PERSON_COOK = PERSON + ZWJ + COOKING",
                                            "MAN_COOK = MAN + ZWJ + COOKING",
                                            "WOMAN_COOK = WOMAN + ZWJ + COOKING",
                                            "PERSON_MECHANIC = PERSON + ZWJ + WRENCH",
                                            "MAN_MECHANIC = MAN + ZWJ + WRENCH",
                                            "WOMAN_MECHANIC = WOMAN + ZWJ + WRENCH",
                                            "PERSON_SCIENTIST = PERSON + ZWJ + MICRO_SCOPE",
                                            "MAN_SCIENTIST = MAN + ZWJ + MICRO_SCOPE",
                                            "WOMAN_SCIENTIST = WOMAN + ZWJ + MICRO_SCOPE",
                                            "PERSON_TECHNOLOGIST = PERSON + ZWJ + LAPTOP",
                                            "MAN_TECHNOLOGIST = MAN + ZWJ + LAPTOP",
                                            "WOMAN_TECHNOLOGIST = WOMAN + ZWJ + LAPTOP",
                                            "PERSON_ASTRONAUT = PERSON + ZWJ + ROCKET",
                                            "MAN_ASTRONAUT = MAN + ZWJ + ROCKET",
                                            "WOMAN_ASTRONAUT = WOMAN + ZWJ + ROCKET",
                                            "PERSON_ARTIST = PERSON + ZWJ + PALETTE",
                                            "MAN_ARTIST = MAN + ZWJ + PALETTE",
                                            "WOMAN_ARTIST = WOMAN + ZWJ + PALETTE"};

            AddEmoji(EMOJI_VIEW_8, WORK_COMB3_ARY, WORK_COMB3_DESC_ARY);


            // * 9 *
            string CHRISTMAS_TREE = "\U0001F384";
            string SANTA = "\U0001F385";
            string SANTA_WOMAN = "\U0001F936";
            string SANTA_PERSON = PERSON + ZWJ + CHRISTMAS_TREE;

            string MAGE = "\U0001F9D9";
            string MAGE_MAN = MAGE + ZWJ + MALE_SIGN + VS16;
            string MAGE_WOMAN = MAGE + ZWJ + FEMALE_SIGN + VS16;

            string VAMPIRE = "\U0001F9DB";
            string VAMPIRE_MAN = VAMPIRE + ZWJ + MALE_SIGN + VS16;
            string VAMPIRE_WOMAN = VAMPIRE + ZWJ + FEMALE_SIGN + VS16;

            string ELF = "\U0001F9DD";
            string ELF_MAN = ELF + ZWJ + MALE_SIGN + VS16;
            string ELF_WOMAN = ELF + ZWJ + FEMALE_SIGN + VS16;

            string ZOMBIE = "\U0001F9DF";
            string ZOMBIE_MAN = ZOMBIE + ZWJ + MALE_SIGN + VS16;
            string ZOMBIE_WOMAN = ZOMBIE + ZWJ + FEMALE_SIGN + VS16;

            string MERPERSON = "\U0001F9DC";
            string MERPERSON_WOMAN = MERPERSON + ZWJ + FEMALE_SIGN + VS16;

            string GENIE = "\U0001F9DE";
            string GENIE_MAN = GENIE + ZWJ + MALE_SIGN + VS16;

            View EMOJI_VIEW_9 = AddView(MAIN_VIEW);

            string[] FANTASY_ARY = {CHRISTMAS_TREE, SANTA, SANTA_WOMAN, SANTA_PERSON,
                                    MAGE, MAGE_MAN, MAGE_WOMAN,
                                    VAMPIRE, VAMPIRE_MAN, VAMPIRE_WOMAN,
                                    ELF, ELF_MAN, ELF_WOMAN,
                                    ZOMBIE, ZOMBIE_MAN, ZOMBIE_WOMAN,
                                    MERPERSON_WOMAN, GENIE_MAN};

            string[] FANTASY_DESC_ARY = {"CHRISTMAS_TREE", "SANTA", "SANTA_WOMAN", "SANTA_PERSON = PERSON + ZWJ + CHRISTMAS_TREE",
                                         "MAGE",
                                         "MAGE_MAN = MAGE + ZWJ + MALE_SIGN + VS16",
                                         "MAGE_WOMAN = MAGE + ZWJ + FEMALE_SIGN + VS16",
                                         "VAMPIRE",
                                         "VAMPIRE_MAN = VAMPIRE + ZWJ + MALE_SIGN + VS16",
                                         "VAMPIRE_WOMAN = VAMPIRE + ZWJ + FEMALE_SIGN + VS16",
                                         "ELF",
                                         "ELF_MAN = ELF + ZWJ + MALE_SIGN + VS16",
                                         "ELF_WOMAN = ELF + ZWJ + FEMALE_SIGN + VS16",
                                         "ZOMBIE",
                                         "ZOMBIE_MAN = ZOMBIE + ZWJ + MALE_SIGN + VS16",
                                         "ZOMBIE_WOMAN = ZOMBIE + ZWJ + FEMALE_SIGN + VS16",
                                         "MERPERSON_WOMAN = MERPERSON + ZWJ + FEMALE_SIGN + VS16",
                                         "GENIE_MAN = GENIE + ZWJ + MALE_SIGN + VS16"};

            AddEmoji(EMOJI_VIEW_9, FANTASY_ARY, FANTASY_DESC_ARY);


            // * 10 ~ 11 *
            // Family..
            string[] parent = {MAN, WOMAN, EMPTY};
            string[] child = {BOY, GIRL, EMPTY};
            string[] parentDesc = {"MAN", "WOMAN", "EMPTY"};
            string[] childDesc = {"BOY", "GIRL", "EMPTY"};
            int wrapCount = 0;
            View EMOJI_VIEW_10_11 = NewView(MATCH_PARENT, WRAP_CONTENT, HORIZONTAL);

            for (int p1 = 0 ; p1 < parent.Length ; p1 ++)
            for (int p2 = 0 ; p2 < parent.Length ; p2 ++)
            for (int c1 = 0 ; c1 < child.Length ; c1 ++)
            for (int c2 = 0 ; c2 < child.Length ; c2 ++)
            {
                if (p1 == 1 && p2 == 0) continue; // woman + man
                if (p1 == 2)            continue; // empty + man, woman already performed
                if (c1 == 0 && c2 == 1) continue; // boy + girl
                if (c1 == 2)            continue; // empty + girl, boy already performed

                if (wrapCount % ROW == 0)
                {
                    EMOJI_VIEW_10_11 = AddView(MAIN_VIEW);
                }
                wrapCount++;

                string description = "FAMILY = " + parentDesc[p1] + " + ZWJ + " + parentDesc[p2] + " + ZWJ + " + childDesc[c1] + " + ZWJ + " + childDesc[c2];
                string unicode = parent[p1] + ZWJ + parent[p2] + ZWJ + child[c1] + ZWJ + child[c2];

                AddEmoji(EMOJI_VIEW_10_11, unicode, description);
            }

            string FAMILY = "\U0001F46A";

            string COUPLE = "\U0001F491";
            string COUPLE_WOMAN_MAN = WOMAN + ZWJ + RED_HEART + ZWJ + MAN;
            string COUPLE_MAN_MAN = MAN + ZWJ + RED_HEART + ZWJ + MAN;
            string COUPLE_WOMAN_WOMAN = WOMAN + ZWJ + RED_HEART + ZWJ + WOMAN;

            string KISS_MARK = "\U0001F48B";
            string KISS = "\U0001F48F";
            string KISS_WOMAN_MAN = WOMAN + ZWJ + RED_HEART + VS16 + ZWJ + KISS_MARK + ZWJ + MAN;
            string KISS_MAN_MAN = MAN + ZWJ + RED_HEART + VS16 + ZWJ + KISS_MARK + ZWJ + MAN;
            string KISS_WOMAN_WOMAN = WOMAN + ZWJ + RED_HEART + VS16 + ZWJ + KISS_MARK + ZWJ + WOMAN;

            string HANDSHAKE = "\U0001F91D";
            string PEOPLE_HOLDING_HANDS = PERSON + ZWJ + HANDSHAKE + ZWJ + PERSON;
            string WOMAN_MAN_HOLDING_HANDS = "\U0001F46B";

            string[] FAMILY_ARY = {FAMILY,
                                   COUPLE, COUPLE_WOMAN_MAN, COUPLE_MAN_MAN, COUPLE_WOMAN_WOMAN,
                                   KISS, KISS_WOMAN_MAN, KISS_MAN_MAN, KISS_WOMAN_WOMAN,
                                   PEOPLE_HOLDING_HANDS, WOMAN_MAN_HOLDING_HANDS};

            string[] FAMILY_DESC_ARY = {"FAMILY", "COUPLE",
                                        "COUPLE_WOMAN_MAN = WOMAN + ZWJ + RED_HEART + ZWJ + MAN",
                                        "COUPLE_MAN_MAN = MAN + ZWJ + RED_HEART + ZWJ + MAN",
                                        "COUPLE_WOMAN_WOMAN = WOMAN + ZWJ + RED_HEART + ZWJ + WOMAN",
                                        "KISS",
                                        "KISS_WOMAN_MAN = WOMAN + ZWJ + RED_HEART + VS16 + ZWJ + KISS_MARK + ZWJ + MAN",
                                        "KISS_MAN_MAN = MAN + ZWJ + RED_HEART + VS16 + ZWJ + KISS_MARK + ZWJ + MAN",
                                        "KISS_WOMAN_WOMAN = WOMAN + ZWJ + RED_HEART + VS16 + ZWJ + KISS_MARK + ZWJ + WOMAN",
                                        "PEOPLE_HOLDING_HANDS = PERSON + ZWJ + HANDSHAKE + ZWJ + PERSON",
                                        "WOMAN_MAN_HOLDING_HANDS"};

            AddEmoji(EMOJI_VIEW_10_11, FAMILY_ARY, FAMILY_DESC_ARY);


            // * 12 *
            string JUGGLING = "\U0001F939";
            string JUGGLING_MAN = JUGGLING + ZWJ + MALE_SIGN + VS16;
            string JUGGLING_WOMAN = JUGGLING + ZWJ + FEMALE_SIGN + VS16;

            string SURFER = "\U0001F3C4";
            string SURFER_MAN = SURFER + ZWJ + MALE_SIGN + VS16;
            string SURFER_WOMAN = SURFER + ZWJ + FEMALE_SIGN + VS16;

            string WHITE_CANE = "\U0001F9AF";
            string WHITE_CANE_PERSON = PERSON + ZWJ + WHITE_CANE;
            string WHITE_CANE_MAN = MAN + ZWJ + WHITE_CANE;
            string WHITE_CANE_WOMAN = WOMAN + ZWJ + WHITE_CANE;

            string MANUAL_WHEELCHAIR = "\U0001F9BD";
            string MANUAL_WHEELCHAIR_PERSON = PERSON + ZWJ + MANUAL_WHEELCHAIR;
            string MANUAL_WHEELCHAIR_MAN = MAN + ZWJ + MANUAL_WHEELCHAIR;
            string MANUAL_WHEELCHAIR_WOMAN = WOMAN + ZWJ + MANUAL_WHEELCHAIR;

            string MOTORIZED_WHEELCHAIR = "\U0001F9BC";
            string MOTORIZED_WHEELCHAIR_PERSON = PERSON + ZWJ + MOTORIZED_WHEELCHAIR;
            string MOTORIZED_WHEELCHAIR_MAN = MAN + ZWJ + MOTORIZED_WHEELCHAIR;
            string MOTORIZED_WHEELCHAIR_WOMAN = WOMAN + ZWJ + MOTORIZED_WHEELCHAIR;

            View EMOJI_VIEW_12 = AddView(MAIN_VIEW);

            string[] ACTIVITY_ARY = {JUGGLING, JUGGLING_MAN, JUGGLING_WOMAN,
                                     SURFER, SURFER_MAN, SURFER_WOMAN,
                                     WHITE_CANE, WHITE_CANE_PERSON, WHITE_CANE_MAN, WHITE_CANE_WOMAN,
                                     MANUAL_WHEELCHAIR, MANUAL_WHEELCHAIR_PERSON, MANUAL_WHEELCHAIR_MAN, MANUAL_WHEELCHAIR_WOMAN,
                                     MOTORIZED_WHEELCHAIR, MOTORIZED_WHEELCHAIR_PERSON, MOTORIZED_WHEELCHAIR_MAN, MOTORIZED_WHEELCHAIR_WOMAN};

            string[] ACTIVITY_DESC_ARY = {"JUGGLING",
                                          "JUGGLING_MAN = JUGGLING + ZWJ + MALE_SIGN + VS16",
                                          "JUGGLING_WOMAN = JUGGLING + ZWJ + FEMALE_SIGN + VS16",
                                          "SURFER",
                                          "SURFER_MAN = SURFER + ZWJ + MALE_SIGN + VS16",
                                          "SURFER_WOMAN = SURFER + ZWJ + FEMALE_SIGN + VS16",
                                          "WHITE_CANE",
                                          "WHITE_CANE_PERSON = PERSON + ZWJ + WHITE_CANE",
                                          "WHITE_CANE_MAN = MAN + ZWJ + WHITE_CANE",
                                          "WHITE_CANE_WOMAN = WOMAN + ZWJ + WHITE_CANE",
                                          "MANUAL_WHEELCHAIR",
                                          "MANUAL_WHEELCHAIR_PERSON = PERSON + ZWJ + MANUAL_WHEELCHAIR",
                                          "MANUAL_WHEELCHAIR_MAN = MAN + ZWJ + MANUAL_WHEELCHAIR",
                                          "MANUAL_WHEELCHAIR_WOMAN = WOMAN + ZWJ + MANUAL_WHEELCHAIR",
                                          "MOTORIZED_WHEELCHAIR",
                                          "MOTORIZED_WHEELCHAIR_PERSON = PERSON + ZWJ + MOTORIZED_WHEELCHAIR",
                                          "MOTORIZED_WHEELCHAIR_MAN = MAN + ZWJ + MOTORIZED_WHEELCHAIR",
                                          "MOTORIZED_WHEELCHAIR_WOMAN = WOMAN + ZWJ + MOTORIZED_WHEELCHAIR"};

            AddEmoji(EMOJI_VIEW_12, ACTIVITY_ARY, ACTIVITY_DESC_ARY);


            // * 13 *
            string DRAGON = "\U0001F409";
            string TREX = "\U0001F996";
            string MAMMOTH = "\U0001F9A3";
            string BEAVER = "\U0001F9AB";
            string UNICORN = "\U0001F984";
            string TIGER = "\U0001F405";
            string BUFFALO = "\U0001F403";
            string WHALE = "\U0001F40B";

            View EMOJI_VIEW_13 = AddView(MAIN_VIEW);

            string[] ANIMAL_ARY = {DRAGON, TREX, MAMMOTH, BEAVER, UNICORN, TIGER, BUFFALO, WHALE};

            string[] ANIMAL_DESC_ARY = {"DRAGON", "TREX", "MAMMOTH", "BEAVER", "UNICORN", "TIGER", "BUFFALO", "WHALE"};

            AddEmoji(EMOJI_VIEW_13, ANIMAL_ARY, ANIMAL_DESC_ARY);


            string GUIDE_DOG = "\U0001F9AE";
            string DOG = "\U0001F415";
            string SAFETY_VEST = "\U0001F9BA";
            string SERVICE_DOG = DOG + ZWJ + SAFETY_VEST;

            string CAT = "\U0001F408";
            string BLACK_LARGE_SQUARE = "\u2B1B";
            string BLACK_CAT = CAT + ZWJ + BLACK_LARGE_SQUARE;

            string BEAR = "\U0001F43B";
            string SNOW_FLAKE = "\u2744";
            string POLAR_BEAR = BEAR + ZWJ + SNOW_FLAKE + VS16;

            string[] ANIMAL_COMB_ARY = {GUIDE_DOG, DOG, SAFETY_VEST, SERVICE_DOG,
                                        CAT, BLACK_LARGE_SQUARE, BLACK_CAT,
                                        BEAR, SNOW_FLAKE, POLAR_BEAR};

            string[] ANIMAL_COMB_DESC_ARY = {"GUIDE_DOG", "DOG", "SAFETY_VEST", "SERVICE_DOG = DOG + ZWJ + SAFETY_VEST",
                                             "CAT", "BLACK_LARGE_SQUARE", "BLACK_CAT = CAT + ZWJ + BLACK_LARGE_SQUARE",
                                             "BEAR", "SNOW_FLAKE", "POLAR_BEAR = BEAR + ZWJ + SNOW_FLAKE + VS16"};

            AddEmoji(EMOJI_VIEW_13, ANIMAL_COMB_ARY, ANIMAL_COMB_DESC_ARY);


            // * 14 *
            string KEYCAP = "\u20E3";
            string KEYCAP_SHARP = "#" + VS16 + KEYCAP;
            string KEYCAP_ASTERISK = "*" + VS16 + KEYCAP;
            string KEYCAP_10 = "\U0001F51F";

            string[] KEYCAP_ARY = new string[11]; // 0, 1, 2 ... 9, 10
            string[] KEYCAP_DESC_ARY = new string[11];
            for (int key = 0 ; key < 10 ; key ++)
            {
                KEYCAP_ARY[key] = key + VS16 + KEYCAP;
                KEYCAP_DESC_ARY[key] = "KEYCAP_" + key + " = " + key + " + VS16 + KEYCAP";
            }
            KEYCAP_ARY[10] = KEYCAP_10;
            KEYCAP_DESC_ARY[10] = "KEYCAP_10";

            View EMOJI_VIEW_14 = AddView(MAIN_VIEW);

            AddEmoji(EMOJI_VIEW_14, KEYCAP, "KEYCAP");
            AddEmoji(EMOJI_VIEW_14, KEYCAP_SHARP, "KEYCAP_SHARP = # + VS16 + KEYCAP");
            AddEmoji(EMOJI_VIEW_14, KEYCAP_ASTERISK, "KEYCAP_ASTERISK = * + VS16 + KEYCAP");
            AddEmoji(EMOJI_VIEW_14, KEYCAP_ARY, KEYCAP_DESC_ARY);

            string AB_BUTTON = "\U0001F18E";
            string VS_BUTTON = "\U0001F19A";
            string UP_BUTTON = "\U0001F199";
            string RESERVED_BUTTON = "\U0001F22F";

            string[] KEYCAP_MORE_ARY = {AB_BUTTON, VS_BUTTON, UP_BUTTON, RESERVED_BUTTON};
            string[] KEYCAP_MORE_DESC_ARY = {"AB_BUTTON_BLOOD_TYPE", "VS_BUTTON", "UP_BUTTON", "JAPANESE_RESERVED_BUTTON"};

            AddEmoji(EMOJI_VIEW_14, KEYCAP_MORE_ARY, KEYCAP_MORE_DESC_ARY);


            // * 15 *
            string WHITE_FLAG = "\U0001F3F3";
            string RAINBOW = "\U0001F308";

            string RAINBOW_FLAG = WHITE_FLAG + VS16 + ZWJ + RAINBOW;
            string TRANSGENDER_FLAG = WHITE_FLAG + VS16 + ZWJ + TRANSGENDER_SIGN + VS16;

            string BLACK_FLAG = "\U0001F3F4";
            string SKULL_AND_CROSSBONES = "\u2620";
            string PIRATE_FLAG = BLACK_FLAG + ZWJ + SKULL_AND_CROSSBONES + VS16;

            View EMOJI_VIEW_15 = AddView(MAIN_VIEW);

            string[] FLAG_ARY = {WHITE_FLAG, RAINBOW, RAINBOW_FLAG,
                                 WHITE_FLAG, TRANSGENDER_SIGN, TRANSGENDER_FLAG,
                                 BLACK_FLAG, SKULL_AND_CROSSBONES, PIRATE_FLAG};

            string[] FLAG_DESC_ARY = {"WHITE_FLAG",
                                      "RAINBOW",
                                      "RAINBOW_FLAG = WHITE_FLAG + VS16 + ZWJ + RAINBOW",
                                      "WHITE_FLAG",
                                      "TRANSGENDER_SIGN",
                                      "TRANSGENDER_FLAG = WHITE_FLAG + VS16 + ZWJ + TRANSGENDER_SIGN + VS16",
                                      "BLACK_FLAG",
                                      "SKULL_AND_CROSSBONES",
                                      "PIRATE_FLAG = BLACK_FLAG + ZWJ + SKULL_AND_CROSSBONES + VS16"};

            AddEmoji(EMOJI_VIEW_15, FLAG_ARY, FLAG_DESC_ARY);

            string LETTER_b = "\U000E0062";
            string LETTER_c = "\U000E0063";
            string LETTER_e = "\U000E0065";
            string LETTER_g = "\U000E0067";
            string LETTER_l = "\U000E006C";
            string LETTER_n = "\U000E006E";
            string LETTER_s = "\U000E0073";
            string LETTER_t = "\U000E0074";
            string LETTER_w = "\U000E0077";

            string CANCEL_TAG = "\U000E007F";

            string EGLAND = BLACK_FLAG + LETTER_g + LETTER_b + LETTER_e + LETTER_n + LETTER_g + CANCEL_TAG;
            string SCOTLAND = BLACK_FLAG + LETTER_g + LETTER_b + LETTER_s + LETTER_c + LETTER_t + CANCEL_TAG;
            string WALES = BLACK_FLAG + LETTER_g + LETTER_b + LETTER_w + LETTER_l + LETTER_s + CANCEL_TAG;

            string UNI_B = "\U0001F1E7";
            string UNI_D = "\U0001F1E9";
            string UNI_E = "\U0001F1EA";
            string UNI_G = "\U0001F1EC";
            string UNI_K = "\U0001F1F0";
            string UNI_N = "\U0001F1F3";
            string UNI_R = "\U0001F1F7";
            string UNI_S = "\U0001F1F8";
            string UNI_U = "\U0001F1FA";
            string GB = UNI_G + UNI_B;
            string DE = UNI_D + UNI_E;
            string EU = UNI_E + UNI_U;
            string UN = UNI_U + UNI_N;
            string US = UNI_U + UNI_S;
            string KR = UNI_K + UNI_R;

            string[] FLAG_NATION_ARY = {EGLAND, SCOTLAND, WALES, GB, DE, EU, UN, US, KR};

            string[] FLAG_NATION_DESC_ARY = {"EGLAND = BLACK_FLAG + g + b + e + n + g + CANCEL_TAG",
                                             "SCOTLAND = BLACK_FLAG + g + b + s + c + t + CANCEL_TAG",
                                             "WALES = BLACK_FLAG + g + b + w + l + s + CANCEL_TAG",
                                             "GB = G + B",
                                             "DE = D + E",
                                             "EU = E + U",
                                             "UN = U + N",
                                             "US = U + S",
                                             "KR = K + R"};

            AddEmoji(EMOJI_VIEW_15, FLAG_NATION_ARY, FLAG_NATION_DESC_ARY);


            // * 16 *
            View EMOJI_VIEW_16 = AddView(MAIN_VIEW);

            string[] FLAG_LETTER_ARY = {"\U0001F1E6", "\U0001F1E7", "\U0001F1E8", "\U0001F1E9", "\U0001F1EA", "\U0001F1EB",  // A ~ F
                                        "\U0001F1EC", "\U0001F1ED", "\U0001F1EE", "\U0001F1EF", "\U0001F1F0", "\U0001F1F1",  // G ~ L
                                        "\U0001F1F2", "\U0001F1F3", "\U0001F1F4", "\U0001F1F5", "\U0001F1F6", "\U0001F1F7"}; // M ~ R

            string[] FLAG_LETTER_DESC_ARY = {"Unicode Character A", "Unicode Character B", "Unicode Character C",
                                             "Unicode Character D", "Unicode Character E", "Unicode Character F",
                                             "Unicode Character G", "Unicode Character H", "Unicode Character I",
                                             "Unicode Character J", "Unicode Character K", "Unicode Character L",
                                             "Unicode Character M", "Unicode Character N", "Unicode Character O",
                                             "Unicode Character P", "Unicode Character Q", "Unicode Character R"};


            AddEmoji(EMOJI_VIEW_16, FLAG_LETTER_ARY, FLAG_LETTER_DESC_ARY);


            // * 17 *
            View EMOJI_VIEW_17 = AddView(MAIN_VIEW);

            string[] FLAG_LETTER2_ARY = {"\U0001F1F8", "\U0001F1F9", "\U0001F1FA", "\U0001F1FB", "\U0001F1FC", "\U0001F1FD", // S ~ X
                                         "\U0001F1FE", "\U0001F1FF"}; // Y ~ Z

            string[] FLAG_LETTER2_DESC_ARY = {"Unicode Character S", "Unicode Character T", "Unicode Character U",
                                              "Unicode Character V", "Unicode Character W", "Unicode Character X",
                                              "Unicode Character Y", "Unicode Character Z"};

            AddEmoji(EMOJI_VIEW_17, FLAG_LETTER2_ARY, FLAG_LETTER2_DESC_ARY);

            AddEmojiButton(EMOJI_VIEW_17, LETTER_b, "b", "Latin Small Letter B");
            AddEmojiButton(EMOJI_VIEW_17, LETTER_c, "c", "Latin Small Letter C");
            AddEmojiButton(EMOJI_VIEW_17, LETTER_e, "e", "Latin Small Letter E");
            AddEmojiButton(EMOJI_VIEW_17, LETTER_g, "g", "Latin Small Letter G");
            AddEmojiButton(EMOJI_VIEW_17, LETTER_l, "l", "Latin Small Letter L");
            AddEmojiButton(EMOJI_VIEW_17, LETTER_n, "n", "Latin Small Letter N");
            AddEmojiButton(EMOJI_VIEW_17, LETTER_s, "s", "Latin Small Letter S");
            AddEmojiButton(EMOJI_VIEW_17, LETTER_t, "t", "Latin Small Letter T");
            AddEmojiButton(EMOJI_VIEW_17, LETTER_w, "w", "Latin Small Letter W");
            AddEmojiButton(EMOJI_VIEW_17, CANCEL_TAG, "Cancel", "CANCEL_TAG");


            // * 18 *
            View EMOJI_VIEW_18 = AddView(MAIN_VIEW);

            string[] FLAG_DIGIT_ARY = {"#", "*", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string[] FLAG_DIGIT_DESC_ARY = {"HASH", "ASTERISK", "DIGIT 0", "DIGIT 1", "DIGIT 2", "DIGIT 3",
                                            "DIGIT 4", "DIGIT 5", "DIGIT 6", "DIGIT 7", "DIGIT 8", "DIGIT 9"};

            AddEmoji(EMOJI_VIEW_18, FLAG_DIGIT_ARY, FLAG_DIGIT_DESC_ARY);

            string LIGHT_SKIN_TONE = "\U0001F3FB";
            string MIDIUM_LIGHT_SKIN_TONE = "\U0001F3FC";
            string MIDIUM_SKIN_TONE = "\U0001F3FD";
            string MIDIUM_DARK_SKIN_TONE = "\U0001F3FE";
            string DARK_SKIN_TONE = "\U0001F3FF";

            string[] SKIN_TONE_ARY = {LIGHT_SKIN_TONE, MIDIUM_LIGHT_SKIN_TONE, MIDIUM_SKIN_TONE, MIDIUM_DARK_SKIN_TONE, DARK_SKIN_TONE};
            string[] SKIN_TONE_DESC_ARY = {"LIGHT_SKIN_TONE", "MIDIUM_LIGHT_SKIN_TONE", "MIDIUM_SKIN_TONE", "MIDIUM_DARK_SKIN_TONE", "DARK_SKIN_TONE"};

            AddEmoji(EMOJI_VIEW_18, SKIN_TONE_ARY, SKIN_TONE_DESC_ARY);

            AddEmojiButton(EMOJI_VIEW_18, ZWNJ, "ZWNJ", "Zero Width Non Joiner");

            //AddEmojiButton(EMOJI_VIEW_18, VS15, "VS15", "Variation Selector 15");

            //AddDummy(EMOJI_VIEW_18);
            //AddDummy(EMOJI_VIEW_18);
            //AddDummy(EMOJI_VIEW_18);
            //AddDummy(EMOJI_VIEW_18);
        }

        public void AddDummy(View parent)
        {
            TextLabel dummy;
            dummy = AddEmojiButton(parent, EMPTY_UNICODE, EMPTY_LABEL, EMPTY_DESCRIPTION, false);
        }

        public void ClearAll()
        {
            int count = (int)VIEW.GetChildCount();

            for (int i = 0 ; i < count ; i ++)
            {
                var item = VIEW.GetChildAt(0);
                VIEW.Remove(item);
            }
            Window window = Window.Instance;
            window.Remove(VIEW);
        }

        public void ScaleUpdate()
        {
            string text = WORK_BENCH.Text;
            List<string> list = new List<string>();
            list.AddRange(HISTORY);
            HISTORY.Clear();

            Initialize();

            WORK_BENCH.Text = text;
            for (int i = 0 ; i < list.Count ; i ++)
            {
                AddLog(list[i]);
            }
            Tizen.Log.Info(TAG, "Scale:" + SCALE);
        }

        public void AddEmoji(View parent, string unicode, string description = "")
        {
            EMOJI_DICTIONARY[unicode] = description;
            parent.Add(NewTextLabel(unicode));
        }

        public void AddEmoji(View parent, string[] unicodeArray, string[] descriptionArray = null)
        {
            for (int i = 0 ; i < unicodeArray.Length ; i ++)
            {
                if (descriptionArray != null)
                {
                    EMOJI_DICTIONARY[unicodeArray[i]] = descriptionArray[i];
                }
                parent.Add(NewTextLabel(unicodeArray[i]));
            }
        }

        public TextLabel NewTextLabel(string text, bool tap = true)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = FONT,
                EnableMarkup = true,
                Ellipsis = false,
                WidthSpecification = WIDTH,
                HeightSpecification = HEIGHT,
                PixelSize = PIXEL_SIZE,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                RenderMode = ASYNC ? TextRenderMode.AsyncAuto : TextRenderMode.Sync,
            };

            if (tap)
            {
                TapDetector.Attach(label);
            }

            return label;
        }

        public TextLabel AddEmojiButton(View parent, string unicode, string labelText, string description, bool tap = true)
        {
            if (!string.IsNullOrEmpty(unicode))
            {
                EMOJI_DICTIONARY[unicode] = description;
            }

            var emoji = NewTextLabel(unicode, tap);
            var label = new TextLabel
            {
                Text = labelText,
                WidthSpecification = WIDTH,
                HeightSpecification = HEIGHT,
                PixelSize = PIXEL_SIZE / 3,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                RenderMode = ASYNC ? TextRenderMode.AsyncAuto : TextRenderMode.Sync,
            };
            emoji.Add(label);
            parent.Add(emoji);
            return emoji;
        }

        public View NewView(int width, int height, bool horizontal = false)
        {
            View view = new View()
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
            };
            return view;
        }

        public View AddView(View parent)
        {
            var view = NewView(MATCH_PARENT, WRAP_CONTENT, HORIZONTAL);
            parent.Add(view);
            return view;
        }

        public void ClearLog(int count)
        {
            for (int i = 0 ; i < count ; i ++)
            {
                var item = LOG_VIEW.GetChildAt(0);
                LOG_VIEW.Remove(item);
                HISTORY.RemoveAt(0);
            }
        }

        public void AddLog(string unicode)
        {
            int calcedHeight = (int)(LOG_VIEW.ChildCount + 1) * (int)(HEIGHT / 2 + 1);
            if (calcedHeight > LOG_HEIGHT)
            {
                ClearLog((int)LOG_VIEW.GetChildCount() / 2);
            }

            var view = NewView(MATCH_PARENT, WRAP_CONTENT, HORIZONTAL);
            view.BorderlineWidth = 1.0f;
            LOG_VIEW.Add(view);

            var emoji = new TextLabel
            {
                Text = unicode,
                FontFamily = FONT,
                EnableMarkup = true,
                Ellipsis = false,
                WidthSpecification = WIDTH / 2,
                HeightSpecification = HEIGHT / 2,
                PixelSize = PIXEL_SIZE / 2,
                BackgroundColor = Color.White,
                RenderMode = ASYNC ? TextRenderMode.AsyncAuto : TextRenderMode.Sync,
            };
            view.Add(emoji);

            HISTORY.Add(unicode);

            string desc = " " + "No description";
            if (EMOJI_DICTIONARY.ContainsKey(unicode))
            {
                desc = " " + EMOJI_DICTIONARY[unicode];
            }

            var description = new TextLabel
            {
                Text = desc,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = HEIGHT / 2,
                PixelSize = PIXEL_SIZE / 3 - 1,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = Color.White,
                RenderMode = ASYNC ? TextRenderMode.AsyncAuto : TextRenderMode.Sync,
            };
            view.Add(description);
        }

        void SetTapDetector(int benchLength)
        {
            TapDetector = new TapGestureDetector();
            TapDetector.Detected += (s, e) =>
            {
                string emoji = (e.View as TextLabel).Text;
                string description = "[" + emoji + "] : No description";

                if (EMOJI_DICTIONARY.ContainsKey(emoji))
                {
                    description = "[" + emoji + "] : " + EMOJI_DICTIONARY[emoji];
                }
                Tizen.Log.Info(TAG, description);

                AddLog(emoji);

                WORK_BENCH.Text += emoji;

                int textLength = (int)WORK_BENCH.NaturalSize.Width;
                if (benchLength < textLength)
                {
                    WORK_BENCH.Text = emoji; // clear
                }

                Tizen.Log.Info(TAG, "ViewCount : " + View.AliveCount);
            };
        }

        public void GenerateUI()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.WindowSize = new Size((WIDTH + CELL) * ROW + LOG_WIDTH + 1, (HEIGHT + CELL) * COL);

            int benchLength = (WIDTH + CELL) * (ROW - NUM_OF_BUTTON) - CELL;
            SetTapDetector(benchLength);

            // VIEW
            // - MAIN_VIEW                                     |  - LOG_MAIN_VIEW
            //   - MAIN_TOP_VIEW                               |    - LOG_TOP_VIEW
            //     - WORK_BENCH | BUTTON | BUTTON | BUTTON     |      - TITLE | BUTTON | BUTTON
            //                                                 |
            //   - EMOJI_VIEW_1                                |    - LOG_VIEW
            //     - EMOJI | EMOJI | EMOJI | EMOJI | EMOJI ... |      - DESCRIPTION_LIST_ITEM
            //                                                 |      - DESCRIPTION_LIST_ITEM
            //   - EMOJI_VIEW_2                                |      - DESCRIPTION_LIST_ITEM
            //   - EMOJI_VIEW_3                                |      - DESCRIPTION_LIST_ITEM
            //   - ...                                         |      - ...

            VIEW = NewView(MATCH_PARENT, MATCH_PARENT, HORIZONTAL);
            window.Add(VIEW);

            MAIN_VIEW = NewView((WIDTH + CELL) * ROW, (HEIGHT + CELL) * COL);
            VIEW.Add(MAIN_VIEW);

            View LOG_MAIN_VIEW = NewView(MATCH_PARENT, (HEIGHT + CELL) * COL);
            VIEW.Add(LOG_MAIN_VIEW);

            View LOG_TOP_VIEW = NewView(MATCH_PARENT, WRAP_CONTENT, HORIZONTAL);
            LOG_MAIN_VIEW.Add(LOG_TOP_VIEW);

            var TITLE = new TextLabel
            {
                Text = "History",
                FontFamily = FONT,
                Ellipsis = false,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = HEIGHT,
                PixelSize = PIXEL_SIZE / 3,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = new Color("#EEEEEE"),
                RenderMode = ASYNC ? TextRenderMode.AsyncAuto : TextRenderMode.Sync,
            };
            LOG_TOP_VIEW.Add(TITLE);

            var clearLog = AddEmojiButton(LOG_TOP_VIEW, EMPTY_UNICODE, "Clear", EMPTY_DESCRIPTION, false);
            ClearLogDetector = new TapGestureDetector();
            ClearLogDetector.Attach(clearLog);
            ClearLogDetector.Detected += (s, e) =>
            {
                Tizen.Log.Info(TAG, "Clear Log");
                ClearLog((int)LOG_VIEW.GetChildCount());
            };

            var scale = AddEmojiButton(LOG_TOP_VIEW, EMPTY_UNICODE, "Scale", EMPTY_DESCRIPTION, false);
            ScaleDetector = new TapGestureDetector();
            ScaleDetector.Attach(scale);
            ScaleDetector.Detected += (s, e) =>
            {
                ClearAll();
                SCALE += SCALE_STEP;
                SCALE = SCALE > 2.6f ? 0.6f : SCALE;
                ScaleUpdate();
            };

            var help = AddEmojiButton(LOG_TOP_VIEW, EMPTY_UNICODE, "Help", EMPTY_DESCRIPTION, false);
            HelpDetector = new TapGestureDetector();
            HelpDetector.Attach(help);
            HelpDetector.Detected += (s, e) =>
            {
                PrintShortcut();                
            };

            LOG_VIEW = NewView(MATCH_PARENT, WRAP_CONTENT);
            LOG_VIEW.HeightSpecification = LOG_HEIGHT;
            LOG_VIEW.BackgroundColor = new Color("#EEEEEE");
            LOG_MAIN_VIEW.Add(LOG_VIEW);


            // * 0 *
            View MAIN_TOP_VIEW = AddView(MAIN_VIEW);

            WORK_BENCH = new TextLabel
            {
                Text = EMPTY,
                FontFamily = FONT,
                Ellipsis = false,
                EnableMarkup = true,
                WidthSpecification = benchLength,
                HeightSpecification = HEIGHT,
                PixelSize = PIXEL_SIZE,
                VerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = new Color("#EEEEEE"),
                RenderMode = ASYNC ? TextRenderMode.AsyncAuto : TextRenderMode.Sync,
            };
            MAIN_TOP_VIEW.Add(WORK_BENCH);


            string ZWJ = "\u200d";
            string ZWNJ = "\u200c";
            string VS15 = "\ufe0e";
            string VS16 = "\ufe0f";


            AddEmojiButton(MAIN_TOP_VIEW, ZWJ, "ZWJ", "Zero Width Joiner");
            AddEmojiButton(MAIN_TOP_VIEW, VS16, "VS16", "Variation Selector 16");

            var clear = AddEmojiButton(MAIN_TOP_VIEW, EMPTY_UNICODE, "Clear", EMPTY_DESCRIPTION, false);
            ClearDetector = new TapGestureDetector();
            ClearDetector.Attach(clear);
            ClearDetector.Detected += (s, e) =>
            {
                Tizen.Log.Info(TAG, "Clear");
                WORK_BENCH.Text = EMPTY;
            };
        }

        public void SetConfig()
        {
            PIXEL_SIZE = 29.0f;
            CELL = 1;
            WIDTH = 30;
            HEIGHT = 29;
            LOG_WIDTH = 300;

            PIXEL_SIZE = PIXEL_SIZE * SCALE;
            WIDTH = (int)(WIDTH * SCALE);
            HEIGHT = (int)(HEIGHT * SCALE);
            LOG_WIDTH = (int)(LOG_WIDTH * SCALE);

            HEIGHT = HEIGHT % 2 > 0 ? HEIGHT : HEIGHT + 1;
            LOG_HEIGHT = (HEIGHT + CELL) * (COL - 1) - 1;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
