using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(480, 780));
        }

        public void GenerateUI(Size windowSize)
        {
            Window window = Window.Instance;
            window.WindowSize = windowSize;

            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            var field = NewTextEditor("");
            InputMethodContext ime = field.GetInputMethodContext();
            ime.TextPrediction = true;
            view.Add(field);

            var field1 = NewTextEditor("");
            InputMethodContext ime1 = field1.GetInputMethodContext();
            ime1.TextPrediction = true;
            ime1.NotifyTextInputMultiLine(false);
            view.Add(field1);

            var field2 = NewTextEditor("");
            InputMethodContext ime2 = field2.GetInputMethodContext();
            ime2.TextPrediction = true;
            ime2.NotifyTextInputMultiLine(true);
            view.Add(field2);

        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "SamsungOneUI",
                //MultiLine = true,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 45.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                MaxLength = 20,
            };
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
            };
            return editor;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                PointSize = 20.0f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
            };
            return button;
        }

        public ButtonStyle NewButtonStyle()
        {
            var style = new ButtonStyle
            {
                CornerRadius = 0.0f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.25f, 0.75f, 1.0f, 1.0f),
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
                    TextColor = new Color(0.0f, 0.0f, 0.0f, 1.0f),
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
