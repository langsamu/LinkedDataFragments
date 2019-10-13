namespace LinkedDataFragments.TriplePatternFragments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VDS.RDF;

    internal class TripleStore : WrapperTripleStore
    {
        private readonly Uri uri;

        internal TripleStore(Uri uri)
            : base()
        {
            this.uri = uri;
            this.LoadFromUri(uri);
        }

        internal Metadata Metadata
        {
            get
            {
                return (
                    from g in this.Graphs.Where(g => g.BaseUri is object)
                    select new Metadata(g, this.uri))
                    .Single();
            }
        }

        internal IEnumerable<Triple> Data
        {
            get
            {
                if (!this.HasGraph(null))
                {
                    return System.Linq.Enumerable.Empty<Triple>();
                }

                return this.Graphs[null].Triples;
            }
        }
    }
}
