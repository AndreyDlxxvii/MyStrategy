using UnityEngine;
using UnityEngine.PlayerLoop;


public interface ISelectable
{
    float Health { get; }
    float MaxHealth { get; }
    Sprite Icon { get; }
    
    Outline Contour { get; }
}