using System;
using System.Collections.Generic;
using System.Diagnostics;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";
        const string LONG_TEXT = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
        int TEST_COUNT = 0;

        TextLabel LABEL;
        Stopwatch STOP_WATCH = new Stopwatch();
        Timer TIMER;

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

            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            var button = NewButton("Size Animation");
            view.Add(button);

            var testView = new View()
            {
                Layout = new AbsoluteLayout(){},
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            view.Add(testView);

            LABEL = NewTextLabel(LONG_TEXT);
            testView.Add(LABEL);
            LABEL.AsyncTextRendered += (s, e) =>
            {
                if(LABEL.ManualRendered)
                {
                    LABEL.WidthSpecification = (int)e.Width;
                    LABEL.HeightSpecification = (int)e.Height;

                    TEST_COUNT++;
                    if(TEST_COUNT < 1000)
                    {
                        TIMER = new Timer(1);
                        TIMER.Tick += (s, e) =>
                        {
                            LABEL.FontSizeScale = 1 + (0.01f * TEST_COUNT);
                            LABEL.RequestAsyncRenderWithFixedWidth(1920);
                            return false;
                        };
                        TIMER.Start();
                    }
                }
            };

            button.TouchEvent += (s, e) =>
            {
                if (e == null || e.Touch.GetState(0) != PointStateType.Up) return true;

                TEST_COUNT = 0;
                LABEL.RequestAsyncRenderWithFixedWidth(1920);
                return true;
            };
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                FontFamily = "One UI Sans 400 Regular",
                WidthSpecification = 0,
                HeightSpecification = 0,
                PixelSize = 10,
                TextColor = Color.White,
                RenderMode = TextRenderMode.AsyncAuto,
            };
            return label;
        }

        public TextLabel NewButton(string text)
        {
            var button = new TextLabel
            {
                Text = text,
                TextColor = Color.White,
                BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 1.0f),
                PixelSize = 16.0f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 40,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return button;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
