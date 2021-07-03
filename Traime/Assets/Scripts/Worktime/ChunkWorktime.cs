using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [System.Serializable]
    public class ChunkWorktime
    {
        public DateTime startTime;
        public DateTime endTime;

        public void Start()
        {
            startTime = DateTime.Now;
        }

        public void End()
        {
            endTime = DateTime.Now;
        }

        public TimeSpan GetTimeSpan()
        {            
            if(endTime != DateTime.MinValue)
            {
                return endTime - startTime;
            }
            else
            {
                return DateTime.Now - startTime;
            }
        }
    }
}

