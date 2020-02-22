namespace Code.EventSystem.Listeners
{
    public interface IListener<T>
    {
        void OnEventRaised(T item);
    }
}