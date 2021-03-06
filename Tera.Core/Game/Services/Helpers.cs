﻿// Copyright (c) Gothos
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Tera.Game
{
    public static class Helpers
    {
        public static Func<T, TResult> Memoize<T, TResult>(Func<T, TResult> func)
        {
            var lookup = new ConcurrentDictionary<T, TResult>();
            return x => lookup.GetOrAdd(x, func);
        }

        internal static void On<T>(this object obj, Action<T> callback)
        {
            if (obj is T)
            {
                var castObject = (T)obj;
                callback(castObject);
            }
        }

        internal class ProjectingEqualityComparer<T, TKey> : Comparer<T>
        {
            private readonly Comparer<TKey> _keyComparer = Comparer<TKey>.Default;
            private readonly Func<T, TKey> _projection;

            public ProjectingEqualityComparer(Func<T, TKey> projection)
            {
                _projection = projection;
            }

            public override int Compare(T x, T y)
            {
                return _keyComparer.Compare(_projection(x), _projection(y));
            }
        }
    }
}
