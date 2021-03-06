﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeQuality.Analyzers.ApiDesignGuidelines;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.CodeQuality.CSharp.Analyzers.ApiDesignGuidelines
{
    /// <summary>
    /// CA1065: Do not raise exceptions in unexpected locations
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class CSharpDoNotRaiseExceptionsInUnexpectedLocationsAnalyzer : DoNotRaiseExceptionsInUnexpectedLocationsAnalyzer
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
