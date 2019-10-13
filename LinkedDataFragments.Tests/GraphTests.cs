namespace LinkedDataFragments.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VDS.RDF;
    using VDS.RDF.Parsing;
    using VDS.RDF.Query;
    using VDS.RDF.Writing.Formatting;

    [TestClass]
    public class GraphTests
    {
        private static readonly NodeFactory factory = new NodeFactory();

        [TestMethod]
        public void ContainsTriple()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var s = UriNode("http://dbpedia.org/ontology/extinctionDate");
            var p = UriNode("http://www.w3.org/1999/02/22-rdf-syntax-ns#type");
            var o = UriNode("http://www.w3.org/1999/02/22-rdf-syntax-ns#Property");
            var t = new Triple(s, p, o);

            Console.WriteLine(g.ContainsTriple(t));
        }

        [TestMethod]
        public void Equals()
        {
            using var g1 = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            using var g2 = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var equals = g1.Equals(g2);

            Console.WriteLine(equals);
        }

        [TestMethod]
        public void GetTriplesWithObject()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var o = LiteralNode("1997-02-04", XmlSpecsHelper.XmlSchemaDataTypeDate);
            var triples = g.GetTriplesWithObject(o);

            foreach (var triple in triples)
            {
                Console.WriteLine(triple);
            }
        }

        [TestMethod]
        public void GetTriplesWithPredicate()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var p = UriNode("http://dbpedia.org/ontology/extinctionDate");
            var triples = g.GetTriplesWithPredicate(p);

            foreach (var triple in triples)
            {
                Console.WriteLine(triple);
            }
        }

        [TestMethod]
        public void GetTriplesWithPredicateObject()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var p = UriNode("http://dbpedia.org/ontology/extinctionDate");
            var o = LiteralNode("2011-10-05", XmlSpecsHelper.XmlSchemaDataTypeDate);
            var triples = g.GetTriplesWithPredicateObject(p, o);

            foreach (var triple in triples)
            {
                Console.WriteLine(triple);
            }
        }

        [TestMethod]
        public void GetTriplesWithSubject()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var s = UriNode("http://0-access.newspaperarchive.com.topcat.switchinc.org/Viewer.aspx?img=7578853");
            var triples = g.GetTriplesWithSubject(s);

            foreach (var triple in triples)
            {
                Console.WriteLine(triple);
            }
        }

        [TestMethod]
        public void GetTriplesWithSubjectObject()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var s = UriNode("http://dbpedia.org/resource/123_Democratic_Alliance");
            var o = LiteralNode("707366241", XmlSpecsHelper.XmlSchemaDataTypeInteger);
            var triples = g.GetTriplesWithSubjectObject(s, o);

            foreach (var triple in triples)
            {
                Console.WriteLine(triple);
            }
        }

        [TestMethod]
        public void GetTriplesWithSubjectPredicate()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var s = UriNode("http://dbpedia.org/resource/123_Democratic_Alliance");
            var p = UriNode("http://dbpedia.org/ontology/extinctionDate");
            var triples = g.GetTriplesWithSubjectPredicate(s, p);

            foreach (var triple in triples)
            {
                Console.WriteLine(triple);
            }
        }

        [TestMethod]
        public void ObjectNodes()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            using var triples = g.Triples.ObjectNodes.GetEnumerator();

            for (int i = 0; i < 50; i++)
            {
                triples.MoveNext();
                Console.WriteLine(triples.Current);
            }
        }

        [TestMethod]
        public void PredicateNodes()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            using var triples = g.Triples.PredicateNodes.GetEnumerator();

            for (int i = 0; i < 50; i++)
            {
                triples.MoveNext();
                Console.WriteLine(triples.Current);
            }
        }

        [TestMethod]
        public void Sparql()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var results = (SparqlResultSet)g.ExecuteQuery(@"
SELECT *
WHERE {
    <http://0-access.newspaperarchive.com.topcat.switchinc.org/Viewer.aspx?img=7578853> ?p ?o .
}
");

            var formatter = new SparqlFormatter();
            foreach (var result in results)
            {
                Console.WriteLine(formatter.Format(result));
            }
        }

        [TestMethod]
        public void SubjectNodes()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            using var triples = g.Triples.SubjectNodes.GetEnumerator();

            for (int i = 0; i < 50; i++)
            {
                triples.MoveNext();
                Console.WriteLine(triples.Current);
            }
        }

        [TestMethod]
        public void Triples()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            using var triples = g.Triples.GetEnumerator();

            for (int i = 0; i < 1000; i++)
            {
                triples.MoveNext();
                Console.WriteLine(triples.Current);
            }
        }

        [TestMethod]
        public void TriplesCount()
        {
            using var g = new TriplePatternFragments.Graph("https://fragments.dbpedia.org/2016-04/en");
            var count = g.Triples.Count;

            Console.WriteLine(count);
        }

        private static IUriNode UriNode(string uri)
        {
            return factory.CreateUriNode(UriFactory.Create(uri));
        }

        private static ILiteralNode LiteralNode(string literal, string datatype)
        {
            return factory.CreateLiteralNode(literal, UriFactory.Create(datatype));
        }
    }
}
