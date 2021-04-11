namespace playerElement.minor
{
    public class State_Minor
    {
        public bool IsDisposeObject { get; set; } = true;
        
        public bool IsLaunchable { get; set; } = false;

        public int RemainingJump { get; set; } = 0;

        public bool IsDash { get; set; } = false;
    }
    
}
