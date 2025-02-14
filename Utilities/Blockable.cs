using System;

public class Blockable
{
    public bool IsBlocked { get; private set; }
    public event Action<bool> OnBlockChanged; 
    private int _counter;

    public void AddBlock()
    {
        _counter++;
        AfterCounterChanged();
    }

    public void RemoveBlock()
    {
        _counter--;
        AfterCounterChanged();
    }

    public Blocker CreateBlocker()
    {
        return new Blocker(this);
    }

    private void AfterCounterChanged()
    {
        var blocked = _counter > 0;
        if (blocked != IsBlocked)
        {
            IsBlocked = blocked;
            OnBlockChanged?.Invoke(blocked);
        }
    }
}

public class Blocker
{
    public readonly Blockable Blockable;
    public bool IsBlocking { get; private set; }

    public Blocker(Blockable blockable)
    {
        Blockable = blockable;
    }

    public void Block()
    {
        if (!IsBlocking)
        {
            Blockable.AddBlock();
            IsBlocking = true;
        }
    }

    public void Unblock()
    {
        if (IsBlocking)
        {
            Blockable.RemoveBlock();
            IsBlocking = false;
        }
    }
}