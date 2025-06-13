using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        const float defaultBorderlineWidth = 10.0f;
        const float defaultInnerShadowBlurRadius = 24.0f;
        const float defaultShadowBlurRadius = 24.0f;
        const int cornerRadius = 30;
        Extents itemMargin = new Extents(0, 0, 200, 50);

        static private readonly UIExtents[] shadowExtentsList = new UIExtents[]
        {
            // begin, end, top, bottom
            new UIExtents(defaultBorderlineWidth * 2.0f, 0.0f, defaultBorderlineWidth * 2.0f, 0.0f),
            new UIExtents(0.0f, defaultBorderlineWidth * 2.0f, 0.0f, defaultBorderlineWidth * 2.0f),
            new UIExtents(defaultBorderlineWidth * 2.0f, 0.0f),
            new UIExtents(0.0f, defaultBorderlineWidth * 2.0f),
            new UIExtents(defaultBorderlineWidth * 2.0f),
            new UIExtents(defaultBorderlineWidth * 4.0f),
            new UIExtents(defaultBorderlineWidth * 4.0f, 0.0f, 0.0f, 0.0f),
            new UIExtents(0.0f, defaultBorderlineWidth * 4.0f, 0.0f, 0.0f),
            new UIExtents(0.0f, 0.0f, defaultBorderlineWidth * 4.0f, 0.0f),
            new UIExtents(0.0f, 0.0f, 0.0f, defaultBorderlineWidth * 4.0f),
            new UIExtents(0.0f),
        };

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
            Window window = Window.Default;
            window.WindowSize = windowSize;

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            string backgroundUrl = "/images/background.gif";

            var view = new View()
            {
                Layout = new AbsoluteLayout(){},
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            window.Add(view);

            var backgroundImage = new ImageView
            {
                ResourceUrl = resourcePath + backgroundUrl,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                FittingMode = FittingModeType.Fill,
            };
            view.Add(backgroundImage);

            var blurView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color(0.015f, 0, 0.15f, 0.5f),
            };
            view.Add(blurView);
            blurView.SetRenderEffect(RenderEffect.CreateBackgroundBlurEffect(120));

            var layout = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            view.Add(layout);

            var scroll = new ScrollableBase()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size(50, 50),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            layout.Add(scroll);

            int shadowExtentsIndex = 4;
            var innerShadow = new InnerShadow(shadowExtentsList[shadowExtentsIndex], defaultInnerShadowBlurRadius, Color.Black);
            var boxShadow = new Shadow(defaultShadowBlurRadius, ColorVisualCutoutPolicyType.CutoutViewWithCornerRadius, new Color(0.0f, 0.0f, 0.0f, 0.5f), new Vector2(0, defaultShadowBlurRadius), new Vector2(defaultShadowBlurRadius, defaultShadowBlurRadius));


            var itemLeft = NewItem(600, 340, resourcePath + "/images/game1.jpg", innerShadow, boxShadow);
            scroll.Add(itemLeft);


            var itemMain = NewMainItem(900, 500, resourcePath + "/images/game.webp", innerShadow, boxShadow);
            scroll.Add(itemMain);


            var itemRight = NewItem(600, 340, resourcePath + "/images/game2.webp", innerShadow, boxShadow);
            scroll.Add(itemRight);




            // PropertyMap texGradient = new PropertyMap();
            // texGradient.Insert((int)Visual.Property.Type, new PropertyValue((int)Visual.Type.Gradient));
            // texGradient.Insert((int)GradientVisualProperty.Center, new PropertyValue(new Vector2((MAIN_WIDTH + THICKNESS * 2) / 2, (MAIN_HEIGHT + THICKNESS * 2) / 2)));
            // texGradient.Insert((int)GradientVisualProperty.StartAngle, new PropertyValue(0.0f));
            // texGradient.Insert((int)GradientVisualProperty.StopOffset, new PropertyValue(stopOffsetArray));
            // texGradient.Insert((int)GradientVisualProperty.StopColor, new PropertyValue(stopColorArray));
            // texGradient.Insert((int)GradientVisualProperty.SpreadMethod, new PropertyValue((int)GradientVisualSpreadMethodType.Repeat));
            // texGradient.Insert((int)GradientVisualProperty.Units, new PropertyValue((int)GradientVisualUnitsType.UserSpace));

            // View texGradientView = new View()
            // {
            //     WidthSpecification = LayoutParamPolicies.MatchParent,
            //     HeightSpecification = 100,
            // };
            // texGradientView.Background = texGradient;
            // layout.Add(texGradientView);

            // TextLabel textlabel = new TextLabel()
            // {
            //     Text = "Samsung Tizen OS",
            //     FontFamily = "One UI Sans APP 600 SemiBold",
            //     WidthSpecification = LayoutParamPolicies.MatchParent,
            //     VerticalAlignment = VerticalAlignment.Center,
            //     HorizontalAlignment = HorizontalAlignment.End,
            //     TextColor = Color.White,
            //     PixelSize = 75,
            //     Padding = new Extents(0, 20, 0, 20),
            // };
            // texGradientView.Add(textlabel);

            // texGradientView.SetRenderEffect(RenderEffect.CreateMaskEffect(textlabel));

            // Animation textAnim = new Animation(3000);
            // textAnim.AnimateTo(texGradientView, "gradient.StartOffset", 1.0f);
            // textAnim.Looping = true;
            // textAnim.LoopingMode = Animation.LoopingModes.Restart;
            // textAnim.Play();
        }

        public View NewItem(int width, int height, string imageUrl, InnerShadow innerShadow, Shadow boxShadow)
        {
            var item = new View()
            {
                Layout = new AbsoluteLayout() {},
                WidthSpecification = width,
                HeightSpecification = height,
                Margin = itemMargin,
                CornerRadius = cornerRadius,
            };
            var image = new ImageView
            {
                ResourceUrl = imageUrl,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                FittingMode = FittingModeType.Fill,
                CornerRadius = cornerRadius,
            };
            item.Add(image);

            image.InnerShadow = innerShadow;
            item.BoxShadow = boxShadow;

            return item;
        }

        public View NewMainItem(int width, int height, string imageUrl, InnerShadow innerShadow, Shadow boxShadow)
        {
            var item = new View()
            {
                Layout = new AbsoluteLayout() {},
                WidthSpecification = width,
                HeightSpecification = height,
                Margin = itemMargin,
                CornerRadius = cornerRadius * 1.5f,
            };

            int MAIN_WIDTH = width;
            int MAIN_HEIGHT = height;
            int MAIN_CORNER_RADIUS = (int)(cornerRadius * 1.5f);
            int THICKNESS = 7;

            PropertyMap map2 = new PropertyMap();
            map2.Insert((int)Visual.Property.Type, new PropertyValue((int)Visual.Type.Gradient));
            map2.Insert((int)GradientVisualProperty.Center, new PropertyValue(new Vector2((MAIN_WIDTH + THICKNESS * 4) / 2, (MAIN_HEIGHT + THICKNESS * 4) / 2)));
            map2.Insert((int)GradientVisualProperty.StartAngle, new PropertyValue(0.0f));

            var stopOffsetArray = new PropertyArray();
            stopOffsetArray.Add(new PropertyValue(0.0f));
            stopOffsetArray.Add(new PropertyValue(0.167f));
            stopOffsetArray.Add(new PropertyValue(0.333f));
            stopOffsetArray.Add(new PropertyValue(0.500f));
            stopOffsetArray.Add(new PropertyValue(0.667f));
            stopOffsetArray.Add(new PropertyValue(0.833f));
            stopOffsetArray.Add(new PropertyValue(1.0f));
            map2.Insert((int)GradientVisualProperty.StopOffset, new PropertyValue(stopOffsetArray));

            var stopColorArray = new PropertyArray();
            stopColorArray.Add(new PropertyValue(new Color("#0892d070")));
            stopColorArray.Add(new PropertyValue(new Color("#4b008270")));
            stopColorArray.Add(new PropertyValue(new Color("#00000000")));
            stopColorArray.Add(new PropertyValue(new Color("#0892d070")));
            stopColorArray.Add(new PropertyValue(new Color("#4b008270")));
            stopColorArray.Add(new PropertyValue(new Color("#00000000")));
            stopColorArray.Add(new PropertyValue(new Color("#0892d070")));
            map2.Insert((int)GradientVisualProperty.StopColor, new PropertyValue(stopColorArray));
            map2.Insert((int)GradientVisualProperty.SpreadMethod, new PropertyValue((int)GradientVisualSpreadMethodType.Repeat));
            map2.Insert((int)GradientVisualProperty.Units, new PropertyValue((int)GradientVisualUnitsType.UserSpace));

            View GradientView2 = new View
            {
                Size2D = new Size2D(MAIN_WIDTH + THICKNESS * 4, MAIN_HEIGHT + THICKNESS * 4),
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                CornerRadius = MAIN_CORNER_RADIUS + THICKNESS * 2,
                BackgroundColor = Color.Blue,
            };
            GradientView2.Background = map2;
            item.Add(GradientView2);

            PropertyMap map1 = new PropertyMap();
            map1.Insert((int)Visual.Property.Type, new PropertyValue((int)Visual.Type.Gradient));
            map1.Insert((int)GradientVisualProperty.Center, new PropertyValue(new Vector2((MAIN_WIDTH + THICKNESS * 2) / 2, (MAIN_HEIGHT + THICKNESS * 2) / 2)));
            map1.Insert((int)GradientVisualProperty.StartAngle, new PropertyValue(0.0f));

            stopOffsetArray = new PropertyArray();
            stopOffsetArray.Add(new PropertyValue(0.0f));
            stopOffsetArray.Add(new PropertyValue(0.167f));
            stopOffsetArray.Add(new PropertyValue(0.333f));
            stopOffsetArray.Add(new PropertyValue(0.500f));
            stopOffsetArray.Add(new PropertyValue(0.667f));
            stopOffsetArray.Add(new PropertyValue(0.833f));
            stopOffsetArray.Add(new PropertyValue(1.0f));
            map1.Insert((int)GradientVisualProperty.StopOffset, new PropertyValue(stopOffsetArray));

            stopColorArray = new PropertyArray();
            stopColorArray.Add(new PropertyValue(new Color("#0892d0ff")));
            stopColorArray.Add(new PropertyValue(new Color("#4b0082ff")));
            stopColorArray.Add(new PropertyValue(new Color("#ffffffff")));
            stopColorArray.Add(new PropertyValue(new Color("#0892d0ff")));
            stopColorArray.Add(new PropertyValue(new Color("#4b0082ff")));
            stopColorArray.Add(new PropertyValue(new Color("#ffffffff")));
            stopColorArray.Add(new PropertyValue(new Color("#0892d0ff")));
            map1.Insert((int)GradientVisualProperty.StopColor, new PropertyValue(stopColorArray));
            map1.Insert((int)GradientVisualProperty.SpreadMethod, new PropertyValue((int)GradientVisualSpreadMethodType.Repeat));
            map1.Insert((int)GradientVisualProperty.Units, new PropertyValue((int)GradientVisualUnitsType.UserSpace));

            View GradientView1 = new View
            {
                Size2D = new Size2D(MAIN_WIDTH + THICKNESS * 2, MAIN_HEIGHT + THICKNESS * 2),
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                CornerRadius = MAIN_CORNER_RADIUS + THICKNESS,
            };
            GradientView1.Background = map1;
            item.Add(GradientView1);

            var image = new ImageView
            {
                ResourceUrl = imageUrl,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                FittingMode = FittingModeType.Fill,
                CornerRadius = cornerRadius * 1.5f,
            };
            item.Add(image);

            image.InnerShadow = innerShadow;
            item.BoxShadow = boxShadow;

            Animation anim1 = new Animation(3000);
            anim1.AnimateTo(GradientView1, "gradient.StartOffset", 1.0f);
            anim1.Looping = true;
            anim1.LoopingMode = Animation.LoopingModes.Restart;
            anim1.Play();

            Animation anim2 = new Animation(3000);
            anim2.AnimateTo(GradientView2, "gradient.StartOffset", 1.0f);
            anim2.Looping = true;
            anim2.LoopingMode = Animation.LoopingModes.Restart;
            anim2.Play();

            return item;
        }


        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PixelSize = 30,
                TextColor = Color.White,
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
