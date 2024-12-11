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
        const int WINDOW_WIDTH = 1200;
        const int WINDOW_HEIGHT = 700;
        const int SCROLL_ITEM_WIDTH = 280;
        const int SCROLL_ITEM_HEIGHT = 180;
        const int SCROLL_TITLE_MAX_WIDTH = SCROLL_ITEM_WIDTH - 50;
        const int SCROLL_LABEL_WIDTH = SCROLL_ITEM_WIDTH;
        const int SCROLL_LABEL_HEIGHT = 50;

        // Horizontal
        List<View> HORIZONTAL_VIEWS = new List<View>();
        TextLabel LABEL_TITLE;
        View LABEL_VIEW;
        View ICON;
        View SEPARATOR_1;
        View SEPARATOR_2;

        TextLabel LABEL_DIST;
        TextLabel LABEL_AGE;
        TextLabel LABEL_DESC;

        // Auto scroll
        List<View> SCROLL_VIEWS = new List<View>();
        List<bool> SCROLL_VIEW_FOCUSED = new List<bool>();
        List<TextLabel> SCROLL_TITLES = new List<TextLabel>();
        List<TextLabel> SCROLL_LABELS = new List<TextLabel>();

        // Test data
        Color[] colors = new Color[]{Color.DimGray, Color.LightGray, Color.SkyBlue, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.DarkBlue, Color.Purple};
        String[] movieTitles = new String[]{"The Shawshank Redemption", "Pulp Fiction", "The Godfather", "Schindler's List", "One Flew Over the Cuckoo's Nest", "Fight Club", "Seven Samurai", "City Lights", "Rear Window", "The Silence of the Lambs"};
        String[] distributors = new String[]{
            "Columbia Pictures",
            "Miramax Films",
            "Paramount Pictures",
            "Universal Pictures",
            "United Artists",
            "Fox Searchlight Pictures",
            "Shochiku",
            "United Artists",
            "Warner Bros.",
            "Orion Pictures"
        };
        String[] ageRestrictions = new String[]{"PG-13", "R", "R", "R", "NR", "R", "NR", "G", "PG", "R"};
        String[] movieDescriptions = new String[]{
            "A man unjustly imprisoned struggles to survive and maintain his dignity.",
            "An anthology film featuring multiple stories linked together by chance encounters.",
            "The story of a powerful mafia family and their rise to power in New York City.",
            "A businessman risks everything to save Jewish refugees during World War II.",
            "A rebellious patient fights against the oppressive rules of a mental institution.",
            "A disillusioned insomniac finds solace in an underground fight club.",
            "A samurai and seven farmers defend a village against bandits.",
            "A blind flower seller falls in love with a wealthy heiress.",
            "A photographer suspects his neighbor of committing murder.",
            "A young FBI agent hunts down a serial killer who targets only women."
        };

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(WINDOW_WIDTH, WINDOW_HEIGHT));
        }

        public void GenerateUI(Size windowSize)
        {
            Window window = Window.Instance;
            window.WindowSize = windowSize;

            Window.Instance.KeyEvent += OnKeyEvent;

            FocusManager.Instance.EnableDefaultAlgorithm(true);

            View mainView = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
                Padding = new Extents(10, 10, 10, 10),
            };
            window.Add(mainView);

            // Horizontal
            var title = NewTextLabel("Async Text Horizontal Layout");
            title.PointSize = 32.0f;
            mainView.Add(title);
            title.RequestAsyncRenderWithFixedWidth(WINDOW_WIDTH);

            View view = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Margin = new Extents(0, 0, 6, 6),
            };
            mainView.Add(view);

            var scroll = new ScrollableBase()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    CellPadding = new Size2D(10, 10),
                },
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 180,
                BackgroundColor = Color.Transparent,
            };
            view.Add(scroll);

            Animation sizeAnimation;
            Animation textOpacityAnimation;

            for (int i = 0 ; i < colors.Length ; i ++)
            {
                var item = NewScrollItem(colors[i]);
                scroll.Add(item);
                HORIZONTAL_VIEWS.Add(item);

                item.FocusGained += (s, e) =>
                {
                    int index = HORIZONTAL_VIEWS.FindIndex(tem => tem == (s as View));
                    Tizen.Log.Error(TAG, $"index : {index}\n");

                    LABEL_TITLE.Text = movieTitles[index];
                    LABEL_TITLE.RequestAsyncRenderWithFixedWidth(WINDOW_WIDTH);

                    LABEL_DIST.Text = distributors[index];
                    LABEL_DIST.RequestAsyncRenderWithConstraint(200);

                    LABEL_AGE.Text = ageRestrictions[index];
                    LABEL_AGE.RequestAsyncRenderWithConstraint(200);

                    LABEL_DESC.Text = movieDescriptions[index];
                    LABEL_DESC.RequestAsyncRenderWithConstraint(float.PositiveInfinity);

                    ICON.BackgroundColor = colors[index];
                    SEPARATOR_1.BackgroundColor = colors[index];
                    SEPARATOR_2.BackgroundColor = colors[index];

                    textOpacityAnimation = new Animation(200);
                    LABEL_TITLE.Opacity = 0.0f;
                    textOpacityAnimation.AnimateTo(LABEL_TITLE, "opacity", 1.0f);
                    textOpacityAnimation.Play();

                    textOpacityAnimation = new Animation(200);
                    LABEL_VIEW.Opacity = 0.0f;
                    textOpacityAnimation.AnimateTo(LABEL_VIEW, "opacity", 1.0f);
                    textOpacityAnimation.Play();
                };
            }

            LABEL_TITLE = NewTextLabel("");
            LABEL_TITLE.PointSize = 24.0f;
            mainView.Add(LABEL_TITLE);

            LABEL_VIEW = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Margin = new Extents(0, 0, 6, 6),
            };
            mainView.Add(LABEL_VIEW);

            ICON = NewView(Color.Transparent, 30, 30);
            LABEL_VIEW.Add(ICON);

            LABEL_DIST = NewTextLabel("");
            LABEL_VIEW.Add(LABEL_DIST);

            SEPARATOR_1 = NewView(Color.Transparent, 4, 24);
            LABEL_VIEW.Add(SEPARATOR_1);

            LABEL_AGE = NewTextLabel("");
            LABEL_VIEW.Add(LABEL_AGE);

            SEPARATOR_2 = NewView(Color.Transparent, 4, 24);
            LABEL_VIEW.Add(SEPARATOR_2);

            LABEL_DESC = NewTextLabel("");
            LABEL_VIEW.Add(LABEL_DESC);


            // Auto scroll
            var dummy = NewView(Color.Transparent, 0, 40);
            mainView.Add(dummy);

            title = NewTextLabel("Async Text Auto Scroll");
            title.PointSize = 32.0f;
            mainView.Add(title);
            title.RequestAsyncRenderWithFixedWidth(WINDOW_WIDTH);

            view = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
                Margin = new Extents(0, 0, 6, 6),
            };
            mainView.Add(view);

            scroll = new ScrollableBase()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    CellPadding = new Size2D(10, 10),
                },
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 180,
                BackgroundColor = Color.Transparent,
            };
            view.Add(scroll);

            for (int i = 0 ; i < colors.Length ; i ++)
            {
                var item = NewScrollItem(colors[i]);
                scroll.Add(item);
                SCROLL_VIEWS.Add(item);
                SCROLL_VIEW_FOCUSED.Add(false);

                var labelTitle = NewScrollLabel(movieTitles[i]);
                labelTitle.PointSize = 24.0f;
                item.Add(labelTitle);
                SCROLL_TITLES.Add(labelTitle);
                labelTitle.RequestAsyncRenderWithConstraint(SCROLL_TITLE_MAX_WIDTH);

                var labelDesc = NewScrollLabel(movieDescriptions[i]);
                item.Add(labelDesc);
                SCROLL_LABELS.Add(labelDesc);

                item.FocusGained += (s, e) =>
                {
                    int index = SCROLL_VIEWS.FindIndex(tem => tem == (s as View));
                    Tizen.Log.Error(TAG, $"FocusGained index:{index}\n");
                    SCROLL_VIEW_FOCUSED[index] = true;
                    SCROLL_TITLES[index].RequestAsyncNaturalSize();
                    SCROLL_LABELS[index].RequestAsyncNaturalSize();
                };

                item.FocusLost += (s, e) =>
                {
                    int index = SCROLL_VIEWS.FindIndex(tem => tem == (s as View));
                    Tizen.Log.Error(TAG, $"FocusLost index:{index}\n");
                    SCROLL_VIEW_FOCUSED[index] = false;
                    SCROLL_TITLES[index].EnableAutoScroll = false;
                    SCROLL_LABELS[index].EnableAutoScroll = false;
                    SCROLL_TITLES[index].RequestAsyncRenderWithConstraint(SCROLL_TITLE_MAX_WIDTH);
                    SCROLL_LABELS[index].RequestAsyncRenderWithFixedSize(SCROLL_LABEL_WIDTH, SCROLL_LABEL_HEIGHT);
                };
            }
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                return;                    
            }

            if (e.Key.KeyPressedName == "Escape")
            {

            }

            if (e.Key.KeyPressedName == "1")
            {

            }
        }

        public View NewView(Color color, int width, int height)
        {
            View view = new View()
            {
                WidthSpecification = width,
                HeightSpecification = height,
                BackgroundColor = color,
            };
            return view;
        }

        public View NewScrollItem(Color color)
        {
            View view = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = SCROLL_ITEM_WIDTH,
                HeightSpecification = SCROLL_ITEM_HEIGHT,
                BackgroundColor = color,
                CornerRadius = 10,
                ClippingMode = ClippingModeType.ClipChildren,
                Focusable = true,
                FocusableInTouch = true,
            };
            return view;
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                TextColor = Color.Black,
                MultiLine = false,
                Ellipsis = false,
                WidthSpecification = 0,
                HeightSpecification = 0,
                PointSize = 16.0f,
                BackgroundColor = Color.Transparent,
                VerticalAlignment = VerticalAlignment.Center,
                AutoScrollStopMode = AutoScrollStopMode.Immediate,
                RenderMode = TextRenderMode.AsyncAuto,
            };

            label.AsyncTextRendered += (s, e) =>
            {
                Tizen.Log.Error(TAG, $"Rendered size : {e.Width}, {e.Height}, Line : {label.AsyncLineCount}\n");

                if (label.ManualRendered)
                {
                    label.WidthSpecification = (int)e.Width;
                    label.HeightSpecification = (int)e.Height;
                }
            };

            return label;
        }

        public TextLabel NewScrollLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                TextColor = Color.White,
                MultiLine = false,
                Ellipsis = true,
                WidthSpecification = SCROLL_LABEL_WIDTH,
                HeightSpecification = SCROLL_LABEL_HEIGHT,
                PointSize = 18.0f,
                VerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.5f),
                Padding = new Extents(10, 10, 0, 0),
                AutoScrollStopMode = AutoScrollStopMode.Immediate,
                AutoScrollLoopCount = 0,
                RenderMode = TextRenderMode.AsyncAuto,
            };

            label.AsyncNaturalSizeComputed += (s, e) =>
            {
                int index = SCROLL_TITLES.FindIndex(tem => tem == (s as TextLabel));
                if (index < 0)
                {
                    index = SCROLL_LABELS.FindIndex(tem => tem == (s as TextLabel));
                }

                if (index < 0) return;

                bool focused = SCROLL_VIEW_FOCUSED[index];
                if (focused)
                {
                    (s as TextLabel).EnableAutoScroll = e.Width > (s as TextLabel).Size.Width ? true : false;
                }
                Tizen.Log.Error(TAG, $"Natural Width:{e.Width}, Label Width:{(s as TextLabel).Size.Width}, Label index:{index}, Scroll:{(s as TextLabel).EnableAutoScroll}, Focused:{focused}\n");
            };

            label.AsyncTextRendered += (s, e) =>
            {
                Tizen.Log.Error(TAG, $"Rendered size : {e.Width}, {e.Height}, Line : {label.AsyncLineCount}\n");

                if (label.ManualRendered)
                {
                    label.WidthSpecification = (int)e.Width;
                    label.HeightSpecification = (int)e.Height;
                }
            };

            return label;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                PointSize = 10.0f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 30,
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
