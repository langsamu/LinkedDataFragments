namespace LinkedDataFragments.TriplePatternFragments
{
    using System;
    using System.Collections.Generic;
    using LinkedDataFragments.Hydra;
    using VDS.RDF;

    public class Graph : VDS.RDF.Graph
    {
        private IriTemplate template;

        public Graph(string baseUri)
        {
            using var tripleStore = new TripleStore(UriFactory.Create(baseUri));
            this.template = tripleStore.Metadata.Search;
            this._triples = new TripleCollection(this.template);
        }

        public override bool Assert(Triple t)
        {
            throw new NotSupportedException("This graph is read-only.");
        }

        public override bool Assert(IEnumerable<Triple> ts)
        {
            throw new NotSupportedException("This graph is read-only.");
        }

        public override void Clear()
        {
            throw new NotSupportedException("This graph is read-only.");
        }

        public override bool Equals(IGraph g, out Dictionary<INode, INode> mapping)
        {
            if (g is Graph fragments)
            {
                if (this.template.Template == fragments.template.Template)
                {
                    mapping = new Dictionary<INode, INode>();
                    return true;
                }
            }

            return base.Equals(g, out mapping);
        }

        // TODO: Throw?
        public override IBlankNode GetBlankNode(string nodeId)
        {
            // No blanks in LDF
            return null;
        }

        public override void Merge(IGraph g, bool keepOriginalGraphUri)
        {
            throw new NotSupportedException("This graph is read-only.");
        }

        public override bool Retract(Triple t)
        {
            throw new NotSupportedException("This graph is read-only.");
        }

        public override bool Retract(IEnumerable<Triple> ts)
        {
            throw new NotSupportedException("This graph is read-only.");
        }
    }
}
