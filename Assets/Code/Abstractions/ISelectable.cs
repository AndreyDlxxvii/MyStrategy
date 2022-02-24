using UnityEngine;

public interface ISelectable : IHealthHolder
{
    Transform StartPoint { get; }
    Sprite Icon { get; }
    Contour Outline { get; }
}