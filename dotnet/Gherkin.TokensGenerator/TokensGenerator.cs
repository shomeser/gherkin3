﻿using System;
using System.IO;
using System.Linq;

namespace Gherkin.TokensGenerator
{
    public class TokensGenerator
    {
        public static string GenerateTokens(string featureFilePath)
        {
            var parser = new Parser<object>();
            var tokenFormatterBuilder = new TokenFormatterBuilder();
            using (var reader = new StreamReader(featureFilePath))
                parser.Parse(new TokenScanner(reader), new TokenMatcher(), tokenFormatterBuilder);

            var tokensText = tokenFormatterBuilder.GetTokensText();

            return NormalizeLineEndings(tokensText);
        }

        public static string NormalizeLineEndings(string text)
        {
            return text.Replace("\r\n", "\n").TrimEnd('\n');
        }
    }
}
