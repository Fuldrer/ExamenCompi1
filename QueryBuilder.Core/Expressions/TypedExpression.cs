using QueryBuilder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Core.Expressions
{
    public abstract class TypedExpression : Node
    {
        protected readonly CompilerType type;

        public Token Token { get; }

        public TypedExpression(CompilerType type, Token token)
        {
            Token = token;
            this.type = type;
        }

        public abstract CompilerType GetExpressionType();

        public abstract string GenerateCode();

    }
}
