using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        const string TEST_STRING = "ABCabc";

        Color TEXT_COLOR = Color.White;
        float TEXT_OPACITY = 1.0f;

        Color BACKGROUND_COLOR = Color.Black;
        float BACKGROUND_OPACITY = 1.0f;

        Color SHADOW_COLOR = Color.Red;
        float SHADOW_OPACITY = 1.0f;
        int SHADOW_TYPE = 0;

        TextLabel LABEL_BIG;
        TextLabel LABEL_SMALL;

        PropertyMap EMPTY_MAP = new PropertyMap();

        // Test button
        Button btnStyle1;
        Button btnStyle2;
        Button btnStyle3;

        Button btnNoShadow;
        Button btnShadow1;
        Button btnShadow2;
        Button btnShadow3;
        Button btnShadow4;

        Button btnShadowColor1;
        Button btnShadowColor2;
        Button btnShadowColor3;
        Button btnShadowColor4;
        Button btnShadowColor5;

        Button btnShadowOpacity1;
        Button btnShadowOpacity2;
        Button btnShadowOpacity3;
        Button btnShadowOpacity4;

        Button btnBgColor1;
        Button btnBgColor2;
        Button btnBgColor3;
        Button btnBgColor4;
        Button btnBgColor5;

        Button btnBgOpacity1;
        Button btnBgOpacity2;
        Button btnBgOpacity3;
        Button btnBgOpacity4;

        Button btnTextColor1;
        Button btnTextColor2;
        Button btnTextColor3;
        Button btnTextColor4;
        Button btnTextColor5;

        Button btnTextOpacity1;
        Button btnTextOpacity2;
        Button btnTextOpacity3;
        Button btnTextOpacity4;

        Button btnTextCutoutOn;
        Button btnTextCutoutOff;


        public Program() : base()
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(580, 980));
        }

        public void GenerateUI(Size windowSize)
        {
            Window window = Window.Instance;
            window.WindowSize = windowSize;
            window.SetTransparency(true);
            window.BackgroundColor = Color.Transparent;

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            FontClient.Instance.AddCustomFontDirectory(resourcePath);

            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(2, 2),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                //BackgroundColor = Color.Black,
                BackgroundColor = Color.Transparent,
            };
            window.Add(view);

            var dummy = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                //BackgroundColor = Color.Black,
                BackgroundColor = Color.Transparent,
            };
            view.Add(dummy);



            // Test Label
            var videoView_small = new VideoView();
            videoView_small.WidthSpecification = 200;
            videoView_small.HeightSpecification = 100;
            view.Add(videoView_small);

            LABEL_SMALL = NewTextLabel(TEST_STRING);
            LABEL_SMALL.WidthSpecification = 200;
            LABEL_SMALL.HeightSpecification = 100;
            LABEL_SMALL.PointSize = 40.0f;
            videoView_small.Add(LABEL_SMALL);



            var videoView = new VideoView();
            videoView.WidthSpecification = 500;
            videoView.HeightSpecification = 200;
            view.Add(videoView);

            LABEL_BIG = NewTextLabel(TEST_STRING);
            LABEL_BIG.WidthSpecification = 500;
            LABEL_BIG.HeightSpecification = 200;
            videoView.Add(LABEL_BIG);



            // Font style
            TextLabel titleFontStyle = NewTitleLabel(" Font style");
            view.Add(titleFontStyle);

            var styleView = NewView(true);
            view.Add(styleView);

            btnStyle1 = NewButton("Default");
            styleView.Add(btnStyle1);
            btnStyle1.Clicked += (s, e) =>
            {
                SetStyleButton(btnStyle1);

                var styleNormal = new Tizen.NUI.Text.FontStyle
                {
                    Width = FontWidthType.Normal,
                    Weight = FontWeightType.Normal,
                    Slant = FontSlantType.Normal,
                };

                LABEL_BIG.SetFontStyle(styleNormal);
                LABEL_SMALL.SetFontStyle(styleNormal);
            };

            btnStyle2 = NewButton("Bold");
            styleView.Add(btnStyle2);
            btnStyle2.Clicked += (s, e) =>
            {
                SetStyleButton(btnStyle2);

                var styleBold = new Tizen.NUI.Text.FontStyle
                {
                    Width = FontWidthType.Normal,
                    Weight = FontWeightType.Bold,
                    Slant = FontSlantType.Normal,
                };

                LABEL_BIG.SetFontStyle(styleBold);
                LABEL_SMALL.SetFontStyle(styleBold);
           };

            btnStyle3 = NewButton("Italic");
            styleView.Add(btnStyle3);
            btnStyle3.Clicked += (s, e) =>
            {
                SetStyleButton(btnStyle3);

                var styleItalic = new Tizen.NUI.Text.FontStyle
                {
                    Width = FontWidthType.Normal,
                    Weight = FontWeightType.Normal,
                    Slant = FontSlantType.Italic,
                };

                LABEL_BIG.SetFontStyle(styleItalic);
                LABEL_SMALL.SetFontStyle(styleItalic);
            };



            // Shadow
            TextLabel titleEdge = NewTitleLabel(" Edge");
            view.Add(titleEdge);

            var shadowView = NewView(true);
            view.Add(shadowView);

            btnNoShadow = NewButton("No Type");
            shadowView.Add(btnNoShadow);
            btnNoShadow.Clicked += (s, e) =>
            {
                SetShadowTypeButton(btnNoShadow);

                SHADOW_TYPE = 0;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadow1 = NewButton("Type 1");
            shadowView.Add(btnShadow1);
            btnShadow1.Clicked += (s, e) =>
            {
                SetShadowTypeButton(btnShadow1);

                SHADOW_TYPE = 1;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadow2 = NewButton("Type 2");
            shadowView.Add(btnShadow2);
            btnShadow2.Clicked += (s, e) =>
            {
                SetShadowTypeButton(btnShadow2);

                SHADOW_TYPE = 2;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadow3 = NewButton("Type 3");
            shadowView.Add(btnShadow3);
            btnShadow3.Clicked += (s, e) =>
            {
                SetShadowTypeButton(btnShadow3);

                SHADOW_TYPE = 3;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadow4 = NewButton("Type 4");
            shadowView.Add(btnShadow4);
            btnShadow4.Clicked += (s, e) =>
            {
                SetShadowTypeButton(btnShadow4);

                SHADOW_TYPE = 4;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };



            // Shadow color
            var shadowColorView = NewView(true);
            view.Add(shadowColorView);

            btnShadowColor1 = NewButton("White");
            shadowColorView.Add(btnShadowColor1);
            btnShadowColor1.Clicked += (s, e) =>
            {
                SetShadowColorButton(btnShadowColor1);

                SHADOW_COLOR = Color.White;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadowColor2 = NewButton("Black");
            shadowColorView.Add(btnShadowColor2);
            btnShadowColor2.Clicked += (s, e) =>
            {
                SetShadowColorButton(btnShadowColor2);

                SHADOW_COLOR = Color.Black;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadowColor3 = NewButton("Red");
            shadowColorView.Add(btnShadowColor3);
            btnShadowColor3.Clicked += (s, e) =>
            {
                SetShadowColorButton(btnShadowColor3);

                SHADOW_COLOR = Color.Red;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadowColor4 = NewButton("Blue");
            shadowColorView.Add(btnShadowColor4);
            btnShadowColor4.Clicked += (s, e) =>
            {
                SetShadowColorButton(btnShadowColor4);

                SHADOW_COLOR = Color.Blue;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadowColor5 = NewButton("Green");
            shadowColorView.Add(btnShadowColor5);
            btnShadowColor5.Clicked += (s, e) =>
            {
                SetShadowColorButton(btnShadowColor5);

                SHADOW_COLOR = Color.Green;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };



            // shadow opacity
            var shadowOpacityView = NewView(true);
            view.Add(shadowOpacityView);

            btnShadowOpacity1 = NewButton("Opacity 0.0");
            shadowOpacityView.Add(btnShadowOpacity1);
            btnShadowOpacity1.Clicked += (s, e) =>
            {
                SetShadowOpacityButton(btnShadowOpacity1);

                SHADOW_OPACITY = 0.0f;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadowOpacity2 = NewButton("Opacity 0.3");
            shadowOpacityView.Add(btnShadowOpacity2);
            btnShadowOpacity2.Clicked += (s, e) =>
            {
                SetShadowOpacityButton(btnShadowOpacity2);

                SHADOW_OPACITY = 0.3f;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadowOpacity3 = NewButton("Opacity 0.6");
            shadowOpacityView.Add(btnShadowOpacity3);
            btnShadowOpacity3.Clicked += (s, e) =>
            {
                SetShadowOpacityButton(btnShadowOpacity3);

                SHADOW_OPACITY = 0.6f;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };

            btnShadowOpacity4 = NewButton("Opacity 1.0");
            shadowOpacityView.Add(btnShadowOpacity4);
            btnShadowOpacity4.Clicked += (s, e) =>
            {
                SetShadowOpacityButton(btnShadowOpacity4);

                SHADOW_OPACITY = 1.0f;
                SetShadow(LABEL_BIG, SHADOW_TYPE, SHADOW_COLOR);
                SetShadow(LABEL_SMALL, SHADOW_TYPE, SHADOW_COLOR);
            };



            // Background color
            TextLabel titleBackground = NewTitleLabel(" Background");
            view.Add(titleBackground);

            var bgColorView = NewView(true);
            view.Add(bgColorView);

            btnBgColor1 = NewButton("White");
            bgColorView.Add(btnBgColor1);
            btnBgColor1.Clicked += (s, e) =>
            {
                SetBackgroundColorButton(btnBgColor1);

                SetBackgroundColor(LABEL_BIG, Color.White);
                SetBackgroundColor(LABEL_SMALL, Color.White);
            };

            btnBgColor2 = NewButton("Black");
            bgColorView.Add(btnBgColor2);
            btnBgColor2.Clicked += (s, e) =>
            {
                SetBackgroundColorButton(btnBgColor2);

                SetBackgroundColor(LABEL_BIG, Color.Black);
                SetBackgroundColor(LABEL_SMALL, Color.Black);
            };

            btnBgColor3 = NewButton("Red");
            bgColorView.Add(btnBgColor3);
            btnBgColor3.Clicked += (s, e) =>
            {
                SetBackgroundColorButton(btnBgColor3);

                SetBackgroundColor(LABEL_BIG, Color.Red);
                SetBackgroundColor(LABEL_SMALL, Color.Red);
            };

            btnBgColor4 = NewButton("Blue");
            bgColorView.Add(btnBgColor4);
            btnBgColor4.Clicked += (s, e) =>
            {
                SetBackgroundColorButton(btnBgColor4);

                SetBackgroundColor(LABEL_BIG, Color.Blue);
                SetBackgroundColor(LABEL_SMALL, Color.Blue);
            };

            btnBgColor5 = NewButton("Green");
            bgColorView.Add(btnBgColor5);
            btnBgColor5.Clicked += (s, e) =>
            {
                SetBackgroundColorButton(btnBgColor5);

                SetBackgroundColor(LABEL_BIG, Color.Green);
                SetBackgroundColor(LABEL_SMALL, Color.Green);
            };



            // background opacity
            var bgOpacityView = NewView(true);
            view.Add(bgOpacityView);

            btnBgOpacity1 = NewButton("Opacity 0.0");
            bgOpacityView.Add(btnBgOpacity1);
            btnBgOpacity1.Clicked += (s, e) =>
            {
                SetBackgroundOpacityButton(btnBgOpacity1);

                BACKGROUND_OPACITY = 0.0f;
                SetBackgroundColor(LABEL_BIG, BACKGROUND_COLOR);
                SetBackgroundColor(LABEL_SMALL, BACKGROUND_COLOR);
            };

            btnBgOpacity2 = NewButton("Opacity 0.3");
            bgOpacityView.Add(btnBgOpacity2);
            btnBgOpacity2.Clicked += (s, e) =>
            {
                SetBackgroundOpacityButton(btnBgOpacity2);

                BACKGROUND_OPACITY = 0.3f;
                SetBackgroundColor(LABEL_BIG, BACKGROUND_COLOR);
                SetBackgroundColor(LABEL_SMALL, BACKGROUND_COLOR);
            };

            btnBgOpacity3 = NewButton("Opacity 0.6");
            bgOpacityView.Add(btnBgOpacity3);
            btnBgOpacity3.Clicked += (s, e) =>
            {
                SetBackgroundOpacityButton(btnBgOpacity3);

                BACKGROUND_OPACITY = 0.6f;
                SetBackgroundColor(LABEL_BIG, BACKGROUND_COLOR);
                SetBackgroundColor(LABEL_SMALL, BACKGROUND_COLOR);
            };

            btnBgOpacity4 = NewButton("Opacity 1.0");
            bgOpacityView.Add(btnBgOpacity4);
            btnBgOpacity4.Clicked += (s, e) =>
            {
                SetBackgroundOpacityButton(btnBgOpacity4);

                BACKGROUND_OPACITY = 1.0f;
                SetBackgroundColor(LABEL_BIG, BACKGROUND_COLOR);
                SetBackgroundColor(LABEL_SMALL, BACKGROUND_COLOR);
            };



            // Text color
            TextLabel titleText = NewTitleLabel(" Text");
            view.Add(titleText);

            var textColorView = NewView(true);
            view.Add(textColorView);

            btnTextColor1 = NewButton("White");
            textColorView.Add(btnTextColor1);
            btnTextColor1.Clicked += (s, e) =>
            {
                SetTextColorButton(btnTextColor1);

                SetTextColor(LABEL_BIG, Color.White);
                SetTextColor(LABEL_SMALL, Color.White);
            };

            btnTextColor2 = NewButton("Black");
            textColorView.Add(btnTextColor2);
            btnTextColor2.Clicked += (s, e) =>
            {
                SetTextColorButton(btnTextColor2);

                SetTextColor(LABEL_BIG, Color.Black);
                SetTextColor(LABEL_SMALL, Color.Black);
            };

            btnTextColor3 = NewButton("Red");
            textColorView.Add(btnTextColor3);
            btnTextColor3.Clicked += (s, e) =>
            {
                SetTextColorButton(btnTextColor3);

                SetTextColor(LABEL_BIG, Color.Red);
                SetTextColor(LABEL_SMALL, Color.Red);
            };

            btnTextColor4 = NewButton("Blue");
            textColorView.Add(btnTextColor4);
            btnTextColor4.Clicked += (s, e) =>
            {
                SetTextColorButton(btnTextColor4);

                SetTextColor(LABEL_BIG, Color.Blue);
                SetTextColor(LABEL_SMALL, Color.Blue);
            };

            btnTextColor5 = NewButton("Green");
            textColorView.Add(btnTextColor5);
            btnTextColor5.Clicked += (s, e) =>
            {
                SetTextColorButton(btnTextColor5);

                SetTextColor(LABEL_BIG, Color.Green);
                SetTextColor(LABEL_SMALL, Color.Green);
            };



            // Text opacity
            var textOpacityView = NewView(true);
            view.Add(textOpacityView);

            btnTextOpacity1 = NewButton("Opacity 0.0");
            textOpacityView.Add(btnTextOpacity1);
            btnTextOpacity1.Clicked += (s, e) =>
            {
                SetTextOpacityButton(btnTextOpacity1);

                TEXT_OPACITY = 0.0f;
                SetTextColor(LABEL_BIG, TEXT_COLOR);
                SetTextColor(LABEL_SMALL, TEXT_COLOR);
            };

            btnTextOpacity2 = NewButton("Opacity 0.3");
            textOpacityView.Add(btnTextOpacity2);
            btnTextOpacity2.Clicked += (s, e) =>
            {
                SetTextOpacityButton(btnTextOpacity2);

                TEXT_OPACITY = 0.3f;
                SetTextColor(LABEL_BIG, TEXT_COLOR);
                SetTextColor(LABEL_SMALL, TEXT_COLOR);
            };

            btnTextOpacity3 = NewButton("Opacity 0.6");
            textOpacityView.Add(btnTextOpacity3);
            btnTextOpacity3.Clicked += (s, e) =>
            {
                SetTextOpacityButton(btnTextOpacity3);

                TEXT_OPACITY = 0.6f;
                SetTextColor(LABEL_BIG, TEXT_COLOR);
                SetTextColor(LABEL_SMALL, TEXT_COLOR);
            };

            btnTextOpacity4 = NewButton("Opacity 1.0");
            textOpacityView.Add(btnTextOpacity4);
            btnTextOpacity4.Clicked += (s, e) =>
            {
                SetTextOpacityButton(btnTextOpacity4);

                TEXT_OPACITY = 1.0f;
                SetTextColor(LABEL_BIG, TEXT_COLOR);
                SetTextColor(LABEL_SMALL, TEXT_COLOR);
            };



            // Text cutout
            TextLabel titleCutout = NewTitleLabel(" Text Cutout");
            view.Add(titleCutout);

            var textCutoutView = NewView(true);
            view.Add(textCutoutView);

            btnTextCutoutOn = NewButton("On");
            textCutoutView.Add(btnTextCutoutOn);
            btnTextCutoutOn.Clicked += (s, e) =>
            {
                SetTextCutoutButton(btnTextCutoutOn);

                LABEL_BIG.Cutout = true;
                LABEL_SMALL.Cutout = true;
            };

            btnTextCutoutOff = NewButton("Off");
            textCutoutView.Add(btnTextCutoutOff);
            btnTextCutoutOff.Clicked += (s, e) =>
            {
                SetTextCutoutButton(btnTextCutoutOff);

                LABEL_BIG.Cutout = false;
                LABEL_SMALL.Cutout = false;
            };



            // Button default select
            SetStyleButton(btnStyle1);
            SetShadowTypeButton(btnNoShadow);
            SetShadowColorButton(btnShadowColor3);
            SetShadowOpacityButton(btnShadowOpacity4);
            SetBackgroundColorButton(btnBgColor2);
            SetBackgroundOpacityButton(btnBgOpacity4);
            SetTextColorButton(btnTextColor1);
            SetTextOpacityButton(btnTextOpacity4);
            SetTextCutoutButton(btnTextCutoutOff);
        }

        public void SetShadow(TextLabel label, int type, Color color)
        {
            float pointSize = label.PointSize;
            float roughValue = (float)Math.Round(pointSize / 20);

            SHADOW_COLOR = new Color(color.R, color.G, color.B, SHADOW_OPACITY);
            color = SHADOW_COLOR;

            switch(type)
            {
                case 0:
                label.Shadow = EMPTY_MAP;
                label.Outline = EMPTY_MAP;
                break;

                case 1:
                var shadow1 = new PropertyMap();
                shadow1.Add("color", new PropertyValue(color));
                shadow1.Add("offset", new PropertyValue(new Vector2(-roughValue, -roughValue)));
                shadow1.Add("blurRadius", new PropertyValue(roughValue));

                label.Shadow = shadow1;
                label.Outline = EMPTY_MAP;
                break;

                case 2:
                var shadow2 = new PropertyMap();
                shadow2.Add("color", new PropertyValue(color));
                shadow2.Add("offset", new PropertyValue(new Vector2(roughValue, roughValue)));
                shadow2.Add("blurRadius", new PropertyValue(roughValue));

                label.Shadow = shadow2;
                label.Outline = EMPTY_MAP;
                break;

                case 3:
                var outline1 = new PropertyMap();
                outline1.Add("width", new PropertyValue(roughValue));
                outline1.Add("color", new PropertyValue(color));
                outline1.Add("offset", new PropertyValue(new Vector2(0, 0)));
                outline1.Add("blurRadius", new PropertyValue(roughValue));

                label.Shadow = EMPTY_MAP;
                label.Outline = outline1;
                break;

                case 4:
                var outline2 = new PropertyMap();
                outline2.Add("width", new PropertyValue(roughValue));
                outline2.Add("color", new PropertyValue(color));
                outline2.Add("offset", new PropertyValue(new Vector2(-roughValue, -roughValue)));
                outline2.Add("blurRadius", new PropertyValue(roughValue));

                label.Shadow = EMPTY_MAP;
                label.Outline = outline2;
                break;

                default:
                break;
            }
        }

        public void SetTextColor(TextLabel label, Color color)
        {
            TEXT_COLOR = new Color(color.R, color.G, color.B, TEXT_OPACITY);
            label.TextColor = TEXT_COLOR;
        }

        public void SetBackgroundColor(TextLabel label, Color color)
        {
            BACKGROUND_COLOR = new Color(color.R, color.G, color.B, BACKGROUND_OPACITY);
            label.BackgroundColor = BACKGROUND_COLOR;
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "Smr00",
                PointSize = 75.0f,
                TextColor = Color.White,
                BackgroundColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return label;
        }

        public TextLabel NewTitleLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "SamsungOneUI_500",
                PointSize = 14.0f,
                TextColor = Color.White,
                BackgroundColor = Color.Black,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Bottom,
                Padding = new Extents(0, 0, 10, 0),
            };
            return label;
        }

        public View NewView(bool horizontal)
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = horizontal ? LinearLayout.Orientation.Horizontal : LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(2, 2),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Black,
            };
            return view;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                PointSize = 14.0f,
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

        public void SetStyleButton(Button button)
        {
            btnStyle1.TextColor = Color.Black;
            btnStyle2.TextColor = Color.Black;
            btnStyle3.TextColor = Color.Black;
            button.TextColor = Color.Red;
        }

        public void SetShadowTypeButton(Button button)
        {
            btnNoShadow.TextColor = Color.Black;
            btnShadow1.TextColor = Color.Black;
            btnShadow2.TextColor = Color.Black;
            btnShadow3.TextColor = Color.Black;
            btnShadow4.TextColor = Color.Black;
            button.TextColor = Color.Red;
        }

        public void SetShadowColorButton(Button button)
        {
            btnShadowColor1.TextColor = Color.Black;
            btnShadowColor2.TextColor = Color.Black;
            btnShadowColor3.TextColor = Color.Black;
            btnShadowColor4.TextColor = Color.Black;
            btnShadowColor5.TextColor = Color.Black;
            button.TextColor = Color.Red;
        }

        public void SetShadowOpacityButton(Button button)
        {
            btnShadowOpacity1.TextColor = Color.Black;
            btnShadowOpacity2.TextColor = Color.Black;
            btnShadowOpacity3.TextColor = Color.Black;
            btnShadowOpacity4.TextColor = Color.Black;
            button.TextColor = Color.Red;
        }

        public void SetBackgroundColorButton(Button button)
        {
            btnBgColor1.TextColor = Color.Black;
            btnBgColor2.TextColor = Color.Black;
            btnBgColor3.TextColor = Color.Black;
            btnBgColor4.TextColor = Color.Black;
            btnBgColor5.TextColor = Color.Black;
            button.TextColor = Color.Red;
        }

        public void SetBackgroundOpacityButton(Button button)
        {
            btnBgOpacity1.TextColor = Color.Black;
            btnBgOpacity2.TextColor = Color.Black;
            btnBgOpacity3.TextColor = Color.Black;
            btnBgOpacity4.TextColor = Color.Black;
            button.TextColor = Color.Red;
        }

        public void SetTextColorButton(Button button)
        {
            btnTextColor1.TextColor = Color.Black;
            btnTextColor2.TextColor = Color.Black;
            btnTextColor3.TextColor = Color.Black;
            btnTextColor4.TextColor = Color.Black;
            btnTextColor5.TextColor = Color.Black;
            button.TextColor = Color.Red;
        }

        public void SetTextOpacityButton(Button button)
        {
            btnTextOpacity1.TextColor = Color.Black;
            btnTextOpacity2.TextColor = Color.Black;
            btnTextOpacity3.TextColor = Color.Black;
            btnTextOpacity4.TextColor = Color.Black;
            button.TextColor = Color.Red;
        }

        public void SetTextCutoutButton(Button button)
        {
            btnTextCutoutOn.TextColor = Color.Black;
            btnTextCutoutOff.TextColor = Color.Black;
            button.TextColor = Color.Red;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
