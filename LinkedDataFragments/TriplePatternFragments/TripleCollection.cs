namespace LinkedDataFragments.TriplePatternFragments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LinkedDataFragments.Hydra;
    using VDS.RDF;

    internal class TripleCollection : BaseTripleCollection
    {
        private readonly IriTemplate template;

        internal TripleCollection(IriTemplate template)
        {
            this.template = template;
        }

        public override int Count
        {
            get
            {
                using var ts = new TripleStore(new Parameters(this.template));
                return (int)ts.Metadata.TripleCount;
            }
        }

        public override IEnumerable<INode> ObjectNodes
        {
            get
            {
                return this.Select(t => t.Object).Distinct();
            }
        }

        public override IEnumerable<INode> PredicateNodes
        {
            get
            {
                return this.Select(t => t.Predicate).Distinct();
            }
        }

        public override IEnumerable<INode> SubjectNodes
        {
            get
            {
                return this.Select(t => t.Subject).Distinct();
            }
        }

        public override Triple this[Triple t]
        {
            get
            {
                if (this.Contains(t))
                {
                    return t;
                }

                throw new KeyNotFoundException();
            }
        }

        public override bool Contains(Triple t)
        {
            return new Enumerable(new Parameters(this.template, t.Subject, t.Predicate, t.Object)).Any();
        }

        public override void Dispose()
        {
        }

        public override IEnumerator<Triple> GetEnumerator()
        {
            return new Enumerator(new Parameters(this.template));
        }

        public override IEnumerable<Triple> WithObject(INode obj)
        {
            return new Enumerable(new Parameters(this.template, @object: obj));
        }

        public override IEnumerable<Triple> WithPredicate(INode pred)
        {
            return new Enumerable(new Parameters(this.template, predicate: pred));
        }

        public override IEnumerable<Triple> WithPredicateObject(INode pred, INode obj)
        {
            return new Enumerable(new Parameters(this.template, predicate: pred, @object: obj));
        }

        public override IEnumerable<Triple> WithSubject(INode subj)
        {
            return new Enumerable(new Parameters(this.template, subj));
        }

        public override IEnumerable<Triple> WithSubjectObject(INode subj, INode obj)
        {
            return new Enumerable(new Parameters(this.template, subj, @object: obj));
        }

        public override IEnumerable<Triple> WithSubjectPredicate(INode subj, INode pred)
        {
            return new Enumerable(new Parameters(this.template, subj, pred));
        }

        protected override bool Add(Triple t)
        {
            throw new NotSupportedException("This triple collection is read-only.");
        }

        protected override bool Delete(Triple t)
        {
            throw new NotSupportedException("This triple collection is read-only.");
        }
    }
}
