
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

public sealed class Multiton
{
  private readonly static List<Multiton> _list = new List<Multiton>();
  private static object _gate = new object();
  private static int _count = 2;

  private Multiton()
  {
  }

  public static Multiton GetInstance()
  {
    if (_list.Count < _count)
    {
      lock (_gate)
      {
        if (_list.Count < _count)
        {
          var obj = new Multiton();
          _list.Add(obj);

          return obj;
        }
      }
    }

    return _list[new Random().Next(2)];
  }
}

public sealed class NewMultiton
{
  private readonly static ConcurrentBag<NewMultiton> _list = new ConcurrentBag<NewMultiton>();
  private static int _count = 2;

  private NewMultiton()
  {
  }

  public static NewMultiton GetInstance()
  {
    if (_list.Count < _count)
    {
      var obj = new NewMultiton();
      _list.Add(obj);

      return obj;
    }

    return _list.First();
  }
}


public sealed class Singleton
{
  private static readonly Lazy<Singleton> lazy =
      new Lazy<Singleton>(() => new Singleton());

  public static Singleton Instance { get { return lazy.Value; } }

  private Singleton()
  {
  }
}


public sealed class NewSingleton
{
  private static readonly Lazy<ConcurrentBag<NewSingleton>> lazy =
      new Lazy<ConcurrentBag<NewSingleton>>(() =>
      {
        return new ConcurrentBag<NewSingleton>(Enumerable.Repeat(new NewSingleton(), _count));
      });

  private static int _count = 2;

  public static NewSingleton Instance { get { return lazy.Value.First(); } }

  private NewSingleton()
  {
  }
}