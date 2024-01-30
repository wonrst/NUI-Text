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

            var label = NewTextLabel("Hello, World!");
            view.Add(label);

            var field = NewTextField("Hello, World!");
            field.EnableCursorBlink = false;
            view.Add(field);

            var dummyField = NewTextField("dummy");
            dummyField.HeightSpecification = LayoutParamPolicies.WrapContent;
            dummyField.EnableCursorBlink = false;
            view.Add(dummyField);

            var button = NewButton("Get natural size");
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                Tizen.Log.Error(TAG, $"label natural size w:{label.NaturalSize.Width}, h:{label.NaturalSize.Height}\n");
                Tizen.Log.Error(TAG, $"field natural size w:{field.NaturalSize.Width}, h:{field.NaturalSize.Height}\n");
            };

            var buttonUp = NewButton("PointSize up");
            view.Add(buttonUp);
            buttonUp.Clicked += (s, e) =>
            {
                label.PointSize += 1;
                field.PointSize += 1;
                //field.InputPointSize += 1;
            };

            var buttonDown = NewButton("PointSize down");
            view.Add(buttonDown);
            buttonDown.Clicked += (s, e) =>
            {
                label.PointSize -= 1;
                field.PointSize -= 1;
                //field.InputPointSize -= 1;
            };
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 200,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                PlaceholderText = "Hello, World!",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                MaxLength = 100,
            };
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
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
