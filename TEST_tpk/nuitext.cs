using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        const float FONT_SIZE = 32;
        const float BUTTON_FONT_SIZE = FONT_SIZE / 2;

        const bool HORIZONTAL = true;
        const bool VERTICAL   = false;
        const int  MATCH_PARENT = LayoutParamPolicies.MatchParent;
        const int  WRAP_CONTENT = LayoutParamPolicies.WrapContent;
        Extents    PADDING      = new Extents(10, 10, 5, 5);

        const string SHORT_TEXT = "Hello, World!";
        const string LONG_TEXT = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
        const string RTL_TEXT = "مرحبا بمرحبا مرحبا مرحبا مرحبا مرحبا مرحبا مرحبا مرحبا العالم.";
        const string MIX_TEXT = "Hello world demo\n안녕하세요 세계 (مرحبا بالعالم שלום) עולם\nשלום مرحبا بالعالم עולם (hello) مرحبا بالعالم world مرحبا بالعالم שלום עולם 안녕하세요 세계\nبالعالم שלום (세계) world demo (עולם)\nשלום (مرحبا بالعالم עולם) (안녕하세요)";
        const string EMOJI_TEXT = "👨‍👩‍👧‍👦👩‍👩‍👦‍👦👨‍👨‍👧‍👧👩‍👦‍👦👨‍👦‍👦👩‍👩‍👧‍👧👨‍👧‍👦👩‍👩‍👧‍👦👨‍👨‍👦‍👦👩‍👧‍👧👨‍👩‍👧‍👧👩‍👦‍👧🧑‍🎓👨‍🎓👩‍🎓🧑‍🏫👨‍🏫👩‍🏫🧑‍⚖️👨‍⚖️👩‍⚖️🧑‍🌾👨‍🌾👩‍🌾🧑‍🍳👨‍🍳👩‍🍳🧑‍🔬👨‍🔬👩‍🔬🧑‍💻👨‍💻👩‍💻🧑‍🎨👨‍🎨👩‍🎨🧑‍✈️👨‍✈️👩‍✈️🧑‍🚀👨‍🚀👩‍🚀🧑‍🚒👨‍🚒👩‍🚒🧑‍🏭👨‍🏭👩‍🏭🧑‍⚕️👨‍⚕️👩‍⚕️🧑‍🎤👨‍🎤👩‍🎤🏃‍♂️🏃‍♀️🏋️‍♂️🏋️‍♀️🚴‍♂️🚴‍♀️🤹‍♂️🤹‍♀️🚣‍♂️🚣‍♀️🏄‍♂️🏄‍♀️🤾‍♂️🤾‍♀️⛹️‍♂️⛹️‍♀️🤽‍♂️🤽‍♀️";

        public TextLabel label;
        public TextField field;
        public TextEditor editor;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(1200, 800));
        }

        public void GenerateUI(Size windowSize)
        {
            Window window = Window.Instance;
            window.WindowSize = windowSize;

            var view = NewView(VERTICAL, MATCH_PARENT, MATCH_PARENT);
            window.Add(view);

            var menu = NewView(HORIZONTAL, MATCH_PARENT, WRAP_CONTENT);
            view.Add(menu);

            label = NewTextLabel(SHORT_TEXT);
            view.Add(label);

            field = NewTextField(SHORT_TEXT);
            view.Add(field);

            editor = NewTextEditor(SHORT_TEXT);
            view.Add(editor);

            var buttonShort = NewButton("SHORT");
            menu.Add(buttonShort);
            buttonShort.Clicked += (s, e) => { SetText(SHORT_TEXT); };

            var buttonLong = NewButton("LONG");
            menu.Add(buttonLong);
            buttonLong.Clicked += (s, e) => { SetText(LONG_TEXT); };

            var buttonRTL = NewButton("RTL");
            menu.Add(buttonRTL);
            buttonRTL.Clicked += (s, e) => { SetText(RTL_TEXT); };

            var buttonMix = NewButton("MIX");
            menu.Add(buttonMix);
            buttonMix.Clicked += (s, e) => { SetText(MIX_TEXT); };

            var buttonEmoji = NewButton("EMOJI");
            menu.Add(buttonEmoji);
            buttonEmoji.Clicked += (s, e) => { SetText(EMOJI_TEXT); };
        }

        public void SetText(string text)
        {
            label.Text = text;
            field.Text = text;
            editor.Text = text;
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PixelSize = FONT_SIZE,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                Padding = PADDING,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PixelSize = FONT_SIZE,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                Padding = PADDING,
                MaxLength = 2000,
            };
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                PixelSize = FONT_SIZE,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                Padding = PADDING,
            };
            return editor;
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
            };
            return view;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = (int)BUTTON_FONT_SIZE * 2 + 8,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
            };
            button.TextLabel.PixelSize = BUTTON_FONT_SIZE;
            return button;
        }

        public ButtonStyle NewButtonStyle()
        {
            var style = new ButtonStyle
            {
                CornerRadius = 0.0f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.1f, 0.1f, 0.1f, 1.0f),
                    Pressed = new Color(0.5f, 0.5f, 0.5f, 0.25f),
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
