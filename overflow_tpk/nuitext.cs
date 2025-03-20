using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        const int LABEL_WIDTH = 600;
        const string FONT_FAMILY = "Ubuntu Mono";

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(1200, 800));
        }

        public void GenerateUI(Size windowSize)
        {
#region UI
            Window window = Window.Instance;
            window.WindowSize = windowSize;
            FocusManager.Instance.EnableDefaultAlgorithm(true);

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            FontClient.Instance.AddCustomFontDirectory(resourcePath);

            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Center,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            window.Add(view);

            string[] desc = new string[]{
                "<b>Overflow Option1</b>\nText will be abbreviated if the area is insufficient.",
                "<b>Overflow Option2</b>\n(1) The font size can be reduced to the minimum value to show the text as mush as possible.\n(2) The font size is reduced by 4\n(3) The minimum font size is 16.\n(4) The text will be ellipsis when it reaches minimum font size.",
                "<b>Overflow Option3</b>\nIncrease the width of the <background color='#dddddd'>TextLabel</background> to show all text.",
                "<b>Overflow Option4</b>\nText will be abbreviated if the area is insufficient.\nHowever, auto-scroll is applied when the <background color='#dddddd'>TextLabel</background> has got focused.",
                "<b>Overflow Option5</b>\nAuto-scroll is always applied to show all text.",
                "<b>Overflow Option6</b>\nSame as <background color='#dddddd'>Overflow Option2</background> except (4).\n(4) The text will be auto-scrolled when it reaches minimum font size.",
                "<b>Overflow Option7</b>\nIncrease the width of the <background color='#dddddd'>TextLabel</background> to show all text.\nWhen it reaches specified maximum size, auto-scroll is applied."
             };

            string shortText = "Hello, World!";
            string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            var label = NewTextLabel(longText);
            view.Add(label);

            var description = NewDescription(desc[0]);
            var properties = NewDescription("");
            SetProperties(properties, label);

            var textOptionView = NewView();
            view.Add(textOptionView);

            var btnShort = NewButton("Short Text");
            textOptionView.Add(btnShort);
            var btnLong = NewButton("Long Text");
            textOptionView.Add(btnLong);
            var btnSingle = NewButton("Singleline");
            textOptionView.Add(btnSingle);
            var btnMulti = NewButton("Multiline");
            textOptionView.Add(btnMulti);
            var btnSync = NewButton("Sync");
            textOptionView.Add(btnSync);
            var btnAsync = NewButton("Async");
            textOptionView.Add(btnAsync);

            var overflowOptionView = NewView();
            view.Add(overflowOptionView);

            var overflow1 = NewButton("Overflow 1");
            overflowOptionView.Add(overflow1);
            var overflow2 = NewButton("Overflow 2");
            overflowOptionView.Add(overflow2);
            var overflow3 = NewButton("Overflow 3");
            overflowOptionView.Add(overflow3);
            var overflow4 = NewButton("Overflow 4");
            overflowOptionView.Add(overflow4);
            var overflow5 = NewButton("Overflow 5");
            overflowOptionView.Add(overflow5);
            var overflow6 = NewButton("Overflow 6");
            overflowOptionView.Add(overflow6);
            var overflow7 = NewButton("Overflow 7");
            overflowOptionView.Add(overflow7);

            view.Add(description);
            view.Add(properties);
#endregion

            // OVERFLOW OPTION TEST CODE
            overflow1.Clicked += (s, e) =>
            {
                description.Text = desc[0];
                ResetText(label);

                // Overflow option 1
                label.Ellipsis = true;
                // Overflow option 1

                SetProperties(properties, label);
            };

            overflow2.Clicked += (s, e) =>
            {
                description.Text = desc[1];
                ResetText(label);

                // Overflow option 2
                label.Ellipsis = true;
                label.SetTextFit(new Tizen.NUI.Text.TextFit()
                {
                    Enable = true,
                    MinSize = 12.0f,
                    MaxSize = 32.0f,
                    StepSize = 4.0f,
                    FontSizeType = FontSizeType.PixelSize
                });
                // Overflow option 2

                SetProperties(properties, label);
            };

            overflow3.Clicked += (s, e) =>
            {
                description.Text = desc[2];
                ResetText(label);

                // Overflow option 3
                label.WidthSpecification = LayoutParamPolicies.WrapContent;
                // Overflow option 3

                SetProperties(properties, label);
            };

            overflow4.Clicked += (s, e) =>
            {
                description.Text = desc[3];
                ResetText(label);

                // Overflow option 4
                label.Ellipsis = true;
                label.FocusGained += OnFocusGained;
                label.FocusLost += OnFocusLost;
                // Overflow option 4


                SetProperties(properties, label);
            };

            overflow5.Clicked += (s, e) =>
            {
                description.Text = desc[4];
                ResetText(label);

                // Overflow option 5
                label.Ellipsis = true;
                label.EllipsisMode = EllipsisMode.AutoScroll;
                // Overflow option 5

                SetProperties(properties, label);
            };

            overflow6.Clicked += (s, e) =>
            {
                description.Text = desc[5];
                ResetText(label);

                // Overflow option 6
                label.WidthSpecification = LayoutParamPolicies.MatchParent;
                label.Ellipsis = true;
                label.EllipsisMode = EllipsisMode.AutoScroll;
                label.SetTextFit(new Tizen.NUI.Text.TextFit()
                {
                    Enable = true,
                    MinSize = 14.0f,
                    MaxSize = 32.0f,
                    StepSize = 4.0f,
                    FontSizeType = FontSizeType.PixelSize
                });
                // Overflow option 6

                SetProperties(properties, label);
            };

            overflow7.Clicked += (s, e) =>
            {
                description.Text = desc[6];
                ResetText(label);

                // Overflow option 7
                label.WidthSpecification = LayoutParamPolicies.WrapContent;
                label.MaximumSize.Width = 480;
                label.Ellipsis = true;
                label.EllipsisMode = EllipsisMode.AutoScroll;
                // Overflow option 7

                SetProperties(properties, label);
            };
            // OVERFLOW OPTION TEST CODE END

#region TEST
            btnShort.Clicked += (s, e) =>
            {
                label.Text = shortText;
            };
            
            btnLong.Clicked += (s, e) =>
            {
                label.Text = longText;
            };

            btnSingle.Clicked += (s, e) =>
            {
                label.MultiLine = false;
            };

            btnMulti.Clicked += (s, e) =>
            {
                label.MultiLine = true;
            };

            btnSync.Clicked += (s, e) =>
            {
                label.RenderMode = TextRenderMode.Sync;
            };

            btnAsync.Clicked += (s, e) =>
            {
                label.RenderMode = TextRenderMode.AsyncAuto;
            };
#endregion
        }

        // Overflow option 4
        public void OnFocusGained(object sender, EventArgs e)
        {  
            (sender as TextLabel).EllipsisMode = EllipsisMode.AutoScroll;
        }  

        public void OnFocusLost(object sender, EventArgs e)
        {  
            (sender as TextLabel).EllipsisMode = EllipsisMode.Truncate;
        }
        // Overflow option 4


        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                WidthSpecification = LABEL_WIDTH,
                HeightSpecification = 50,
                PixelSize = 30.0f,
                BackgroundColor = Color.White,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Extents(10, 10, 10, 10),
                Focusable = true,
                FocusableInTouch = true,
                FontFamily = FONT_FAMILY,
            };
            return label;
        }

        public TextLabel NewDescription(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                PixelSize = 20.0f,
                BackgroundColor = new Color(0.99f, 0.99f, 0.99f, 1.0f),
                MinLineSize = 30.0f,
                VerticalLineAlignment = VerticalLineAlignment.Center,
                Padding = new Extents(10, 10, 10, 10),
                FontFamily = FONT_FAMILY,
            };
            return label;
        }

        public void ResetText(TextLabel label)
        {
            label.Text = label.Text;
            label.WidthSpecification = LABEL_WIDTH;
            label.MaximumSize.Width = int.MaxValue;
            label.Ellipsis = false;
            label.EllipsisMode = EllipsisMode.Truncate;
            label.SetTextFit(new Tizen.NUI.Text.TextFit(){Enable = false});
            label.FocusGained -= OnFocusGained;
            label.FocusLost -= OnFocusLost;
        }

        public void SetProperties(TextLabel properties, TextLabel label)
        {
            string text = $"<b>Text Properties</b>\n" +
                          $"<background color='#dddddd'>WidthSpecification</background> {GetWidthSpecification(label.WidthSpecification)}\n" +
                          $"<background color='#dddddd'>MaximumSize.Width</background> {label.MaximumSize.Width}\n" +
                          $"<background color='#dddddd'>Ellipsis</background> {label.Ellipsis}\n" +
                          $"<background color='#dddddd'>EllipsisMode</background> {label.EllipsisMode}\n" +
                          $"<background color='#dddddd'>TextFit.Enable</background> {label.GetTextFit().Enable}";

            properties.Text = text;
        }

        public string GetWidthSpecification(int widthSpecification)
        {
            string width = "";
            switch (widthSpecification)
            {
                case LayoutParamPolicies.MatchParent:
                width += "MatchParent";
                break;
                case LayoutParamPolicies.WrapContent:
                width += "WrapContent";
                break;
                default:
                width += widthSpecification;
                break;
            }
            return width;
        }

        public View NewView()
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            return view;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 40,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                Focusable = true,
                FocusableInTouch = true,
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
