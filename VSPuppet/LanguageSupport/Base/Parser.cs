// --------------------------------------------------------------------------
//     Copyright (c) Microsoft Open Technologies, Inc.
//     All Rights Reserved. Licensed under the Apache 2.0 License.
// --------------------------------------------------------------------------
namespace Puppet.Parser
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.Package;
    using Microsoft.VisualStudio.TextManager.Interop;

    public partial class Parser
    {
        public void MBWInit(ParseRequest request)
        {
            this.request = request;
            braces = new List<TextSpan[]>();
        }

        ParseRequest request;
        IList<TextSpan[]> braces;

        public IList<TextSpan[]> Braces
        {
            get { return this.braces; }
        }

        public ParseRequest Request
        {
            get { return this.request; }
        }

        public AuthoringSink Sink
        {
            get { return this.request.Sink; }
        }

        // brace matching, pairs and triples
        public void DefineMatch(int priority, params TextSpan[] locations)
        {            
            if (locations.Length == 2)
                braces.Add(new TextSpan[] { locations[0], 
                    locations[1]});

            else if (locations.Length >= 3)
                braces.Add(new TextSpan[] { locations[0], 
                    locations[1],
                    locations[2]});
        }

        public void DefineMatch(params TextSpan[] locations)
        {
            DefineMatch(0, locations);
        }

        // hidden regions - not working?
        public void DefineRegion(TextSpan span)
        {
            Sink.AddHiddenRegion(span);
        }

        // auto hidden?
        // public void DefineHiddenRegion
        // etc. see NewHiddenRegion structure


        // error reporting
        public void ReportError(TextSpan span, string message, Severity severity)
        {
            Sink.AddError(request.FileName, message, span, severity);
        }

        #region Error Overloads (Severity)
        public void ReportError(TextSpan location, string message)
        {
            ReportError(location, message, Severity.Error);
        }

        public void ReportFatal(TextSpan location, string message)
        {
            ReportError(location, message, Severity.Fatal);
        }

        public void ReportWarning(TextSpan location, string message)
        {
            ReportError(location, message, Severity.Warning);
        }

        public void ReportHint(TextSpan location, string message)
        {
            ReportError(location, message, Severity.Hint);
        }
        #endregion

        #region TextSpan Conversion
        public TextSpan TextSpan(int startLine, int startIndex, int endIndex)
        {
            return TextSpan(startLine, startIndex, startLine, endIndex);
        }

        public TextSpan TextSpan(int startLine, int startIndex, int endLine, int endIndex)
        {
            TextSpan ts;
            ts.iStartLine = startLine - 1;
            ts.iStartIndex = startIndex;
            ts.iEndLine = endLine - 1;
            ts.iEndIndex = endIndex;
            return ts;
        }
        #endregion
    }
}