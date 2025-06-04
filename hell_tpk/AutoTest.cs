using System;
using System.Collections.Generic;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIText
{
    class AutoTest
    {
        private Timer timer;
        private int intervalMs;
        private int runningCount = 0;
        private Action<int> onNextSample;
        private int sampleIndex = 0;

        public bool IsRunning => timer?.IsRunning() ?? false;
        public int RunningCount => runningCount;

        public int IntervalMs
        {
            get => intervalMs;
            set
            {
                if (intervalMs == value) return;
                intervalMs = value < 1 ? 200 : value;
                if (timer != null)
                {
                    bool wasRunning = timer.IsRunning();
                    timer.Stop();
                    timer.Dispose();
                    timer = new Timer((uint)intervalMs);
                    timer.Tick += OnTick;
                    if (wasRunning)
                        timer.Start();
                }
                Tizen.Log.Info("NUI", $"AutoTest IntervalMs:{intervalMs}\n");
            }
        }

        public AutoTest(int intervalMs = 4000)
        {
            this.intervalMs = intervalMs < 1 ? 200 : intervalMs;
            timer = new Timer((uint)this.intervalMs);
            timer.Tick += OnTick;
        }

        public void Start(Action<int> onNextSample)
        {
            this.onNextSample = onNextSample;
            runningCount = 0;
            sampleIndex = 0;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private bool OnTick(object s, EventArgs e)
        {
            onNextSample?.Invoke(sampleIndex);
            Tizen.Log.Info("NUI", $"AutoTest runningCount : {++runningCount}\n");
            sampleIndex = (sampleIndex + 1) % TestMarkdowns.Count;
            return true;
        }

public static readonly string ShortcutGuide = @"
# 🖥️ NUI Markdown Renderer Test

> Reusable NUI view that renders Markdown as UI components

---

## 🔥 Shortcuts

| **카테고리**       | **키**       | **동작 설명**                               |
|:----------------:|:-----------:|:------------------------------------------|
| 🔢 **스트리밍**    | `1` / `2`  | 랜덤 스트리밍 **시작**/**중단**                 |
|                  | `3` / `4`   | **이전**/**다음** 샘플 스트리밍                |
| ⚙️ **스트리밍 옵션** | `a` / `s`   | Stream Chunk Size 감소/증가                 |
|                  | `z` / `x`   | Stream Interval(ms) 10 감소/증가             |
| 🔍 **스케일**      | `q` / `w`    | 75% 축소/복원                              |
| 🧹 **기타**       | `r`         | 마크다운 클리어                               |
| 🔁 **자동 테스트**  | `0` / `9`  | AutoTest **시작**/**중단**                   |
| ⏰ **자동 테스트 옵션** | `d` / `f`   | AutoTest Interval(ms) 1000 감소/증가     |

---

";

    }
}
