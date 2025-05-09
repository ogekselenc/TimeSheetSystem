namespace TimeSheetSystem.Domain.Handlers
{
    public abstract class Handler<T>
    {
        public abstract Task<T> HandleAsync(T request);
    }
}