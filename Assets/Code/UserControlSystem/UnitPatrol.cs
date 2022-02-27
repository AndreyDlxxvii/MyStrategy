    using UnityEngine;

    public class UnitPatrol : IPatrol
    {
        public Vector3 From { get; }
        public Vector3 To { get; }

        public UnitPatrol(Vector3 from, Vector3 to)
        {
            From = from;
            To = to;
        }
    }