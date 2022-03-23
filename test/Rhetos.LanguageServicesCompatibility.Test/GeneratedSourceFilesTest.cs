using Rhetos.Deployment;
using Rhetos.Dsl;
using Rhetos.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Rhetos.LanguageServicesCompatibility.Test
{
    public class GeneratedSyntaxFilesTest
    {
        [Fact]
        public void DslParserFromSyntaxFiles()
        {
            string testAppFolder = Path.GetFullPath(Path.Combine("..", "..", "..", "..", "TestApp"));

            var rhetosBuildEnvironment = new RhetosBuildEnvironment
            {
                CacheFolder = Path.Combine(testAppFolder, "obj", "Rhetos")
            };

            var logProvider = new ConsoleLogProvider();

            var dslSyntaxFile = new DslSyntaxFile(rhetosBuildEnvironment, logProvider);
            var dslSyntax = dslSyntaxFile.Load();
            var lazyDslSyntax = new Lazy<DslSyntax>(() => dslSyntax);

            var filesUtility = new FilesUtility(logProvider);
            var dslFiles = Directory.GetFiles(Path.Combine(testAppFolder, "DslScripts"))
                .Select(path => new ContentFile { InPackagePath = Path.GetRelativePath(testAppFolder, path), PhysicalPath = path })
                .ToList();
            var dslPackage = new InstalledPackage("TestApp", "1", Array.Empty<PackageRequest>(), testAppFolder, dslFiles);
            var installedPackages = new InstalledPackages { Packages = new List<InstalledPackage> { dslPackage } };

            IDslScriptsProvider dslScriptsProvider = new DiskDslScriptLoader(installedPackages, filesUtility);
            ITokenizer tokenizer = new Tokenizer(dslScriptsProvider, filesUtility, lazyDslSyntax);

            IDslParser dslParser = new DslParser(tokenizer, lazyDslSyntax, logProvider);
            var concepts = dslParser.GetConcepts();
            Assert.Equal("Entity (Module 'Test') 'SimpleEntity', Module 'Test'", Report(concepts));
        }

        private string Report(IEnumerable<ConceptSyntaxNode> concepts)
        {
            return string.Join(", ", concepts.Select(Report).OrderBy(x => x));
        }

        private string Report(ConceptSyntaxNode concept)
        {
            var report = new StringBuilder(concept.Concept.Keyword);
            foreach (var parameter in concept.Parameters)
                report.Append(' ').Append(Report(parameter));
            return report.ToString();
        }

        private string Report(object parameter)
        {
            if (parameter is string s)
                return $"'{s}'";
            else if (parameter is ConceptSyntaxNode node)
                return $"({Report(node)})";
            else
                return parameter.GetType().ToString();
        }
    }
}
