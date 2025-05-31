using System;
using System.Collections.Generic;

namespace Source.CodeBase.GameData
{
    public class Score : IReadOnlyScore
    {
        public event Action<Fraction, int> OnScoreChanged;

        private readonly Dictionary<Fraction, int> _scores;

        public Score()
        {
            _scores = new Dictionary<Fraction, int>()
            {
                { Fraction.One, 0 },
                { Fraction.Two, 0 },
            };
        }

        public void Add(Fraction fraction)
        {
            var newScore = ++_scores[fraction];
            OnScoreChanged?.Invoke(fraction, newScore);
        }
    }
}