using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        const float APP_WIDTH = 480;
        const float APP_HEIGHT = 780; 
        const float TEXT_WIDTH = 100;
        const float TEXT_HEIGHT = 80;

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
            var labels = new List<TextLabel>();
            var backLabels = new List<TextLabel>();

            var view = new View()
            {
                Layout = new AbsoluteLayout(){},
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            var scrollBack = new ScrollableBase()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = (int)TEXT_WIDTH,
                HeightSpecification = (int)TEXT_HEIGHT * 3,
                BackgroundColor = Color.Black,
                Position = new Position((APP_WIDTH - TEXT_WIDTH) / 2, (APP_HEIGHT - TEXT_HEIGHT * 3) / 2),
                ScrollEnabled = false,
                DecelerationRate = 0.0f,
            };
            view.Add(scrollBack);

            var dummy = new View()
            {
                WidthSpecification = (int)TEXT_WIDTH,
                HeightSpecification = (int)TEXT_HEIGHT,
                BackgroundColor = Color.White,
            };
            scrollBack.Add(dummy);

            for (int i = 0 ; i < 100 ; i ++)
            {
                var label = NewTextLabel("" + i);
                label.TextColor = Color.Black * 0.2f;
                scrollBack.Add(label);
                backLabels.Add(label);
            }

            dummy = new View()
            {
                WidthSpecification = (int)TEXT_WIDTH,
                HeightSpecification = (int)TEXT_HEIGHT,
                BackgroundColor = Color.White,
            };
            scrollBack.Add(dummy);

            var scroll = new ScrollableBase()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = (int)TEXT_WIDTH,
                HeightSpecification = (int)TEXT_HEIGHT,
                BackgroundColor = Color.Red,
                Position = new Position((APP_WIDTH - TEXT_WIDTH) / 2, (APP_HEIGHT - TEXT_HEIGHT) / 2),
                DecelerationRate = 0.995f,

            };
            view.Add(scroll);

            for (int i = 0 ; i < 100 ; i ++)
            {
                var label = NewTextLabel("" + i);
                scroll.Add(label);
                label.FontSizeScale = 1.05f;
                // label.Scale = new Vector3(1.1f, 1.1f, 1.0f);
                labels.Add(label);
            }

            bool firstRelayout = true;
            scroll.Relayout += (s, e) =>
            {
                if(firstRelayout)
                {
                    firstRelayout = false;
                    scroll.ScrollTo(TEXT_HEIGHT, false);
                }
            };

            var defaultColor = Color.Black;
            var animationColor = new Color(0.65f, 0.55f, 0.2f, 1.0f);

            scroll.Scrolling += (s, e) =>
            {
                scrollBack.ScrollTo(e.ScrollPosition.Y, false);
                Tizen.Log.Error(TAG, $"Scrolling {e.ScrollPosition.Y}, back {scrollBack.ScrollPosition.Y}\n");

                // I don't know why this case happens. bug of ScrollTo.
                if(e.ScrollPosition.Y != scrollBack.ScrollPosition.Y)
                {
                    Tizen.Log.Error(TAG, $"ScrollTo doesn't work!! Scrolling {e.ScrollPosition.Y}, back {scrollBack.ScrollPosition.Y}\n");
                    scroll.ScrollTo(e.ScrollPosition.Y, false);
                }
            };

            Animation textColorAnimation;

            scroll.ScrollDragStarted += (s, e) =>
            {
                Tizen.Log.Error(TAG, "ScrollDragStarted\n");

                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    textColorAnimation = new Animation(100);
                    textColorAnimation.AnimateTo(labels[i], "textColor", animationColor);
                    textColorAnimation.Play();
                }

                for (int i = 0 ; i < backLabels.Count ; i ++)
                {
                    textColorAnimation = new Animation(100);
                    textColorAnimation.AnimateTo(backLabels[i], "textColor", animationColor * 0.4f);
                    textColorAnimation.Play();
                }
            };

            scroll.ScrollAnimationEnded += (s, e) =>
            {
                Tizen.Log.Error(TAG, $"ScrollAnimationEnded {e.ScrollPosition.Y}, back {scrollBack.ScrollPosition.Y}\n");

                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    textColorAnimation = new Animation(100);
                    textColorAnimation.AnimateTo(labels[i], "textColor", defaultColor);
                    textColorAnimation.Play();
                }

                for (int i = 0 ; i < backLabels.Count ; i ++)
                {
                    textColorAnimation = new Animation(100);
                    textColorAnimation.AnimateTo(backLabels[i], "textColor", defaultColor * 0.2f);
                    textColorAnimation.Play();
                }
            };
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                FontFamily = "One UI Sans APP 500 Medium",
                WidthSpecification = (int)TEXT_WIDTH,
                HeightSpecification = (int)TEXT_HEIGHT,
                PixelSize = 50.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return label;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                PointSize = 20.0f,
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

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
