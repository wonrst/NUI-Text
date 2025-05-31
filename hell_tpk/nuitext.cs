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

        const float FONT_SIZE = 20;

        string TEXT;

        const string SIMPLE_TEXT = "## **Hello** *world*";

        const string SON = @"## 🇰🇷 손흥민 (Son Heung-min)

> ""아시아의 자존심, 프리미어리그의 레전드""

---

### 🧾 기본 정보
- **출생**: 1992년 7월 8일, 강원도 춘천  
- **신체**: 183cm / 77kg  
- **포지션**: 공격수 (윙어, 스트라이커)  
- **소속팀**: 토트넘 홋스퍼 FC (등번호 7)  
- **국가대표**: *대한민국* 축구 대표팀   

---

### 🏅 주요 커리어 요약

| 구분           | 주요 기록 및 성과                                                 |
|----------------|------------------------------------------------------------------|
| 프리미어리그   | 100+ 골 기록 (아시아 선수 최초)                                  |
| 득점왕         | 2021–22 시즌 득점왕 (23골, 살라와 공동)                          |
| 챔피언스리그   | 2019 결승전 선발 출전 (vs 리버풀)                                |
| 국가대표       | A매치 130+경기 / 50+골                                            |
| 국제대회       | 2018 아시안게임 금메달, 2014·2018·2022 월드컵 참가                |
| 개인 수상      | 2020 FIFA 푸슈카시상 (번리전 단독 드리블 골)                      |

---

### 💡 특징 및 성장 배경

- 양발잡이 / 스피드와 슈팅력 뛰어남  
- 철저한 기본기 훈련 (아버지 손웅정 지도)  
- 겸손하고 성실한 태도로 팬과 동료에게 존경받음  

---

### 🎯 대표 명언

> “겸손하라. 감사하라. 그러면 너의 것이 된다.”  
> – 손웅정 (손흥민 아버지)

---

## ✅ 요약 한줄

> **손흥민은 ~~아시아~~ 축구의 한계를 넘어선 세계적인 공격수입니다.**";


const string WORK = @"# How to Optimize Your Workflow in 2025
 
In today's fast-paced world, it's *critical* to optimize your **daily workflow**. Here's a quick summary of what we'll cover:
 
1. Time management techniques
2. Tools that actually help
3. Common mistakes to avoid
 
> ""The key is not to prioritize what's on your schedule, but to schedule your priorities."" 
> — Stephen Covey
 
## 🔧 Recommended Tools
 
Here are some tools we found helpful:
 
- [Notion](https://www.notion.so) for knowledge management
- ~~Evernote~~ (deprecated in our tests)
- **Obsidian** for offline markdown note-taking
 
And don't forget inline `code snippets` like `git commit -m ""optimize workflow""`.
 
### ✅ Quick Tips
 
- **Batch** similar tasks together
  - For example, answer all emails in a 30-minute block
- Use `Pomodoro` technique
- Avoid context switching
 
### 🧠 Example Table
 
| Tool      | Purpose              | Free Plan |
|-----------|----------------------|-----------|
| Notion    | All-in-one workspace | ✅        |
| Obsidian  | Markdown editor      | ✅        |
| Trello    | Task management      | ✅        |
 
### 🧪 Sample Code
 
```csharp
public class WorkflowOptimizer
{
    public void Optimize()
    {
        Console.WriteLine(""Workflow optimized!"");
    }
}
```
`Hello` world.

";


        public string streamText = "";
        public int streamIndex;
        public TextLabel label;
        public Timer TIMER;
        public MarkdownRenderer MARKDOWN;

        public Timer HELL;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(1200, 1400));
        }

        public void GenerateUI(Size windowSize)
        {
            Window window = Window.Instance;
            window.WindowSize = windowSize;
            Window.Instance.KeyEvent += OnKeyEvent;

            var view = NewView();
            // view.BackgroundColor = Color.Red;
            window.Add(view);

            // label = NewTextLabel(TEXT);
            // view.Add(label);

            MARKDOWN = new MarkdownRenderer();
            MARKDOWN.WidthSpecification = LayoutParamPolicies.MatchParent;
            MARKDOWN.HeightSpecification = LayoutParamPolicies.WrapContent;
            // MARKDOWN.BackgroundColor = Color.Red;
            view.Add(MARKDOWN);

            MARKDOWN.Style.Heading.FontFamily = "One UI Sans KR 700 Bold";
            // MARKDOWN.Style.Heading.FontSizeLevel1 = 30;
            // MARKDOWN.Style.Heading.FontSizeLevel2 = 20;
            // MARKDOWN.Style.Heading.FontSizeLevel3 = 16;

            // MARKDOWN.Style.Paragraph.FontFamily = "One UI Sans APP 400 Regular";
            MARKDOWN.Style.Paragraph.FontFamily = "One UI Sans KR 400 Regular";
            // MARKDOWN.Style.Paragraph.FontSize = 10;
            // MARKDOWN.Style.Paragraph.FontColor = "#FF008899";
            // MARKDOWN.Style.Paragraph.LineHeight = 20;

            // MARKDOWN.Style.Table.BorderThickness = 5;
            // MARKDOWN.Style.Table.BorderColor = "#FF007788";
            // MARKDOWN.Style.Table.Padding = 30;



            streamIndex = 0;
            streamText = "";
            int chunkSize = 10;

            TIMER = new Timer(10);

            TIMER.Tick += (s, e) =>
            {
                if (streamIndex < TEXT.Length)
                {
                    int length = Math.Min(chunkSize, TEXT.Length - streamIndex);
                    streamText += TEXT.Substring(streamIndex, length);

                    MARKDOWN.Render(streamText);
                    // Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");

                    streamIndex += chunkSize;

                    // Tizen.Log.Error(TAG, $"MARKDOWN size : {MARKDOWN.Size.Width}, {MARKDOWN.Size.Height}\n");
                }
                else
                {
                    return false;
                }
                return true;
            };

            int runningCount = 0;

            HELL = new Timer(5000);
            HELL.Tick += (s, e) =>
            {
                if (TIMER.IsRunning())
                {
                    TIMER.Stop();
                }
                TEXT = SON;
                streamText = "";
                streamIndex = 0;
                TIMER.Start();
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
                Tizen.Log.Error(TAG, $"runningCount : {++runningCount}\n");
                return true;
            };

        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                return;                    
            }

            // TEST

            if (e.Key.KeyPressedName == "1")
            {
                if (TIMER.IsRunning())
                {
                    TIMER.Stop();
                }
                TEXT = SON;
                streamText = "";
                streamIndex = 0;
                TIMER.Start();
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
            }
            else if (e.Key.KeyPressedName == "2")
            {
                if (TIMER.IsRunning())
                {
                    TIMER.Stop();
                }
                TEXT = WORK;
                streamText = "";
                streamIndex = 0;
                TIMER.Start();
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
            }
            else if (e.Key.KeyPressedName == "8")
            {
                if (TIMER.IsRunning())
                {
                    TIMER.Stop();
                }
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
                MARKDOWN.Render(SIMPLE_TEXT);
                Tizen.Log.Error(TAG, $"aliveCount : {View.AliveCount}\n");
            }

            else if (e.Key.KeyPressedName == "9")
            {
                if (HELL.IsRunning())
                {
                    HELL.Stop();
                }
            }

            else if (e.Key.KeyPressedName == "0")
            {
                if (HELL.IsRunning())
                {
                    HELL.Stop();
                }
                HELL.Start();
            }
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                PixelSize = FONT_SIZE,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
            };
            return label;
        }

        public View NewView()
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    CellPadding = new Size2D(1, 1),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            return view;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
