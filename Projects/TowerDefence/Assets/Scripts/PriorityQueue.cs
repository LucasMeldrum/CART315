using System.Collections.Generic;

public class PriorityQueue<T>
{
    private List<KeyValuePair<T, float>> elements = new List<KeyValuePair<T, float>>();

    public int Count => elements.Count;

    public void Enqueue(T item, float priority)
    {
        elements.Add(new KeyValuePair<T, float>(item, priority));
        elements.Sort((a, b) => a.Value.CompareTo(b.Value));  // Sort by priority (lower is better)
    }

    public T Dequeue()
    {
        if (elements.Count == 0)
            return default(T);

        T item = elements[0].Key;
        elements.RemoveAt(0);
        return item;
    }

    public bool Contains(T item)
    {
        return elements.Exists(e => EqualityComparer<T>.Default.Equals(e.Key, item));
    }
}