﻿using JECS.Abstractions;
using System;

namespace JECS.ParsingLogic
{
    /// <summary>
    /// Represents a line of text in a JECS file that contains data addressed by key.
    /// </summary>
    internal class KeyNode : Node
    {
        public KeyNode(string rawText, ReadableDataFile file) : base(rawText, file) { }
        public KeyNode(int indentation, string key, ReadableDataFile file) : base(indentation, file)
        {
            if (!Utilities.IsValidKey(key, out string whyNot))
                throw new FormatException(whyNot);

            RawText += key + ":";
        }

        public string Key
        {
            get
            {
                var text = GetDataText();
                int ColonIndex = GetColonIndex(text);

                text = text.Substring(0, ColonIndex);
                text = text.TrimEnd(); // remove trailing spaces
                return text;
            }
        }

        public override string Value
        {
            get
            {
                var text = GetDataText();
                int ColonIndex = GetColonIndex(text);

                text = text.Substring(ColonIndex + 1);
                text = text.TrimStart();
                return text;
                // note that trailing spaces are already trimmed in GetDataText()
            }
            set
            {
                if (this.StyleNotYetApplied)
                {
                    SetDataText(Key + ":".AddSpaces(Style.SpacesAfterColon) + value);
                    this.StyleNotYetApplied = false;
                    return;
                }

                var text = GetDataText();
                int colonIndex = GetColonIndex(text);

                string afterColon = text.Substring(colonIndex + 1);
                int spacesAfterColon = afterColon.GetIndentationLevel();

                SetDataText(
                    text.Substring(startIndex: 0, length: colonIndex + spacesAfterColon + 1) + value
                );
            }
        }

        private int GetColonIndex(string text)
        {
            int ColonIndex = text.IndexOf(':');

            if (ColonIndex < 0)
                throw new FormatException("Key node comprised of the following text: " + RawText + " did not contain the character ':'");
            return ColonIndex;
        }
    }
}
