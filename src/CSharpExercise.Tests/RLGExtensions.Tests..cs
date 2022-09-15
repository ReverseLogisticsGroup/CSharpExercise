namespace CSharpExercise.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class RLGExtensions_Tests
{
	[Fact]
	public void RLGWhere()
	{
		var source = Enumerable.Range(1, 100);

		var myResult = source.RLGWhere(x => x % 2 == 1);
		var linqResult = source.Where(x => x % 2 == 1);

		Assert.Equal(linqResult, myResult);
	}

    [Fact]
    public void RLGWhereWithObject()
    {
        var source = Enumerable.Range(1, 100).Select(x => new {someValue = x});

        var myResult = source.RLGWhere(x => x.someValue % 2 == 1);
        var linqResult = source.Where(x => x.someValue % 2 == 1);

        Assert.Equal(linqResult, myResult);
    }
    [Fact]
    public void RLGWhereUsingSelectMany()
    {
        var source = Enumerable.Range(1, 10).Select(x => Enumerable.Range(1, 10));

        var myResult = source.RLGWhere(x => x % 2 == 1);
        var linqResult = source.SelectMany(x => x).Where(x => x % 2 == 1);

        Assert.Equal(linqResult, myResult);
    }
    [Fact]
    public void RLGSelect()
    {
        var source = Enumerable.Range(1, 100);

        var myResult = source.RLGSelect(x => x * 2);
        var linqResult = source.Select(x => x * 2);

        Assert.Equal(linqResult, myResult);
    }

    [Fact]
    public void RLGSelectWithObject()
    {
        var source = Enumerable.Range(1, 100).Select(x => new { someValue = x });

        var myResult = source.RLGSelect(x => x.someValue*2 );
        var linqResult = source.Select(x => x.someValue * 2);

        Assert.Equal(linqResult, myResult);
    }

    [Fact]
    public void RLGSelectUsingSelectMany()
    {
        var source = Enumerable.Range(1, 10).Select(x => Enumerable.Range(1,10));

        var myResult = source.RLGSelect(x => x * 2);
        var linqResult = source.SelectMany(x => x).Select(x => x * 2);

        Assert.Equal(linqResult, myResult);
    }


}