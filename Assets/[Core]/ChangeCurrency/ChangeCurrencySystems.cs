using System;
using Entitas;

namespace _Core_.ChangeCurrency
{
    public sealed class ChangeCurrencySystems : Systems
    {
        public ChangeCurrencySystems(Contexts contexts)
        {
            Add(new ChangeCurrencyReactiveSystem(contexts));
        }
    }
}