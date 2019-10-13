namespace LinkedDataFragments.TriplePatternFragments
{
    using System;
    using System.Collections.Generic;
    using LinkedDataFragments.Hydra;
    using Resta.UriTemplates;
    using VDS.RDF;

    internal class Parameters
    {
        private readonly IriTemplate template;
        private readonly INode subject;
        private readonly INode predicate;
        private readonly INode @object;

        internal Parameters(IriTemplate template, INode subject = null, INode predicate = null, INode @object = null)
        {
            if (template is null)
            {
                throw new ArgumentNullException(nameof(template));
            }

            if (subject is object && subject.NodeType != NodeType.Uri)
            {
                throw new ArgumentException("Subject can only be IRI", nameof(subject));
            }

            if (predicate is object && predicate.NodeType != NodeType.Uri)
            {
                throw new ArgumentException("Predicate can only be IRI", nameof(predicate));
            }

            if (@object is object && @object.NodeType != NodeType.Uri && @object.NodeType != NodeType.Literal)
            {
                throw new ArgumentException("Object can only be IRI or literal", nameof(@object));
            }

            this.template = template;
            this.subject = subject;
            this.predicate = predicate;
            this.@object = @object;
        }

        private Uri Uri
        {
            get
            {
                var uriTemplate = new UriTemplate(this.template.Template);
                var variables = new Dictionary<string, object>();
                var formatter = new ExplicitRepresentationFormatter();

                if (this.subject is object)
                {
                    variables.Add("subject", formatter.Format(this.subject));
                }

                if (this.predicate is object)
                {
                    variables.Add("predicate", formatter.Format(this.predicate));
                }

                if (this.@object is object)
                {
                    variables.Add("object", formatter.Format(this.@object));
                }

                return uriTemplate.ResolveUri(variables);
            }
        }

        public static implicit operator Uri(Parameters parameters)
        {
            return parameters.Uri;
        }
    }
}
