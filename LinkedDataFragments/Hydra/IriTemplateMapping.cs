namespace LinkedDataFragments.Hydra
{
    using System.Diagnostics;
    using System.Linq;
    using VDS.RDF;
    using VDS.RDF.Nodes;

    internal class IriTemplateMapping : WrapperNode
    {
        [DebuggerStepThrough]
        internal IriTemplateMapping(INode node)
            : base(node)
        {
        }

        internal string Variable
        {
            get
            {
                return Vocabulary.Hydra.Variable.ObjectsOf(this).SingleOrDefault()?.AsValuedNode().AsString();
            }
        }

        internal INode Property
        {
            get
            {
                return Vocabulary.Hydra.Property.ObjectsOf(this).SingleOrDefault();
            }
        }
    }
}
