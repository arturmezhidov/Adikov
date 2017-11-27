﻿namespace Adikov.Domain.Criterion
{
    public class IdCriterion : ICriterion
    {
        public object Id { get; }

        public IdCriterion(object id)
        {
            Id = id;
        }
    }
}