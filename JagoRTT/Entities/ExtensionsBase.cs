namespace JagoRTT.domain.Entities
{
    public static class ExtensionsBase
    {
        public static IEnumerator<T> GetEnumerator<T>(this IEnumerator<T> enumerator) => enumerator;
    }
}