using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LoopBenchMark;

[MemoryDiagnoser]
public class LoopBenchmarks
{

 
     [Params(1_000, 10_000, 1_000_000)]
    public int Size { get; set; }

    private readonly List<string> _items = new();

    [GlobalSetup]
    public void Setup()
    {
        _items.Clear();
        var random = new Random(123);
        for (var i = 0; i < Size; i++)
        {
            var randomValue = random.Next();
            _items.Add(randomValue.ToString());
        }
    }

    [Benchmark]
    public string While()
    {
        var response = string.Empty;
        var size = _items.Count;
        var index = 0;
        while (index < size)
        {
            response = _items[index];
            index++;
        }
        return response;
    }

    [Benchmark]
    public string DoWhile()
    {
        string response;
        var size = _items.Count;
        var i = 0;

        do
        {
            response = _items[i];
            i++;
        } while (i < size);

        return response;
    }

    [Benchmark]
    public string For()
    {
        string response = string.Empty;
        var size = _items.Count;
        for (var i = 0; i < size; i++)
        {
            response = _items[i];
        }
        return response;
    }
    [Benchmark]
    public string Foreach()
    {
        string response = string.Empty;
        foreach (var item in _items)
        {
            response = item;
        }
        return response;
    }

    [Benchmark]
    public string ForEach()
    {
        string response = string.Empty;
        _items.ForEach(item => response = item);
        return response;
    }

    [Benchmark]
    public string Span()
    {
        var response = string.Empty;
        var size = _items.Count;

        Span<string> span = CollectionsMarshal.AsSpan(_items);

        for (var i = 0; i < size; i++)
        {
            response = span[i];
        }
        return response;
    }

}