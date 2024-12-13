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

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            FontClient.Instance.AddCustomFontDirectory(resourcePath + "fonts");

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
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            string text = "Hello, World!";

            var regular = new Tizen.NUI.Text.FontStyle{Weight = FontWeightType.Regular};
            var medium = new Tizen.NUI.Text.FontStyle{Weight = FontWeightType.Medium};
            var bold = new Tizen.NUI.Text.FontStyle{Weight = FontWeightType.Bold};

            var label = NewTextLabel(text);
            label.FontFamily = "Roboto";
            label.SetFontStyle(regular);
            view.Add(label);

            var label2 = NewTextLabel(text);
            label2.FontFamily = "Roboto";
            label2.SetFontStyle(medium);
            view.Add(label2);

            var label3 = NewTextLabel(text);
            label3.FontFamily = "Roboto";
            label3.SetFontStyle(bold);
            view.Add(label3);

            Tizen.Log.Error(TAG, $"RYU - size1 {label.NaturalSize.Width}, {label.NaturalSize.Height}\n");
            Tizen.Log.Error(TAG, $"RYU - size2 {label2.NaturalSize.Width}, {label2.NaturalSize.Height}\n");
            Tizen.Log.Error(TAG, $"RYU - size3 {label3.NaturalSize.Width}, {label3.NaturalSize.Height}\n");
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                PixelSize = 40.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return label;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
