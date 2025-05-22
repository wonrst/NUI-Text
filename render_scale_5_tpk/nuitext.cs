using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        const float FONT_SIZE = 34;

        const bool HORIZONTAL = true;
        const bool VERTICAL   = false;
        const int  MATCH_PARENT = LayoutParamPolicies.MatchParent;
        const int  WRAP_CONTENT = LayoutParamPolicies.WrapContent;
        Extents    PADDING      = new Extents(25, 25, 30, 30);

        float SCALE = 1.1f;

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

            var view = NewView(VERTICAL, MATCH_PARENT, MATCH_PARENT);
            window.Add(view);

            var menu = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = MATCH_PARENT,
                HeightSpecification = WRAP_CONTENT,
            };
            view.Add(menu);

            menu.Add(NewDesc("SCALE"));
            var touchf = NewTouchView(MATCH_PARENT, 40, 1000, false);
            menu.Add(touchf);
            touchf.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Motion)
                {
                    Vector2 position = e.Touch.GetLocalPosition(0);
                    SCALE = 1.0f + (position.X / 1000);
                }
                return true;
            };

            // dummy
            var dummy = new View()
            {
                HeightSpecification = 100,
            };
            view.Add(dummy);

            var desc = NewDesc("RenderScale");
            desc.BackgroundColor = Color.Transparent;
            view.Add(desc);

            string[] texts = { "Most Popular in your Region", "Global Top 20", "Most Loved Theme of the Week", "Most Viewed Partner of the Week" };
            string[] descs = { "20 Pieces", "20 Pieces", "12 Pieces", "3 Pieces"};

            Animation scaleAnimation;
            Animation pixelSnapAnimation = null;
            Animation descSnapAnimation = null;

            // render scale
            var horView = NewView(HORIZONTAL, MATCH_PARENT, WRAP_CONTENT);
            view.Add(horView);
            for (int i = 0 ; i < 4 ; i ++)
            {
                var content = new View()
                {
                    Layout = new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                        HorizontalAlignment = HorizontalAlignment.Begin,
                        VerticalAlignment = VerticalAlignment.Top,
                        CellPadding = new Size2D(10, 10),
                    },
                    WidthSpecification = 450,
                    HeightSpecification = 300,
                    BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1.0f),
                    CornerRadius = 25,
                    Focusable = true,
                    FocusableInTouch = true,

                };
                horView.Add(content);

                var label = NewTextLabel(texts[i]);
                content.Add(label);
                var description = NewDescription(descs[i]);
                content.Add(description);

                content.FocusGained += (s, e) =>
                {
                    label.TextColor = new Color(0.1f, 0.1f, 0.1f, 1.0f);
                    content.BackgroundColor = Color.White;

                    float scale = SCALE;
                    label.RenderScale = scale;
                    label.PixelSnapFactor = 0.0f;

                    description.RenderScale = scale;
                    description.PixelSnapFactor = 0.0f;

                    pixelSnapAnimation?.Clear();
                    pixelSnapAnimation = new Animation(200);
                    pixelSnapAnimation.AnimateTo(label, "pixelSnapFactor", 1.0f);
                    pixelSnapAnimation.Play();

                    descSnapAnimation?.Clear();
                    descSnapAnimation = new Animation(200);
                    descSnapAnimation.AnimateTo(description, "pixelSnapFactor", 1.0f);
                    descSnapAnimation.Play();

                    scaleAnimation = new Animation(150);
                    scaleAnimation.AnimateTo(content, "scale", new Vector3(scale, scale, 1.0f));
                    scaleAnimation.Play();
                };
                content.FocusLost += (s, e) =>
                {
                    label.TextColor = Color.White;
                    content.BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1.0f);

                    label.RenderScale = 1.0f;
                    label.PixelSnapFactor = 1.0f;

                    description.RenderScale = 1.0f;
                    description.PixelSnapFactor = 1.0f;

                    pixelSnapAnimation?.Clear();
                    pixelSnapAnimation = new Animation(200);
                    pixelSnapAnimation.AnimateTo(label, "pixelSnapFactor", 0.0f);
                    pixelSnapAnimation.Play();

                    descSnapAnimation?.Clear();
                    descSnapAnimation = new Animation(200);
                    descSnapAnimation.AnimateTo(description, "pixelSnapFactor", 0.0f);
                    descSnapAnimation.Play();

                    scaleAnimation = new Animation(150);
                    scaleAnimation.AnimateTo(content, "scale", new Vector3(1.0f, 1.0f, 1.0f));
                    scaleAnimation.Play();
                };
            }

            // dummy
            dummy = new View()
            {
                HeightSpecification = 100,
            };
            view.Add(dummy);
            
            desc = NewDesc("Original");
            desc.BackgroundColor = Color.Transparent;
            view.Add(desc);

            // original
            var horView2 = NewView(HORIZONTAL, MATCH_PARENT, WRAP_CONTENT);
            view.Add(horView2);
            for (int i = 0 ; i < 4 ; i ++)
            {
                var content = new View()
                {
                    Layout = new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                        HorizontalAlignment = HorizontalAlignment.Begin,
                        VerticalAlignment = VerticalAlignment.Top,
                        CellPadding = new Size2D(10, 10),
                    },
                    WidthSpecification = 450,
                    HeightSpecification = 300,
                    BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1.0f),
                    CornerRadius = 25,
                    Focusable = true,
                    FocusableInTouch = true,
                };
                horView2.Add(content);

                var label = NewTextLabel(texts[i]);
                content.Add(label);
                var description = NewDescription(descs[i]);
                content.Add(description);

                content.FocusGained += (s, e) =>
                {
                    label.TextColor = new Color(0.1f, 0.1f, 0.1f, 1.0f);
                    content.BackgroundColor = Color.White;

                    float scale = SCALE;
                    scaleAnimation = new Animation(150);
                    scaleAnimation.AnimateTo(content, "scale", new Vector3(scale, scale, 1.0f));
                    scaleAnimation.Play();
                };
                content.FocusLost += (s, e) =>
                {
                    label.TextColor = Color.White;
                    content.BackgroundColor = new Color(0.1f, 0.1f, 0.1f, 1.0f);

                    scaleAnimation = new Animation(150);
                    scaleAnimation.AnimateTo(content, "scale", new Vector3(1.0f, 1.0f, 1.0f));
                    scaleAnimation.Play();
                };
            }
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "One UI Sans APP 700 Bold",
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 220,
                PixelSize = FONT_SIZE,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                Padding = PADDING,
                RenderMode = TextRenderMode.AsyncAuto,
                MinLineSize = 54,
                VerticalLineAlignment = VerticalLineAlignment.Center,
            };
            return label;
        }

        public View NewView(bool horizontal, int width, int height)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = horizontal ? LinearLayout.Orientation.Horizontal : LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(30, 10),
                },
                WidthSpecification = width,
                HeightSpecification = height,
                BackgroundColor = Color.Black,
            };
            return view;
        }

        public TextLabel NewDescription(string text)
        {
            var desc = new TextLabel
            {
                Text = text,
                FontFamily = "One UI Sans APP 400 Regular",
                TextColor = Color.DimGray,
                BackgroundColor = Color.Transparent,
                PixelSize = 24.0f,
                WidthSpecification = MATCH_PARENT,
                HeightSpecification = 40,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Extents(25, 25, 0, 0),
                RenderMode = TextRenderMode.AsyncAuto,
            };
            return desc;
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

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
