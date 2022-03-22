using QueryBuilder.Core.Enums;
using QueryBuilder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Core.Expressions
{
    public class ArithmeticExpression : BinaryExpression
    {
        private readonly Dictionary<(CompilerType, CompilerType, TokenType), CompilerType> _typeRules;

        public ArithmeticExpression(Token token, TypedExpression leftExpression, TypedExpression rightExpression)
            : base(token, leftExpression, rightExpression, null)
        {
            _typeRules = new Dictionary<(CompilerType, CompilerType, TokenType), CompilerType>
            {
                { (CompilerType.Number, CompilerType.Number, TokenType.Plus), CompilerType.Number },
                { (CompilerType.Number, CompilerType.Number, TokenType.Minus), CompilerType.Number },
                { (CompilerType.Number, CompilerType.Number, TokenType.Multiplication), CompilerType.Number },
                { (CompilerType.Number, CompilerType.Number, TokenType.Division), CompilerType.Number },
                { (CompilerType.Float, CompilerType.Float, TokenType.Plus), CompilerType.Float },
                { (CompilerType.Float, CompilerType.Float, TokenType.Minus), CompilerType.Float },
                { (CompilerType.Float, CompilerType.Float, TokenType.Multiplication), CompilerType.Float },
                { (CompilerType.Float, CompilerType.Float, TokenType.Division), CompilerType.Float },
                { (CompilerType.Float, CompilerType.Number, TokenType.Plus), CompilerType.Float },
                { (CompilerType.Float, CompilerType.Number, TokenType.Minus), CompilerType.Float },
                { (CompilerType.Float, CompilerType.Number, TokenType.Multiplication), CompilerType.Float },
                { (CompilerType.Float, CompilerType.Number, TokenType.Division), CompilerType.Float },
                { (CompilerType.Number, CompilerType.String, TokenType.Plus), CompilerType.String },
                { (CompilerType.String, CompilerType.Number, TokenType.Plus), CompilerType.String },
                { (CompilerType.String, CompilerType.String, TokenType.Plus), CompilerType.String }
            };
        }

        public override string GenerateCode()
        {
            return $"{this.LeftExpression.GenerateCode()} {this.Token.Lexeme} {this.RightExpression.GenerateCode()}";
        }

        public override CompilerType GetExpressionType()
        {
            var leftType = LeftExpression.GetExpressionType();
            var rightType = RightExpression.GetExpressionType();
            if (_typeRules.TryGetValue((leftType, rightType, Token.TokenType), out var resultType))
            {
                return resultType;
            }

            throw new System.ApplicationException($"Cannot perform {Token.Lexeme} operation on types {leftType} and {rightType}");
        }
    }
}
