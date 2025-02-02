﻿using System.Threading.Tasks;
using LanguageExt.Pipes;
using LanguageExt.Sys.Test;
using Xunit;

using static LanguageExt.Pipes.Proxy;
using static LanguageExt.Prelude;

namespace LanguageExt.Tests;

public class PipesTests
{
    [Fact]
    public Task MergeSynchronousProducersSucceeds() =>
        compose(
            Producer.merge<Runtime, int, Unit>(
                yield(1),
                yield(1)),
            awaiting<int>().Map(ignore))
        .RunEffect()
        .RunUnit(Runtime.New())
        .AsTask();
}
