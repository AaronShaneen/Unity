using System;
using UnityEngine;

namespace MatchingGameTemplate.Types
{
    [Serializable]
    public class PairTextSound
    {
        [Tooltip("The text of the pair")]
        public string text;

        [Tooltip("The sound of the pair")]
        public AudioClip sound;

        [Tooltip("The image of the pair")]
        public Sprite image;
    }
}

