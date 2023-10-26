namespace LinkedDataFragments.Hydra
{
    using System.Diagnostics;
    using System.Linq;
    using VDS.RDF;
    using VDS.RDF.Nodes;

    internal class IriTemplateMapping : GraphWrapperNode
    {
        [DebuggerStepThrough]
        internal IriTemplateMapping(INode node, IGraph graph)
            : base(node, graph)
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
