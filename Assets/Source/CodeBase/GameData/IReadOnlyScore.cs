using System;

namespace Source.CodeBase.GameData
{
    public interface IReadOnlyScore
    {
        event Action<Fraction, int> OnScoreChanged;
    }
}