using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [CreateAssetMenu]
    public class DaytimeSegmentsList : ScriptableObject
    {
        public List<DaytimeSegmentData> segments;
    }
}