# ReactiveProperty7.6.1_DisposeException
Occurred InvalidOperationException when dispose on Rp 7.6.1.

ReactiveProperty の Dispose時に System.InvalidOperationException: `Sequence contains no elements` が表示される。

RpのNuget 7.6.0 ならOKで、7.6.1 で発生する。 7.6.1 から依存Lib が .NET5 にアップ対応してるっぽい。

FirstAsync() も影響してるっぽい。

会社PCでは発生して、家PCだと発生しない。なぜ？
