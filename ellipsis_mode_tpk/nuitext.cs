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

            FocusManager.Instance.EnableDefaultAlgorithm(true);

            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            string longText = "Hello, World! Hello, World! Hello, World! Hello, World!!";

            var label = NewTextLabel(longText);
            view.Add(label);

            label.FocusGained += (s, e) =>
            {
                Tizen.Log.Error(TAG, "label FocusGained\n");
                label.TextColor = Color.White;
                label.BackgroundColor = Color.Black;
                label.EllipsisMode = EllipsisMode.AutoScroll;
            };

            label.FocusLost += (s, e) =>
            {
                Tizen.Log.Error(TAG, "label FocusLost\n");
                label.TextColor = Color.Black;
                label.BackgroundColor = Color.White;
                label.EllipsisMode = EllipsisMode.Truncate;
            };

            var truncate = NewButton("EllipsisMode.Truncate");
            view.Add(truncate);
            truncate.Clicked += (s, e) =>
            {
                label.EllipsisMode = EllipsisMode.Truncate;
            };

            var autoScroll = NewButton("EllipsisMode.AutoScroll");
            view.Add(autoScroll);
            autoScroll.Clicked += (s, e) =>
            {
                label.EllipsisMode = EllipsisMode.AutoScroll;
            };
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                WidthSpecification = 400,
                HeightSpecification = 50,
                PixelSize = 30.0f,
                BackgroundColor = Color.White,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Extents(10, 10, 10, 10),
                Focusable = true,
                FocusableInTouch = true,
            };
            return label;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 40,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                Focusable = true,
                FocusableInTouch = true,
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
                    Normal = new Color(0.1f, 0.1f, 0.1f, 1.0f),
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
