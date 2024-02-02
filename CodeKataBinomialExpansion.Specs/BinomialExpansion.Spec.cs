using Machine.Specifications;

namespace CodeKataBinomialExpansion.Specs
{
    public class When_Parsing_String_Equation
    {
        Establish context = () =>
        {
            inputs = new string[]{
                "(2x+3)^0",
                "(x-1)^1",
                "(x-1)^2"
            };
            expected = new decimal[][]
            {
                new decimal[]
                {
                    2,3,0
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
                "(x+1)^2",
                "(x-1)^0",
                "(x-1)^1",
                "(x-1)^2",
            };
            expected = new string[]
            {
                "x^2+2x+1",
                "1",
                "x-1",
                "x^2-2x+1",
            };
            answers = new string[inputs.Length];
        };

        Because of = () =>
        {
            for(var i=0; i < inputs.Length; i++)
            {
                answers[i] = Expander.Expand(inputs[i]);
            }
        };

        It Should_Return_Values_In_A_String_Array = () => answers.ShouldEqual(expected);
        It Should_Return_An_Answer_For_Each_Input = () =>
        {
            for (var i = 0; i < answers.Length; i++)
            {
                answers[i].ShouldEqual(expected[i]);
            }
        };

        private static string[] inputs;
        private static string[] expected;
        private static string[] answers;
    }

    public class When_Finding_A_Coefficient
    {
        Establish context = () =>
        {
            input = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            expect = new int[][] 
            {
                new int[] { 1 },
                new int[] { 1,1 },
                new int[] { 1,2,1 },
                new int[] { 1,3,3,1},
                new int[] { 1,4,6,4,1},
                new int[] { 1,5,10,10,5,1},
                new int[] { 1,6,15,20,15,6,1},
                new int[] { 1,7,21,35,35,21,7,1},
                new int[] { 1,8,28,56,70,56,28,8,1}
            };
            answers = new int[input.Length][];
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answers[i] = Expander.FindCoefficients(input[i]);
            }
        };

        //It Should_Return_Correct_Results_In_An_Int_Array = () => answers.ShouldEqual(expect);
        It Should_Return_Expected_Results = () =>
        {
            for (var i = 0; i < answers.Length; i++)
            {
                for(var j=0; j < answers[i].Length; j++)
                {
                    var answer = answers[i][j];
                    var expected = expect[i][j];
                    answers[i][j].ShouldEqual(expect[i][j]);
                }
            }
        };

        private static int[] input;
        private static int[][] expect;
        private static int[][] answers;
    }

    public class When_Calculating_A_Factorial
    {
        Establish context = () =>
        {
            input = new int[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            expect = new int[] { 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            answers = new int[input.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answers[i] = Expander.Factorialize(input[i]);
            }
        };

        It Should_Return_Correct_Answer = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answers[i].ShouldEqual(expect[i]);
            }
        };

        private static int[] input;
        private static int[] expect;
        private static int[] answers;
    }
}