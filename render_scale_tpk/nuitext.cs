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
        const string FONT_FAMILY = "SamsungOneUI_600";

        List<TextLabel> labels = new List<TextLabel>();
        float SCALE = 1.045f;
        bool IS_DARK = false;

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
            FocusManager.Instance.EnableDefaultAlgorithm(true);

            var view = NewView(VERTICAL, MATCH_PARENT, MATCH_PARENT, 1);
            view.BackgroundColor = Color.LightGray;
            window.Add(view);
            var menuView = NewView(VERTICAL, MATCH_PARENT, WRAP_CONTENT);
            view.Add(menuView);
            var menu = NewView(HORIZONTAL, MATCH_PARENT, WRAP_CONTENT);
            menuView.Add(menu);
            var scaleMenu = NewView(HORIZONTAL, MATCH_PARENT, WRAP_CONTENT);
            menuView.Add(scaleMenu);

            var scrollView = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(20, 35),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(0, 0, 50, 50),
            };
            view.Add(scrollView);

            Animation scaleAnimation;
            Animation pixelSnapAnimation;

            string text = "龍國欟虌钃䶩虋龗 화면음향연결유용한기능 Hello World ฉันเป็นเอาต์บอก";

            for (int i = 20 ; i < 41 ; i += 4)
            {
                float fontSize = (float)i;

                var labelRenderScale = NewTextLabel(text, fontSize);
                labels.Add(labelRenderScale);
                scrollView.Add(labelRenderScale);
                labelRenderScale.Add(NewDescription($"FontSize:{i}, Render Scale + Scale Animation"));
                labelRenderScale.FocusGained += (s, e) =>
                {
                    labelRenderScale.RenderScale = SCALE;
                    labelRenderScale.EllipsisMode = EllipsisMode.AutoScroll;
                    labelRenderScale.PixelSnapFactor = 0.0f;

                    labelRenderScale.TextColor = Color.Black;
                    labelRenderScale.BackgroundColor = Color.White;

                    scaleAnimation = new Animation(200);
                    scaleAnimation.AnimateTo(labelRenderScale, "scale", new Vector3(SCALE, SCALE, 1.0f));
                    scaleAnimation.Play();

                    pixelSnapAnimation = new Animation(250);
                    pixelSnapAnimation.AnimateTo(labelRenderScale, "pixelSnapFactor", 1.0f);
                    pixelSnapAnimation.Play();
                };
                labelRenderScale.FocusLost += (s, e) =>
                {
                    labelRenderScale.RenderScale = 1.0f;
                    labelRenderScale.EllipsisMode = EllipsisMode.Truncate;
                    labelRenderScale.PixelSnapFactor = 1.0f;

                    labelRenderScale.TextColor = IS_DARK ? Color.White : Color.Black;
                    labelRenderScale.BackgroundColor = IS_DARK ? Color.Black : Color.White;

                    scaleAnimation = new Animation(200);
                    scaleAnimation.AnimateTo(labelRenderScale, "scale", new Vector3(1.0f, 1.0f, 1.0f));
                    scaleAnimation.Play();

                    pixelSnapAnimation = new Animation(250);
                    pixelSnapAnimation.AnimateTo(labelRenderScale, "pixelSnapFactor", 0.0f);
                    pixelSnapAnimation.Play();
                };

                var labelOriginalScale = NewTextLabel(text, fontSize);
                labels.Add(labelOriginalScale);
                scrollView.Add(labelOriginalScale);
                labelOriginalScale.Add(NewDescription($"FontSize:{i}, Original Scale Animation"));
                labelOriginalScale.FocusGained += (s, e) =>
                {
                    labelOriginalScale.EllipsisMode = EllipsisMode.AutoScroll;

                    labelOriginalScale.TextColor = Color.Black;
                    labelOriginalScale.BackgroundColor = Color.White;

                    scaleAnimation = new Animation(200);
                    scaleAnimation.AnimateTo(labelOriginalScale, "scale", new Vector3(SCALE, SCALE, 1.0f));
                    scaleAnimation.Play();
                };
                labelOriginalScale.FocusLost += (s, e) =>
                {
                    labelOriginalScale.EllipsisMode = EllipsisMode.Truncate;

                    labelOriginalScale.TextColor = IS_DARK ? Color.White : Color.Black;
                    labelOriginalScale.BackgroundColor = IS_DARK ? Color.Black : Color.White;

                    scaleAnimation = new Animation(200);
                    scaleAnimation.AnimateTo(labelOriginalScale, "scale", new Vector3(1.0f, 1.0f, 1.0f));
                    scaleAnimation.Play();
                };
            }


            var buttonLight = NewButton("LIGHT");
            buttonLight.WidthSpecification = 200;
            menu.Add(buttonLight);
            buttonLight.TouchEvent += (s, e) =>
            {
                if (e == null || e.Touch.GetState(0) != PointStateType.Up) return true;
                IS_DARK = false;
                foreach (var label in labels)
                {
                    label.TextColor = Color.Black;
                    label.BackgroundColor = Color.White;
                }
                return true;
            };

            var buttonDark = NewButton("DARK");
            buttonDark.WidthSpecification = 200;
            menu.Add(buttonDark);
            buttonDark.TouchEvent += (s, e) =>
            {
                if (e == null || e.Touch.GetState(0) != PointStateType.Up) return true;
                IS_DARK = true;
                foreach (var label in labels)
                {
                    label.TextColor = Color.White;
                    label.BackgroundColor = Color.Black;
                }
                return true;
            };

            var wrap = NewButton("WRAP");
            wrap.WidthSpecification = 200;
            menu.Add(wrap);
            wrap.TouchEvent += (s, e) =>
            {
                if (e == null || e.Touch.GetState(0) != PointStateType.Up) return true;
                SetSize(WRAP_CONTENT);
                return true;
            };

            var match = NewButton("MATCH");
            match.WidthSpecification = 200;
            menu.Add(match);
            match.TouchEvent += (s, e) =>
            {
                if (e == null || e.Touch.GetState(0) != PointStateType.Up) return true;
                SetSize(MATCH_PARENT);
                return true;
            };

            var touch = NewTextLabel("DRAG TO SET WIDTH", 16.0f);
            touch.FontFamily = "SamsungOneUI_400";
            touch.TextColor = Color.White;
            touch.BackgroundColor = new Color(0.19f, 0.19f, 0.19f, 1.0f);
            touch.WidthSpecification = MATCH_PARENT;
            touch.HeightSpecification = 40;
            menu.Add(touch);
            touch.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Motion)
                {
                    Vector2 position = e.Touch.GetLocalPosition(0);
                    SetSize((int)position.X);
                    touch.Text = "DRAG TO SET WIDTH:" + (int)position.X;
                }
                return true;
            };

            float[] scales = { 1.045f, 1.05f, 1.1f, 1.15f, 1.2f, 1.25f, 1.3f, 1.35f, 1.4f, 2.0f };

            for (int i = 0 ; i < scales.Length ; i ++)
            {
                float scale = scales[i];
                string scaleText = "SCALE:" + String.Format("{0:F3}", scale);

                var button = NewButton(scaleText);
                scaleMenu.Add(button);
                button.TouchEvent += (s, e) =>
                {
                    if (e == null || e.Touch.GetState(0) != PointStateType.Up) return true;
                    SCALE = scale;
                    return true;
                };

            }
        }

        public void SetSize(int width)
        {
            foreach (var label in labels)
            {
                label.WidthSpecification = width;
            }
        }

        public TextLabel NewTextLabel(string text, float fontSize)
        {
            int minLineSize = (int)Math.Ceiling(fontSize * 1.6f);
            minLineSize = minLineSize % 2 == 0 ? minLineSize : minLineSize - 1;

            var label = new TextLabel
            {
                Text = text,
                FontFamily = FONT_FAMILY,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PixelSize = fontSize,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Focusable = true,
                FocusableInTouch = true,
                AutoScrollLoopCount = 0,
                MinLineSize = (float)minLineSize,
                VerticalLineAlignment = VerticalLineAlignment.Center,

                RenderMode = TextRenderMode.AsyncAuto,
            };
            return label;
        }

        public TextLabel NewDescription(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "SamsungOneUI_400",
                PixelSize = 14.0f,
                TextColor = Color.White,
                BackgroundColor = new Color(0.05f, 0.05f, 0.05f, 0.95f),
                InheritScale = false,
                VerticalAlignment = VerticalAlignment.Center,
            };
            label.Size = label.NaturalSize;
            label.Position = new Position(0, -label.NaturalSize.Height);
            return label;
        }

        public View NewView(bool horizontal, int width, int height, int cellPadding = 1)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = horizontal ? LinearLayout.Orientation.Horizontal : LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, cellPadding),
                },
                WidthSpecification = width,
                HeightSpecification = height,
                BackgroundColor = Color.Transparent,
            };
            return view;
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
