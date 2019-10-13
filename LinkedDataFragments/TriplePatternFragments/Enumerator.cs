namespace LinkedDataFragments.TriplePatternFragments
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using VDS.RDF;

    internal class Enumerator : IEnumerator<Triple>
    {
        private IEnumerator<Triple> e;
        private Uri uri;

        internal Enumerator(Uri uri)
        {
            this.uri = uri;
        }

        Triple IEnumerator<Triple>.Current => this.e.Current;

        object IEnumerator.Current => ((IEnumerator<Triple>)this).Current;

        void IDisposable.Dispose()
        {
            this.e?.Dispose();
        }

        bool IEnumerator.MoveNext()
        {
            if (this.e is null)
            {
                using var ts = new TripleStore(this.uri);

                this.e = ts.Data.GetEnumerator();
                this.uri = ts.Metadata.NextPageUri;
            }

            if (this.e.MoveNext())
            {
                return true;
            }

            if (this.uri is object)
            {
                this.e.Dispose();
                this.e = null;

                return ((IEnumerator)this).MoveNext();
            }

            return false;
        }

        void IEnumerator.Reset()
        {
            throw new NotSupportedException("This enumerator cannot be reset.");
        }
    }
}
