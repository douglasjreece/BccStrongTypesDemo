using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExampleSourceGenerator
{
    [Generator]
    internal class Generator : ISourceGenerator
    {
        const bool debug = false;

        public void Execute(GeneratorExecutionContext context)
        {
            static string GenerateCode(SyntaxReceiver.Entry entry)
            {
                StringBuilder code = new();
                code.AppendLine($"using System;");
                code.AppendLine($"using System.Text.Json;");
                code.AppendLine($"namespace {entry.NamespaceIdentifier}");
                code.AppendLine( "{");
                code.AppendLine($"    public partial {entry.Type.ToString().ToLower()} {entry.TypeIdentifier}");
                code.AppendLine( "    {");
                code.AppendLine($"        public string ToJson()");
                code.AppendLine( "        {");
                code.AppendLine($"            return JsonSerializer.Serialize(this);");
                code.AppendLine( "        }");
                code.AppendLine( "    }");
                code.AppendLine( "}");
                return code.ToString();
            }

            SyntaxReceiver syntaxReceiver = (SyntaxReceiver)context.SyntaxContextReceiver!;
            foreach (var entry in syntaxReceiver.Entries)
            {
                string source = GenerateCode(entry);
                string filename = $"StrongType_{entry.NamespaceIdentifier}_{entry.TypeIdentifier}.g.cs";
                context.AddSource(filename, source);
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            if (debug && !Debugger.IsAttached)
            {
                Debugger.Launch();
            }

            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        class SyntaxReceiver : ISyntaxContextReceiver
        {
            public enum NodeType { Neither, Class, Struct }

            public class Entry
            {
                public string NamespaceIdentifier { get; set; }
                public string TypeIdentifier { get; set; }
                public NodeType Type { get; set; }
            }

            public List<Entry> Entries = new();
            
            private string namespaceIdentifier; // to track the current namespace

            public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
            {
                if (context.Node is NamespaceDeclarationSyntax namespaceDecl) // node is namespace
                {
                    namespaceIdentifier = namespaceDecl.Name.ToString();
                }
                else
                {
                    NodeType type = NodeType.Neither;
                    string typeIdentifier = string.Empty;
                    SyntaxList<AttributeListSyntax>? list = null;

                    if (context.Node is StructDeclarationSyntax structdecl) // node is struct
                    {
                        type = NodeType.Struct;
                        typeIdentifier = structdecl.Identifier.Text;
                        list = structdecl.AttributeLists;
                    }
                    else if (context.Node is ClassDeclarationSyntax classdecl) // node is class
                    {
                        type = NodeType.Class;
                        typeIdentifier = classdecl.Identifier.Text;
                        list = classdecl.AttributeLists;
                    }

                    // Check for ToJson attribute
                    if (type != NodeType.Neither)
                    {
                        var hasAttribute = 
                            (list != null) && 
                            (list.Value.Any(x => x.Attributes.Any(y => y.Name.ToString() == "ToJson")));

                        if (hasAttribute)
                        {
                            Entries.Add(new Entry { NamespaceIdentifier = namespaceIdentifier, TypeIdentifier = typeIdentifier, Type = type });
                        }
                    }
                }
            }
        }
    }
}
