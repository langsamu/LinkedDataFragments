namespace LinkedDataFragments
{
    using VDS.RDF;
    using VDS.RDF.Parsing;

    internal static class Vocabulary
    {
        private static readonly NodeFactory Factory = new NodeFactory();

        private static IUriNode Node(string name) => Factory.CreateUriNode(UriFactory.Create(name));

        private static IUriNode Node(string baseUri, string name) => Node($"{baseUri}{name}");

        internal static class Hydra
        {
            private const string BaseUri = "http://www.w3.org/ns/hydra/core#";

            internal static IUriNode Next { get; } = Node(BaseUri, "next");

            internal static IUriNode Variable { get; } = Node(BaseUri, "variable");

            internal static IUriNode Property { get; } = Node(BaseUri, "property");

            internal static IUriNode Mapping { get; } = Node(BaseUri, "mapping");

            internal static IUriNode Search { get; } = Node(BaseUri, "search");

            internal static IUriNode Template { get; } = Node(BaseUri, "template");
        }

        internal static class Void
        {
            private const string BaseUri = "http://rdfs.org/ns/void#";

            internal static IUriNode Triples { get; } = Node(BaseUri, "triples");
        }

        internal static class Rdf
        {
            internal static IUriNode Subject { get; } = Node(RdfSpecsHelper.RdfSubject);

            internal static IUriNode Predicate { get; } = Node(RdfSpecsHelper.RdfPredicate);

            internal static IUriNode Object { get; } = Node(RdfSpecsHelper.RdfObject);
        }
    }
}
