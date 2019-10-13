namespace ConsoleApp1
{
    using LinkedDataFragments.Tests;

    class Program
    {
        static void Main(string[] args)
        {
            var tests = new GraphTests();

            tests.Contains();
            tests.Equals();
            tests.GetTriplesWithObject();
            tests.GetTriplesWithPredicate();
            tests.GetTriplesWithPredicateObject();
            tests.GetTriplesWithSubject();
            tests.GetTriplesWithSubjectObject();
            tests.GetTriplesWithSubjectPredicate();
            tests.ObjectNodes();
            tests.PredicateNodes();
            tests.Sparql();
            tests.SubjectNodes();
            tests.Triples();
            tests.TriplesCount();
        }
    }
}
