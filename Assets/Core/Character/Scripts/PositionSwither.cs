using UnityEngine;

public class PositionSwither
{
    public Transform CurrentPosition => _positions[_currentIndex];

    private Transform[] _positions;
    private int _currentIndex;

    public PositionSwither(Transform[] positions, int current)
    {
        _positions = positions;
        _currentIndex = current;
    }

    public Transform TryMoveRight() => TryMove(_currentIndex + 1);

    public Transform TryMoveLeft() => TryMove(_currentIndex - 1);

    private Transform TryMove(int index)
    {
        if (index >= 0 && index < _positions.Length)
            _currentIndex = index;

        return _positions[_currentIndex];
    }
}
