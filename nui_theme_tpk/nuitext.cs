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
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ThemeChangeSensitive = true,
            };
            window.Add(view);


            var brightTheme = new Theme()
            {
                ["BackgroundView"] = new ViewStyle()
                {
                    BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1.0f),
                },
                ["NormalLabel"] = new TextLabelStyle()
                {
                    TextColor = new Color(0.1f, 0.1f, 0.1f, 1.0f),
                    BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 1.0f),
                },
                ["NormalField"] = new TextFieldStyle()
                {
                    TextColor = new Color(0.1f, 0.1f, 0.1f, 1.0f),
                    BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 1.0f),
                },
                ["NormalEditor"] = new TextEditorStyle()
                {
                    TextColor = new Color(0.1f, 0.1f, 0.1f, 1.0f),
                    BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 1.0f),
                },
            };

            var darkTheme = new Theme()
            {
                ["BackgroundView"] = new ViewStyle()
                {
                    BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 1.0f),
                },
                ["NormalLabel"] = new TextLabelStyle()
                {
                    TextColor = new Color(0.9f, 0.9f, 0.9f, 1.0f),
                    BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1.0f),
                },
                ["NormalField"] = new TextFieldStyle()
                {
                    TextColor = new Color(0.9f, 0.9f, 0.9f, 1.0f),
                    BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1.0f),
                },
                ["NormalEditor"] = new TextEditorStyle()
                {
                    TextColor = new Color(0.9f, 0.9f, 0.9f, 1.0f),
                    BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1.0f),
                },
            };

            ThemeManager.ApplyTheme(brightTheme);

            view.StyleName = "BackgroundView";

            var buttonBright = NewButton("Set bright theme");
            view.Add(buttonBright);
            buttonBright.Clicked += (s, e) =>
            {
                ThemeManager.ApplyTheme(brightTheme);
            };

            var buttonDark = NewButton("Set dark theme");
            view.Add(buttonDark);
            buttonDark.Clicked += (s, e) =>
            {
                ThemeManager.ApplyTheme(darkTheme);
            };

            var label = NewTextLabel("Hello, World!");
            label.StyleName = "NormalLabel";
            view.Add(label);

            var field = NewTextField("Hello, World!");
            field.StyleName = "NormalField";
            view.Add(field);

            var editor = NewTextEditor("Hello, World!");
            editor.StyleName = "NormalEditor";
            view.Add(editor);
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "SamsungOneUI",
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                ThemeChangeSensitive = true,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                FontFamily = "SamsungOneUI",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                ThemeChangeSensitive = true,
            };
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                FontFamily = "SamsungOneUI",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                ThemeChangeSensitive = true,
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
