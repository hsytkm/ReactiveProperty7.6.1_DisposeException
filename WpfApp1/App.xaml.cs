using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class App : Application
    {
        readonly struct MyData
        {
            public readonly int X;
        }

        public App()
        {
            var disposables = new CompositeDisposable();

            var rp = new ReactivePropertySlim<MyData>(mode: ReactivePropertyMode.None).AddTo(disposables);

            var rorp = rp
                .FirstAsync()
                .ToReadOnlyReactivePropertySlim()
                .AddTo(disposables);

            Exit += (_, __) =>
            {
                // ↓会社PCだとここで System.InvalidOperationException:`Sequence contains no elements` が表示される。
                //   家PCだと Exception 発生しない。なぜ…？
                //   RpのNuget 7.6.0 ならOKで、7.6.1 で発生する。 7.6.1 から依存Lib が .NET5 にアップ対応してるっぽい。
                disposables.Dispose();
                // ↑ここ

                Debug.WriteLine("end");
            };
            Startup += (_, __) => new MyWindow().Show();
        }
    }

    class MyWindow : Window
    {
        public MyWindow()
        {
            Loaded += (_, __) => App.Current.Shutdown();
        }
    }
}
