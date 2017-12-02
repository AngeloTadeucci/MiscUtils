using System;
using System.Reactive.Disposables;

namespace MiscUtils
{
    public static class ArrayExtensions
    {
        public static IDisposable AsDisposableArray<T>(this T[] array) where T : IDisposable
        {
            return Disposable.Create(() =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i]?.Dispose();
                }
            });
        }
    }
}
