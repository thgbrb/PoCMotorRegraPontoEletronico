﻿using System;
using System.Linq.Expressions;
using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto
{
    public abstract class Specification<T>
    {
        protected abstract Func<Registro, Resultado> ExpressionDefinition();

        public Resultado IsSatisfyBy(Registro registro)
        {
            var predicate = ExpressionDefinition();
            return predicate(registro);
        }
    }
}