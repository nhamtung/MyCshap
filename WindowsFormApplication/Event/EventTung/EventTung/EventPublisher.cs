namespace Event
{
    public delegate void UpdateNumber(int x);
    class EventPublisher
    {
        public event UpdateNumber updateNumberEvent;
        int num;
        public void DoSomething()
        {
            num++;
            updateNumberEvent(num);
        }
    }
}
