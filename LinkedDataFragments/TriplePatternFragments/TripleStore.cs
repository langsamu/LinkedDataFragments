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
            : base(new VDS.RDF.TripleStore())
        {
            this.uri = uri;
            this.LoadFromUri(uri);
        }

        internal Metadata Metadata
        {
            get
            {
                return (
                    from g in this.Graphs.Where(g => g.Name is object)
                    select new Metadata(g, this.uri))
                    .Single();
            }
        }

        internal IEnumerable<Triple> Data
        {
            get
            {
                if (!this.HasGraph((IRefNode)null))
                {
                    return System.Linq.Enumerable.Empty<Triple>();
                }

                return this.Graphs[(IRefNode)null].Triples;
            }
        }
    }
}
