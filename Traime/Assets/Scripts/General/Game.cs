using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    public class Game : MonoBehaviour
    {
        public static Game inst;

        public GameUI ui;

        private void Awake()
        {
            inst = this;
        }
    }
}