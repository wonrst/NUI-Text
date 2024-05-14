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
            GenerateUI(new Size(1200, 600));
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
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(2, 2),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            FontClient.Instance.AddCustomFontDirectory(resourcePath + "/fonts");
            
            var ocean = MakeTest();
            view.Add(ocean);
        }

        public View MakeTest()
        {
            var view = new View()
            {
                Layout = new AbsoluteLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            var image = NewImageView(resourcePath + "/images/ocean.gif");
            view.Add(image);

            var label = NewTextLabel("OCEAN");
            view.Add(label);

            return view;
        }

        public ImageView NewImageView(string url)
        {
            var image = new ImageView()
            {
                ResourceUrl = url,
                AdjustViewSize = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            return image;
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "Montserrat ExtraBold",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                PointSize = 160.0f,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Cutout = true,
                TextColor = new Color(0.0f, 0.0f, 0.0f, 0.0f),
                BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.8f),
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
