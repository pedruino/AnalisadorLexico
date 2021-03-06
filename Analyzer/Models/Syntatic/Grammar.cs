﻿using Analyzer.DataTypes.Enums;
using System;
using System.Collections.Generic;

namespace Analyzer.Models.Syntatic
{
    class Grammar : Dictionary<Tuple<eToken, eToken>, Stack<eToken>>
    {
        private Tuple<eToken, eToken> _tuple;

        public Grammar()
        {
            this.CreateRuleStart();
            this.CreateRuleExpression();
            this.CreateRuleExpressionL();
            this.CreateRuleTerm();
            this.CreateRuleTermL();
            this.CreateRuleFator();
            this.CreateRuleFatorL();
            this.CreateRuleNumberL();
            this.CreateRuleEnd();
        }

        #region RULES
        private void CreateRuleEnd()
        {
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.Identifier).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.Attribution).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.OpenParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.CloseParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.Number).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.EndOfSentence, eToken.EndOfSentence).WithValues(eToken.Empty);
        }

        private void CreateRuleNumberL()
        {
            this.CreateUsingKeys(eToken.NumberL, eToken.Identifier).WithValues(eToken.Identifier);
            this.CreateUsingKeys(eToken.NumberL, eToken.Attribution).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.NumberL, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.NumberL, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.NumberL, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.NumberL, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.NumberL, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.NumberL, eToken.OpenParenthesis).WithValues(eToken.CloseParenthesis, eToken.Expression, eToken.OpenParenthesis);
            this.CreateUsingKeys(eToken.NumberL, eToken.CloseParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.NumberL, eToken.Number).WithValues(eToken.Number);
            this.CreateUsingKeys(eToken.NumberL, eToken.EndOfSentence).WithValues(eToken.Error);
        }

        private void CreateRuleFatorL()
        {
            this.CreateUsingKeys(eToken.FatorL, eToken.Identifier).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.FatorL, eToken.Attribution).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorAddition).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorSubtraction).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorMultiply).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorDivision).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.OperatorPower).WithValues(eToken.FatorL, eToken.NumberL, eToken.OperatorPower);
            this.CreateUsingKeys(eToken.FatorL, eToken.OpenParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.FatorL, eToken.CloseParenthesis).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.FatorL, eToken.Number).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.FatorL, eToken.EndOfSentence).WithValues(eToken.Empty);
        }

        private void CreateRuleFator()
        {
            this.CreateUsingKeys(eToken.Fator, eToken.Identifier).WithValues(eToken.FatorL, eToken.NumberL);
            this.CreateUsingKeys(eToken.Fator, eToken.Attribution).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.OpenParenthesis).WithValues(eToken.FatorL, eToken.NumberL);
            this.CreateUsingKeys(eToken.Fator, eToken.CloseParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Fator, eToken.Number).WithValues(eToken.FatorL, eToken.NumberL);
            this.CreateUsingKeys(eToken.Fator, eToken.EndOfSentence).WithValues(eToken.Error);
        }

        private void CreateRuleTermL()
        {
            this.CreateUsingKeys(eToken.TermL, eToken.Identifier).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.Attribution).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorAddition).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorSubtraction).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorMultiply).WithValues(eToken.TermL, eToken.Fator, eToken.OperatorMultiply);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorDivision).WithValues(eToken.TermL, eToken.Fator, eToken.OperatorDivision);
            this.CreateUsingKeys(eToken.TermL, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.OpenParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.CloseParenthesis).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.TermL, eToken.Number).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.TermL, eToken.EndOfSentence).WithValues(eToken.Empty);
        }

        private void CreateRuleTerm()
        {
            this.CreateUsingKeys(eToken.Term, eToken.Identifier).WithValues(eToken.TermL, eToken.Fator);
            this.CreateUsingKeys(eToken.Term, eToken.Attribution).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.OpenParenthesis).WithValues(eToken.TermL, eToken.Fator);
            this.CreateUsingKeys(eToken.Term, eToken.CloseParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Term, eToken.Number).WithValues(eToken.TermL, eToken.Fator);
            this.CreateUsingKeys(eToken.Term, eToken.EndOfSentence).WithValues(eToken.Empty);
        }

        private void CreateRuleExpressionL()
        {
            this.CreateUsingKeys(eToken.ExpressionL, eToken.Identifier).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.Attribution).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorAddition).WithValues(eToken.ExpressionL, eToken.Term, eToken.OperatorAddition);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorSubtraction).WithValues(eToken.ExpressionL, eToken.Term, eToken.OperatorSubtraction);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.OpenParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.CloseParenthesis).WithValues(eToken.Empty);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.Number).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.ExpressionL, eToken.EndOfSentence).WithValues(eToken.Empty);
        }

        private void CreateRuleExpression()
        {
            this.CreateUsingKeys(eToken.Expression, eToken.Identifier).WithValues(eToken.ExpressionL, eToken.Term);
            this.CreateUsingKeys(eToken.Expression, eToken.Attribution).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.OpenParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.CloseParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.Expression, eToken.Number).WithValues(eToken.ExpressionL, eToken.Term);
            this.CreateUsingKeys(eToken.Expression, eToken.EndOfSentence).WithValues(eToken.Error);
        }

        private void CreateRuleStart()
        {
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.Identifier).WithValues(eToken.Expression, eToken.Attribution, eToken.Identifier);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.Attribution).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.OperatorAddition).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.OperatorSubtraction).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.OperatorMultiply).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.OperatorDivision).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.OperatorPower).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.OpenParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.CloseParenthesis).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.Number).WithValues(eToken.Error);
            this.CreateUsingKeys(eToken.StartOfSentence, eToken.EndOfSentence).WithValues(eToken.Error);
        } 
        #endregion

        private Grammar WithValues(params eToken[] tokensArray)
        {
            this.Add(this._tuple, new Stack<eToken>(tokensArray));
            return this;
        }
        private Grammar CreateUsingKeys(eToken key1, eToken key2)
        {
            this._tuple = Tuple.Create(key1, key2);
            return this;
        }

        public Stack<eToken> FindByKey(eToken expectedToken, eToken readToken)
        {
            return this[Tuple.Create(expectedToken, readToken)];
        }
    }
}
