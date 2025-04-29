using System;
using System.Collections.Generic;

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

        TextLabel LABEL;
        TextLabel DESC;
        float FONT_SIZE = 32.0f;
        float SCALE = 1.045f;

        EllipsisMode ELLIPSIS_MODE = EllipsisMode.Truncate;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(1920, 160));
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
                    CellPadding = new Size2D(1, 10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Gray,
            };
            window.Add(view);

            var menuView = NewView(VERTICAL, MATCH_PARENT, WRAP_CONTENT);
            view.Add(menuView);

            var menu = NewView(HORIZONTAL, MATCH_PARENT, WRAP_CONTENT);
            menuView.Add(menu);

            DESC = NewDesc("SCALE");
            menu.Add(DESC);

            var touch = NewTouchView(MATCH_PARENT, 40, 1000, false);
            menu.Add(touch);
            touch.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Motion)
                {
                    Vector2 position = e.Touch.GetLocalPosition(0);
                    SetScale(1.0f + (position.X / 1000));
                }
                return true;
            };

            var textView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(20, 35),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                WidthSpecification = MATCH_PARENT,
                HeightSpecification = MATCH_PARENT,
                BackgroundColor = Color.Gray,
            };
            view.Add(textView);

            string text = "龍國欟虌钃䶩虋龗 화면음향연결유용한기능 Hello World ฉันเป็นเอาต์บอก";
            LABEL = NewTextLabel(text);
            LABEL.PixelSize = FONT_SIZE;
            textView.Add(LABEL);
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "SamsungOneUI_600",
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PixelSize = FONT_SIZE,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                RenderMode = TextRenderMode.AsyncAuto,
            };

            return label;
        }

        public void SetScale(float scale)
        {
            scale = (float)Math.Round(scale, 3);
            SCALE = scale;
            DESC.Text = "SCALE:" + scale;

            LABEL.PixelSize = FONT_SIZE * scale;
        }

        public View NewView(bool horizontal, int width, int height)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = horizontal ? LinearLayout.Orientation.Horizontal : LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(1, 1),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                WidthSpecification = width,
                HeightSpecification = height,
                BackgroundColor = Color.Black,
            };
            return view;
        }

        public View NewTouchView(int width, int height, int adjust, bool integer = true)
        {
            var view = new View()
            {
                WidthSpecification = width,
                HeightSpecification = height,
                BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1.0f),
            };
            var overlay = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.1f),
            };
            view.Add(overlay);
            var indicator = new View()
            {
                WidthSpecification = 2,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red * 0.95f,
            };
            view.Add(indicator);
            var desc = new TextLabel()
            {
                PixelSize = 16.0f,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(desc);
            view.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Motion)
                {
                    Vector2 position = e.Touch.GetLocalPosition(0);
                    indicator.Position.X = position.X;
                    desc.Position.X = position.X + indicator.WidthSpecification + 10;

                    desc.Text = integer ? "" + (int)position.X / adjust : "" + String.Format("{0:F3}", 1.0f + (position.X / adjust));
                }
                return true;
            };

            return view;
        }

        public TextLabel NewDesc(string text)
        {
            var desc = new TextLabel
            {
                Text = text,
                TextColor = Color.White,
                BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 1.0f),
                PixelSize = 16.0f,
                WidthSpecification = 200,
                HeightSpecification = 40,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return desc;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
