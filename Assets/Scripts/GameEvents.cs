using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public class KeyPointEvent
    {
        public string keyName { get; set; }
        public bool isInTime { get; set; }
    }

    public class GateEvent
    {
        public string gateName { get; set; }
        public string message { get; set; }
    }
}
