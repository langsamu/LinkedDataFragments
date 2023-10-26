namespace LinkedDataFragments.TriplePatternFragments
{
    using System;
    using System.Linq;
    using LinkedDataFragments.Hydra;
    using VDS.RDF;
    using VDS.RDF.Nodes;

    internal class Metadata : WrapperGraph
    {
        private readonly Uri uri;

        internal Metadata(IGraph original, Uri uri)
            : base(original)
        {
            this.uri = uri;
            this.Fragment = new GraphWrapperNode(this.CreateUriNode(this.uri), this);
        }

        internal IriTemplate Search
        {
            get
            {
                return this.GetTriplesWithPredicate(Vocabulary.Hydra.Search).Select(t => new IriTemplate(t.Object, this)).SingleOrDefault();
            }
        }

        internal Uri NextPageUri
        {
            get
            {
                return Vocabulary.Hydra.Next.ObjectsOf(this.Fragment).Cast<IUriNode>().SingleOrDefault()?.Uri;
            }
        }

        internal long? TripleCount
        {
            get
            {
                return Vocabulary.Void.Triples.ObjectsOf(this.Fragment).SingleOrDefault()?.AsValuedNode().AsInteger();
            }
        }

        private GraphWrapperNode Fragment { get; set; }
    }
}
