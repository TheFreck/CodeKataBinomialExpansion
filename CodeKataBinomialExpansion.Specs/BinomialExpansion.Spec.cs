using Machine.Specifications;

namespace CodeKataBinomialExpansion.Specs
{
    public class When_Parsing_String_Equation
    {
        Establish context = () =>
        {
            inputs = new string[]{
                "(x-1)^0",
                "(x-1)^1",
                "(x-1)^2"
            };
            expected = new decimal[][]
            {
                new decimal[]
                {
                    1,-1,0
                },
                new decimal[]
                {
                    1,-1,1
                },
                new decimal[]
                {
                    1,-1,2
                }
            };
            answers = new decimal[inputs.Length][];
        };

        Because of = () =>
        {
            for (var i = 0; i < inputs.Length; i++)
            {
                answers[i] = Expander.Parse(inputs[i]);
            }
        };

        It Should_Return_X_And_N_Values = () =>
        {
            for (var i = 0; i < answers.Length; i++)
            {
                answers[i][0].ShouldEqual(expected[i][0]);
                answers[i][1].ShouldEqual(expected[i][1]);
            }
        };

        private static string[] inputs;
        private static decimal[][] expected;
        private static decimal[][] answers;
    }

    public class When_Expanding
    {
        Establish context = () =>
        {
            inputs = new string[]{
                "(x-1)^0",
                "(x-1)^1",
                "(x-1)^2"
            };
            expected = new string[]
            {
                "1",
                "x-1",
                "x^2-2x+1"
            };
            answers = new string[inputs.Length];
        };


        private static string[] inputs;
        private static string[] expected;
        private static string[] answers;
    }
}