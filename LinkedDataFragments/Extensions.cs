namespace LinkedDataFragments
{
    using System.Collections.Generic;
    using System.Linq;
    using VDS.RDF;

    internal static class Extensions
    {
        internal static IEnumerable<INode> ObjectsOf(this INode predicate, GraphWrapperNode subject)
        {
            return
                from t in subject.Graph.GetTriplesWithSubjectPredicate(subject, predicate)
                select t.Object;
        }
    }
}