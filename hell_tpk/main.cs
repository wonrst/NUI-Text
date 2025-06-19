using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using Tizen.NUI.MarkdownRenderer;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";
        const string simpleText = "## **Hello** *world*";

        public AutoTest autoTest;
        public LLMStreamSimulator streamSim;
        public MarkdownRenderer markdownRenderer;
        public MarkdownRenderer descriptionRenderer;

        public View view;
        public bool disposeMode = false;
        public bool asyncRendering = false;
        public float scale = 1.0f;

        protected override void OnCreate()
        {
            NUIApplication.IsUsingXaml = false;

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
            window.KeyEvent += OnKeyEvent;

            view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            window.Add(view);

            autoTest = new AutoTest(4000);
            streamSim = new LLMStreamSimulator(intervalMs: 1, chunkSize: 1);

            markdownRenderer = new MarkdownRenderer
            {
                WidthSpecification = 1200,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(markdownRenderer);


            // This view is used only for displaying test descriptions and is not directly related to the test logic itself.
            // If you want to measure memory usage or performance accurately,
            // do not create the description renderer (NewDescriptionRenderer).
            view.Add(NewDescriptionRenderer());


            // // For Style test
            // // Common
            // markdownRenderer.Style.Common.Indent = 40;
            // markdownRenderer.Style.Common.Padding = 10;
            // markdownRenderer.Style.Common.Margin = 10;

            // // Paragraph
            // markdownRenderer.Style.Paragraph.FontColor = "#000000FF";
            // markdownRenderer.Style.Paragraph.FontSize = 20.0f;
            // markdownRenderer.Style.Paragraph.FontFamily = "SamsungOneUI_400";
            // markdownRenderer.Style.Paragraph.LineHeight = 32.0f;
            // markdownRenderer.Style.Paragraph.StrikethroughThickness = 2;

            // // Heading
            // markdownRenderer.Style.Heading.FontSizeLevel1 = 28.0f;
            // markdownRenderer.Style.Heading.FontSizeLevel2 = 24.0f;
            // markdownRenderer.Style.Heading.FontSizeLevel3 = 20.0f;
            // markdownRenderer.Style.Heading.FontSizeLevel4 = 16.0f;
            // markdownRenderer.Style.Heading.FontSizeLevel5 = 12.0f;
            // markdownRenderer.Style.Heading.FontFamily = "SamsungOneUI_700";

            // // ThematicBreak
            // markdownRenderer.Style.ThematicBreak.Color = "#DFDFDFFF";
            // markdownRenderer.Style.ThematicBreak.Thickness = 1;
            // markdownRenderer.Style.ThematicBreak.Margin = 10;

            // // Quote
            // markdownRenderer.Style.Quote.FontColor = "#2F2F2FFF";
            // markdownRenderer.Style.Quote.BarColor = "#DFDFDFFF";
            // markdownRenderer.Style.Quote.BarWidth = 6;
            // markdownRenderer.Style.Quote.BarMargin = 10;
            // markdownRenderer.Style.Quote.Padding = 10;
            // markdownRenderer.Style.Quote.BarCornerRadius = 3.0f;

            // // Table
            // markdownRenderer.Style.Table.BackgroundColor = "#00000000";
            // markdownRenderer.Style.Table.BorderColor = "#000000FF";
            // markdownRenderer.Style.Table.BorderThickness = 1;
            // markdownRenderer.Style.Table.Padding = 10;
            // markdownRenderer.Style.Table.ItemPadding = 5;
            // markdownRenderer.Style.Table.CornerRadius = 12.0f;

            // // Code
            // markdownRenderer.Style.Code.FontFamily = "Ubuntu Mono"; // FIXME: Tizen devices do not have mono space font.
            // markdownRenderer.Style.Code.FontColor = "#121212FF";
            // markdownRenderer.Style.Code.BackgroundColor = "#CCCCCC33";
            // markdownRenderer.Style.Code.FontSize = 20.0f;
            // markdownRenderer.Style.Code.TitleFontFamily = "Ubuntu Mono"; // FIXME: Tizen devices do not have mono space font.
            // markdownRenderer.Style.Code.TitleFontColor = "#454545FF";
            // markdownRenderer.Style.Code.TitleBackgroundColor = "#CCCCCC55";
            // markdownRenderer.Style.Code.TitleFontSize = 16.0f;
            // markdownRenderer.Style.Code.Padding = 10;
            // markdownRenderer.Style.Code.CornerRadius = 12.0f;

            // markdownRenderer.Render(simpleText);
        }

        void StartStreamingSample(int index)
        {
            streamSim.Stop();
            string sample = TestMarkdowns.GetSample(index);
            var sb = new System.Text.StringBuilder();
            if (disposeMode)
            {
                view.Add(NewMarkdownRenderer());
            }
            else
            {
                markdownRenderer.Clear();
            }
            streamSim.Start(sample, (chunk, idx) =>
            {
                sb.Append(chunk);
                markdownRenderer.Render(sb.ToString());
            });
            UpdateDescription();
            Tizen.Log.Error(TAG, $"[AutoTest] RunningCount:{autoTest.RunningCount}, IsRunning:{autoTest.IsRunning}, DisposeMode:{disposeMode} AliveCount:{View.AliveCount}\n");
        }

        void StartStreamingPrev()
        {
            streamSim.Stop();
            string sample = TestMarkdowns.GetPrev();
            var sb = new System.Text.StringBuilder();
            if (disposeMode)
            {
                view.Add(NewMarkdownRenderer());
            }
            else
            {
                markdownRenderer.Clear();
            }
            streamSim.Start(sample, (chunk, idx) =>
            {
                sb.Append(chunk);
                markdownRenderer.Render(sb.ToString());
            });
        }

        void StartStreamingNext()
        {
            streamSim.Stop();
            string sample = TestMarkdowns.GetNext();
            var sb = new System.Text.StringBuilder();
            if (disposeMode)
            {
                view.Add(NewMarkdownRenderer());
            }
            else
            {
                markdownRenderer.Clear();
            }
            streamSim.Start(sample, (chunk, idx) =>
            {
                sb.Append(chunk);
                markdownRenderer.Render(sb.ToString());
            },
            () =>
            {
                Tizen.Log.Error(TAG, $"[AutoTest] AliveCount:{View.AliveCount}\n");
            });
        }

        void StartStreamingRandom()
        {
            streamSim.Stop();
            string sample = TestMarkdowns.GetRandom();
            var sb = new System.Text.StringBuilder();
            markdownRenderer.Clear();
            streamSim.Start(sample, (chunk, idx) =>
            {
                sb.Append(chunk);
                markdownRenderer.Render(sb.ToString());
            });
        }

        void StartStreamingNextRef()
        {
            streamSim.Stop();
            string sample = TestMarkdowns.GetNextRef();
            var sb = new System.Text.StringBuilder();
            markdownRenderer.Clear();
            streamSim.Start(sample, (chunk, idx) =>
            {
                sb.Append(chunk);
                markdownRenderer.Render(sb.ToString());
            });
        }

        void StartStreamingPrevRef()
        {
            streamSim.Stop();
            string sample = TestMarkdowns.GetPrevRef();
            var sb = new System.Text.StringBuilder();
            markdownRenderer.Clear();
            streamSim.Start(sample, (chunk, idx) =>
            {
                sb.Append(chunk);
                markdownRenderer.Render(sb.ToString());
            });
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                return;
            }

            // Tests
            if (e.Key.KeyPressedName == "1")
            {
                StartStreamingRandom();
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
            }
            else if (e.Key.KeyPressedName == "2")
            {
                streamSim.Stop();
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
            }
            if (e.Key.KeyPressedName == "3")
            {
                StartStreamingPrev();
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
            }
            else if (e.Key.KeyPressedName == "4")
            {
                StartStreamingNext();
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
            }
            else if (e.Key.KeyPressedName == "q")
            {
                markdownRenderer.PivotPoint = PivotPoint.TopLeft;
                markdownRenderer.Scale = new Vector3(0.75f, 0.75f, 1.0f);
            }
            else if (e.Key.KeyPressedName == "w")
            {
                markdownRenderer.Scale = new Vector3(1.0f, 1.0f, 1.0f);
            }

            else if (e.Key.KeyPressedName == "9")
            {
                Tizen.Log.Error(TAG, $"auto test stop : {View.AliveCount}\n");
                autoTest.Stop();
                UpdateDescription();
            }

            // Auto test
            else if (e.Key.KeyPressedName == "0")
            {
                Tizen.Log.Error(TAG, $"auto test start : {View.AliveCount}\n");
                autoTest.Stop();
                autoTest.Start(StartStreamingSample);
                UpdateDescription();
            }
            else if (e.Key.KeyPressedName == "r")
            {
                markdownRenderer.Clear();
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
                UpdateDescription();
            }

            // Options
            else if (e.Key.KeyPressedName == "a")
            {
                streamSim.ChunkSize--;
                UpdateDescription();
            }
            else if (e.Key.KeyPressedName == "s")
            {
                streamSim.ChunkSize++;
                UpdateDescription();
            }
            else if (e.Key.KeyPressedName == "e")
            {
                streamSim.UseRandomChunkSize = !streamSim.UseRandomChunkSize;
                UpdateDescription();
            }
            else if (e.Key.KeyPressedName == "t")
            {
                streamSim.ChunkSize = 9999;
                UpdateDescription();
            }
            else if (e.Key.KeyPressedName == "d")
            {
                autoTest.IntervalMs -= 1000;
                UpdateDescription();
            }
            else if (e.Key.KeyPressedName == "f")
            {
                autoTest.IntervalMs += autoTest.IntervalMs == 200 ? 800 : 1000;
                UpdateDescription();
            }
            else if (e.Key.KeyPressedName == "z")
            {
                streamSim.IntervalMs -= 10;
                UpdateDescription();
            }
            else if (e.Key.KeyPressedName == "x")
            {
                streamSim.IntervalMs += streamSim.IntervalMs == 1 ? 9 : 10;
                UpdateDescription();
            }
            else if (e.Key.KeyPressedName == "v")
            {
                view.LayoutDirection = ViewLayoutDirectionType.RTL;
                Tizen.Log.Error(TAG, $"RTL\n");
            }
            else if (e.Key.KeyPressedName == "b")
            {
                view.LayoutDirection = ViewLayoutDirectionType.LTR;
                Tizen.Log.Error(TAG, $"LTR\n");
            }
            else if (e.Key.KeyPressedName == "n")
            {
                LightMode(markdownRenderer);
                markdownRenderer.Clear();
                view.BackgroundColor = Color.White;

                DarkMode(descriptionRenderer);
                descriptionRenderer?.Clear();
                UpdateDescription();
                descriptionRenderer.BackgroundColor = new Color("#0F161EFF");
            }
            else if (e.Key.KeyPressedName == "m")
            {
                DarkMode(markdownRenderer);
                markdownRenderer.Clear();
                view.BackgroundColor = new Color("#0F161EFF");

                LightMode(descriptionRenderer);
                descriptionRenderer?.Clear();
                UpdateDescription();
                descriptionRenderer.BackgroundColor = Color.White;
            }
            else if (e.Key.KeyPressedName == "u")
            {
                disposeMode = false;
                Tizen.Log.Error(TAG, $"Dispose Mode Off\n");
            }
            else if (e.Key.KeyPressedName == "i")
            {
                disposeMode = true;
                Tizen.Log.Error(TAG, $"Dispose Mode On\n");
            }
            else if (e.Key.KeyPressedName == "k")
            {
                StartStreamingPrevRef();
            }
            else if (e.Key.KeyPressedName == "l")
            {
                StartStreamingNextRef();
            }
            else if (e.Key.KeyPressedName == "h")
            {
                asyncRendering = false;
                markdownRenderer.AsyncRendering = asyncRendering;
                Tizen.Log.Error(TAG, $"AsyncRendering Off\n");
            }
            else if (e.Key.KeyPressedName == "j")
            {
                asyncRendering = true;
                markdownRenderer.AsyncRendering = asyncRendering;
                Tizen.Log.Error(TAG, $"AsyncRendering On\n");
            }
            else if (e.Key.KeyPressedName == "7")
            {
                scale -= 0.1f;
                if (scale < 0.2f) scale = 0.2f;
                view.Add(NewMarkdownRenderer());
                Tizen.Log.Error(TAG, $"LLMS scale:{scale}\n");
            }
            else if (e.Key.KeyPressedName == "8")
            {
                scale += 0.1f;
                view.Add(NewMarkdownRenderer());
                Tizen.Log.Error(TAG, $"LLMS scale:{scale}\n");
            }
        }

        View NewMarkdownRenderer()
        {
            markdownRenderer?.Clear();
            markdownRenderer?.Dispose();
            markdownRenderer = new MarkdownRenderer
            {
                WidthSpecification = 1200,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                AsyncRendering = asyncRendering,
            };

            markdownRenderer.Style.Common.Indent = (int)(40 * scale);
            markdownRenderer.Style.Common.Padding = (int)(10 * scale);
            markdownRenderer.Style.Common.Margin = (int)(10 * scale);
            markdownRenderer.Style.Paragraph.FontSize = 20.0f * scale;
            markdownRenderer.Style.Paragraph.LineHeight = 32.0f * scale;
            markdownRenderer.Style.Heading.FontSizeLevel1 = 28.0f * scale;
            markdownRenderer.Style.Heading.FontSizeLevel2 = 24.0f * scale;
            markdownRenderer.Style.Heading.FontSizeLevel3 = 20.0f * scale;
            markdownRenderer.Style.Heading.FontSizeLevel4 = 16.0f * scale;
            markdownRenderer.Style.Heading.FontSizeLevel5 = 12.0f * scale;
            markdownRenderer.Style.ThematicBreak.Margin = (int)(10 * scale);
            markdownRenderer.Style.Quote.BarWidth = (int)(6 * scale);
            markdownRenderer.Style.Quote.BarMargin = (int)(10 * scale);
            markdownRenderer.Style.Quote.Padding = (int)(10 * scale);
            markdownRenderer.Style.Quote.BarCornerRadius = 3.0f * scale;
            markdownRenderer.Style.Table.Padding = (int)(10 * scale);
            markdownRenderer.Style.Table.ItemPadding = (int)(5 * scale);
            markdownRenderer.Style.Table.CornerRadius = 12.0f * scale;
            markdownRenderer.Style.Code.FontSize = 20.0f * scale;
            markdownRenderer.Style.Code.TitleFontSize = 16.0f * scale;
            markdownRenderer.Style.Code.Padding = (int)(10 * scale);
            markdownRenderer.Style.Code.CornerRadius = 12.0f * scale;

            return markdownRenderer;
        }

        View NewDescriptionRenderer()
        {
            descriptionRenderer = new MarkdownRenderer
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color("#0F161EFF"),
            };
            DarkMode(descriptionRenderer);
            descriptionRenderer.Style.ThematicBreak.Margin = 0;

            descriptionRenderer.Render(AutoTest.ShortcutGuide + GetCurrentOptions());
            return descriptionRenderer; 
        }

        void UpdateDescription()
        {
            descriptionRenderer?.Render(AutoTest.ShortcutGuide + GetCurrentOptions());
        }

        string GetCurrentOptions()
        {
            string autoTestStatus = autoTest.IsRunning ? "🟢 Running" : "🔴 Stopped";
            string chunkSizeStr = streamSim.UseRandomChunkSize ? "Random" : streamSim.ChunkSize.ToString();

            return $@"

## ⚡ Stream Options

- **Chunk Size:** {chunkSizeStr}
- **Interval:** {streamSim.IntervalMs}ms

---

## 🔄 AutoTest Options

- **Status:** {autoTestStatus}
- **Interval:** {autoTest.IntervalMs}ms
- **Running Count:** {autoTest.RunningCount}
";
        }

        void LightMode(MarkdownRenderer markdown)
        {
            markdown.Style.Paragraph.FontColor = "#000000FF";
            markdown.Style.Quote.FontColor = "#2F2F2FFF";
            markdown.Style.Code.FontColor = "#121212FF";
            markdown.Style.Code.TitleFontColor = "#454545FF";
            markdown.Style.Code.BackgroundColor = "#CCCCCC33";
            markdown.Style.Code.TitleBackgroundColor = "#CCCCCC55";
            markdown.Style.ThematicBreak.Color = "#DFDFDFFF";
            markdown.Style.Table.BorderColor = "#000000FF";
        }

        void DarkMode(MarkdownRenderer markdown)
        {
            markdown.Style.Paragraph.FontColor = "#EFEFEFFF";
            markdown.Style.Quote.FontColor = "#DFDFDFFF";
            markdown.Style.Code.FontColor = "#EFEFEFFF";
            markdown.Style.Code.TitleFontColor = "#E1E1E1FF";
            markdown.Style.Code.BackgroundColor = "#030303FF";
            markdown.Style.Code.TitleBackgroundColor = "#333333FF";
            markdown.Style.ThematicBreak.Color = "#DFDFDFFF";
            markdown.Style.Table.BorderColor = "#FFFFFFFF";
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
