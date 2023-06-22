 var output = new Dictionary<string, string>();

            var csFilePath = @"C:\Users\Haadv\source\repos\ConsoleApp6\TestProgram.cs";
            var csFileContent = File.ReadAllText(csFilePath);
            SyntaxTree tree = CSharpSyntaxTree.ParseText(csFileContent);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            var nds = (NamespaceDeclarationSyntax)root.Members[0];
            var cds = (ClassDeclarationSyntax)nds.Members[0];

            foreach (var ds in cds.Members)
            {
                //Only take methods into consideration
                if (ds is MethodDeclarationSyntax)
                {
                    var mds = (MethodDeclarationSyntax)ds;

                    //Method name
                    var methodName = ((SyntaxToken)mds.Identifier).ValueText;

                    //Method body (including curly braces)
                    var methodBody = mds.Body.ToString();

                    output.Add(methodName, methodBody);
                }
            }
