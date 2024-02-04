using CodeKataBinomialExpansion;

	var keepGoing = false;
	Console.WriteLine("Enter a polynomial in the form of (ax+b)^n to get its expanded form");
	do
	{
		var polynomial = Console.ReadLine();
		Console.WriteLine(Expander.Expand(polynomial));
		Console.WriteLine("Would you like to enter another polynomial? y/n");
		keepGoing = Console.ReadLine().ToLower() == "y";
	} while (keepGoing);
	Console.WriteLine("Ok. Love you. Bye bye");
