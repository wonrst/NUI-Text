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
            window.KeyEvent += OnKeyEvent;

            var view = new View()
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

            // // Heading
            // markdownRenderer.Style.Heading.FontSizeLevel1 = 28.0f;
            // markdownRenderer.Style.Heading.FontSizeLevel2 = 24.0f;
            // markdownRenderer.Style.Heading.FontSizeLevel3 = 20.0f;
            // markdownRenderer.Style.Heading.FontSizeLevel4 = 16.0f;
            // markdownRenderer.Style.Heading.FontSizeLevel5 = 12.0f;
            // markdownRenderer.Style.Heading.FontFamily = "SamsungOneUI_700";

            // // ThematicBreak
            // markdownRenderer.Style.ThematicBreak.Color = "#EEEEEEFF";
            // markdownRenderer.Style.ThematicBreak.Thickness = 1;

            // // Quote
            // markdownRenderer.Style.Quote.BackgroundColor = "#CCCCCC33";
            // markdownRenderer.Style.Quote.Padding = 10;

            // // Table
            // markdownRenderer.Style.Table.BorderColor = "#EEEEEEFF";
            // markdownRenderer.Style.Table.BorderThickness = 1;
            // markdownRenderer.Style.Table.Padding = 5;

            // // Code
            // markdownRenderer.Style.Code.FontFamily = "Ubuntu Mono"; // FIXME
            // markdownRenderer.Style.Code.FontColor = "#121212FF";
            // markdownRenderer.Style.Code.BackgroundColor = "#CCCCCC33";
            // markdownRenderer.Style.Code.FontSize = 20.0f;
            // markdownRenderer.Style.Code.TitleFontFamily = "Ubuntu Mono";
            // markdownRenderer.Style.Code.TitleFontColor = "#454545FF";
            // markdownRenderer.Style.Code.TitleBackgroundColor = "#CCCCCC55";
            // markdownRenderer.Style.Code.TitleFontSize = 16.0f;
            // markdownRenderer.Style.Code.Padding = 10;

            // // Link
            // markdownRenderer.Style.Link.Color = "#4A90E2FF";
            // markdownRenderer.Style.Link.VisitedColor = "#9B59B6FF";

            // markdownRenderer.Render(simpleText);
        }

        void StartStreamingSample(int index)
        {
            streamSim.Stop();
            string sample = TestMarkdowns.GetSample(index);
            var sb = new System.Text.StringBuilder();
            streamSim.Start(sample, (chunk, idx) =>
            {
                sb.Append(chunk);
                markdownRenderer.Render(sb.ToString());
            });
            UpdateDescription();
            Tizen.Log.Error(TAG, $"[AutoTest] RunningCount:{autoTest.RunningCount}, IsRunning:{autoTest.IsRunning}, AliveCount:{View.AliveCount}\n");
        }

        void StartStreamingPrev()
        {
            streamSim.Stop();
            string sample = TestMarkdowns.GetPrev();
            var sb = new System.Text.StringBuilder();
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
            streamSim.Start(sample, (chunk, idx) =>
            {
                sb.Append(chunk);
                markdownRenderer.Render(sb.ToString());
            });
        }

        void StartStreamingRandom()
        {
            streamSim.Stop();
            string sample = TestMarkdowns.GetRandom();
            var sb = new System.Text.StringBuilder();
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
        }

        View NewDescriptionRenderer()
        {
            descriptionRenderer = new MarkdownRenderer
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color("#0F161EFF"),
            };

            descriptionRenderer.Style.Paragraph.FontColor = "#EFEFEFFF";
            descriptionRenderer.Style.Table.BorderColor = "#DEDEDEAA";
            descriptionRenderer.Style.Quote.BackgroundColor = "#152536FF";

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

## **⚡ Stream Options**

- **Chunk Size:** {chunkSizeStr}
- **Interval:** {streamSim.IntervalMs}ms

---

## **🔄 AutoTest Options**

- **Status:** {autoTestStatus}
- **Interval:** {autoTest.IntervalMs}ms
- **Running Count:** {autoTest.RunningCount}
";
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
