using Syph.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Engine
{
    class Command : ICommand
    {
        private const char SplitBySpace = ' ';
        private string nameOfMove;
        private List<string> parameters;

        public Command(string input)
        {
            this.Parameters = new List<string>();
            this.TranslateInput(input);
        }

        public string NameOfMove
        {
            get
            {
                return this.nameOfMove;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {

                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.nameOfMove = value;
            }
        }

        public List<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of strings cannot be null.");
                }

                this.parameters = value;
            }
        }

        private void TranslateInput(string input)
        {
            var indexOfFirstSpace = input.IndexOf(SplitBySpace);
            //System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("{{.+(?=}})}}");

            if (indexOfFirstSpace < 0)
            {
                this.NameOfMove = input;
                return;
            }
            else
            {
                this.NameOfMove = input.Substring(0, indexOfFirstSpace);

                if (input.IndexOf(SplitBySpace) < 0)
                {
                    this.Parameters.Add(input.Substring(0).Trim());
                    input = string.Empty;
                }
                this.Parameters.AddRange(input.Remove(0, indexOfFirstSpace).Split(SplitBySpace, StringSplitOptions.RemoveEmptyEntries));

            }
        }

    }
}