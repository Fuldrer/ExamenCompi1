using QueryBuilder.Core.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Core.Expressions
{
    public class SequenceStatement : Statement
    {
        public SequenceStatement(Statement firstStatement, Statement nextStatement)
        {
            FirstStatement = firstStatement;
            NextStatement = nextStatement;
            this.ValidateSemantic();
        }

        public Statement FirstStatement { get; }
        public Statement NextStatement { get; }

        public override string GenerateCode()
        {
            return $"{this.FirstStatement?.GenerateCode()}{System.Environment.NewLine}{this.NextStatement?.GenerateCode()}";
        }

        public override void ValidateSemantic()
        {
            this.FirstStatement?.ValidateSemantic();
            this.NextStatement?.ValidateSemantic();
        }
    }
}
