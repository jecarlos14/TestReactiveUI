using ReactiveUI;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;

namespace TestReactiveUI
{
    public class MainPageViewModel : ReactiveObject
    {
        private int firstValue;
        public int FirstValue
        {
            get => firstValue;
            set => this.RaiseAndSetIfChanged(ref firstValue, value);
        }

        private int secondValue;
        public int SecondValue
        {
            get => secondValue;
            set => this.RaiseAndSetIfChanged(ref secondValue, value);
        }

        private int result;
        public int Result
        {
            get => result;
            set => this.RaiseAndSetIfChanged(ref result, value);
        }

        public MainPageViewModel()
        {
            this.WhenAnyValue(x => x.SecondValue, x => x.FirstValue, (x, y) => x + y).
                 Subscribe(x => { result = x; });
        }
    }
}
