namespace LinkedDataFragments.TriplePatternFragments
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using VDS.RDF;

    internal class Enumerable : IEnumerable<Triple>
    {
        private readonly Uri uri;

        internal Enumerable(Uri uri)
        {
            this.uri = uri;
        }

        IEnumerator<Triple> IEnumerable<Triple>.GetEnumerator() => new Enumerator(this.uri);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<Triple>)this).GetEnumerator();
    }
}
