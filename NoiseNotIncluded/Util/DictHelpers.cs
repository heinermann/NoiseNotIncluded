using System.Collections.Generic;

namespace NoiseNotIncluded.Util
{
  public static class DictHelpers
  {
    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
    where TValue : new()
    {
      TValue val;

      if (!dict.TryGetValue(key, out val))
      {
        val = new TValue();
        dict.Add(key, val);
      }

      return val;
    }
  }
}
