using System;
using UnityEngine;

namespace MatchingGameTemplate.Types
{
    [Serializable]
    public class PairImageText
    {
        [Tooltip("The image of the pair")]
        public Sprite image;

        [Tooltip("The text of the pair")]
        public String text;
    }
}

