using ReactiveUI;
using System;
using System.Linq.Expressions;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Util
{
  // Source: https://github.com/reactiveui/ReactiveUI/blob/371b7fc117c44636f865cc5c5b5d09220d7acec0/src/ReactiveUI/VariadicTemplates.cs
  public static class WhenAnyObservableMixinExt
  {
    public static IObservable<T> EmptyIfNull<T>(this IObservable<T> @this)
    {
      return @this ?? Observable.Empty<T>();
    }

    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Func<T1, T2, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, (o1, o2) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Func<T1, T2, T3, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, (o1, o2, o3) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3, T4>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Expression<Func<TSender, IObservable<T4>>> obs4,
                        Func<T1, T2, T3, T4, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, obs4, (o1, o2, o3, o4) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), o4.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3, T4, T5>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Expression<Func<TSender, IObservable<T4>>> obs4,
                        Expression<Func<TSender, IObservable<T5>>> obs5,
                        Func<T1, T2, T3, T4, T5, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, obs4, obs5, (o1, o2, o3, o4, o5) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), o4.Value.EmptyIfNull(), o5.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3, T4, T5, T6>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Expression<Func<TSender, IObservable<T4>>> obs4,
                        Expression<Func<TSender, IObservable<T5>>> obs5,
                        Expression<Func<TSender, IObservable<T6>>> obs6,
                        Func<T1, T2, T3, T4, T5, T6, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, obs4, obs5, obs6, (o1, o2, o3, o4, o5, o6) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), o4.Value.EmptyIfNull(), o5.Value.EmptyIfNull(), o6.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3, T4, T5, T6, T7>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Expression<Func<TSender, IObservable<T4>>> obs4,
                        Expression<Func<TSender, IObservable<T5>>> obs5,
                        Expression<Func<TSender, IObservable<T6>>> obs6,
                        Expression<Func<TSender, IObservable<T7>>> obs7,
                        Func<T1, T2, T3, T4, T5, T6, T7, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, obs4, obs5, obs6, obs7, (o1, o2, o3, o4, o5, o6, o7) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), o4.Value.EmptyIfNull(), o5.Value.EmptyIfNull(), o6.Value.EmptyIfNull(), o7.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3, T4, T5, T6, T7, T8>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Expression<Func<TSender, IObservable<T4>>> obs4,
                        Expression<Func<TSender, IObservable<T5>>> obs5,
                        Expression<Func<TSender, IObservable<T6>>> obs6,
                        Expression<Func<TSender, IObservable<T7>>> obs7,
                        Expression<Func<TSender, IObservable<T8>>> obs8,
                        Func<T1, T2, T3, T4, T5, T6, T7, T8, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, (o1, o2, o3, o4, o5, o6, o7, o8) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), o4.Value.EmptyIfNull(), o5.Value.EmptyIfNull(), o6.Value.EmptyIfNull(), o7.Value.EmptyIfNull(), o8.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Expression<Func<TSender, IObservable<T4>>> obs4,
                        Expression<Func<TSender, IObservable<T5>>> obs5,
                        Expression<Func<TSender, IObservable<T6>>> obs6,
                        Expression<Func<TSender, IObservable<T7>>> obs7,
                        Expression<Func<TSender, IObservable<T8>>> obs8,
                        Expression<Func<TSender, IObservable<T9>>> obs9,
                        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, (o1, o2, o3, o4, o5, o6, o7, o8, o9) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), o4.Value.EmptyIfNull(), o5.Value.EmptyIfNull(), o6.Value.EmptyIfNull(), o7.Value.EmptyIfNull(), o8.Value.EmptyIfNull(), o9.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Expression<Func<TSender, IObservable<T4>>> obs4,
                        Expression<Func<TSender, IObservable<T5>>> obs5,
                        Expression<Func<TSender, IObservable<T6>>> obs6,
                        Expression<Func<TSender, IObservable<T7>>> obs7,
                        Expression<Func<TSender, IObservable<T8>>> obs8,
                        Expression<Func<TSender, IObservable<T9>>> obs9,
                        Expression<Func<TSender, IObservable<T10>>> obs10,
                        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, obs10, (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), o4.Value.EmptyIfNull(), o5.Value.EmptyIfNull(), o6.Value.EmptyIfNull(), o7.Value.EmptyIfNull(), o8.Value.EmptyIfNull(), o9.Value.EmptyIfNull(), o10.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Expression<Func<TSender, IObservable<T4>>> obs4,
                        Expression<Func<TSender, IObservable<T5>>> obs5,
                        Expression<Func<TSender, IObservable<T6>>> obs6,
                        Expression<Func<TSender, IObservable<T7>>> obs7,
                        Expression<Func<TSender, IObservable<T8>>> obs8,
                        Expression<Func<TSender, IObservable<T9>>> obs9,
                        Expression<Func<TSender, IObservable<T10>>> obs10,
                        Expression<Func<TSender, IObservable<T11>>> obs11,
                        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, obs10, obs11, (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), o4.Value.EmptyIfNull(), o5.Value.EmptyIfNull(), o6.Value.EmptyIfNull(), o7.Value.EmptyIfNull(), o8.Value.EmptyIfNull(), o9.Value.EmptyIfNull(), o10.Value.EmptyIfNull(), o11.Value.EmptyIfNull(), selector))
          .Switch();
    }
    public static IObservable<TRet> WhenAnyObservable<TSender, TRet, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this TSender This,
                        Expression<Func<TSender, IObservable<T1>>> obs1,
                        Expression<Func<TSender, IObservable<T2>>> obs2,
                        Expression<Func<TSender, IObservable<T3>>> obs3,
                        Expression<Func<TSender, IObservable<T4>>> obs4,
                        Expression<Func<TSender, IObservable<T5>>> obs5,
                        Expression<Func<TSender, IObservable<T6>>> obs6,
                        Expression<Func<TSender, IObservable<T7>>> obs7,
                        Expression<Func<TSender, IObservable<T8>>> obs8,
                        Expression<Func<TSender, IObservable<T9>>> obs9,
                        Expression<Func<TSender, IObservable<T10>>> obs10,
                        Expression<Func<TSender, IObservable<T11>>> obs11,
                        Expression<Func<TSender, IObservable<T12>>> obs12,
                        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TRet> selector)
        where TSender : class
    {
      return This.WhenAny(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, obs10, obs11, obs12, (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => Observable.CombineLatest(o1.Value.EmptyIfNull(), o2.Value.EmptyIfNull(), o3.Value.EmptyIfNull(), o4.Value.EmptyIfNull(), o5.Value.EmptyIfNull(), o6.Value.EmptyIfNull(), o7.Value.EmptyIfNull(), o8.Value.EmptyIfNull(), o9.Value.EmptyIfNull(), o10.Value.EmptyIfNull(), o11.Value.EmptyIfNull(), o12.Value.EmptyIfNull(), selector))
          .Switch();
    }
  }
}
