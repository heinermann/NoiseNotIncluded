using ReactiveUI;
using System;
using System.Linq.Expressions;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Util
{
  public static class WhenAnyObservableMixinExt
  {
    public static IObservable<T> EmptyIfNull<T>(this IObservable<T> @this)
    {
      return @this ?? Observable.Empty<T>();
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
  }
}
