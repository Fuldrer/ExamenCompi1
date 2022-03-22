using QueryBuilder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Core.Expressions
{
    public abstract class BinaryExpression : TypedExpression
    {
        public TypedExpression LeftExpression { get; }

        public TypedExpression RightExpression { get; }

        public BinaryExpression(Token token, TypedExpression leftExpression, TypedExpression rightExpression, CompilerType type)
            : base(type, token)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }
    }
}
