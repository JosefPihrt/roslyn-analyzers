﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeQuality.Analyzers.ApiDesignGuidelines;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.CodeQuality.CSharp.Analyzers.ApiDesignGuidelines
{
    /// <summary>
    /// <para>CA1019: Define accessors for attribute arguments</para>
    /// <para>
    /// Cause:
    /// In its constructor, an attribute defines arguments that do not have corresponding properties.
    /// </para>
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class CSharpDefineAccessorsForAttributeArgumentsAnalyzer : DefineAccessorsForAttributeArgumentsAnalyzer
    {
        protected override bool IsAssignableTo(
            [NotNullWhen(returnValue: true)] ITypeSymbol? fromSymbol,
            [NotNullWhen(returnValue: true)] ITypeSymbol? toSymbol,
            Compilation compilation)
        {
            return fromSymbol != null &&
                toSymbol != null &&
                ((CSharpCompilation)compilation).ClassifyConversion(fromSymbol, toSymbol).IsImplicit;
        }
    }
}
