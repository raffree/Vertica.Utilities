﻿using System;
using System.Linq;
using NUnit.Framework;
using Vertica.Utilities_v4.Collections;
using Vertica.Utilities_v4.Extensions.EnumerableExt;
using Vertica.Utilities_v4.Tests.Collections.Support;

namespace Vertica.Utilities_v4.Tests.Collections
{
	[TestFixture]
	public class TreeTester
	{
		private static readonly Category c1 = new Category { Id = 1 },
			c2 = new Category { Id = 2 },
			c3 = new Category { Id = 3, ParentId = 1 },
			c4 = new Category { Id = 4, ParentId = 5 };

		[Test]
		public void ToTree_BuildsATree_OfWrappedCategories()
		{
			var categories = new[] { c1, c2, c3, c4 };

			Tree<Category, int> tree = categories.ToTree(
				c => c.Id,
				(c, p) => c.ParentId.HasValue ? p.Value(c.ParentId.Value) : p.None);

			Assert.That(tree.Count(), Is.EqualTo(2));
			Assert.That(tree.ElementAt(0).Model, Is.SameAs(c1));
			Assert.That(tree.ElementAt(1).Model, Is.SameAs(c2));

			Assert.That(tree.ElementAt(0).Count(), Is.EqualTo(1));
			Assert.That(tree.ElementAt(0).ElementAt(0).Model, Is.SameAs(c3));
		}

		[Test]
		public void Orphans_NodesWithoutParent_GoToAnotherStructure()
		{
			var categories = new[] { c1, c2, c3, c4 };

			Tree<Category, int> tree = categories.ToTree(
				c => c.Id, 
				(c, p) => c.ParentId.HasValue ? p.Value(c.ParentId.Value) : p.None);

			Assert.That(tree.Orphans().Count(), Is.EqualTo(1));
			Assert.That(tree.Orphans().ElementAt(0), Is.EqualTo(c4));
		}

		[Test]
		public void Indexer_NodeKeysInTree_NodeReference()
		{
			var categories = new[] { c1, c2, c3, c4 };

			Tree<Category, int> tree = categories.ToTree(
				c => c.Id,
				(c, p) => c.ParentId.HasValue ? p.Value(c.ParentId.Value) : p.None);

			Assert.That(tree[1], Is.Not.Null);
			Assert.That(tree[1].Model, Is.SameAs(c1));
		}

		[Test]
		public void Indexer_NodeKeysNotInTree_Null()
		{
			var categories = new[] { c1, c2, c3, c4 };

			Tree<Category, int> tree = categories.ToTree(c => c.Id, (c, p) => c.ParentId.HasValue ? p.Value(c.ParentId.Value) : p.None);

			Assert.That(tree[4], Is.Null, "c4 is an orphan");
			Assert.That(tree[42], Is.Null, "c42 does not even exist");
		}

		[Test]
		public void TryGet_NodeKeysInTree_TrueAndNodeReference()
		{
			var categories = new[] { c1, c2, c3, c4 };

			Tree<Category, int> tree = categories.ToTree(
				c => c.Id,
				(c, p) => c.ParentId.HasValue ? p.Value(c.ParentId.Value) : p.None);

			TreeNode<Category> node;
			Assert.That(tree.TryGet(3, out node), Is.True);
			Assert.That(node.Model, Is.SameAs(c3));
		}

		[Test]
		public void TryGet_NodeKeysNotInTree_FalseAndNull()
		{
			var categories = new[] { c1, c2, c3, c4 };

			Tree<Category, int> tree = categories.ToTree(
				c => c.Id,
				(c, p) => c.ParentId.HasValue ? p.Value(c.ParentId.Value) : p.None);

			TreeNode<Category> node;
			Assert.That(tree.TryGet(4, out node), Is.False, "c4 is an orphan");
			Assert.That(tree.TryGet(42, out node), Is.False, "c42 does not even exist");
		}

		[Test]
		public void Build_Family_Tree_Of_Men_With_Projection()
		{
			var members = new[]
			{
				new FamilyMember { Name = "Son", ParentName = "Dad"},
				new FamilyMember { Name = "Grand Dad" },
				new FamilyMember { Name = "Dad", ParentName = "Grand dad" }
			};

			Tree<FamilyMember, string, string> tree = members.ToTree(
				x => x.Name, 
				(x, p) => x.ParentName != null ? p.Value(x.ParentName) : p.None, 
				x => x.Name, 
				StringComparer.OrdinalIgnoreCase);

			Assert.That(tree.Count(), Is.EqualTo(1));
			Assert.That(tree.ElementAt(0).Model, Is.EqualTo("Grand Dad"));

			Assert.That(tree.ElementAt(0).Count(), Is.EqualTo(1));
			Assert.That(tree.ElementAt(0).ElementAt(0).Model, Is.EqualTo("Dad"));

			Assert.That(tree.ElementAt(0).ElementAt(0).Count(), Is.EqualTo(1));
			Assert.That(tree.ElementAt(0).ElementAt(0).ElementAt(0).Model, Is.EqualTo("Son"));
			Assert.That(tree.ElementAt(0).ElementAt(0).ElementAt(0).Parent.Model, Is.EqualTo("Dad"));
			Assert.That(tree.ElementAt(0).ElementAt(0).ElementAt(0).Parent.Parent.Model, Is.EqualTo("Grand Dad"));

			CollectionAssert.AreEqual(tree["Grand Dad"].Breadcrumb(), new[] { "Grand Dad" });
			CollectionAssert.AreEqual(tree["dad"].Breadcrumb(), new[] { "Grand Dad", "Dad" });
			CollectionAssert.AreEqual(tree["Son"].Breadcrumb(), new[] {"Grand Dad", "Dad", "Son"});
		}
	}
}