    using UnityEngine;

    public class UnitMove : IMove
    {
        public Vector3 Target { get; }

        public UnitMove(Vector3 target)
        {
            Target = target;
        }
    }