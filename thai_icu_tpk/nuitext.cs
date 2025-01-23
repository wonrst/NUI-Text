using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        const bool HORIZONTAL = true;
        const bool VERTICAL   = false;
        const int  MATCH_PARENT = LayoutParamPolicies.MatchParent;
        const int  WRAP_CONTENT = LayoutParamPolicies.WrapContent;

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

            var view = NewView(MATCH_PARENT, MATCH_PARENT, VERTICAL);
            window.Add(view);

            var contentView = NewView(MATCH_PARENT, 400, HORIZONTAL);
            view.Add(contentView);

            string ENG = "Hello! I am Gauss, your AI assistant. The weather is quite nice today. What are your plans for today? I am ready to help you. If you have any questions, feel free to ask!";
            string THAI = "ฉันเป็นเอาต์บอกความร้อนของสิ่งที่ถูกหล่อหลอม ฉันไม่สามารถพูดภาษาไทยได้จริงๆ แต่ฉันสามารถช่วยเหลือคุณในการสร้างคำบรรยายสำหรับภาษาไทยได้ แต่ฉันจะต้องพึ่งความช่วยเหลือของ Google Translate ในการทำงานนี้ และฉันสามารถทำงานนี้ได้เฉพาะกับข้อความที่ไม่เกิน 300 คำ";

            // async
            var async = NewTextLabel("ASYNC");
            async.HorizontalAlignment = HorizontalAlignment.Center;
            async.WidthSpecification = 100;
            async.HeightSpecification = WRAP_CONTENT;
            contentView.Add(async);

            var Async = NewTextLabel(THAI);
            Async.RenderMode = TextRenderMode.AsyncAuto;
            contentView.Add(Async);


            // sync
            contentView = NewView(MATCH_PARENT, 400, HORIZONTAL);
            view.Add(contentView);

            var sync = NewTextLabel("SYNC");
            sync.HorizontalAlignment = HorizontalAlignment.Center;
            sync.WidthSpecification = 100;
            sync.HeightSpecification = WRAP_CONTENT;
            contentView.Add(sync);

            var Sync = NewTextLabel(THAI);
            contentView.Add(Sync);


            // input
            var touchView = new View()
            {
                WidthSpecification = 800,
                HeightSpecification = 100,
                BackgroundColor = Color.DarkGray,
            };
            view.Add(touchView);
            touchView.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Motion)
                {
                    Vector2 position = e.Touch.GetLocalPosition(0);
                    Tizen.Log.Error(TAG, $"RYU - pos : {position.X}, {position.Y}");

                    Async.WidthSpecification = (int)position.X;
                    Sync.WidthSpecification = (int)position.X;
                }
                return true;
            };


            // button
            contentView = NewView(MATCH_PARENT, 50, HORIZONTAL);
            view.Add(contentView);

            var eng = NewButton("ENG");
            contentView.Add(eng);
            eng.Clicked += (s, e) =>
            {
                Async.Text = ENG;
                Sync.Text = ENG;
            };

            var thai = NewButton("THAI");
            contentView.Add(thai);
            thai.Clicked += (s, e) =>
            {
                Async.Text = THAI;
                Sync.Text = THAI;
            };

            var character = NewButton("Character");
            contentView.Add(character);
            character.Clicked += (s, e) =>
            {
                Async.LineWrapMode = LineWrapMode.Character;
                Sync.LineWrapMode = LineWrapMode.Character;
            };

            var wrap = NewButton("Word");
            contentView.Add(wrap);
            wrap.Clicked += (s, e) =>
            {
                Async.LineWrapMode = LineWrapMode.Word;
                Sync.LineWrapMode = LineWrapMode.Word;
            };

            var hyphen = NewButton("Hyphenation");
            contentView.Add(hyphen);
            hyphen.Clicked += (s, e) =>
            {
                Async.LineWrapMode = LineWrapMode.Hyphenation;
                Sync.LineWrapMode = LineWrapMode.Hyphenation;
            };

            var mixed = NewButton("Mixed");
            contentView.Add(mixed);
            mixed.Clicked += (s, e) =>
            {
                Async.LineWrapMode = LineWrapMode.Mixed;
                Sync.LineWrapMode = LineWrapMode.Mixed;
            };
        }

        public View NewView(int width, int height, bool horizontal)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = horizontal ? LinearLayout.Orientation.Horizontal : LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = width,
                HeightSpecification = height,
                BackgroundColor = Color.Black,
            };
            return view;
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                LineWrapMode = LineWrapMode.Word,
                WidthSpecification = 500,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
                PixelSize = 30,
            };
            return label;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
            };
            button.TextLabel.PixelSize = 16;
            return button;
        }

        public ButtonStyle NewButtonStyle()
        {
            var style = new ButtonStyle
            {
                CornerRadius = 0.0f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = Color.DimGray,
                    Pressed = new Color(0.25f, 0.75f, 1.0f, 0.3f),
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
                    TextColor = Color.White,
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
