public interface IObserver<T> {
    void OnNext(T value);
    void OnError(Exception error);
    void OnComplete();
}
