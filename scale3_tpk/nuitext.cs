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

        const float BUTTON_FONT_SIZE = 16.0f;
        const bool HORIZONTAL = true;
        const bool VERTICAL   = false;
        const int  MATCH_PARENT = LayoutParamPolicies.MatchParent;
        const int  WRAP_CONTENT = LayoutParamPolicies.WrapContent;
        Extents    PADDING      = new Extents(0, 0, 0, 0);

        List<TextLabel> labels = new List<TextLabel>();
        TextLabel referenceOriginal;
        TextLabel referenceScale;
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
            GenerateUI(new Size(1920, 1080));
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
            {
                var desc = NewButton("HORIZONTAL");
                menu.Add(desc);

                var wrap = NewButton("WRAP");
                menu.Add(wrap);
                wrap.Clicked += (s, e) => { SetSize(HORIZONTAL, WRAP_CONTENT, desc); };

                var match = NewButton("MATCH");
                menu.Add(match);
                match.Clicked += (s, e) => { SetSize(HORIZONTAL, MATCH_PARENT, desc); };

                var touch = NewTouchView(MATCH_PARENT, 40, 1);
                menu.Add(touch);
                touch.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Motion)
                    {
                        Vector2 position = e.Touch.GetLocalPosition(0);
                        SetSize(HORIZONTAL, (int)position.X, desc);
                    }
                    return true;
                };
            }

            var menuv = NewView(HORIZONTAL, MATCH_PARENT, WRAP_CONTENT);
            menuView.Add(menuv);
            {
                var desc = NewButton("VERTICAL");
                menuv.Add(desc);

                var wrap = NewButton("WRAP");
                menuv.Add(wrap);
                wrap.Clicked += (s, e) => { SetSize(VERTICAL, WRAP_CONTENT, desc); };

                var match = NewButton("MATCH");
                menuv.Add(match);
                match.Clicked += (s, e) => { SetSize(VERTICAL, MATCH_PARENT, desc); };

                var touch = NewTouchView(MATCH_PARENT, 40, 5);
                menuv.Add(touch);
                touch.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Motion)
                    {
                        Vector2 position = e.Touch.GetLocalPosition(0);
                        SetSize(VERTICAL, (int)position.X / 5, desc);
                    }
                    return true;
                };

                var descf = NewButton("FONT SIZE");
                menuv.Add(descf);
                var touchf = NewTouchView(MATCH_PARENT, 40, 10);
                menuv.Add(touchf);
                touchf.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Motion)
                    {
                        Vector2 position = e.Touch.GetLocalPosition(0);
                        SetFontSize((int)position.X / 10, descf);
                    }
                    return true;
                };
            }

            var menuvv = NewView(HORIZONTAL, MATCH_PARENT, WRAP_CONTENT);
            menuView.Add(menuvv);
            {
                var wrap = NewButton("TRUNCATE");
                menuvv.Add(wrap);
                wrap.Clicked += (s, e) => { ELLIPSIS_MODE = EllipsisMode.Truncate; };

                var match = NewButton("AUTO SCROLL");
                menuvv.Add(match);
                match.Clicked += (s, e) => { ELLIPSIS_MODE = EllipsisMode.AutoScroll; };

                var desc = NewButton("RENDER SCALE");
                menuvv.Add(desc);
                var touchf = NewTouchView(MATCH_PARENT, 40, 1000, false);
                menuvv.Add(touchf);
                touchf.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Motion)
                    {
                        Vector2 position = e.Touch.GetLocalPosition(0);
                        SetRenderScale(1.0f + (position.X / 1000), desc);
                    }
                    return true;
                };
            }

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


            Animation scaleAnimation;

            string text = "龍國欟虌钃䶩虋龗 화면음향연결유용한기능 Hello World ฉันเป็นเอาต์บอก";
            // string text = "화면 음향 연결 유용한 기능 [123456789...]";

            string labelText = text;

            var label = NewTextLabel(labelText);
            textView.Add(label);
            labels.Add(label);
            label.Add(NewDescription("Render Scale + Scale Animation"));

            label.FocusGained += (s, e) =>
            {
                float scale = GetScale();
                var ellipsisMode = GetEllipsisMode();
                label.EllipsisMode = ellipsisMode;

                // label.RenderScale = scale;
                scaleAnimation = new Animation(200);
                scaleAnimation.AnimateTo(label, "scale", new Vector3(scale, scale, 1.0f));
                scaleAnimation.Play();
            };
            label.FocusLost += (s, e) =>
            {
                label.EllipsisMode = EllipsisMode.Truncate;

                // label.RenderScale = 1.0f;
                scaleAnimation = new Animation(200);
                scaleAnimation.AnimateTo(label, "scale", new Vector3(1.0f, 1.0f, 1.0f));
                scaleAnimation.Play();
            };

            var original = NewTextLabel(labelText);
            textView.Add(original);
            labels.Add(original);
            original.Add(NewDescription("Original Scale Animation"));
            original.FocusGained += (s, e) =>
            {
                float scale = GetScale();
                var ellipsisMode = GetEllipsisMode();
                original.EllipsisMode = ellipsisMode;

                scaleAnimation = new Animation(200);
                scaleAnimation.AnimateTo(original, "scale", new Vector3(scale, scale, 1.0f));
                scaleAnimation.Play();
            };
            original.FocusLost += (s, e) =>
            {
                original.EllipsisMode = EllipsisMode.Truncate;

                scaleAnimation = new Animation(200);
                scaleAnimation.AnimateTo(original, "scale", new Vector3(1.0f, 1.0f, 1.0f));
                scaleAnimation.Play();
            };

            referenceOriginal = NewTextLabel(labelText);
            referenceOriginal.Add(NewDescription("Original Scale 1.0"));
            textView.Add(referenceOriginal);

            referenceScale = NewTextLabel(labelText);
            referenceScale.PixelSize = FONT_SIZE * GetScale();
            referenceScale.Add(NewDescription("Render Scale Original Texture"));

            Tizen.Log.Error(TAG, $"ref natural:{referenceScale.NaturalSize.Width}, {referenceScale.NaturalSize.Height}\n");
            textView.Add(referenceScale);
        }

        public float GetScale()
        {
            return SCALE;
        }

        public EllipsisMode GetEllipsisMode()
        {
            return ELLIPSIS_MODE;
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
                Focusable = true,
                FocusableInTouch = true,
                AutoScrollLoopCount = 0,
                RenderMode = TextRenderMode.AsyncAuto,
                EllipsisMode = EllipsisMode.Truncate,
                VerticalLineAlignment = VerticalLineAlignment.Center,
            };

            return label;
        }

        public TextLabel NewDescription(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "SamsungOneUI_400",
                PixelSize = 16.0f,
                TextColor = Color.White,
                BackgroundColor = new Color(0.05f, 0.05f, 0.05f, 0.95f),
                InheritScale = false,
                VerticalAlignment = VerticalAlignment.Center,
            };
            label.Size = label.NaturalSize;
            label.Position = new Position(0, -label.NaturalSize.Height);
            return label;
        }

        public void SetRenderScale(float scale, Button desc)
        {
            scale = (float)Math.Round(scale, 3);
            SCALE = scale;
            desc.Text = "RENDER SCALE:" + scale;

            referenceScale.PixelSize = FONT_SIZE * scale;

            foreach (var label in labels)
            {
                if (label.Scale.X > 1.0f)
                {
                    label.Scale = new Vector3(scale, scale, 1.0f);
                    // if (label.RenderScale > 1.0f)
                    // {
                    //     label.RenderScale = scale;
                    // }
                }
            }
        }

        public void SetFontSize(float pixelSize, Button desc)
        {
            FONT_SIZE = pixelSize;
            foreach (var label in labels)
            {
                label.PixelSize = pixelSize;
            }
            referenceOriginal.PixelSize = pixelSize;
            referenceScale.PixelSize = pixelSize * GetScale();
            desc.Text = "FONT SIZE:" + pixelSize;
        }

        public void SetSize(bool horizontal, int size, Button desc)
        {
            foreach (var label in labels)
            {
                if (horizontal)
                {
                    label.WidthSpecification = size;
                }
                else
                {
                    label.HeightSpecification = size;
                }
            }
            desc.Text = horizontal ? "HORIZONTAL:" + size : "VERTICAL:" + size;
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
                PixelSize = BUTTON_FONT_SIZE,
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

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                WidthSpecification = 200,
                HeightSpecification = 40,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
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
