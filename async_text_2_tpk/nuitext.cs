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
        int numberOfCharacters = 0;
        int colorIndex = 0;
        Color[] colors = new Color[]{Color.Black, Color.Brown, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.DarkBlue, Color.Purple};
        List<TextLabel> labels = new List<TextLabel>();

        string[] imageUrls = new string[]{
            "/images/colorful.jpg",
            "/images/leaves.jpg",
            "/images/sky.jpg",
            "/images/wave.gif",
            "/images/ocean.gif"
        };

        int cutoutIndex = 0;
        string[] cutoutTexts = new string[]{ "COLORFUL", "Leaf", "SUNSET", "WAVE", "OCEAN" };

        string[] cutoutFamilys = new string[]{ "Gotham", "Morganite", "Montserrat", "MachineatDemo", "Montserrat ExtraBold" };
        Color[] cutoutBGColors = new Color[]{ Color.Black, Color.White, new Color(0.0f, 0.0f, 0.0f, 0.5f), new Color(0.0f, 0.0f, 0.0f, 0.8f), new Color(1.0f, 1.0f, 1.0f, 0.8f)};

        const int labelWidth = 100;
        const int labelHeight = 50;

        // PC
        const int windowWidth = 2400;
        const int windowHeight = 1280;
        const float BUTTON_POINT_SIZE = 10.0f;
        const int BUTTON_WIDTH = labelWidth - 1;
        const int TIMER_INTERVAL = 2000;
        const string longText = "🌟 Lorem ipsum dolor sit amet, 🌟consectetur adipiscing elit. 🌟Sed non risus. Suspendisse lectus tortor, 🌟dignissim sit amet, adipiscing nec, 🌟ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Vestibulum volutpat pretium libero. Vivamus at augue. In hac habitasse platea dictumst. Pellentesque eu metus. Etiam vitae tortor. Morbi vestibulum volutpat enim. Fusce vel dui. Sed vulputate odio vel purus. Aliquam at lorem." +
        "\n In hac habitasse platea dictumst. Integer eu lacus. Nullam lobortis quam a nulla. Nam imperdiet. In hac habitasse platea dictumst. Nunc commodo leo ac massa. Praesent mattis aliquet aliquam. Curabitur facilisis gravida arcu. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In hac habitasse platea dictumst. Fusce tempor tellus blandit magna. " +
        "\n Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Vestibulum volutpat pretium libero. Vivamus at augue. In hac habitasse platea dictumst. Pellentesque eu metus. Etiam vitae tortor. Morbi vestibulum volutpat enim. Fusce vel dui. Sed vulputate odio vel purus. Aliquam at lorem." +
        "\n In hac habitasse platea dictumst. Integer eu lacus. Nullam lobortis quam a nulla. Nam imperdiet. In hac habitasse platea dictumst. Nunc commodo leo ac massa. Praesent mattis aliquet aliquam. Curabitur facilisis gravida arcu. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In hac habitasse platea dictumst. Fusce tempor tellus blandit magna. " +
        "🌟 Lorem ipsum dolor sit amet, 🌟consectetur adipiscing elit. 🌟Sed non risus. Suspendisse lectus tortor, 🌟dignissim sit amet, adipiscing nec, 🌟ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Vestibulum volutpat pretium libero. Vivamus at augue. In hac habitasse platea dictumst. Pellentesque eu metus. Etiam vitae tortor. Morbi vestibulum volutpat enim. Fusce vel dui. Sed vulputate odio vel purus. Aliquam at lorem." +
        "\n In hac habitasse platea dictumst. Integer eu lacus. Nullam lobortis quam a nulla. Nam imperdiet. In hac habitasse platea dictumst. Nunc commodo leo ac massa. Praesent mattis aliquet aliquam. Curabitur facilisis gravida arcu. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In hac habitasse platea dictumst. Fusce tempor tellus blandit magna. " +
        "\n Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Vestibulum volutpat pretium libero. Vivamus at augue. In hac habitasse platea dictumst. Pellentesque eu metus. Etiam vitae tortor. Morbi vestibulum volutpat enim. Fusce vel dui. Sed vulputate odio vel purus. Aliquam at lorem." +
        "\n In hac habitasse platea dictumst. Integer eu lacus. Nullam lobortis quam a nulla. Nam imperdiet. In hac habitasse platea dictumst. Nunc commodo leo ac massa. Praesent mattis aliquet aliquam. Curabitur facilisis gravida arcu. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In hac habitasse platea dictumst. Fusce tempor tellus blandit magna. " +
        "🌟";

        // TV
        //const int windowWidth = 1920;
        //const int windowHeight = 1080;
        //const float BUTTON_POINT_SIZE = 8.0f;
        //const int BUTTON_WIDTH = labelWidth - 18;
        //const int TIMER_INTERVAL = 3000;
        //const string longText = "🌟 Lorem ipsum dolor sit amet, 🌟consectetur adipiscing elit. 🌟Sed non risus. Suspendisse lectus tortor, 🌟dignissim sit amet, adipiscing nec, 🌟ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Vestibulum volutpat pretium libero. Vivamus at augue. In hac habitasse platea dictumst."\n🌟";

        public TextRenderMode RENDER_MODE = TextRenderMode.AsyncAuto;
        public Timer TIMER;
        public int TIMER_INDEX = -1;

        ScrollableBase SCROLL;
        View MAIN_VIEW;
        TextLabel titleLabel;
        string TITLE;
        bool SCENE_ON = true;

        string shortText;
        string shortRtlText;
        string markupText;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(windowWidth, windowHeight));
        }

        public void GenerateUI(Size windowSize)
        {
            Window window = Window.Instance;
            window.WindowSize = windowSize;

            TIMER = new Timer(TIMER_INTERVAL);
            TIMER.Tick += (s, e) =>
            {
                TIMER_INDEX ++;
                if (TIMER_INDEX > 9)
                    TIMER_INDEX = 0;
                
                ManualRenderTest(TIMER_INDEX);
                return true;
            };

            Window.Instance.KeyEvent += OnKeyEvent;

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            FontClient.Instance.AddCustomFontDirectory(resourcePath + "fonts");

            MAIN_VIEW = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            window.Add(MAIN_VIEW);

            shortText = "🌟 Hello!, world!";
            shortRtlText = "مرحبا بمرحبا مرحبا مرحبا مرحبا مرحبا مرحبا مرحبا مرحبا العالم Hello ... good day to die.";
            markupText = "<color value='blue'><u color='red'>Hello</u></color>, <s color='magenta'><b>world</b></s>";

            titleLabel = NewTextLabel("", windowWidth, labelHeight - 1);
            titleLabel.PointSize = 14.0f;

            MAIN_VIEW.Add(titleLabel);
            MAIN_VIEW.Add(NewColorView(Color.Black, windowWidth, 1));

            var optionView = NewView(windowWidth, labelHeight, true);
            MAIN_VIEW.Add(optionView);

            var optionLabel = NewTextLabel("all options", labelWidth - 1, labelHeight - 1);
            optionLabel.PointSize = 12.0f;
            optionLabel.TextColor = Color.Black;
            optionView.Add(optionLabel);

            var buttonAddText = NewButton("Add Text");
            optionView.Add(buttonAddText);

            var buttonManualLabelAdd = NewButton("Add Manual");
            optionView.Add(buttonManualLabelAdd);

            var buttonDispose = NewButton("Dispose All");
            optionView.Add(buttonDispose);

            var buttonSceneOn = NewButton("Scene On");
            optionView.Add(buttonSceneOn);

            var buttonSceneOff = NewButton("Scene Off");
            optionView.Add(buttonSceneOff);

            var buttonEmpty = NewButton("Empty Text");
            //optionView.Add(buttonEmpty);

            var buttonText = NewButton("Set Text");
            //optionView.Add(buttonText);

            var buttonScrollStart = NewButton("scroll start");
            optionView.Add(buttonScrollStart);

            var buttonScrollStop = NewButton("scroll stop");
            optionView.Add(buttonScrollStop);

            var buttonCutoutStart = NewButton("cutout start");
            //optionView.Add(buttonCutoutStart);

            var buttonCutoutStop = NewButton("cutout stop");
            //optionView.Add(buttonCutoutStop);

            var buttonSync = NewButton("SYNC");
            optionView.Add(buttonSync);

            var buttonAutoAsync = NewButton("AUTO");
            optionView.Add(buttonAutoAsync);

            var buttonManualAsync = NewButton("MANUAL");
            optionView.Add(buttonManualAsync);

            var buttonNatural = NewButton("Natural Size");
            optionView.Add(buttonNatural);

            var buttonHeightForWidth = NewButton("Height for width");
            optionView.Add(buttonHeightForWidth);

            var buttonSizeComputation = NewButton("Size Compute");
            optionView.Add(buttonSizeComputation);

            var buttonFixed = NewButton("FIXED");
            optionView.Add(buttonFixed);

            var buttonFixed3 = NewButton("FIXED/1.5");
            optionView.Add(buttonFixed3);

            var buttonFixed2 = NewButton("FIXED/2");
            optionView.Add(buttonFixed2);

            var buttonFixedWidth = NewButton("FIXED WIDTH");
            optionView.Add(buttonFixedWidth);

            var buttonFixedWidth2 = NewButton("FIXED WIDTH/2");
            optionView.Add(buttonFixedWidth2);

            var buttonConstraint = NewButton("CONSTRAINT");
            optionView.Add(buttonConstraint);

            var buttonConstraint2 = NewButton("CONSTRAINT/2");
            optionView.Add(buttonConstraint2);

            var buttonSize = NewButton("SIZE");
            optionView.Add(buttonSize);

            var buttonSize2 = NewButton("SIZE/2");
            optionView.Add(buttonSize2);

            SCROLL = new ScrollableBase()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            MAIN_VIEW.Add(SCROLL);

            int num = 0;

            buttonAddText.Clicked += (s, e) =>
            {
                AddText(TextRenderMode.AsyncAuto);
            };

            buttonManualLabelAdd.Clicked += (s, e) =>
            {
                AddText(TextRenderMode.AsyncManual);
            };

            buttonDispose.Clicked += (s, e) =>
            {
                DisposeAll();
            };

            buttonSceneOn.Clicked += (s, e) =>
            {
                if (!SCENE_ON)
                {
                    MAIN_VIEW.Add(SCROLL);
                    SCENE_ON = true;
                }
            };

            buttonSceneOff.Clicked += (s, e) =>
            {
                if (SCENE_ON)
                {
                    MAIN_VIEW.Remove(SCROLL);
                    SCENE_ON = false;
                }
            };

            buttonEmpty.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].Text = "";
                }
            };

            buttonText.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].Text = longText;
                }
            };

            buttonScrollStart.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    if(labels[i].Cutout || i % (windowWidth / labelWidth) == 0)
                        continue;

                    labels[i].MultiLine = false;
                    labels[i].EnableAutoScroll = true;
                }
            };

            buttonScrollStop.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].AutoScrollStopMode = AutoScrollStopMode.Immediate;
                    labels[i].EnableAutoScroll = false;

                    if(i % 2 == 0)
                    {
                        labels[i].MultiLine = true;
                    }
                }
            };

            buttonCutoutStart.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].Cutout = true;
                }
            };

            buttonCutoutStop.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].Cutout = false;
                }
            };

            buttonSync.Clicked += (s, e) =>
            {
                RENDER_MODE = TextRenderMode.Sync;
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RenderMode = RENDER_MODE;
                }
            };

            buttonAutoAsync.Clicked += (s, e) =>
            {
                RENDER_MODE = TextRenderMode.AsyncAuto;
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RenderMode = RENDER_MODE;
                }
            };

            buttonManualAsync.Clicked += (s, e) =>
            {
                RENDER_MODE = TextRenderMode.AsyncManual;
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RenderMode = RENDER_MODE;
                }
            };

            buttonNatural.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncNaturalSize();
                }
            };

            buttonHeightForWidth.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncHeightForWidth(labelWidth - 1);
                }
            };

            buttonSizeComputation.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncNaturalSize();
                    labels[i].RequestAsyncHeightForWidth(labelWidth / 2);
                }
            };

            buttonFixed.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedSize(labelWidth - 1, labelHeight - 1);
                }
            };

            buttonFixed2.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedSize(labelWidth / 2, labelHeight / 2);
                }
            };

            buttonFixed3.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedSize(labelWidth / 1.5f, labelHeight / 1.5f);
                }
            };

            buttonFixedWidth.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedWidth(labelWidth - 1, labelHeight - 1);
                }
            };

            buttonFixedWidth2.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedWidth(labelWidth / 2, labelHeight / 2);
                }
            };

            buttonConstraint.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithConstraint(labelWidth - 1, labelHeight - 1);
                }
            };

            buttonConstraint2.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithConstraint(labelWidth / 2, labelHeight / 2);
                }
            };

            buttonSize.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].WidthSpecification = labelWidth - 1;
                    labels[i].HeightSpecification = labelHeight - 1;
                }
            };

            buttonSize2.Clicked += (s, e) =>
            {
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].WidthSpecification = labelWidth / 2;
                    labels[i].HeightSpecification = labelHeight / 2;
                }
            };
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                return;                    
            }

            if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "1")
            {
                if (TIMER.IsRunning())
                {
                    titleLabel.Text = TITLE;
                    TIMER.Stop();
                }
                else
                {
                    TITLE = titleLabel.Text;
                    TIMER.Start();
                }
            }
        }

        public void OnAsyncTextRendered(object sender, AsyncTextRenderedEventArgs e)
        {
            TextLabel label = sender as TextLabel;
            if (label.ManualRendered)
            {
                label.WidthSpecification = (int)e.Width;
                label.HeightSpecification = (int)e.Height;
            }
            Tizen.Log.Error(TAG, $"Manual : {label.ManualRendered}, Rendered Size : {e.Width}, {e.Height}, Line count : {label.AsyncLineCount}\n");
        }

        public void OnAsyncNaturalSizeComputed(object sender, AsyncTextSizeComputedEventArgs e)
        {
            var label = sender as TextLabel;
            Tizen.Log.Error(TAG, $"Computed Natural size : {e.Width}, {e.Height}, Line count : {label.AsyncLineCount}\n");
        }

        public void OnAsyncHeightForWidthComputed(object sender, AsyncTextSizeComputedEventArgs e)
        {
            var label = sender as TextLabel;
            Tizen.Log.Error(TAG, $"Computed Height for width : {e.Width}, {e.Height}, Line count : {label.AsyncLineCount}\n");
        }

        public void ManualRenderTest(int index)
        {
            if (labels.Count == 0)
            return;

            switch(index)
            {
                case 0:
                titleLabel.Text = $"Manual render test : FixedSize, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedSize(labelWidth - 1, labelHeight - 1);
                }
                break;

                case 1:
                titleLabel.Text = $"Manual render test : FixedSize / 2, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedSize(labelWidth / 2, labelHeight / 2);
                }
                break;

                case 2:
                titleLabel.Text = $"Manual render test : FixedSize / 1.5, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedSize(labelWidth / 1.5f, labelHeight / 1.5f);
                }
                break;

                case 3:
                titleLabel.Text = $"Manual render test : FixedWidth, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedWidth(labelWidth - 1, labelHeight - 1);
                }
                break;

                case 4:
                titleLabel.Text = $"Manual render test : FixedWidth / 2, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithFixedWidth(labelWidth / 2, labelHeight / 2);
                }
                break;

                case 5:
                titleLabel.Text = $"Manual render test : Constraint, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithConstraint(labelWidth - 1, labelHeight - 1);
                }
                break;

                case 6:
                titleLabel.Text = $"Manual render test : Constraint / 2, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RequestAsyncRenderWithConstraint(labelWidth / 2, labelHeight / 2);
                }
                break;

                case 7:
                titleLabel.Text = $"Manual render test : Dispose All, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                DisposeAll();
                bool titleUpdate = false;
                AddText(RENDER_MODE, titleUpdate);
                break;

                case 8:
                titleLabel.Text = $"Auto render test : Size / 2, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].WidthSpecification = labelWidth / 2;
                    labels[i].HeightSpecification = labelHeight / 2;
                }
                break;

                case 9:
                titleLabel.Text = $"Auto render test : Size / 1.5, {labels[0].RenderMode}";
                titleLabel.RequestAsyncRenderWithFixedSize(titleLabel.Size.Width, titleLabel.Size.Height);
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].WidthSpecification = (int)(labelWidth / 1.5f);
                    labels[i].HeightSpecification = (int)(labelHeight / 1.5f);
                }
                break;

                default:
                break;
            }
        }

        public void DisposeAll()
        {
            int count = (int)SCROLL.GetChildCount();
            for (int i = 0 ; i < count ; i ++)
            {
                var item = SCROLL.GetChildAt(0);
                SCROLL.Remove(item);
            }
            MAIN_VIEW.Remove(SCROLL);

            for (int i = 0 ; i < labels.Count ; i ++)
            {
                labels[i].Dispose();
            }
            labels.Clear();

            SCROLL.Dispose();
            SCROLL = new ScrollableBase()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            MAIN_VIEW.Add(SCROLL);

            numberOfCharacters = 0;
            string formattedNumber = String.Format("{0:#,##0}", numberOfCharacters);  
            titleLabel.Text = "Number of characters : " + formattedNumber + ", labels : " + labels.Count;
        }

        public void AddText(TextRenderMode renderMode, bool titleUpdate = true)
        {
            for (int i = 0 ; i < 17 ; i ++)
            {
                var horView = NewView(windowWidth, labelHeight, true);
                SCROLL.Add(horView);

                for (int j = 0 ; j < (windowWidth / labelWidth) ; j ++)
                {
                    var label = NewTextLabel(longText, labelWidth - 1, labelHeight - 1);
                    if (renderMode == TextRenderMode.AsyncManual)
                    {
                        label.WidthSpecification = 50;
                        label.HeightSpecification = 25;
                        label.RenderMode = renderMode;
                    }

                    horView.Add(label);
                    labels.Add(label);

                    int index = i % 17;
                    //index = 1;

                    switch (index)
                    {
                        case 0:
                        if (!SetTitle(label, j, "Text Fit"))
                        {
                            var textFit = new Tizen.NUI.Text.TextFit();
                            textFit.Enable = true;
                            textFit.MinSize = 4.0f;
                            label.SetTextFit(textFit);
                        }
                        break;

                        case 1:
                        if (!SetTitle(label, j, "Auto Scroll"))
                        {
                            int colorItems = colors.Length;
                            if (j < colorItems + 1)
                            {
                                Color textColor = label.TextColor;
                                Color bgColor = new Color(1.0f - textColor.R, 1.0f - textColor.G, 1.0f - textColor.B, 1.0f);
                                label.BackgroundColor = bgColor;
                            }
                            else if (j < (colorItems) * 2 + 1)
                            {
                                Color textColor = label.TextColor;
                                Color color = new Color(1.0f - textColor.R, 1.0f - textColor.G, 1.0f - textColor.B, 1.0f);
                                label.TextColor = color;
                                label.BackgroundColor = textColor;
                            }
                            else
                            {
                                label.BackgroundColor = Color.White;
                            }

                            label.MultiLine = false;
                            label.EnableAutoScroll = true;
                            label.AutoScrollGap = 40;
                            label.AutoScrollLoopCount = 2;
                        }
                        break;

                        case 2:
                        if (!SetTitle(label, j, "Font Family"))
                        {
                            label.FontFamily = "Lobster";
                        }
                        break;

                        case 3:
                        if (!SetTitle(label, j, "Font Style"))
                        {
                            var fontStyle = new Tizen.NUI.Text.FontStyle();
                            fontStyle.Width = FontWidthType.Condensed;
                            fontStyle.Weight = FontWeightType.Bold;
                            fontStyle.Slant = FontSlantType.Italic;
                            label.SetFontStyle(fontStyle);
                        }
                        break;

                        case 4:
                        if (!SetTitle(label, j, "Point Size"))
                        {
                            label.PointSize = 14;
                        }
                        break;

                        case 5:
                        if (!SetTitle(label, j, "Horizontal Alignment"))
                        {
                            label.Text = "Center";
                            label.HorizontalAlignment = HorizontalAlignment.Center;
                        }
                        break;

                        case 6:
                        if (!SetTitle(label, j, "Vertical Alignment"))
                        {
                            label.Text = "Bottom";
                            label.VerticalAlignment = VerticalAlignment.Bottom;
                        }
                        break;

                        case 7:
                        if (!SetTitle(label, j, "Enable Markup"))
                        {
                            label.Text = markupText;
                            label.PointSize = 14;
                            label.EnableMarkup = true;
                        }
                        break;

                        case 8:
                        if (!SetTitle(label, j, "Underline"))
                        {
                            var underline = new Tizen.NUI.Text.Underline();
                            underline.Enable = true;
                            underline.Color = new Color("#3498DB");
                            underline.Height = 1.0f;
                            label.SetUnderline(underline);
                        }
                        break;

                        case 9:
                        if (!SetTitle(label, j, "Strikethrough"))
                        {
                            var strikethrough = new Tizen.NUI.Text.Strikethrough();
                            strikethrough.Enable = true;
                            strikethrough.Color = new Color("#EB4034");
                            strikethrough.Height = 1.0f;
                            label.SetStrikethrough(strikethrough);
                        }
                        break;

                        case 10:
                        if (!SetTitle(label, j, "Shadow"))
                        {
                            var shadow = new Tizen.NUI.Text.Shadow();
                            shadow.BlurRadius = 5.0f;
                            shadow.Color = new Color("#EEFF00");
                            shadow.Offset = new Vector2(2, 2);
                            label.SetShadow(shadow);
                        }
                        break;

                        case 11:
                        if (!SetTitle(label, j, "Outline"))
                        {
                            var outline = new PropertyMap();
                            outline.Add("width", new PropertyValue(1.0f));
                            outline.Add("color", new PropertyValue(new Color("#45B39D")));
                            outline.Add("offset", new PropertyValue(new Vector2(-1.0f, -1.0f)));
                            outline.Add("blurRadius", new PropertyValue(1.0f));
                            label.Outline = outline;
                        }
                        break;

                        case 12:
                        if (!SetTitle(label, j, "Hyphenation"))
                        {
                            label.Text = "Photography hyphenation";
                            label.PointSize = 15.0f;
                            label.LineWrapMode = LineWrapMode.Hyphenation;
                            label.MultiLine = true;
                        }
                        break;

                        case 13:
                        if (!SetTitle(label, j, "Font Size Scale"))
                        {
                            label.FontSizeScale = 1.4f;
                        }
                        break;

                        case 14:
                        if (!SetTitle(label, j, "Ellipsis Position"))
                        {
                            label.EllipsisPosition = EllipsisPosition.Start;
                        }
                        break;

                        case 15:
                        if (!SetTitle(label, j, "Text"))
                        {
                            label.Text = longText;
                        }
                        break;

                        case 16:
                        if (!SetTitle(label, j, "Cutout"))
                        {
                            horView.Add(NewCutoutView(label));
                        }
                        break;

                        default:
                        break;
                    }

                    numberOfCharacters += label.Text.Length;
                }
            }

            if (titleUpdate)
            {
                string formattedNumber = String.Format("{0:#,##0}", numberOfCharacters);  
                titleLabel.Text = "Number of characters : " + formattedNumber + ", labels : " + labels.Count;
            }
        }

        public bool SetTitle(TextLabel label, int index, string title)
        {
            if (index != 0)
            {
                return false;
            }

            var textFit = new Tizen.NUI.Text.TextFit();
            textFit.Enable = true;
            textFit.MinSize = 1.0f;

            label.Text = title;
            label.SetTextFit(textFit);
            return true;
        }

        public View NewCutoutView(TextLabel label)
        {
            var view = new View
            {
                Layout = new AbsoluteLayout(){},
                WidthSpecification = labelWidth - 1,
                HeightSpecification = labelHeight - 1,
            };

            int urlIndex = cutoutIndex++ % 5;

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            var image = new ImageView
            {
                ResourceUrl = resourcePath + imageUrls[urlIndex],
                DesiredWidth = labelWidth - 1,
                DesiredHeight = labelHeight - 1,
                FittingMode = FittingModeType.Fill,
            };
            view.Add(image);

            label.Text = cutoutTexts[urlIndex];
            label.FontFamily = cutoutFamilys[urlIndex];
            label.BackgroundColor = cutoutBGColors[urlIndex];
            label.Cutout = true;
            label.MultiLine = false;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.TextColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            view.Add(label);

            var textFit = new Tizen.NUI.Text.TextFit();
            textFit.Enable = true;
            textFit.MinSize = 1.0f;
            label.SetTextFit(textFit);

            var shadow = new PropertyMap();
            shadow.Add("color", new PropertyValue(new Color(0.0f, 0.0f, 0.0f, 0.5f)));
            shadow.Add("offset", new PropertyValue(new Vector2(2, 2)));
            shadow.Add("blurRadius", new PropertyValue(3));
            label.Shadow = shadow;

            label.Relayout += (s ,e) =>
            {
                image.WidthSpecification = label.WidthSpecification;
                image.HeightSpecification = label.HeightSpecification;
                view.WidthSpecification = label.WidthSpecification;
                view.HeightSpecification = label.HeightSpecification;
            };

            return view;
        }

        public View NewView(int width, int height, bool horizontal)
        {
            View view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = horizontal ? LinearLayout.Orientation.Horizontal : LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = width,
                HeightSpecification = height,
            };
            return view;
        }

        public View NewColorView(Color color, int width, int height)
        {
            View view = new View()
            {
                WidthSpecification = width,
                HeightSpecification = height,
                Color = color,
            };
            return view;
        }

        public TextLabel NewTextLabel(string text, int width, int height)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "Ubuntu Mono",
                MultiLine = true,
                WidthSpecification = width,
                HeightSpecification = height,
                PointSize = 10.0f,
                BackgroundColor = Color.White,
                VerticalAlignment = VerticalAlignment.Center,
                RemoveFrontInset = false,
                RemoveBackInset = false,
                AutoScrollLoopCount = 0,
                RenderMode = RENDER_MODE,
                Padding = new Extents(4, 4, 2, 2),
            };

            label.AsyncTextRendered += OnAsyncTextRendered;
            label.AsyncNaturalSizeComputed += OnAsyncNaturalSizeComputed;
            label.AsyncHeightForWidthComputed += OnAsyncHeightForWidthComputed;


            colorIndex = colorIndex < colors.Length ? colorIndex : 0;
            label.TextColor = colors[colorIndex++];

            return label;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                PointSize = BUTTON_POINT_SIZE,
                WidthSpecification = BUTTON_WIDTH,
                HeightSpecification = labelHeight - 1,
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
