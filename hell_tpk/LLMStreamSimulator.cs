using System;
using System.Collections.Generic;

using Tizen.NUI;

namespace NUIText
{
    internal class LLMStreamSimulator
    {
        private Timer timer;
        private string fullText;
        private int chunkSize;
        private int currentIndex;
        private Action<string, int> onChunk;
        private Action onComplete;
        private Random random = new Random();
        private bool useRandomChunkSize = false;

        public bool IsRunning => timer?.IsRunning() ?? false;

        public bool UseRandomChunkSize
        {
            get => useRandomChunkSize;
            set => useRandomChunkSize = value;
        }

        public int ChunkSize
        {
            get => chunkSize;
            set
            {
                if (value < 1) value = 1;
                chunkSize = value;
                Tizen.Log.Info("NUI", $"ChunkSize:{chunkSize}");
            }
        }

        private int intervalMs;
        public int IntervalMs
        {
            get => intervalMs;
            set
            {
                if (intervalMs == value) return;
                intervalMs = value < 1 ? 1 : value;
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
                Tizen.Log.Info("NUI", $"LLMStreamSimulator IntervalMs:{intervalMs}");
            }
        }

        public LLMStreamSimulator(int intervalMs = 10, int chunkSize = 1)
        {
            this.intervalMs = intervalMs < 1 ? 1 : intervalMs;
            this.chunkSize = chunkSize < 1 ? 1 : chunkSize;
            timer = new Timer((uint)this.intervalMs);
            timer.Tick += OnTick;
        }

        public void Start(string text, Action<string, int> onChunk, Action onComplete = null)
        {
            this.fullText = text ?? "";
            this.currentIndex = 0;
            this.onChunk = onChunk;
            this.onComplete = onComplete;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private bool OnTick(object s, EventArgs e)
        {
            if (currentIndex < fullText.Length)
            {
                if (useRandomChunkSize)
                {
                    if (random.NextDouble() < 0.05)
                        ChunkSize = random.Next(20, 31);
                    else
                        ChunkSize = random.Next(1, 11);
                }
                int length = Math.Min(chunkSize, fullText.Length - currentIndex);
                string chunk = fullText.Substring(currentIndex, length);
                currentIndex += length;
                onChunk?.Invoke(chunk, currentIndex);
                return true;
            }
            onComplete?.Invoke();
            return false;
        }
    }
}
