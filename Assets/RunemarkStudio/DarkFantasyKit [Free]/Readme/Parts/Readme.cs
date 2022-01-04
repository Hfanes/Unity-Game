using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runemark.DarkFantasyKit
{
    [CreateAssetMenu()]
    public class Readme : ScriptableObject
    {
        public Texture2D icon;
        public string title;
        public List<Section> sections = new List<Section>();
        public bool loadedLayout;

        [System.Serializable]
        public class Section
        {
            public string heading;
            [Multiline()]
            public string text;
            public string linkText;
            public string url;
        }
    }
}