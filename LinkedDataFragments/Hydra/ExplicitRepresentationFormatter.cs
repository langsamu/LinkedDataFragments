namespace LinkedDataFragments.Hydra
{
    using System;
    using System.Globalization;
    using System.Text;
    using VDS.RDF;
    using VDS.RDF.Writing;
    using VDS.RDF.Writing.Formatting;

    internal class ExplicitRepresentationFormatter : INodeFormatter
    {
        public string Format(INode n)
        {
            switch (n)
            {
                case IUriNode uriNode:
                    return uriNode.Uri.AbsoluteUri;

                case ILiteralNode literalNode:
                    var builder = new StringBuilder();
                    builder.AppendFormat(CultureInfo.InvariantCulture, "\"{0}\"", literalNode.Value);

                    if (literalNode.DataType is object)
                    {
                        builder.AppendFormat(CultureInfo.InvariantCulture, "^^{0}", literalNode.DataType.AbsoluteUri);
                    }

                    if (!string.IsNullOrEmpty(literalNode.Language))
                    {
                        builder.AppendFormat(CultureInfo.InvariantCulture, "@{0}", literalNode.Language);
                    }

                    return builder.ToString();

                default:
                    throw new NotSupportedException("Only IRI and literal nodes are supported.");
            }
        }

        string INodeFormatter.Format(INode n, TripleSegment? segment)
        {
            return this.Format(n);
        }
    }
}
