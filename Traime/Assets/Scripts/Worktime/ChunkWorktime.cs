using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [System.Serializable]
    public class ChunkWorktime
    {
        public int id;

        public TimeOfDay startTime;
        public TimeOfDay endTime;

        public ChunkWorktime(int id)
        {
            this.id = id;
        }

        public void Start()
        {
            startTime = new TimeOfDay(DateTime.Now);
        }

        public void End()
        {
            endTime = new TimeOfDay(DateTime.Now);
        }

        public TimeOfDay GetDuration()
        {            
            if(endTime != null)
            {
                return endTime - startTime;
            }
            else
            {
                return new TimeOfDay(DateTime.Now) - startTime;
            }
        }
    }
}

