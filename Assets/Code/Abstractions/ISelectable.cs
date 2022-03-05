using UnityEngine;

public interface ISelectable : IHealthHolder, IIconHolder
{
    Transform StartPoint { get; }
    Contour Outline { get; }
}