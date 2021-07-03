using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [System.Serializable]
    public class DayWorktime
    {
        public List<ChunkWorktime> chunks = new List<ChunkWorktime>();

        public void AddChunk(ChunkWorktime chunk)
        {
            chunks.Add(chunk);
        }

        public TimeSpan GetTimeSpan()
        {
            TimeSpan timeSpan = new TimeSpan();

            foreach(ChunkWorktime chunk in chunks)
            {
                timeSpan += chunk.GetTimeSpan();
            }

            return timeSpan;
        }
    }
}