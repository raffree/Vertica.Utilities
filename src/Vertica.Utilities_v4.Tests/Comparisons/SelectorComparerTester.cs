﻿using System;
using NUnit.Framework;
using Vertica.Utilities_v4.Comparisons;
using Vertica.Utilities_v4.Tests.Comparisons.Support;

namespace Vertica.Utilities_v4.Tests.Comparisons
{
	[TestFixture]
	public class SelectorComparerTester
	{
		[Test]
		public void Ctor_DefaultsToAscending()
		{
			var subject = new SelectorComparer<ComparisonSubject, int>(s => s.Property2);
			Assert.That(subject.SortDirection, Is.EqualTo(Direction.Ascending));
		}

		[Test]
		public void Ctor_SetsDirection()
		{
			var subject = new SelectorComparer<ComparisonSubject, int>(s => s.Property2, Direction.Descending);
			Assert.That(subject.SortDirection, Is.EqualTo(Direction.Descending));
		}

		[Test]
		public void Compare_ComparedTheSelectedProperty_HonoringDirection()
		{
			var subject = new SelectorComparer<ComparisonSubject, int>(s => s.Property2, Direction.Ascending);
			Assert.That(subject.Compare(ComparisonSubject.One, ComparisonSubject.Two), Is.LessThan(0));

			subject = new SelectorComparer<ComparisonSubject, int>(s => s.Property2, Direction.Descending);
			Assert.That(subject.Compare(ComparisonSubject.One, ComparisonSubject.Two), Is.GreaterThan(0));
		}

		[Test]
		public void Comparison_HonorsDirection()
		{
			Comparison<ComparisonSubject> comparison = new SelectorComparer<ComparisonSubject, int>(
				s => s.Property2, Direction.Ascending).Comparison;

			Assert.That(comparison(ComparisonSubject.One, ComparisonSubject.Two), Is.LessThan(0));

			comparison = new SelectorComparer<ComparisonSubject, int>(
				s => s.Property2, Direction.Descending).Comparison;

			Assert.That(comparison(ComparisonSubject.One, ComparisonSubject.Two), Is.GreaterThan(0));
		}
	}
}
