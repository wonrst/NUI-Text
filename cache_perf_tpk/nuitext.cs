using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;
using System.Diagnostics;  

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";
        List<TextLabel> labels = new List<TextLabel>();
        List<ScrollableBase> scrolls = new List<ScrollableBase>();

        int windowWidth = 1920;
        int windowHeight = 1080;
        int scrollCount = 10;
        int labelCount = 50;
        int fixedHeight = 100;

        int testCount = 0;

        Color[] colors = new Color[]{Color.Black, Color.Gray, Color.SkyBlue, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.DarkBlue, Color.Purple};

        // string longText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham. t is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like). There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.The standard Lorem Ipsum passage, used since the 1500s Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Section 1.10.32 of de Finibus Bonorum et Malorum, written by Cicero in 45 BC Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? 1914 translation by H. Rackham But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure? Section 1.10.33 of de Finibus Bonorum et Malorum, written by Cicero in 45 BC At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.";
        string longText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum. Contrary to popular belief, Lorem Ipsum is not simply random text.";

        Stopwatch STOP_WATCH = new Stopwatch();

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

            Window.Instance.KeyEvent += OnKeyEvent;

            View mainView = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            window.Add(mainView);

            View horView = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
            };
            mainView.Add(horView);

            var buttonFixedWidth = NewButton("Render");
            horView.Add(buttonFixedWidth);

            var buttonSize = NewButton("Size Variation");
            horView.Add(buttonSize);

            var buttonClear = NewButton("Clear");
            horView.Add(buttonClear);

            View view = new View()
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            mainView.Add(view);


            for (int i = 0 ; i < scrollCount ; i ++)
            {
                var scroll = new ScrollableBase()
                {
                    Layout = new LinearLayout
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                    },
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    BackgroundColor = Color.White,
                };
                view.Add(scroll);
                scrolls.Add(scroll);
            }

            buttonFixedWidth.TouchEvent += (s, e) =>
            {
                if (e == null || e.Touch.GetState(0) != PointStateType.Up) return true;

                if (STOP_WATCH.IsRunning)
                {
                    STOP_WATCH.Stop();
                }
                testCount = 0;
                STOP_WATCH = new Stopwatch();
                STOP_WATCH.Start();

                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RenderMode = TextRenderMode.AsyncAuto;
                    testCount ++;
                    labels[i].RequestAsyncRenderWithFixedWidth(windowWidth / scrollCount, fixedHeight);
                }

                return true;
            };

            buttonSize.TouchEvent += (s, e) =>
            {
                if (e == null || e.Touch.GetState(0) != PointStateType.Up) return true;

                if (STOP_WATCH.IsRunning)
                {
                    STOP_WATCH.Stop();
                }
                testCount = 0;
                STOP_WATCH = new Stopwatch();
                STOP_WATCH.Start();

                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].RenderMode = TextRenderMode.AsyncAuto;
                    labels[i].PixelSize = 10.0f * (i % 5 + 1);
                    testCount ++;
                    labels[i].RequestAsyncRenderWithFixedWidth(windowWidth / scrollCount, fixedHeight);
                }

                return true;
            };

            buttonClear.TouchEvent += (s, e) =>
            {
                if (e == null || e.Touch.GetState(0) != PointStateType.Up) return true;

                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].Dispose();
                }
                labels.Clear();

                for (int j = 0 ; j < scrollCount ; j ++)
                {
                    for (int i = 0 ; i < labelCount ; i ++)
                    {
                        scrolls[j].Add(NewTextLabel(longText, colors[i % colors.Length]));
                    }
                }

                testCount = 0;

                return true;
            };

            for (int s = 0 ; s < scrollCount ; s ++)
            {
                for (int i = 0 ; i < labelCount ; i ++)
                {
                    scrolls[s].Add(NewTextLabel(longText, colors[i % colors.Length]));
                }
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
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    labels[i].Dispose();
                }
                labels.Clear();

                for (int j = 0 ; j < scrollCount ; j ++)
                {
                    for (int i = 0 ; i < labelCount ; i ++)
                    {
                        scrolls[j].Add(NewTextLabel(longText, colors[i % colors.Length]));
                    }
                }
            }

            if (e.Key.KeyPressedName == "1")
            {
                var rand = new Random();
                for (int i = 0 ; i < labels.Count ; i ++)
                {
                    int randomMaxHeight = rand.Next(100, 500);
                    labels[i].RequestAsyncRenderWithFixedWidth(windowWidth / scrollCount, randomMaxHeight);
                }
            }
        }

        public TextLabel NewTextLabel(string text, Color backgroundColor)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "SamsungOneUI_500",
                MultiLine = true,
                WidthSpecification = 0,
                HeightSpecification = 0,
                PixelSize = 10,
                BackgroundColor = backgroundColor,
                RenderMode = TextRenderMode.AsyncAuto,
            };

            float BRIGHTNESS_THRESHOLD = 0.179f;
            float CONSTANT_R           = 0.2126f;
            float CONSTANT_G           = 0.7152f;
            float CONSTANT_B           = 0.0722f;

            float L         = CONSTANT_R * backgroundColor.R + CONSTANT_G * backgroundColor.G + CONSTANT_B * backgroundColor.B;
            Color textColor = L > BRIGHTNESS_THRESHOLD ? Color.Black : Color.White;
            label.TextColor = textColor;

            label.AsyncTextRendered += (s, e) =>
            {
                if(label.ManualRendered)
                {
                    label.WidthSpecification = (int)e.Width;
                    label.HeightSpecification = (int)e.Height;
                }

                testCount--;
                if(testCount == 0)
                {
                    STOP_WATCH.Stop();
                    Tizen.Log.Error(TAG, $"Asyc Rendered : {STOP_WATCH.ElapsedMilliseconds} ms \n");
                }
            };

            label.Relayout += (s, e) =>
            {
                for (int i = 0 ; i < scrollCount ; i ++)
                {
                    scrolls[i].ScrollTo(float.PositiveInfinity, true);
                }
                if(label.RenderMode == TextRenderMode.Sync)
                {
                    testCount--;
                    if(testCount == 0)
                    {
                        STOP_WATCH.Stop();
                        Tizen.Log.Error(TAG, $"Sync Rendered : {STOP_WATCH.ElapsedMilliseconds} ms \n");
                    }
                }
            };
            labels.Add(label);

            return label;
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
