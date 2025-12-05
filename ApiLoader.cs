using System;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CSharp;

namespace AutoEBookBuilder
{
    public static class ApiLoader
    {
        public static Dictionary<string, Type> Load(List<string> filePathList)
        {
            var apiMap = new Dictionary<string, Type>();
            CSharpCodeProvider provider = new CSharpCodeProvider();
            foreach (string fileName in filePathList) {
                try
                {
                    string code = File.ReadAllText(fileName);
                    CompilerParameters parameters = new CompilerParameters
                    {
                        GenerateExecutable = false,
                        GenerateInMemory = true,
                        TreatWarningsAsErrors = false
                    };

                    foreach (var line in code.Split('\n'))
                        if (line.TrimStart().StartsWith("using "))
                            parameters.ReferencedAssemblies.Add(line.Substring(6, line.Length - 8) + ".dll");
                        else
                            break;

                    CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
                    var fileType = Path.GetFileNameWithoutExtension(fileName);
                    if (results.Errors.Count == 0)
                        apiMap.Add(fileType.Substring(0, fileType.Length - 3).ToLower(), results.CompiledAssembly
                            .GetType("AutoEBookBuilder.APIs." + fileType));
                    else
                        foreach (CompilerError error in results.Errors)
                            Console.WriteLine($"Error ({error.ErrorNumber}): {error.ErrorText}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return apiMap;
        }
    }
}
