namespace LinkedDataFragments.Hydra
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using VDS.RDF;
    using VDS.RDF.Nodes;

    public class IriTemplate : GraphWrapperNode
    {
        [DebuggerStepThrough]
        internal IriTemplate(INode node, IGraph graph)
            : base(node, graph)
        {
        }

        public string SubjectVariable
        {
            get
            {
                return this.SelectMapping(Vocabulary.Rdf.Subject);
            }
        }

        public string PredicateVariable
        {
            get
            {
                return this.SelectMapping(Vocabulary.Rdf.Predicate);
            }
        }

        public string ObjectVariable
        {
            get
            {
                return this.SelectMapping(Vocabulary.Rdf.Object);
            }
        }

        public string Template
        {
            get
            {
                return Vocabulary.Hydra.Template.ObjectsOf(this).SingleOrDefault()?.AsValuedNode().AsString();
            }
        }

        private IEnumerable<IriTemplateMapping> Mappings
        {
            get
            {
                return
                    from n in Vocabulary.Hydra.Mapping.ObjectsOf(this)
                    select new IriTemplateMapping(n, this.Graph);
            }
        }

        private string SelectMapping(IUriNode property)
        {
            return (
                from m in this.Mappings
                where m.Property.Equals(property)
                select m.Variable)
                .SingleOrDefault();
        }
    }
}
